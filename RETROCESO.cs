using ORTS.Scripting.Api;
using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace ORTS.Scripting.Script
{
    public enum AspectoRetroceso
    {
        Parada,
        RebaseAutorizado,
        MovimientoAutorizado,
        IndicadoraDesviada,
        IndicadoraDirecta,
    }
    public class SP4MD : CsSignalScript
    {
        bool siguienteEsRetroceso;
        AspectoRetroceso AspectoEstaSeñal;
        AspectoRetroceso previoAspectoEstaSeñal;
        bool forzarParada;
        bool desviada;
        bool maniobra;
        bool estaPreparada;
        bool previoEstaPreparada;
        bool previoPrevioEstaPreparada;
        int idSigSeñal = -1;
        int previoIdSigSeñal = -1;
        bool movimientoAutorizado = false;
        Timer actualizarAspectoTimer;
        public override void Initialize()
        {
            if (SignalTypeName == "sp2rb") movimientoAutorizado = true;
            actualizarAspectoTimer = new Timer(this);
            actualizarAspectoTimer.Setup(1);
        }
        public override void Update()
        {
            previoAspectoEstaSeñal = AspectoEstaSeñal;
            idSigSeñal = NextSignalId("NORMAL");
            estaPreparada = Enabled;
            siguienteEsRetroceso = idSigSeñal >= 0 && IdSignalHasNormalSubtype(idSigSeñal, "RETROCESO");
            if (previoIdSigSeñal != idSigSeñal || (estaPreparada && (!previoEstaPreparada || !previoPrevioEstaPreparada)))
            {
                desviada = FlagPresente("M_V_DESV");
                forzarParada = FlagPresente("F_PARADA");
            }
            bool absoluta = false;
            if (CurrentBlockState == BlockState.Obstructed || !Enabled || HoldState == HoldState.ManualLock)
            {
                AspectoEstaSeñal = AspectoRetroceso.Parada;
                absoluta = true;
                maniobra = false;
            }
            else if (siguienteEsRetroceso && (IdSignalAspect(idSigSeñal, "NORMAL") == Aspect.Stop || IdTextSignalAspect(idSigSeñal, "NORMAL") == "Parada"))
            {
                AspectoEstaSeñal = AspectoRetroceso.Parada;
            }
            else if (maniobra || TrainHasCallOn(false, true) || (siguienteEsRetroceso && IdTextSignalAspect(idSigSeñal, "NORMAL") == "RebaseAutorizado"))
            {
                AspectoEstaSeñal = AspectoRetroceso.RebaseAutorizado;
            }
            else if (forzarParada)
            {
                AspectoEstaSeñal = AspectoRetroceso.Parada;
            }
            else
            {
                BlockState state = RouteClearedToSignal(idSigSeñal, true);
                if (state == BlockState.Clear || state == BlockState.Occupied || HoldState == HoldState.ManualPass)
                {
                    if (movimientoAutorizado) AspectoEstaSeñal = AspectoRetroceso.MovimientoAutorizado;
                    else if (desviada || !RouteSet) AspectoEstaSeñal = AspectoRetroceso.IndicadoraDesviada;
                    else AspectoEstaSeñal = AspectoRetroceso.IndicadoraDirecta;
                }
                else AspectoEstaSeñal = AspectoRetroceso.Parada;
            }
            if (!PreUpdate())
            {
                if (AspectoEstaSeñal != previoAspectoEstaSeñal)
                {
                    if (!actualizarAspectoTimer.Started) actualizarAspectoTimer.Start();
                    if (!actualizarAspectoTimer.Triggered) AspectoEstaSeñal = previoAspectoEstaSeñal;
                }
                else if (actualizarAspectoTimer.Started)
                {
                    actualizarAspectoTimer.Stop();
                }
            }
            switch (AspectoEstaSeñal)
            {
                case AspectoRetroceso.Parada:
                    if (!absoluta) MstsSignalAspect = Aspect.Restricting;
                    else MstsSignalAspect = Aspect.Stop;
                    DrawState = DefaultDrawState(Aspect.Stop);
                    break;
                case AspectoRetroceso.RebaseAutorizado:
                    MstsSignalAspect = Aspect.StopAndProceed;
                    DrawState = DefaultDrawState(Aspect.StopAndProceed);
                    break;
                case AspectoRetroceso.IndicadoraDesviada:
                    MstsSignalAspect = (Aspect)8;
                    DrawState = DefaultDrawState(Aspect.Approach_2);
                    break;
                case AspectoRetroceso.MovimientoAutorizado:
                case AspectoRetroceso.IndicadoraDirecta:
                    MstsSignalAspect = (Aspect)8;
                    DrawState = DefaultDrawState(Aspect.Clear_2);
                    break;
            }
            TextSignalAspect = AspectoEstaSeñal.ToString();
            SharedVariables[801] = (int)CurrentBlockState;
            SharedVariables[802] = (int)DistMultiSigMR("OPREANUNCIO", "NORMAL", false);
            if (siguienteEsRetroceso)
            {
                BlockState bs = (BlockState)IdSignalLocalVariable(idSigSeñal, 801);
                Aspect opap = (Aspect)IdSignalLocalVariable(idSigSeñal, 802);
                if (bs > CurrentBlockState) SharedVariables[801] = (int)bs;
                if (opap != Aspect.Stop) SharedVariables[802] = (int)opap;
            }
            previoPrevioEstaPreparada = previoEstaPreparada;
            previoEstaPreparada = estaPreparada;
            SetSNCA();
        }
		bool consultaFlag;
        bool FlagPresente(string tipo)
        {
            consultaFlag = false;
            if (siguienteEsRetroceso) EnviarMensaje(NextSignalId("NORMAL"), "FLAG:"+tipo);
            return DistMultiSigMR(tipo, "NORMAL", false) == Aspect.Clear_2 || consultaFlag;
        }
        void EnviarMensaje(int id, string message)
        {
            if (id >= 0) SendSignalMessage(id, message);
        }
        public override void HandleSignalMessage(int id, string message)
        {
            if (message == "FLAG:true") consultaFlag = true;
            else if (message == "FLAG:false") consultaFlag = false;
            else if (message.StartsWith("FLAG:"))
            {
                string flag = message.Substring(5);
                SendSignalMessage(id, "FLAG:"+(FlagPresente(flag) ? "true" : "false"));
            }
        }
        int SNCAcount = 0;
        public void SetSNCA()
        {
            if (SNCAcount++ < 10) return;
            SNCAcount = 0;
            int nsig = 0;
            for (int i=0; i<20; i++)
            {
                int id = NextSignalId("NORMAL", i);
                if (id < 0 || i == 19)
                {
                    SignalNumClearAhead = i+2;
                    return;
                }
                if (!IdSignalHasNormalSubtype(id, "PANTALLA_ERTMS") && !IdSignalHasNormalSubtype(id, "RETROCESO"))
                {
                    nsig++;
                    if (nsig == 3)
                    {
                        SignalNumClearAhead = i+1;
                        break;
                    }
                }
            }
        }
    }
}
