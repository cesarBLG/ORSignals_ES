using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
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
}
