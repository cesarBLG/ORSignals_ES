using ORTS.Scripting.Api;
using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
    public class ETCS_PN : PaqueteETCS
    {
        Aspect aspect;
        public ETCS_PN()
        {
            Reaction = 1;
        }
        public override void Update()
        {
            var next_state = IdSignalAspect(NextSignalId("OLPN_T"), "OLPN_T");
            if (next_state != aspect) SharedVariables[KeyPacketNeedsUpdate] = 1;
            aspect = next_state;
            base.Update();
        }
        public override void UpdatePacket()
        {
            int id = NextSignalId("OLPN_T");
            string pack = "01"+format_binary(id&127,8)+"{NextSignalDistanceM(OLPN_T,0)-45-(bgref)}"+format_etcs_distance(20);
            var next_state = IdSignalAspect(id, "OLPN_T");
            if (next_state == Aspect.Approach_2 || next_state == Aspect.Clear_2) pack += "0";
            else
            {
                pack += "1"+format_etcs_speedKpH(10)+"1"+format_etcs_distance(50);
            }
            Packet = create_packet(88, pack, 1);
            base.UpdatePacket();
        }
    }
    public class ETCS_MSG_PN : PaqueteETCS
    {
        public override void UpdatePacket()
        {
            string txt = "Aproximación a Paso a Nivel";
            byte[] ascii = System.Text.Encoding.GetEncoding(28591).GetBytes(txt); 
            string packet = "01" + format_binary(1,2) + "0" + format_etcs_distance(0) + format_binary(15,4) + format_binary(5,3) + "{NextSignalDistanceM(OLPN_T,0)-(bgref)}" + format_binary(1023,10) + format_binary(15,4) + format_binary(5,3) + format_binary(0,2) + format_binary(ascii.Length, 8);   
            for (int i=0; i<ascii.Length; i++)
            {
                packet += format_binary((int)ascii[i],8);
            }
            Packet = create_packet(72,packet,1);
            base.UpdatePacket();
        }
    }
}
