using ORTS.Scripting.Api;
using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace ORTS.Scripting.Script
{
    public class SP4MD : CommonSignalScript
    {
        bool siguienteEsRetroceso;
        Aspecto AspectoEstaSeñal;
        Aspecto previoAspectoEstaSeñal;
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
            base.Initialize();
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
            
            bool callOn = (IdSignalLocalVariable(NextSignalId("NORMAL"), KEY_VARIABLE_COMPARTIDA_REBASE) == 1 && CurrentBlockState == BlockState.Clear) || (CurrentBlockState == BlockState.Occupied && TrainHasCallOn(false, true));
            if (CurrentBlockState == BlockState.Obstructed || !Enabled || HoldState == HoldState.ManualLock)
            {
                AspectoEstaSeñal = Aspecto.Parada;
                absoluta = true;
                maniobra = false;
            }
            else if (siguienteEsRetroceso && (IdSignalAspect(idSigSeñal, "NORMAL") == Aspect.Stop || IdTextSignalAspect(idSigSeñal, "NORMAL") == "Parada"))
            {
                /*if (TrainRequiresSignal(idSigSeñal, 0)) AspectoEstaSeñal = Aspecto.Parada;
                else AspectoEstaSeñal = Aspecto.RebaseAutorizado;*/
                AspectoEstaSeñal = Aspecto.Parada;
                //absoluta = true;
            }
            else if (maniobra || HoldState == HoldState.ManualApproach || (siguienteEsRetroceso && IdTextSignalAspect(idSigSeñal, "NORMAL") == "RebaseAutorizado"))
            {
                AspectoEstaSeñal = Aspecto.RebaseAutorizado;
            }
            else if (forzarParada)
            {
                AspectoEstaSeñal = Aspecto.Parada;
            }
            else if (CurrentBlockState == BlockState.Occupied && !callOn)
            {
                AspectoEstaSeñal = Aspecto.Parada;
                absoluta = true;
            }
            else
            {
                if (movimientoAutorizado) AspectoEstaSeñal = Aspecto.MovimientoAutorizado;
                else if (desviada || !RouteSet) AspectoEstaSeñal = Aspecto.IndicadoraDesviada;
                else AspectoEstaSeñal = Aspecto.IndicadoraDirecta;
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
                case Aspecto.Parada:
                    if (!absoluta) MstsSignalAspect = Aspect.Restricting;
                    else MstsSignalAspect = Aspect.Stop;
                    DrawState = DefaultDrawState(Aspect.Stop);
                    break;
                case Aspecto.RebaseAutorizado:
                    MstsSignalAspect = Aspect.StopAndProceed;
                    DrawState = DefaultDrawState(Aspect.StopAndProceed);
                    break;
                case Aspecto.IndicadoraDesviada:
                    MstsSignalAspect = (Aspect)8;
                    DrawState = DefaultDrawState(Aspect.Approach_2);
                    break;
                case Aspecto.MovimientoAutorizado:
                case Aspecto.IndicadoraDirecta:
                    MstsSignalAspect = (Aspect)8;
                    DrawState = DefaultDrawState(Aspect.Clear_2);
                    break;
            }
            TextSignalAspect = aspectoATexto[AspectoEstaSeñal];
            SharedVariables[KEY_VARIABLE_COMPARTIDA_TIPO_SEÑAL] = (int)TipoSeñal.Retroceso;
            SharedVariables[KEY_VARIABLE_COMPARTIDA_ESTADO_CANTON] = Math.Max((int)CurrentBlockState, IdSignalLocalVariable(NextSignalId("NORMAL"), KEY_VARIABLE_COMPARTIDA_ESTADO_CANTON));
            var informacionDeRutaMSTS = DistMultiSigMR("OPREANUNCIO", "NORMAL", false);
            if (informacionDeRutaMSTS == Aspect.Stop) informacionDeRutaMSTS = (Aspect)IdSignalLocalVariable(NextSignalId("NORMAL"), KEY_VARIABLE_COMPARTIDA_INFO_RUTA);
            SharedVariables[KEY_VARIABLE_COMPARTIDA_INFO_RUTA] = (int)informacionDeRutaMSTS;
            SharedVariables[KEY_VARIABLE_COMPARTIDA_REBASE] = callOn ? 1 : 0;
            previoPrevioEstaPreparada = previoEstaPreparada;
            previoEstaPreparada = estaPreparada;
            SetSNCA();
        }
        public override void SetSNCA()
        {
            SharedVariables[KEY_VARIABLE_COMPARTIDA_PROXIMIDAD] = 0;
            SharedVariables[KEY_VARIABLE_COMPARTIDA_SNCA_DIFF] = 1;
            SharedVariables[KEY_VARIABLE_COMPARTIDA_SNCA] = IdSignalLocalVariable(NextSignalId("NORMAL"), KEY_VARIABLE_COMPARTIDA_SNCA) + 1;
            base.SetSNCA();
        }
		bool consultaFlag;
        bool FlagPresente(string tipo)
        {
            consultaFlag = false;
            if (siguienteEsRetroceso) EnviarMensaje(NextSignalId("NORMAL"), "FLAG:"+tipo);
            return DistMultiSigMR(tipo, "NORMAL", false) == Aspect.Approach_1 || consultaFlag;
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
    }
}
