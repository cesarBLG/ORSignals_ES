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
        public ETCS_VALORES_NACIONALES()
        {
            Reaction = 1;
        }
        T GetParameter<T>(string nvset, string param, T defaultValue)
        {
            T val = defaultValue;
            if (nvset != null) LoadParameter(nvset, param, ref val);
            return val;
        }
		public override void UpdatePacket()
		{
            string nvset = null;
            LoadParameter(string.Format("NID_C.{0}", NID_C), "NV", ref nvset);
            List<int> nid_cs = GetParameter(nvset, "NID_Cs", "").Split(',').Select(int.Parse).ToList();
            nid_cs.Remove(NID_C);
            string data = "";
            data += "01";
            data += format_binary(32767, 15);
            data += format_binary(NID_C, 10);
            data += format_binary(nid_cs.Count ,5);
            foreach (int nid in nid_cs)
            {
                data += format_binary(nid, 10);
            }
            data += format_etcs_speedKpH(GetParameter(nvset, "V_NVSHUNT", 30));
            data += format_etcs_speedKpH(GetParameter(nvset, "V_NVSTFF", 40));
            data += format_etcs_speedKpH(GetParameter(nvset, "V_NVONSIGHT", 30));
            data += format_etcs_speedKpH(GetParameter(nvset, "V_NVLIMSUPERV", 100));
            data += format_etcs_speedKpH(GetParameter(nvset, "V_NVUNFIT", 100));
            data += format_etcs_speedKpH(GetParameter(nvset, "V_NVREL", 40));
            data += format_etcs_distance(GetParameter(nvset, "D_NVROLL", 2));
            data += format_binary(GetParameter(nvset, "Q_NVSBTSMPERM", true) ? 1 : 0, 1);
            data += format_binary(GetParameter(nvset, "Q_NVEMRRLS", false) ? 1 : 0, 1);
            data += format_binary(GetParameter(nvset, "Q_NVGUIPERM", false) ? 1 : 0, 1);
            data += format_binary(GetParameter(nvset, "Q_NVSBFBPERM", false) ? 1 : 0, 1);
            data += format_binary(GetParameter(nvset, "Q_NVINHSMICPERM", false) ? 1 : 0, 1);
            data += format_etcs_speedKpH(GetParameter(nvset, "V_NVALLOWOVTRP", 0));
            data += format_etcs_speedKpH(GetParameter(nvset, "V_NVSUPOVTRP", 30));
            data += format_etcs_distance(GetParameter(nvset, "D_NVOVTRP", 200));
            data += format_binary(GetParameter(nvset, "T_NVOVTRP", 60), 8);
            data += format_etcs_distance(GetParameter(nvset, "D_NVPOTRP", 200));
            data += format_binary(GetParameter(nvset, "M_NVCONTACT", 1), 2);
            data += format_binary(GetParameter(nvset, "T_NVCONTACT", 255), 8);
            data += format_binary(GetParameter(nvset, "M_NVDERUN", 1), 1);
            data += format_etcs_distance(GetParameter(nvset, "D_NVSTFF", 32767));
            data += format_binary(GetParameter(nvset, "Q_NVDRIVER_ADHES", false) ? 1 : 0, 1);
            data += format_binary(GetParameter(nvset, "A_NVMAXREDADH1", 20), 6);
            data += format_binary(GetParameter(nvset, "A_NVMAXREDADH2", 14), 6);
            data += format_binary(GetParameter(nvset, "A_NVMAXREDADH3", 14), 6);
            data += format_binary(GetParameter(nvset, "Q_NVLOCACC", 12), 6);
            data += format_binary(GetParameter(nvset, "M_NVAVADH", 0), 5);
            data += format_binary(GetParameter(nvset, "M_NVEBCL", 9), 4);
            data += format_binary(0, 1);
            Packet = create_packet(3, data, 1);
            base.UpdatePacket();
		}
    }
}
