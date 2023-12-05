using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
	public class EurobalizaConmutable : Eurobaliza
	{
        protected int needsUpdate = 1;
        bool faulty = false;
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
            needsUpdate = 0;
            List<string> msg = ConstruirMensajes();
            if (faulty/* || !Enabled */|| msg == null || NID_BG <= 0)
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
