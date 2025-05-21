using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
    public abstract class Eurobaliza : ETCS
    {
        protected string Telegrama = "";
        protected int N_PIG = -1;
        protected int N_TOTAL = -1;
        protected int M_DUP = 0;
        protected int NID_BG;
        protected bool ActualizarGrupo;
        protected int msgcount = 0;
        protected bool Linked = true;
        protected bool EsPrimera;
        protected int IdSigBaliza = -1;
        protected int BaliseReaction = 2;
        protected int GroupReaction = 2;
        protected bool Faulty = false;
        public override void Initialize()
        {
            SharedVariables[KeyN_PIG] = -1;
            base.Initialize();
            TextSignalAspect = "1" + "0000000" + "0" + format_binary(EsPrimera ? 0 : 1, 3);
        }
        public override void Update()
        {
            base.Update();
            if (NID_C < 0) return;
            int id = -1;
            for (int i = 0; ; i++)
            {
                id = NextSignalId("NORMAL", i);
                if (id < 0) break;
                if (!IdSignalHasNormalSubtype(id, "PANTALLA_ERTMS")) break;
            }
            SharedVariables[KeyNextSignalId] = id;
            if (EsPrimera)
            {
                if (N_TOTAL < 0) NumeraGrupo();
                else if (ActualizarGrupo)
                {
                    ActualizarGrupo = false;
                    SendSignalMessage(SignalId, "ACTUALIZAR:" + msgcount);
                    msgcount++;
                    if (msgcount > 253) msgcount = 0;
                }
            }
        }
        protected void ConstruirTelegrama(int num, List<string> mensajes)
        {
            var sb = new StringBuilder(300);
            sb.Append("1").Append(format_binary(M_VERSION, 7)).Append("0").Append(format_binary(N_PIG, 3)).Append(format_binary(N_TOTAL, 3)).Append(format_binary(M_DUP, 2)).Append(format_binary(num, 8)).Append(format_binary(NID_C, 10)).Append(format_binary(NID_BG, 14)).Append(format_binary(Linked ? 1 : 0, 1));
            if (M_VERSION >= 32) sb.Append(format_binary(0, 8)).Append(format_binary(1, 6)); // VBC
            else if (M_VERSION >= 17) sb.Append(create_packet(200, format_binary(1, 6), 2));
            foreach (string s in mensajes) sb.Append(s);
            sb.Append("11111111");
            Telegrama = sb.ToString();
            TextSignalAspect = Telegrama;
        }
        protected virtual List<string> ConstruirMensajes()
        {
            List<string> msg = new List<string>();
            for (int i = 0; ; i++)
            {
                int id = NextSignalId("ETCS_PACKET", i);
                if (id < 0 || IdSignalLocalVariable(id, KeyNextEurobaliseID) != NextSignalId("ETCS")) break;
                SendSignalMessage(id, "UPDATE_PACKET");
                string pack = IdTextSignalAspect(id, "ETCS_PACKET");
                if (pack != "") msg.Add(pack);
            }
            return msg;
        }
        void SaveVariables()
        {
            SharedVariables[KeyNID_BG] = NID_BG;
            SharedVariables[KeyN_PIG] = N_PIG;
            SharedVariables[KeyN_TOTAL] = N_TOTAL;
        }
        protected void NumeraGrupo()
        {
            if (!EsPrimera) return;
            NID_BG = SignalId;
            N_PIG = 0;
            IdSigBaliza = NextSignalId("ETCS");
            if (IdSigBaliza < 0)
            {
                if (Enabled) N_TOTAL = 0;
            }
            else SendSignalMessage(IdSigBaliza, "NUMERA:" + NID_BG + "," + 1);
            SaveVariables();
        }
        public override void HandleSignalMessage(int id, string message)
        {
            if (message.StartsWith("NUMERA:"))
            {
                string[] dat = message.Substring(7).Split(',');
                int bg = int.Parse(dat[0]);
                int pos = int.Parse(dat[1]);
                if (EsPrimera)
                {
                    SendSignalMessage(bg, "TOTAL:" + (pos - 1));
                    return;
                }
                NID_BG = bg;
                N_PIG = pos;
                IdSigBaliza = NextSignalId("ETCS");
                if (IdSigBaliza < 0) SendSignalMessage(bg, "TOTAL:" + pos);
                else SendSignalMessage(IdSigBaliza, "NUMERA:" + NID_BG + "," + (N_PIG + 1));
                SaveVariables();
            }
            else if (message.StartsWith("TOTAL:"))
            {
                N_TOTAL = int.Parse(message.Substring(6, 1));
                if (N_PIG < N_TOTAL) SendSignalMessage(IdSigBaliza, message);
                SaveVariables();
                for (int i = 0; ; i++)
                {
                    int id2 = NextSignalId("ETCS_PACKET", i);
                    if (id2 < 0 || IdSignalLocalVariable(id2, KeyNextEurobaliseID) != NextSignalId("ETCS")) break;
                    BaliseReaction = Math.Min(IdSignalLocalVariable(id2, KeyBaliseReaction), BaliseReaction);
                }
                SharedVariables[KeyBaliseReaction] = BaliseReaction;
                if (EsPrimera)
                {
                    int reaction = SharedVariables[KeyBaliseReaction];
                    for (int i = 0; i < N_TOTAL; i++)
                    {
                        reaction = Math.Min(reaction, IdSignalLocalVariable(NextSignalId("ETCS", i), KeyBaliseReaction));
                    }
                    SharedVariables[KeyGroupReaction] = reaction;
                }
            }
            else if (message.StartsWith("ACTUALIZA:"))
            {
                ActualizarGrupo = true;
            }
            else if (N_PIG < N_TOTAL) SendSignalMessage(IdSigBaliza, message);
        }
    }
    public class EurobalizaFija : Eurobaliza
    {
        int count = 0;
        public override void Update()
        {
            if (Telegrama != "") return;
            base.Update();
            if (NID_BG > 0)
            {
                count++;
                if (count > 5) GenerarTelegrama();
            }
        }
        void GenerarTelegrama()
        {
            Faulty ^= rand.Next(1000000) == 500;
            var msg = ConstruirMensajes();
            if (Faulty || !Enabled || msg == null || NID_BG <= 0)
            {
                msg = new List<string>();
                msg.Add(create_packet(254, "", 2));
                ConstruirTelegrama(BaliseReaction == 2 ? 255 : 254, msg);
                return;
            }
            ConstruirTelegrama(255, msg);
        }
    }
    
	public class EurobalizaConmutable : Eurobaliza
	{
        protected int needsUpdate = 1;
        bool prevEnabled;
        int prevNumCleared;
        int prevSigId;
		public override void Update()
		{
            base.Update();
            if (NID_BG <= 0) return;
            if (needsUpdate > 0) needsUpdate++;
            for (int i=0; ; i++)
            {
                int id = NextSignalId("ETCS_PACKET", i);
                if (id < 0 || IdSignalLocalVariable(id, KeyNextEurobaliseID) != NextSignalId("ETCS")) break;
                if (IdSignalLocalVariable(id, KeyPacketNeedsUpdate) != 0)
                {
                    needsUpdate++;
                    break;
                }
            }
            if (needsUpdate > 3) SendSignalMessage(NID_BG, "ACTUALIZA:");
		}
		void ActualizarTelegrama(int msgcount)
        {
            Faulty ^= rand.Next(1000000) == 500;
            needsUpdate = 0;
            List<string> msg = ConstruirMensajes();
            if (!Enabled) msg.Add(create_packet(254, "", 2));
            if (Faulty || msg == null || NID_BG <= 0)
            {
                msg  = new List<string>();
                msg.Add(create_packet(254, "", 2));
                ConstruirTelegrama(254, msg);
                return;
            }
            ConstruirTelegrama(msgcount, msg);
        }
        public override void HandleSignalMessage(int id, string message)
		{
            if (message.StartsWith("ACTUALIZAR:")) ActualizarTelegrama(int.Parse(message.Substring(11)));
            base.HandleSignalMessage(id, message);
        }
    }
}
