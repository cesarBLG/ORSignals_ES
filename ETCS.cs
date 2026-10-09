using Orts.Simulation.Signalling;
using ORTS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.CompilerServices;

namespace ORTS.Scripting.Script
{
    public abstract class ETCS : CsSignalScript
    {
        static protected readonly int KeyNextEurobaliseID=151;
        static protected readonly int KeyNextEurobaliseBackfacingID=152;
        static protected readonly int KeyPacketNeedsUpdate=1001;

        static public readonly int KeyNID_BG=100;
        static public readonly int KeyN_PIG=101;
        static public readonly int KeyN_TOTAL=102;
        static public readonly int KeyNID_C=103;
        static public readonly int KeyGroupReaction=110;
        static public readonly int KeyBaliseReaction=111;
        static public readonly int KeyGroupReactionBackfacing=112;
        static public readonly int KeyBaliseReactionBackfacing=113;
        static public readonly int KeyGroupLinkBackfacing=114;
        static public readonly int KeyBaliseLinkBackfacing=115;
        static public readonly int KeyGroupProvidesLinking=116;
        static public readonly int KeyBaliseProvidesLinking=117;
        static public readonly int KeyBackfacingSignalId=120;
        static public readonly int KeyNextSignalId=150;

        static public readonly int DefaultNID_C;

        protected int NID_C=-1;
        protected bool Convencional;
        protected int M_VERSION=33;

        static public readonly Random rand = new Random();

        static Dictionary<string, Aspecto> textoAAspecto;
        public static string RouteDirectoryPath = null;
        public static void InitializeScriptDirectoryPath([CallerFilePath] string sourceFilePath = "")
        {
            RouteDirectoryPath = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(sourceFilePath)), "..", "..");
        }
        static ETCS()
        {
            textoAAspecto = Enum.GetNames(typeof(Aspecto)).ToDictionary(x => x, x => (Aspecto)Enum.Parse(typeof(Aspecto), x), StringComparer.OrdinalIgnoreCase);
            InitializeScriptDirectoryPath();
            LoadParameter("NID_C", "Default", ref DefaultNID_C);
        }
        public override void Initialize()
        {

        }
        public override void Update()
        {
            if (NID_C < 0)
            {
                int id = NextSignalId("ETCS_CFG");
                if (id >= 0)
                {
                    int next = IdSignalLocalVariable(id, 1);
                    if (next == NextSignalId("NORMAL")) NID_C = IdSignalLocalVariable(id, 0);
                    else if (next > -2) NID_C = DefaultNID_C;
                }
                else NID_C = DefaultNID_C;
                if (NID_C >= 0)
                {
                    string section = string.Format("NID_C.{0}", NID_C);
                    string rules = null;
                    LoadParameter(section, "Rules", ref rules);
                    Convencional = rules == "ADIF_CONV";
                    LoadParameter(section, "M_VERSION", ref M_VERSION);
                }
            }
            SharedVariables[KeyNextEurobaliseID] = NextSignalId("ETCS");
            SharedVariables[KeyNextEurobaliseBackfacingID] = NextSignalId("ETCS_BACKFACING");
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
            if (distm > 32767) distm = 32767;
            if (distm < 0) distm = 0;
            int val = (int)distm;
            return format_binary(val, 15);
        }
        protected static string create_packet(int nid_packet, string info, int dir)
        {
            string infocorr = Regex.Replace(info, @"{([^}]*)}", match => {
                return format_etcs_distance(0);
            });
            return format_binary(nid_packet, 8)+format_binary(dir, 2)+format_binary(infocorr.Length+23,13)+info;
        }
        protected string get_linking(bool backfacing=false)
        {
            string link="01";
            var links = new List<string>();
            string prevref = "0";
            int nomCount = 0;
            int revCount = 0;
            int countLimit = 2;
            int current_nid_c = NID_C;
            while (links.Count < countLimit)
            {
                int id1 = NextSignalId("ETCS", nomCount);
                int id2 = NextSignalId("ETCS_BACKFACING", revCount);
                if (id1 < 0 && id2 < 0) break;
                int id;
                bool reverse = false;
                if (id2 > 0 && (id1 < 0 || IdSignalLocalVariable(id2, KeyNextEurobaliseID) == id1))
                {
                    id = IdSignalLocalVariable(id2, KeyBackfacingSignalId);
                    ++revCount;
                    reverse = true;
                }
                else
                {
                    id = id1;
                    ++nomCount;
                }
                if (IdSignalLocalVariable(id, KeyN_PIG) != 0) continue;
                if (reverse && IdSignalLocalVariable(id2, KeyGroupLinkBackfacing) == 0) continue;
                if (countLimit < 15 && (reverse || IdSignalLocalVariable(id, KeyGroupProvidesLinking) == 0)) ++countLimit;

                string r = (reverse ? "bg_reference_back(" : "bg_reference(") + id + ")";
                string l = "{" + r + "-(" + prevref + ")}";
                int nid_c = IdSignalLocalVariable(id, KeyNID_C);
                if (nid_c != current_nid_c) l += "1" + format_binary(nid_c, 10);
                else l += "0";
                current_nid_c = nid_c;
                l += format_binary(IdSignalLocalVariable(id, KeyNID_BG), 14) + (reverse ? "0" : "1") + format_binary(IdSignalLocalVariable(id, reverse ? KeyGroupReactionBackfacing : KeyGroupReaction), 2) + format_binary(3, 6);
                links.Add(l);
                prevref = r;
            }
            if (links.Count == 0) return "";
            link += links[0]+format_binary(links.Count-1, 5);
            for (int i=1; i<links.Count; i++) link += links[i];
            return create_packet(5, link, backfacing ? 0 : 1);
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
            if ((EtcsRbcManager.DefaultRbc == null || !EtcsRbcManager.DefaultRbc.Active) && levels.Contains(3))
            {
                levels.Remove(3);
                levels.Add(3); // Lowest priority
            }
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
        protected string level_tr(float distance, string table, bool backfacing=false)
        {
            string dist;
            if (distance == 0) dist = format_binary(32767, 15);
            else if (distance < 0 && !backfacing) dist = "{(NextSignalDistanceM(0)+50)*1.05}";
            else dist = format_etcs_distance(distance);
            return create_packet(41, "01"+dist+table, backfacing ? 0 : 1);
        }
        public string get_ma(int SenalAsociada, bool Infill)
        {
            string ma = "01";
            Aspecto aspectoAsociada = GetAspectoSenal(SenalAsociada);
            int maxToClear = 0;
            switch (aspectoAsociada)
            {
                case Aspecto.Parada:
                case Aspecto.ParadaSelectiva:
                case Aspecto.ParadaPermisiva:
                case Aspecto.ParadaLZB:
                    maxToClear = 0;
                    break;
                case Aspecto.RebaseAutorizado:
                case Aspecto.RebaseAutorizadoCortaDistancia:
                case Aspecto.RebaseAutorizadoDestellos:
                case Aspecto.AnuncioParadaInmediata:
                    maxToClear = 1;
                    break;
                default:
                    maxToClear = 2;
                    break;
            }
            if (maxToClear == 0)
            {
                TipoSeñal t = (TipoSeñal)IdSignalLocalVariable(SenalAsociada, 201);
                float dangerPoint = 50;
                int vrelease = 15;
                if (t != TipoSeñal.Ninguno && t.HasFlag(TipoSeñal.Intermedia))
                {
                    vrelease = 30;
                    dangerPoint = 100;
                }
                ma += "0000000"+"0000000"+"0000000000"+"00000";
                int ahead = -1;
                for (int i=0;; i++)
                {
                    int sig = NextSignalId("NORMAL", i);
                    if (sig == SenalAsociada)
                    {
                        ahead = i;
                        break;
                    }
                    if (sig < 0) break;
                }
                if (ahead < 0) ma += "000000000000000";
                else ma += "{NextSignalDistanceM("+ahead+")-"+(Infill ? "ilref" : "bgref")+"}";
                ma += "0"+"0"+"1"+format_etcs_distance(dangerPoint)+format_etcs_speedKpH(vrelease)+"0";
            }
            else
            {
                int vrelease = 15;
                ma += format_etcs_speedKpH(300)+format_etcs_speed(0)+format_binary(0, 10);
                int nsignals = 0;
                int proximidad = 0;
                int section = 0;
                int maxsections = 2;
                int senalUltimaSeccion=-1;
                int npn = 0;
                string sect = "";
                int sig = -1;
                string startRef = Infill ? "ilref" : "bgref";
                string sectionLength="";
                float dangerPoint=50;
                bool first = false;
                for(int i=0;; i++)
                {
                    sig = NextSignalId("NORMAL", i);
                    for (int j=npn;; j++)
                    {
                        int pn = NextSignalId("OLPN_T", npn);
                        if (sig >= 0 && pn >= 0 && IdSignalLocalVariable(pn, KeyNextSignalId) == sig)
                        {
                            if (first)
                            {
                                sectionLength = "{(NextSignalDistanceM(OLPN_T,"+j+")-50)-("+startRef+")}";
                                startRef = "NextSignalDistanceM(OLPN_T,"+j+")-50";
                                sect += construirSeccion(SenalAsociada, Infill, sectionLength, section, senalUltimaSeccion, -1, nsignals);
                                senalUltimaSeccion = -1;
                                section++;
                                maxsections++;
                            }
                            npn++;
                        }
                        else break;
                    }
                    if (sig != SenalAsociada && !first)
                    {
                        if (sig < 0) return "";
                        continue;
                    }
                    first = true;
                    if (IdSignalHasNormalSubtype(sig, "PANTALLA_ERTMS") || IdSignalHasNormalSubtype(sig, "RETROCESO")) continue;
                    Aspecto a = GetAspectoSenal(sig);
                    SistemaSeñalizacion sist = (SistemaSeñalizacion)IdSignalLocalVariable(sig, 200);
                    TipoSeñal t = (TipoSeñal)IdSignalLocalVariable(sig, 201);
                    bool stop = sig == -1 || a == Aspecto.Parada || a == Aspecto.ParadaPermisiva || a == Aspecto.ParadaSelectiva || a == Aspecto.ParadaLZB || a == Aspecto.RebaseAutorizado || a == Aspecto.RebaseAutorizadoCortaDistancia;
                    if (a == Aspecto.ParadaSelectivaDestellos && (sist & SistemaSeñalizacion.ETCS_N1) == 0 && (sist & SistemaSeñalizacion.ETCS_N2) == 0 && (sist & SistemaSeñalizacion.LZB) == 0) stop = true;
                    bool esInicioRuta = t != TipoSeñal.Ninguno && (t.HasFlag(TipoSeñal.Entrada) || t.HasFlag(TipoSeñal.Salida) || t.HasFlag(TipoSeñal.Interior)) && !t.HasFlag(TipoSeñal.Liberacion);
                    if (esInicioRuta)
                    {
                        int reqProximidad = IdSignalLocalVariable(sig, 902);
                        if (proximidad > reqProximidad) stop = true;
                    }
                    if (maxToClear == 1 && nsignals > 0) stop = true;
                    if (stop)
                    {
                        if (sig < 0)
                        {
                            vrelease = 10;
                            dangerPoint = 10;
                            sectionLength = "{(EoADistanceM(0)-10)-(" + startRef + ")}";
                        }
                        else sectionLength = "{NextSignalDistanceM(" + i + ")-(" + startRef + ")}";
                        if (t != TipoSeñal.Ninguno && (t.HasFlag(TipoSeñal.Intermedia) || t.HasFlag(TipoSeñal.Avanzada)))
                        {
                            vrelease = 30;
                            dangerPoint = 100;
                        }
                        else if (t != TipoSeñal.Ninguno && t.HasFlag(TipoSeñal.Topera))
                        {
                            vrelease = 10;
                            dangerPoint = 10;
                        }
                        break;
                    }
                    if (esInicioRuta && section < maxsections)
                    {
                        sectionLength = "{NextSignalDistanceM("+i+")-("+startRef+")}";
                        startRef = "NextSignalDistanceM("+i+")";
                        sect += construirSeccion(SenalAsociada, Infill, sectionLength, section, senalUltimaSeccion, sig, nsignals);
                        senalUltimaSeccion = sig;
                        section++;
                    }
                    nsignals++;
                    proximidad += 1 - IdSignalLocalVariable(sig, 900);
                }
                ma += format_binary(section, 5) + sect;
                ma += construirSeccion(SenalAsociada, Infill, sectionLength, section, senalUltimaSeccion, sig, nsignals);
                ma += "0"+"1"+format_etcs_distance(dangerPoint)+format_etcs_speedKpH(vrelease)+"0";
            }
            return create_packet(12, ma, 1);
        }
        string construirSeccion(int SenalAsociada, bool Infill, string longitud, int sectionNumber, int senalInicioSeccion, int senalFinSeccion, int nsignals)
        {
            var tipo = (TipoSeñal)IdSignalLocalVariable(senalInicioSeccion, 201);
            bool esSalida = tipo != TipoSeñal.Ninguno && tipo.HasFlag(TipoSeñal.Salida);
            string sect = longitud;
            if (sectionNumber > 0)
            {
                int T = 30;
                float d = 200;
                if (senalInicioSeccion == SenalAsociada && !Infill) T = Convencional ? 180 : 360; // DEI
                else if (senalInicioSeccion < 0)
                {
                    T = 180;
                    d = 0;
                }
                else
                {
                    if (Convencional) T = /*(senalInicioSeccion == SenalAsociada && esSalida) ? 30 : */150; // DAI
                    else if (nsignals == 1) T = 240; // DAI zona 2
                    else T = 360; // DAI zona 1
                }
                sect += "1"+format_binary(T, 10)+format_etcs_distance(d);
            }
            else if (senalFinSeccion == SenalAsociada && !Infill)
            {
                int T = Convencional ? 150 : 240; // DAI
                sect += "1"+format_binary(T, 10)+longitud;
            }
            else sect += "0"; // Sin temporizar
            return sect;
        }
        protected static void LoadParameter<T>(string sectionName, string keyName, ref T value)
        {
            string file = Path.Combine(RouteDirectoryPath, @"etcs.ini");
            if (File.Exists(file))
            {
                string buffer = new string('\0', 256);
                int length = NativeMethods.GetPrivateProfileString(sectionName, keyName, null, buffer, buffer.Length, file);

                if (length > 0)
                {
                    value = (T)Convert.ChangeType(buffer.Trim('\0').Trim(), typeof(T), System.Globalization.CultureInfo.InvariantCulture);
                }
            }
        }
    }
}
