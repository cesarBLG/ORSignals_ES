using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
	public class ETCS_VALORES_NACIONALES : PaqueteETCS
	{
        int NID_C=0;
        int V_SH = 40;
        int V_SR = 100;
        int V_OS = 30;
        int V_LS = 100;
        int V_UN = 200;
        int V_release = 15;
        int D_roll = 2;
        int V_allowoverride = 0;
        int V_override = 30;
        int D_override = 80;
        int T_override = 40;
        int D_posttrip = 50;
        public ETCS_VALORES_NACIONALES()
        {
            Reaction = 1;
        }
		public override void UpdatePacket()
		{
            if (NID_C == 364) //Madrid Cercanias
            {
                V_UN = 140;
                D_roll = 5;
            }
            else if (NID_C == 352 || NID_C == 353 || NID_C == 357) // Madrid-Barcelona-Frontera, Zaragoza-Huesca-Figueres, Madrid-Valladolid
            {
                V_UN = 200;
                D_roll = 2;
            }
            string data = "";
            data += "01";
            data += format_binary(32767, 15);
            if (NID_C == 352 || NID_C == 353 || NID_C == 357)
            {
                data += format_binary(352, 10);
                data += format_binary(2, 5);
                data += format_binary(353, 10);
                data += format_binary(357, 10);
            }
            else
            {
                data += format_binary(NID_C, 10);
                data += format_binary(0, 5);
            }
            data += format_etcs_speedKpH(V_SH);
            data += format_etcs_speedKpH(V_SR);
            data += format_etcs_speedKpH(V_OS);
            data += format_etcs_speedKpH(V_LS);
            data += format_etcs_speedKpH(V_UN);
            data += format_etcs_speedKpH(V_release);
            data += format_etcs_distance(D_roll);
            data += format_binary(1, 1);
            data += format_binary(0, 1);
            data += format_binary(0, 1);
            data += format_binary(0, 1);
            data += format_binary(0, 1);
            data += format_etcs_speedKpH(V_allowoverride);
            data += format_etcs_speedKpH(V_override);
            data += format_etcs_distance(D_override);
            data += format_binary(T_override, 8);
            data += format_etcs_distance(D_posttrip);
            data += format_binary(1, 2);
            data += format_binary(20, 8);
            data += format_binary(1, 1);
            data += format_binary(32767, 15);
            data += format_binary(0, 1);
            data += format_binary(20, 6);
            data += format_binary(14, 6);
            data += format_binary(14, 6);
            data += format_binary(12, 6);
            data += format_binary(0, 5);
            data += format_binary(9, 4);
            data += format_binary(0, 1);
            Packet = create_packet(3, data, 1);
            base.UpdatePacket();
		}
    }
}
