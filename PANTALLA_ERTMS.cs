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
                SignalNumClearAhead = -1;
            }
            else
            {
                AspectoEstaSeñal = AspectoPantalla.ViaLibre;
                SetSNCA();
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
            SharedVariables[801] = (int)BlockState.Clear;
            var informacionDeRutaMSTS = DistMultiSigMR("OPREANUNCIO", "NORMAL", false);
            if (informacionDeRutaMSTS == Aspect.Stop) informacionDeRutaMSTS = (Aspect)IdSignalLocalVariable(NextSignalId("NORMAL"), 802);
            SharedVariables[802] = (int)informacionDeRutaMSTS;
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
