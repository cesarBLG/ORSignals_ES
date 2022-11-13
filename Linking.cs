using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
	public class ETCS_LINKING : PaqueteETCS
	{
        public override void UpdatePacket()
        {
            Packet = get_linking();
        }
    }
}
