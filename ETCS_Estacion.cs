using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
	public class ETCS_ESTACION : PaqueteETCS
    {
        string Estacion;
        public override void Initialize()
        {
            string nom = SignalTypeName.Substring(14);
            if (nom == "valparaiso_panam") Estacion = "Valparaíso - PANAM";
			else if (nom == "el_paso_panam") Estacion = "El Paso - PANAM";
			else if (nom == "la_cumbre_panam") Estacion = "La Cumbre - PANAM";
			else if (nom == "tiltil_panam") Estacion = "Tiltil - PANAM";
			else if (nom == "santiago_norte_panam") Estacion = "Santiago Norte - PANAM";
			else if (nom == "santiago_alameda_panam") Estacion = "Santiago Alameda - PANAM";
        }
        public override void UpdatePacket()
        {
            double end=0;
            for (int i=0; i<8; i++)
            {
                if (HasHead(i+1)) end += (1<<i)*50;
            }
            if (end == 0) end = 1000;
            string txt = "Próx. Estación "+Estacion;
            byte[] ascii = System.Text.Encoding.GetEncoding(28591).GetBytes(txt);
            string pack = "01" + format_binary(0,2) + "0" + format_etcs_distance(0) + format_binary(15,4) + format_binary(5,3) + format_etcs_distance(end) + format_binary(1023,10) + format_binary(15,4) + format_binary(5,3) + format_binary(0,2) + format_binary(ascii.Length, 8);
            for (int i=0; i<ascii.Length; i++)
            {
                pack += format_binary((int)ascii[i],8);
            }
            Packet = create_packet(72, pack, 1);
            base.UpdatePacket();
        }
    }
}
