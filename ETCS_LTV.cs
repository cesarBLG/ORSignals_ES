using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ORTS.Scripting.Script
{
	public class ETCS_LTV_DESVIOS : PaqueteETCS
    {
        int SignalId=-1;
        Aspecto aspecto;
        public ETCS_LTV_DESVIOS()
        {
            Reaction = 1;
        }
        public override void Update()
        {
            if (SignalId < 0) SignalId = NextSignalId("NORMAL");
            Aspecto nuevo = GetAspectoSenal(SignalId);
            if (nuevo != aspecto)
            {
                SharedVariables[KeyPacketNeedsUpdate] = 1;
                aspecto = nuevo;
            }
            base.Update();
        }
        public override void UpdatePacket()
        {
            double dist=0;
            for (int i=0; i<5; i++)
            {
                if (HasHead(i+1)) dist += (1<<i)*50;
            }
            if (dist == 0) dist = 300;
            string ltv = "01"+format_binary(255,8)+format_etcs_distance(0)+format_etcs_distance(dist)+"0"+format_etcs_speedKpH(30);
            if (aspecto == Aspecto.Parada) Packet = create_packet(65, ltv, 1);
            else Packet = "";
            base.UpdatePacket();
        }
    }
}
