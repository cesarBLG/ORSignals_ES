using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
	public class VELOCIDADLINK : CsSignalScript
	{
		public override void Initialize()
		{
            int velocidad = 0;
            int bit = 5;
            for (int i=1; i<10; i++)
            {
                if (HasHead(i)) velocidad += bit;
                bit *= 2;
            }
            SetSpeedLimit(velocidad/3.6f, velocidad/3.6f, false, false, false, false);
		}

		public override void Update()
		{
            if (RouteSet)
            {
                MstsSignalAspect = Aspect.Clear_2;
                SpeedLimitSetByScript = true;
            }
            else
            {
                MstsSignalAspect = Aspect.Approach_1;
                SpeedLimitSetByScript = false;
            }
            DrawState = DefaultDrawState(MstsSignalAspect);
		}
	}
}
