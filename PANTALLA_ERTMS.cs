using Orts.Simulation.Signalling;
using ORTS.Scripting.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
    public enum AspectoPantalla
    {
        Parada,
        ViaLibre
    }
	public class PANTALLA_ERTMS : CsSignalScript
    {
        AspectoPantalla AspectoEstaSeñal;
        AspectoPantalla previoAspectoEstaSeñal;
        Timer actualizarAspectoTimer;
        readonly int KEY_VARIABLE_COMPARTIDA_SISTEMAS_SEÑALIZACION = 200;
        public override void Initialize()
		{
            actualizarAspectoTimer = new Timer(this);
            actualizarAspectoTimer.Setup(1);
            
            SharedVariables[KEY_VARIABLE_COMPARTIDA_SISTEMAS_SEÑALIZACION] = (int)SistemaSeñalizacion.ETCS_N2;
		}
		public override void Update()
		{
            previoAspectoEstaSeñal = AspectoEstaSeñal;
            if (!Enabled || CurrentBlockState != BlockState.Clear)
            {
                AspectoEstaSeñal = AspectoPantalla.Parada;
            }
            else
            {
                AspectoEstaSeñal = AspectoPantalla.ViaLibre;
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
            if (AspectoEstaSeñal == AspectoPantalla.Parada)
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
            SharedVariables[201] = (int)TipoSeñal.Virtual;
            SharedVariables[801] = (int)BlockState.Clear;
            var informacionDeRutaMSTS = DistMultiSigMR("OPREANUNCIO", "NORMAL", false);
            if (informacionDeRutaMSTS == Aspect.Stop) informacionDeRutaMSTS = (Aspect)IdSignalLocalVariable(NextSignalId("NORMAL"), 802);
            SharedVariables[802] = (int)informacionDeRutaMSTS;
            bool callOn = (IdSignalLocalVariable(NextSignalId("NORMAL"), 803) == 1 && CurrentBlockState == BlockState.Clear) || (CurrentBlockState == BlockState.Occupied && TrainHasCallOn(false, true));
            SharedVariables[803] = callOn ? 1 : 0;

            SharedVariables[900] = 1;
            SignalNumClearAhead = IdSignalLocalVariable(NextSignalId("NORMAL"), 901) + 1;
            SharedVariables[901] = SignalNumClearAhead;
        }
    }
}
