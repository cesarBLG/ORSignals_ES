using ORTS.Scripting.Api;
using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
    public class FLAG : CsSignalScript
    {
        int NextSignalId = -1;
        public override void Initialize()
        {
        }
        public override void Update()
        {
            if (NextSignalId >= 0) return;
            NextSignalId = NextSignalId("NORMAL");
            if (SignalTypeName == "olib" && NextSignalId >= 0)
            {
                SendSignalMessage(NextSignalId, "LIBERACION");
            }
            MstsSignalAspect = RouteSet ? Aspect.Approach_1 : Aspect.Clear_2;
            DrawState = DefaultDrawState(MstsSignalAspect);
        }
    }
}
