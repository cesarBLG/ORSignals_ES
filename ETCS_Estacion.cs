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
            if (nom == "chamartin") Estacion = "Madrid Chamartín";
            else if (nom == "colmenar_viejo") Estacion = "Colmenar Viejo";
            else if (nom == "tres_cantos") Estacion = "Tres Cantos";
            else if (nom == "el goloso") Estacion = "El Goloso";
            else if (nom == "alcobendas") Estacion = "Alcobendas-S.S. de los Reyes";
            else if (nom == "valdefuentes") Estacion = "Valdelasfuentes";
            else if (nom == "uni_comillas") Estacion = "Universidad P. Comillas";
            else if (nom == "cantoblanco") Estacion = "Cantoblanco";
            else if (nom == "fuencarral") Estacion = "Fuencarral";
            else if (nom == "ministerios") Estacion = "Nuevos Ministerios";
            else if (nom == "sol") Estacion = "Sol";
            else if (nom == "atocha") Estacion = "Atocha";
            else if (nom == "vbajo") Estacion = "Villaverde Bajo";
            else if (nom == "valto") Estacion = "Villaverde Alto";
            else if (nom == "margaritas") Estacion = "Las Margaritas";
            else if (nom == "getacentro") Estacion = "Getafe Centro";
            else if (nom == "sectortres") Estacion = "Getafe Sector 3";
            else if (nom == "parla") Estacion = "Parla";
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
