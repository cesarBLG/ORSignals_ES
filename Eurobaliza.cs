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
        protected int N_PIG;
        protected int N_TOTAL=-1;
        protected int M_DUP=0;
        protected int NID_C;
        protected int NID_BG;
        protected bool ActualizarGrupo;
        protected int msgcount=0;
        protected bool Linked = true;
        protected bool EsPrimera;
        protected int IdSigBaliza=-1;
        protected int BaliseReaction = 2;
        public override void Initialize()
        {
            if (EsPrimera) NID_BG = SignalId;
        }
		public override void Update()
		{
            SharedVariables[KeyNID_BG] = NID_BG;
            SharedVariables[KeyN_PIG] = N_PIG;
            SharedVariables[KeyN_TOTAL] = N_TOTAL;
            SharedVariables[KeyNextSignalId] = NextSignalId("NORMAL");
            SharedVariables[KeyBaliseReaction] = BaliseReaction;
            if (EsPrimera)
            {
                if (N_TOTAL<0) NumeraGrupo();
                else if (ActualizarGrupo)
                {
                    ActualizarGrupo = false;
                    SendSignalMessage(SignalId, "ACTUALIZAR:"+msgcount);
                    msgcount++;
                    if (msgcount > 253) msgcount = 0;
                }
            }
		}
		protected void ConstruirTelegrama(int num, List<string> mensajes)
        {
            var sb = new StringBuilder(300);
            sb.Append("1"+"0100001"+"0").Append(format_binary(N_PIG,3)).Append(format_binary(N_TOTAL,3)).Append(format_binary(M_DUP, 2)).Append(format_binary(num, 8)).Append(format_binary(NID_C, 10)).Append(format_binary(NID_BG, 14)).Append(format_binary(Linked?1:0, 1));
            foreach (string s in mensajes) sb.Append(s);
            sb.Append("11111111");
            Telegrama = sb.ToString();
            TextSignalAspect = Telegrama;
        }
		protected virtual List<string> ConstruirMensajes() 
        {
            List<string> msg = new List<string>();
            for (int i=0; ; i++)
            {
                int id = NextSignalId("ETCS_PACKET", i);
                if (id < 0 || IdSignalLocalVariable(id, KeyNextEurobaliseID) != NextSignalId("ETCS")) break;
                SendSignalMessage(id, "UPDATE_PACKET");
                string pack = IdTextSignalAspect(id, "ETCS_PACKET");
                if (pack != "") msg.Add(pack);
            }
            return msg;
        }
        protected void NumeraGrupo()
        {
            if (!EsPrimera) return;
            IdSigBaliza = NextSignalId("ETCS");
            if (IdSigBaliza < 0)
            {
                if (Enabled) N_TOTAL = 0;
            }
            else SendSignalMessage(IdSigBaliza, "NUMERA:"+NID_C+","+NID_BG+","+1);
        }
        public override void HandleSignalMessage(int id, string message)
		{
            if (message.StartsWith("NUMERA:"))
            {
                string[] dat = message.Substring(7).Split(',');
                int country = int.Parse(dat[0]);
                int bg = int.Parse(dat[1]);
                int pos = int.Parse(dat[2]);
                if (EsPrimera)
                {
                    SendSignalMessage(bg, "TOTAL:"+(pos-1));
                    return;
                }
                NID_C = country;
                NID_BG = bg;
                N_PIG = pos;
                IdSigBaliza = NextSignalId("ETCS");
                if (IdSigBaliza < 0) SendSignalMessage(bg, "TOTAL:"+pos);
                else SendSignalMessage(IdSigBaliza, "NUMERA:"+NID_C+","+NID_BG+","+(N_PIG+1));
            }
            else if (message.StartsWith("TOTAL:"))
            {
                N_TOTAL = int.Parse(message.Substring(6,1));
                if (N_PIG<N_TOTAL) SendSignalMessage(IdSigBaliza, message);
                /*if (EsPrimera)
                {
                    int reaction = SharedVariables[KeyBaliseReaction];
                    for (int i=0; i<N_TOTAL; i++)
                    {
                        reaction = Math.Min(reaction, IdSignalLocalVariable(NextSignalId("ETCS", i), KeyBaliseReaction));
                    }
                    SharedVariables[KeyGroupReaction] = 
                }*/
            }
            else if (message.StartsWith("ACTUALIZA:"))
            {
                ActualizarGrupo = true;
            }
            else if (N_PIG<N_TOTAL) SendSignalMessage(IdSigBaliza, message);
        }
    }
}
