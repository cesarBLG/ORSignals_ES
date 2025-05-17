using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
	public class ETCS_MA : PaqueteETCS
    {
        int SenalAsociada = -1;
        bool Infill;
        public override void Update()
        {
            base.Update();
            if (SenalAsociada < 0)
            {
                SenalAsociada = NextSignalId("NORMAL");
            }
        }
        public override void UpdatePacket()
        {
            Packet = get_ma(SenalAsociada, Infill);
            base.UpdatePacket();
        }
    }
}
