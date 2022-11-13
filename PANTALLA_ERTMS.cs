using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
	public class PANTALLA_ERTMS : CsSignalScript
    {
        public override void Initialize()
		{
		}
		public override void Update()
		{
            if (!Enabled || CurrentBlockState != BlockState.Clear)
            {
                SignalNumClearAhead = -1;
                MstsSignalAspect = Aspect.Stop;
                TextSignalAspect = "Parada";
            }
            else
            {
                MstsSignalAspect = (Aspect)8;
                TextSignalAspect = "ParadaSelectiva";
                SetSNCA();
            }
            DrawState = DefaultDrawState(MstsSignalAspect);
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
                if (!IdSignalHasNormalSubtype(id, "PANTALLA_ERTMS"))
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
