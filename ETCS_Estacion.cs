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
            if (nom == "caf") Estacion = "Ind. CAF";
            else if (nom == "santa_ana") Estacion = "Santa Ana";
            else if (nom == "ingeniero_pizias") Estacion = "Ing. Pizias";
            else if (nom == "aeropuerto_sur") Estacion = "Aeropuerto";
            else if (nom == "huerta") Estacion = "Huerta del Molinero";
            else if (nom == "calera") Estacion = "Calera";
            else if (nom == "carthago") Estacion = "Carthago";
            else if (nom == "llamas") Estacion = "Llamas";
        }
        public override void UpdatePacket()
        {
            double end=0;
            for (int i=0; i<6; i++)
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
