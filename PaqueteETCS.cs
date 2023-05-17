using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
	public abstract class PaqueteETCS : ETCS
    {
        protected int Reaction = 2;
        protected string Packet="";
        bool prevRouteSet;
        public override void Initialize()
        {
            SharedVariables[KeyBaliseReaction] = Reaction;
        }
        public override void Update()
        {
            SharedVariables[KeyNextEurobaliseID] = NextSignalId("ETCS", 0);
            bool rs = RouteSet;
            if (rs) TextSignalAspect = Packet;
            else TextSignalAspect = "";
            if (prevRouteSet != rs) SharedVariables[KeyPacketNeedsUpdate] = 1;
            prevRouteSet = rs;
        }
        public virtual void UpdatePacket() 
        {
            SharedVariables[KeyPacketNeedsUpdate] = 0;
            Update();
        }
        public override void HandleSignalMessage(int id, string msg)
        {
            if (msg == "UPDATE_PACKET") UpdatePacket();
        }
    }
}
