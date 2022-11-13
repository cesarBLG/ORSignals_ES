using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ORTS.Scripting.Script
{
	public abstract class ETCS : CsSignalScript
    {
        static protected readonly int KeyNextEurobaliseID=151;
        static protected readonly int KeyPacketNeedsUpdate=1001;
        
        static public readonly int KeyNID_BG=100;
        static public readonly int KeyN_PIG=101;
        static public readonly int KeyN_TOTAL=102;
        static public readonly int KeyGroupReaction=110;
        static public readonly int KeyBaliseReaction=111;
        static public readonly int KeyNextSignalId=150;
        Dictionary<string, Aspecto> textoAAspecto;
        public ETCS()
        {
            textoAAspecto = Enum.GetNames(typeof(Aspecto)).ToDictionary(x => x, x => (Aspecto)Enum.Parse(typeof(Aspecto), x), StringComparer.OrdinalIgnoreCase);
        }
        protected Aspecto GetAspectoSenal(int id, string tipo = "NORMAL")
		{
            if (id < 0) return Aspecto.Parada;
			var aspectoSiguienteSenalTexto = IdTextSignalAspect(id, tipo);
			if (textoAAspecto.ContainsKey(aspectoSiguienteSenalTexto))
			{
				return textoAAspecto[aspectoSiguienteSenalTexto];
			}
			else
			{
				switch (IdSignalAspect(id, tipo))
				{
					case Aspect.Stop:
						return Aspecto.Parada;

					case Aspect.StopAndProceed:
						return Aspecto.RebaseAutorizado;

					case Aspect.Restricting:
						return Aspecto.RebaseAutorizadoDestellos;

					case Aspect.Approach_1:
						return Aspecto.AnuncioParada;

					case Aspect.Approach_2:
						return Aspecto.AnuncioPrecaucion;

					case Aspect.Approach_3:
						return Aspecto.PreanuncioParada;

					case Aspect.Clear_1:
						return Aspecto.ViaLibreCondicional;

					case Aspect.Clear_2:
						return Aspecto.ViaLibre;
				}
			}
			return Aspecto.Parada;
		}
        protected static string format_binary(int value, int size)
        {
            if (value < 0) value = 0;
            return format_binary((ulong)value, size);
        }
        protected static string format_binary(ulong value, int size)
        {
            var sb = new StringBuilder(size);
            for (int i=size-1; i>=0; i--)
            {
                sb.Append(((value>>i)&1) != 0 ? '1' : '0');
            }
            return sb.ToString();
        }
        protected static string format_etcs_speed(double speedmps)
        {
            int val = Math.Min((int)Math.Round(speedmps*3.6)/5, 120);
            return format_binary(val, 7);
        }
        protected static string format_etcs_speedKpH(double speedkph)
        {
            int val = Math.Min((int)Math.Round(speedkph)/5, 120);
            return format_binary(val, 7);
        }
        protected static string format_etcs_distance(double distm)
        {
            int val = Math.Max(Math.Min((int)distm, 32767),0);
            return format_binary(val, 15);
        }
        protected static string create_packet(int nid_packet, string info, int dir)
        {
            string infocorr = Regex.Replace(info, @"{([^}]*)}", match => {
                return format_etcs_distance(0);
            });
            return format_binary(nid_packet, 8)+format_binary(dir, 2)+format_binary(infocorr.Length+23,13)+info;
        }
        protected string get_linking()
        {
            return "{linking}";
            /*string link="";
            var links = new List<string>();
            string prevref = "bgref";
            for (int i=0; links.Count <= 3; i++)
            {
                int id = NextSignalId("ETCS", i);
                if (id < 0) break;
                if (IdSignalLocalVariable(id, KeyN_PIG) != 0) continue;
                string r = "NextEurobaliseDistance("+i+")";
                string l = "{"+r+"-("+prevref+")}"+"0"+format_binary(IdSignalLocalVariable(id, Eurobaliza.KeyNID_BG), 10)+"1"+format_binary(IdSignalLocalVariable(id, KeyGroupReaction), 2)+format_binary(3, 6);
                links.Add(l);
                prevref = r;
            }
            if (links.Count == 0) return "";
            link += links[0]+format_binary(links.Count-1, 5);
            for (int i=1; i<links.Count; i++) link += links[i];
            return create_packet(5, link, 1);*/
        }
        protected string level_table(int tableId, float lack)
        {
            List<int> levels = new List<int>();
            for (int i=0; ; i++)
            {
                int lv = IdSignalLocalVariable(tableId, 602+i);
                if (lv == 0) break;
                levels.Add(lv);
            }
            return level_table(levels, lack);
        }
        protected string level_table(List<int> levels, float lack)
        {
            var sb = new StringBuilder();
            for (int i=0; i<levels.Count; i++)
            {
                if (levels[i] == 1) sb.Append("000");
                else if (levels[i] == 2) sb.Append("010");
                else if (levels[i] == 3) sb.Append("011");
                else if (levels[i] == 4) sb.Append("100");
                else
                {
                    sb.Append("001");
                    sb.Append(format_binary(levels[i]-5, 8));
                }
                sb.Append(format_etcs_distance(lack));
                if (i == 0) sb.Append(format_binary(levels.Count - 1, 5));
            }
            return sb.ToString();
        }
        protected string level_tr(float distance, string table)
        {
            string dist;
            if (distance == 0) dist = format_binary(32767, 15);
            else if (distance < 0) dist = "{(NextSignalDistanceM(0)+50)*1.05}";
            else dist = format_etcs_distance(distance);
            return create_packet(41, "01"+dist+table, 1);
        }
        /*protected string level0_tr(float distance, float lack=-1)
        {
            if (lack < 0) lack = distance/2;
            if (distance <= 0) distance = 32767;
            return create_packet(41, "01" + format_etcs_distance(distance) + "001" + format_binary(0, 8) + format_etcs_distance(lack) + "00001" + "000" + format_etcs_distance(lack), 1);
        }
        protected string level01_tr(bool order)
        {
            string str = create_packet(41, "01" + (order ? format_binary(32767, 15) : "{(NextSignalDistanceM(0)+50)*1.05}") + "010" + format_etcs_distance(300) + "00010" + "001" + format_binary(0, 8) + format_etcs_distance(300) + "000" + format_etcs_distance(300), 1);
            return str;
        }
        protected string level02_tr(bool order)
        {
            string str = create_packet(41, "01" + (order ? format_binary(32767, 15) : "{(NextSignalDistanceM(0)+50)*1.05}") + "011" + format_etcs_distance(300) + "00010" + "001" + format_binary(0, 8) + format_etcs_distance(300) + "000" + format_etcs_distance(300), 1);
            if (!order) str = str.Substring(0, 25)+"{(NextSignalDistanceM(0)+50)*1.05}"+str.Substring(40);
            return "";
        }
        protected string level012_tr(bool order)
        {
            string str = create_packet(41, "01" + (order ? format_binary(32767, 15) : "{(NextSignalDistanceM(0)+50)*1.05}") + "011" + format_etcs_distance(300) + "00011" + "010" + format_etcs_distance(0) + "001" + format_binary(0, 8) + format_etcs_distance(300) + "000" + format_etcs_distance(300), 1);
            return str;
        }*/
    }
}
