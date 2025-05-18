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

    public class ETCS_LTV_DESVIOS : PaqueteETCS
    {
        int SignalId = -1;
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
            double dist = 0;
            for (int i = 0; i < 5; i++)
            {
                if (HasHead(i + 1)) dist += (1 << i) * 50;
            }
            if (dist == 0) dist = 300;
            string ltv = "01" + format_binary(255, 8) + format_etcs_distance(0) + format_etcs_distance(dist) + "0" + format_etcs_speedKpH(30);
            if (aspecto == Aspecto.Parada) Packet = create_packet(65, ltv, 1);
            else Packet = "";
            base.UpdatePacket();
        }
    }

    public class ETCS_LEVELTR : PaqueteETCS
    {
        int prevLevelId;
        bool prevRBCactive;
        public ETCS_LEVELTR()
        {
            Reaction = 1;
        }
        public override void Update()
        {
            int levelId = NextSignalId("ETCS_LEVEL");
            if (prevLevelId != levelId) SharedVariables[KeyPacketNeedsUpdate] = 1;
            if (EtcsRbcManager.DefaultRbc != null && prevRBCactive != EtcsRbcManager.DefaultRbc.Active)
            {
                SharedVariables[KeyPacketNeedsUpdate] = 1;
                prevRBCactive = EtcsRbcManager.DefaultRbc.Active;
            }
            prevLevelId = levelId;
            base.Update();
        }
        public override void UpdatePacket()
        {
            Packet = "";
            float dist = 0;
            for (int i = 0; i < 7; i++)
            {
                if (HasHead(i + 1)) dist += 50 * (1 << i);
            }

            int levelId = NextSignalId("ETCS_LEVEL");
            int lsig = IdSignalLocalVariable(levelId, 601);
            if (levelId >= 0 && (lsig == NextSignalId("NORMAL", 0) || lsig == NextSignalId("NORMAL", 1)))
            {
                Packet = level_tr(dist, level_table(levelId, Math.Max(350, Math.Min(dist / 2 + 50, 1000))));
            }
            base.UpdatePacket();
        }
    }
    public class ETCS_STOPSR : PaqueteETCS
    {
        public ETCS_STOPSR()
        {
            Reaction = 1;
        }
        public override void UpdatePacket()
        {
            Packet = create_packet(137, "0", 1);
            base.UpdatePacket();
        }
    }
	public class ETCS_LINKING : PaqueteETCS
	{
        public override void UpdatePacket()
        {
            Packet = get_linking();
            base.UpdatePacket();
        }
    }
    public class ETCS_NV : PaqueteETCS
    {
        public ETCS_NV()
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
            data += format_binary(nid_cs.Count, 5);
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
    
    public class ETCS_CONEXION_RBC : PaqueteETCS
    {
        bool ManagesRbc;

        EtcsRbcManager Rbc;
        bool Connect;
        bool prevActive;
        public override void Update()
        {
            if (EtcsRbcManager.DefaultRbc == null && NID_C >= 0)
            {
                ManagesRbc = true;
                Rbc = EtcsRbcManager.DefaultRbc = new EtcsRbcManager(NID_C);
            }
            if (ManagesRbc) Rbc.Update();

            base.Update();

            if (Rbc == null)
            {
                Rbc = EtcsRbcManager.DefaultRbc;
            }
            if (Rbc != null)
            {
                if (Rbc.Active != prevActive) SharedVariables[KeyPacketNeedsUpdate] = 1;
                prevActive = Rbc.Active;
            }
        }
        public override void UpdatePacket()
        {
            if (Rbc != null && Rbc.Active)
            {
                Connect = !HasHead(1);
                Packet = create_packet(42, (Connect ? "1" : "0")+format_binary(Rbc.NID_C, 10)+format_binary(Rbc.NID_RBC, 14)+format_binary(Rbc.NID_RADIO, 64)+"0", 1);
            }
            else
            {
                Packet = "";
            }
            base.UpdatePacket();
        }
    }
}
