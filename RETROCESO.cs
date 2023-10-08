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
            
            bool callOn = (IdSignalLocalVariable(NextSignalId("NORMAL"), 803) == 1 && CurrentBlockState == BlockState.Clear) || (CurrentBlockState == BlockState.Occupied && TrainHasCallOn(false, true));
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
            else if (maniobra || HoldState == HoldState.ManualApproach || (siguienteEsRetroceso && IdTextSignalAspect(idSigSeñal, "NORMAL") == "RebaseAutorizado"))
            {
                AspectoEstaSeñal = AspectoRetroceso.RebaseAutorizado;
            }
            else if (forzarParada)
            {
                AspectoEstaSeñal = AspectoRetroceso.Parada;
            }
            else if (CurrentBlockState == BlockState.Occupied && !callOn)
            {
                AspectoEstaSeñal = AspectoRetroceso.Parada;
            }
            else
            {
                if (movimientoAutorizado) AspectoEstaSeñal = AspectoRetroceso.MovimientoAutorizado;
                else if (desviada || !RouteSet) AspectoEstaSeñal = AspectoRetroceso.IndicadoraDesviada;
                else AspectoEstaSeñal = AspectoRetroceso.IndicadoraDirecta;
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
            SharedVariables[801] = Math.Max((int)CurrentBlockState, IdSignalLocalVariable(NextSignalId("NORMAL"), 801));
            var informacionDeRutaMSTS = DistMultiSigMR("OPREANUNCIO", "NORMAL", false);
            if (informacionDeRutaMSTS == Aspect.Stop) informacionDeRutaMSTS = (Aspect)IdSignalLocalVariable(NextSignalId("NORMAL"), 802);
            SharedVariables[802] = (int)informacionDeRutaMSTS;
            SharedVariables[803] = callOn ? 1 : 0;
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
