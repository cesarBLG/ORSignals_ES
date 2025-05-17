using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
	public class ETCS_CFG : ETCS
    {
        public override void Initialize()
        {
            base.Initialize();
            NID_C = ETCS.DefaultNID_C;
            LoadParameter("NID_C", SignalTypeName.Substring(0), ref NID_C);
            SharedVariables[0] = NID_C;
            SharedVariables[1] = -2;
        }
        public override void Update()
        {
            if (SharedVariables[1] == -2) SharedVariables[1] = NextSignalId("NORMAL");
        }
    }
}
