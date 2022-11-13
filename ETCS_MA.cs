using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
	public class ETCS_MA : PaqueteETCS
    {
        bool Infill;
        bool Convencional;
        int SenalAsociada = -1;
        public override void Update()
        {
            if (SenalAsociada < 0)
            {
                SenalAsociada = NextSignalId("NORMAL");
            }
        }
        public override void UpdatePacket()
        {
            Packet = BuildMA();
            base.UpdatePacket();
        }
        public string BuildMA()
        {
            string ma = "01";
            Aspecto aspectoAsociada = GetAspectoSenal(SenalAsociada);
            if (aspectoAsociada == Aspecto.Parada || aspectoAsociada == Aspecto.ParadaSelectiva || aspectoAsociada == Aspecto.ParadaPermisiva)
            {
                ma += "0000000"+"0000000"+"0000000000"+"00000";
                ma += "000000000000000"+"0"+"0"+"1"+format_etcs_distance(50)+format_etcs_speed(15)+"0";
            }
            else
            {
                int vrelease = 15;
                ma += format_etcs_speedKpH(300)+format_etcs_speed(0)+format_binary(0, 10);
                int maxToClear = 0;
                switch(aspectoAsociada)
                {
                    case Aspecto.RebaseAutorizado:
                    case Aspecto.RebaseAutorizadoCortaDistancia:
                    case Aspecto.RebaseAutorizadoDestellos:
                    case Aspecto.AnuncioParadaInmediata:
                        maxToClear = 1;
                        break;
                    case Aspecto.AnuncioParada:
                        maxToClear = 2;
                        break;
                    case Aspecto.AnuncioPrecaucion:
                        maxToClear = 2;
                        break;
                    case Aspecto.PreanuncioParada:
                    case Aspecto.ViaLibreCondicional:
                        maxToClear = 3;
                        break;
                    case Aspecto.ViaLibre:
                    case Aspecto.ParadaSelectivaDestellos:
                        maxToClear = 4;
                        break;
                }
                int nsignals = 0;
                int section = 0;
                int senalUltimaSeccion=-1;
                string sect = "";
                int sig = -1;
                string startRef = Infill ? "ilref" : "bgref";
                string sectionLength="";
                bool topera = false;
                for(int i=0;; i++) 
                {
                    sig = NextSignalId("NORMAL", i);
                    bool esSenalVirtual = IdSignalHasNormalSubtype(sig, "PANTALLA_ERTMS");
                    Aspecto a = GetAspectoSenal(sig);
                    if (esSenalVirtual) continue;
                    if (sig == -1 || a == Aspecto.Parada || a == Aspecto.ParadaPermisiva || a == Aspecto.ParadaSelectiva ||
                        a == Aspecto.RebaseAutorizado || a == Aspecto.RebaseAutorizadoCortaDistancia ||
                        a == Aspecto.RebaseAutorizadoDestellos)
                    {
                        if (sig < 0)
                        {
                            vrelease = 10;
                            topera = true;
                            sectionLength = "{EoADistanceM(0)-10-("+startRef+")}";
                        }
                        else sectionLength = "{NextSignalDistanceM("+i+")-("+startRef+")}";
                        break;
                    }
                    bool esInicioRuta = false;
                    if (esInicioRuta)
                    {
                        if (nsignals >= maxToClear) break;
                        if (section < 2)
                        {
                            sectionLength = "{NextSignalDistanceM("+i+")-("+startRef+")}";
                            startRef = "NextSignalDistanceM("+i+")";
                            sect += construirSeccion(sectionLength, section, senalUltimaSeccion, sig, nsignals);
                            senalUltimaSeccion = sig;
                            section++;
                        }
                    }
                    nsignals++;
                }
                ma += format_binary(section, 5) + sect;
                ma += construirSeccion(sectionLength, section, senalUltimaSeccion, sig, nsignals);
                ma += "0"+"1"+format_etcs_distance(topera ? 10 : 50)+format_etcs_speedKpH(vrelease)+"0";
            }
            return create_packet(12, ma, 1);
        }
        string construirSeccion(string longitud, int sectionNumber, int senalInicioSeccion, int senalFinSeccion, int nsignals)
        {
            bool esSalida = false;
            string sect = longitud;
            if (sectionNumber > 0)
            {
                int T = 30;
                if (senalInicioSeccion == SenalAsociada && !Infill) T = Convencional ? 180 : 360; // DEI
                else
                {
                    if (Convencional) T = (senalInicioSeccion == SenalAsociada && esSalida) ? 30 : 150; // DAI
                    else if (nsignals == 1) T = 240; // DAI zona 2
                    else T = 360; // DAI zona 1
                }
                sect += "1"+format_binary(T, 10)+format_etcs_distance(200);
            }
            else if (senalFinSeccion == SenalAsociada && !Infill)
            {
                int T = Convencional ? 150 : 240; // DAI
                sect += "1"+format_binary(T, 10)+longitud;
            }
            else sect += "0"; // Sin temporizar
            return sect;
        }
    }
}