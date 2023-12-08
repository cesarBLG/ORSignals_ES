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
            if (NID_BG > 0)
            {
                count++;
                if (count > 10) GenerarTelegrama();
            }
            base.Update();
		}
		void GenerarTelegrama()
        {
            var msgs = ConstruirMensajes();
            if (msgs != null) ConstruirTelegrama(255, msgs);
        }
    }
}
