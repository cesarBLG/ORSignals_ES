using Orts.Simulation.Signalling;
using ORTS.Scripting.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
	public class PANTALLA_ERTMS : CommonSignalScript
    {
        Aspecto AspectoEstaSeñal;
        Aspecto previoAspectoEstaSeñal;
        Timer actualizarAspectoTimer;
        public override void Initialize()
		{
            actualizarAspectoTimer = new Timer(this);
            actualizarAspectoTimer.Setup(1);
            
            SharedVariables[KEY_VARIABLE_COMPARTIDA_SISTEMAS_SEÑALIZACION] = (int)SistemaSeñalizacion.ETCS_N2;
		}
		public override void Update()
        {
            base.Initialize();
            previoAspectoEstaSeñal = AspectoEstaSeñal;
            if (!Enabled || CurrentBlockState != BlockState.Clear)
            {
                AspectoEstaSeñal = Aspecto.Parada;
            }
            else
            {
                AspectoEstaSeñal = Aspecto.ViaLibre;
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
            if (AspectoEstaSeñal == Aspecto.Parada)
            {
                MstsSignalAspect = Aspect.Stop;
                TextSignalAspect = "Parada";
            }
            else
            {
                //MstsSignalAspect = (Aspect)8;
                MstsSignalAspect = Aspect.Clear_2;
                TextSignalAspect = "ViaLibre";
            }
            DrawState = DefaultDrawState(MstsSignalAspect);
            SharedVariables[KEY_VARIABLE_COMPARTIDA_TIPO_SEÑAL] = (int)TipoSeñal.Virtual;
            SharedVariables[KEY_VARIABLE_COMPARTIDA_ESTADO_CANTON] = (int)BlockState.Clear;
            var informacionDeRutaMSTS = DistMultiSigMR("OPREANUNCIO", "NORMAL", false);
            if (informacionDeRutaMSTS == Aspect.Stop) informacionDeRutaMSTS = (Aspect)IdSignalLocalVariable(NextSignalId("NORMAL"), KEY_VARIABLE_COMPARTIDA_INFO_RUTA);
            SharedVariables[KEY_VARIABLE_COMPARTIDA_INFO_RUTA] = (int)informacionDeRutaMSTS;
            bool callOn = (IdSignalLocalVariable(NextSignalId("NORMAL"), KEY_VARIABLE_COMPARTIDA_REBASE) == 1 && CurrentBlockState == BlockState.Clear) || (CurrentBlockState == BlockState.Occupied && TrainHasCallOn(false, true));
            SharedVariables[KEY_VARIABLE_COMPARTIDA_REBASE] = callOn ? 1 : 0;

            SharedVariables[KEY_VARIABLE_COMPARTIDA_SNCA_DIFF] = 1;
            SignalNumClearAhead = IdSignalLocalVariable(NextSignalId("NORMAL"), KEY_VARIABLE_COMPARTIDA_SNCA) + 1;
            SharedVariables[KEY_VARIABLE_COMPARTIDA_SNCA] = SignalNumClearAhead;
        }
    }
}
