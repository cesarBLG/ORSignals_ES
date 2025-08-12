using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORTS.Scripting.Script
{
    public class ETCS_LS_MAIN : EurobalizaConmutable
    {
        Aspecto prevAspecto;
        bool Infill = false;
        public ETCS_LS_MAIN()
        {
            BaliseReaction = 1;
            BaliseProvidesLinking = 1;
            EsPrimera = true;
            VBCs.Add(3);
        }
        public override void Initialize()
        {
            Infill = SignalTypeName.Contains("infill");
            base.Initialize();
        }
        public override void Update()
        {
            Aspecto a = GetAspectoSenal(NextSignalId("NORMAL"));
            if (prevAspecto != a) needsUpdate++;
            prevAspecto = a;
            base.Update();
        }
        protected override List<string> ConstruirMensajes()
        {
            List<string> msg = base.ConstruirMensajes();
            msg.Add(get_linking());
            Aspecto asp = GetAspectoSenal(SharedVariables[KeyNextSignalId]);
            if (Infill)
            {
                int id = -1;
                for (int i = 0; ; i++)
                {
                    int nid = NextSignalId("ETCS", i);
                    if (nid < 0) break;
                    if (IdSignalLocalVariable(nid, KeyN_PIG) != 0) continue;
                    if (IdSignalLocalVariable(nid, KeyNextSignalId) != SharedVariables[KeyNextSignalId]) break;
                    id = IdSignalLocalVariable(nid, KeyNID_BG);
                }
                if (id == -1) return msg;
                msg.Add(create_packet(136, "0" + format_binary(id, 14), 1));
            }
            else
            {
                switch (asp)
                {
                    case Aspecto.RebaseAutorizado:
                    case Aspecto.RebaseAutorizadoCortaDistancia:
                        msg.Add(create_packet(132, "1", 1));
                        break;
                    default:
                        msg.Add(create_packet(132, "0", 1));
                        break;
                }
                switch (asp)
                {
                    case Aspecto.Parada:
                    case Aspecto.ParadaPermisiva:
                    case Aspecto.ParadaSelectiva:
                    case Aspecto.ParadaSelectivaDestellos:
                    case Aspecto.ParadaLZB:
                    case Aspecto.RebaseAutorizadoDestellos:
                        msg.Add(create_packet(137, "0", 1));
                        break;
                    default:
                        msg.Add(create_packet(137, "1", 1));
                        break;
                }
            }
            string ma = "01";
            if (asp == Aspecto.Parada || asp == Aspecto.ParadaPermisiva
             || asp == Aspecto.ParadaLZB || asp == Aspecto.ParadaSelectiva || asp == Aspecto.ParadaSelectivaDestellos
             || asp == Aspecto.RebaseAutorizado || asp == Aspecto.RebaseAutorizadoDestellos || asp == Aspecto.RebaseAutorizadoCortaDistancia)
            {
                ma += "0000000" + "0000000" + "0000000000" + "00000";
                ma += "{NextSignalDistanceM(0)-" + (Infill ? "ilref" : "bgref") + "}";
                ma += "0" + "0" + "1" + format_etcs_distance(0) + format_etcs_speedKpH(30) + "0";
            }
            else
            {
                int Vmain;
                int Vloa;
                switch (asp)
                {
                    case Aspecto.AnuncioPrecaucion:
                        Vmain = 160;
                        Vloa = 60;
                        break;
                    case Aspecto.PreanuncioParada:
                        Vmain = 160;
                        Vloa = 60; // TODO: velocidad preanuncio
                        break;
                    case Aspecto.ViaLibreCondicional:
                        Vloa = 160;
                        Vmain = 200;
                        break;
                    case Aspecto.ViaLibre:
                        Vloa = 160; // TODO: TipoSeñalizacion200
                        Vmain = 160;
                        break;
                    default:
                        Vmain = 160;
                        Vloa = 0;
                        break;
                }
                ma += format_etcs_speedKpH(Vmain) + format_etcs_speedKpH(Vloa) + format_binary(1023, 10) + "00000";
                int ahead = 1;
                for (int i = 1; ; i++)
                {
                    int sig = NextSignalId("NORMAL", i);
                    if (sig < 0) break;
                    if (IdSignalHasNormalSubtype(sig, "PANTALLA_ERTMS") || IdSignalHasNormalSubtype(sig, "RETROCESO")) continue;
                    ahead = i;
                    break;
                }
                ma += "{NextSignalDistanceM(" + ahead + ")-" + (Infill ? "ilref" : "bgref") + "}";
                ma += "0" + "0";
                if (Vloa == 0) ma += "1" + format_etcs_distance(0) + format_etcs_speedKpH(30) + "0";
                else ma += "00";
            }
            msg.Add(create_packet(12, ma, 1));
            msg.Add(Infill ? "{ssp_infill}" : "{ssp}");
            string prof = "01" + format_etcs_distance(0) + "10" + "1111111" + format_binary(32767, 15) + format_etcs_distance(300) + "0" + "00000";
            msg.Add(create_packet(80, prof, 1));
            return msg;
        }
    }
    public class ETCS_LS_DEFAULT : EurobalizaFija
    {
        public ETCS_LS_DEFAULT()
        {
            BaliseReaction = 1;
            VBCs.Add(3);
        }
        protected override List<string> ConstruirMensajes()
        {
            List<string> msg = base.ConstruirMensajes();
            msg.Add("{gradient}");
            msg.Add("{pk}");
            return msg;
        }
    }
    public class ETCS_LS_ENTRY : EurobalizaFija
    {
        public ETCS_LS_ENTRY()
        {
            VBCs.Add(2);
        }
        public override void Initialize()
        {
            EsPrimera = HasHead(2);
        }
        protected override List<string> ConstruirMensajes()
        {
            List<string> msg = base.ConstruirMensajes();
            if (EsPrimera)
            {
                string vbco = "1"+format_binary(3, 6)+format_binary(NID_C, 10)+format_binary(1, 8);
                msg.Add(create_packet(6, vbco, 1));
            }
            return msg;
        }
    }
}