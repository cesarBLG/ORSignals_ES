using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORTS.Scripting.Script
{
	public class ETCS_MAIN_MA_1_2 : EurobalizaConmutable
	{
        bool soloN1;
        int prevEndSig = -1;
        public ETCS_MAIN_MA_1_2()
        {
            BaliseReaction = 1;
            BaliseProvidesLinking = 1;
            //EsPrimera = true;
        }
        public override void Initialize()
        {
            soloN1 = HasHead(1);
            base.Initialize();
        }
        public override void Update()
        {
            int sigId = NextSignalId("NORMAL");
            int endSig = -1;
            if (sigId >= 0)
            {
                int max = IdSignalLocalVariable(sigId, 901);
                for (int i=0; i<max; i++)
                {
                    int sig = NextSignalId("NORMAL", i);
                    if (IdSignalHasNormalSubtype(sig, "PANTALLA_ERTMS") || IdSignalHasNormalSubtype(sig, "RETROCESO")) continue;
                    Aspecto a = GetAspectoSenal(sig);
                    if (sig == -1 || a == Aspecto.Parada || a == Aspecto.ParadaPermisiva || a == Aspecto.ParadaSelectiva || a == Aspecto.RebaseAutorizado || a == Aspecto.RebaseAutorizadoCortaDistancia) break;
                    endSig = sig;
                }
            }
            if (endSig != prevEndSig) needsUpdate++;
            prevEndSig = endSig;
            base.Update();
        }
        protected override List<string> ConstruirMensajes() 
        {
            if (!soloN1) SendSignalMessage(SharedVariables[KeyNextSignalId], "ETCS_N2");
            SendSignalMessage(SharedVariables[KeyNextSignalId], "ETCS_N1");
            List<string> msg = new List<string>();
            msg.Add(get_ma(SharedVariables[KeyNextSignalId], false));
            msg.Add("{ssp}");
            msg.Add(get_linking());
            Aspecto asp = GetAspectoSenal(SharedVariables[KeyNextSignalId]);
            switch(asp)
            {
                case Aspecto.RebaseAutorizado:
                case Aspecto.RebaseAutorizadoCortaDistancia:
                    msg.Add(create_packet(132, "1", 1));
                    break;
                default:
                    msg.Add(create_packet(132, "0", 1));
                    break;
            }
            switch(asp)
            {
                case Aspecto.Parada:
                case Aspecto.ParadaPermisiva:
                case Aspecto.ParadaSelectiva:
                case Aspecto.ParadaLZB:
                    msg.Add(create_packet(137, "0", 1));
                    break;
                case Aspecto.RebaseAutorizado:
                case Aspecto.RebaseAutorizadoCortaDistancia:
                {
                    bool shProfile = false;
                    LoadParameter(string.Format("NID_C.{0}", NID_C), "ShProfile", ref shProfile);
                    msg.Add(create_packet(137, shProfile ? "1" : "0", 1));
                    if (shProfile)
                    {
                        string prof = "01" + format_etcs_distance(0) + "01" + "1111111" + format_binary(32767, 15) + format_etcs_distance(0) + "0" + "00000";
                        msg.Add(create_packet(80, prof, 1));
                    }
                    break;
                }
                default:
                    msg.Add(create_packet(137, "1", 1));
                    break;
            }
            if (asp == Aspecto.RebaseAutorizadoDestellos)
            {
                int start = 0;
                int end = 1;
                bool sigfound = false;
                for (int i = 0; ; i++)
                {
                    int id = NextSignalId("NORMAL", i);
                    if (id < 0) break;
                    if (IdSignalHasNormalSubtype(id, "RETROCESO"))
                    {
                        start = i;
                        continue;
                    }
                    if (sigfound) break;
                    start = i;
                    if (IdSignalHasNormalSubtype(id, "PANTALLA_ERTMS")) continue;
                    sigfound = true;
                }
                for (int i = start + 1; ; i++)
                {
                    end = i;
                    int id = NextSignalId("NORMAL", i);
                    if (id < 0) break;
                    if (IdSignalHasNormalSubtype(id, "RETROCESO") || IdSignalHasNormalSubtype(id, "PANTALLA_ERTMS")) continue;
                    break;
                }
                string prof = "01" + "{NextSignalDistanceM(" + start + ")-bgref}" + "00" + "1111111" + "{NextSignalDistanceM(" + end + ")-NextSignalDistanceM(" + start + ")}" + format_etcs_distance(300) + "1" + "00000";
                msg.Add(create_packet(80, prof, 1));
            }
            msg.AddRange(base.ConstruirMensajes());
            return msg;
        }
    }
	public class ETCS_MAIN_FIXED_2_2 : EurobalizaConmutable
	{
        public ETCS_MAIN_FIXED_2_2()
        {
            BaliseReaction = 1;
        }
        protected override List<string> ConstruirMensajes() 
        {
            List<string> msg = new List<string>();
            msg.Add("{gradient}");
            msg.Add("{trackcond}");
            msg.Add("{pk}");
            msg.AddRange(base.ConstruirMensajes());
            return msg;
        }
    }
	public class ETCS_LTV : EurobalizaConmutable
	{
        public ETCS_LTV()
        {
            EsPrimera = true;
            BaliseReaction = 1;
        }
        protected override List<string> ConstruirMensajes() 
        {
            List<string> msg = new List<string>();
            msg.Add("{ltv}");
            return msg;
        }
    }
	public class ETCS_INFILL_MA_1_2 : EurobalizaConmutable
	{
        int prevEndSig = -1;
        public ETCS_INFILL_MA_1_2()
        {
            EsPrimera = true;
            BaliseReaction = 1;
            BaliseProvidesLinking = 1;
        }
        public override void Update()
        {
            int sigId = NextSignalId("NORMAL");
            int endSig = -1;
            if (sigId >= 0)
            {
                int max = IdSignalLocalVariable(sigId, 901);
                for (int i=0; i<max; i++)
                {
                    int sig = NextSignalId("NORMAL", i);
                    if (IdSignalHasNormalSubtype(sig, "PANTALLA_ERTMS") || IdSignalHasNormalSubtype(sig, "RETROCESO")) continue;
                    Aspecto a = GetAspectoSenal(sig);
                    if (sig == -1 || a == Aspecto.Parada || a == Aspecto.ParadaPermisiva || a == Aspecto.ParadaSelectiva || a == Aspecto.RebaseAutorizado || a == Aspecto.RebaseAutorizadoCortaDistancia) break;
                    endSig = sig;
                }
            }
            if (endSig != prevEndSig) needsUpdate++;
            prevEndSig = endSig;
            base.Update();
        }
        protected override List<string> ConstruirMensajes() 
        {
            List<string> msg = new List<string>();
            msg.Add(get_linking());
            msg.AddRange(base.ConstruirMensajes());
            int id = -1;
            for (int i=0; ; i++)
            {
                int nid = NextSignalId("ETCS", i);
                if (nid < 0) break;
                if (IdSignalLocalVariable(nid, KeyN_PIG) != 0) continue;
                if (IdSignalLocalVariable(nid, KeyNextSignalId) != SharedVariables[KeyNextSignalId]) break;
                id = IdSignalLocalVariable(nid, KeyNID_BG);
            }
            if (id != -1)
            {
                msg.Add(create_packet(136, "0"+format_binary(id,14), 1));
                msg.Add("{ssp_infill}");
                msg.Add(get_ma(SharedVariables[KeyNextSignalId], true));
                Aspecto asp = GetAspectoSenal(SharedVariables[KeyNextSignalId]);
                if (asp == Aspecto.RebaseAutorizadoDestellos)
                {
                    int associated = 0;
                    for (int i=0; ; i++)
                    {
                        int id2 = NextSignalId("NORMAL", i);
                        if (id2 < 0) break;
                        if (id2 == SharedVariables[KeyNextSignalId])
                        {
                            associated = i;
                            break;
                        }
                    }
                    int start = 0;
                    int end = 1;
                    bool sigfound = false;
                    for (int i=associated; ; i++)
                    {
                        int id2 = NextSignalId("NORMAL", i);
                        if (id2 < 0) break;
                        if (IdSignalHasNormalSubtype(id2, "RETROCESO"))
                        {
                            start = i;
                            continue;
                        }
                        if (sigfound) break;
                        start = i;
                        if (IdSignalHasNormalSubtype(id2, "PANTALLA_ERTMS")) continue;
                        sigfound = true;
                    }
                    for (int i=start+1; ; i++)
                    {
                        end = i;
                        int id2 = NextSignalId("NORMAL", i);
                        if (id2 < 0) break;
                        if (IdSignalHasNormalSubtype(id2, "RETROCESO") || IdSignalHasNormalSubtype(id2, "PANTALLA_ERTMS")) continue;
                        break;
                    }
                    string prof = "01" + "{NextSignalDistanceM("+start+")-ilref}" + "00" + "1111111" + "{NextSignalDistanceM("+end+")-NextSignalDistanceM("+start+")}" + format_etcs_distance(300) + "1" + "00000";
                    msg.Add(create_packet(80, prof, 1));
                }
            }
            return msg;
        }
    }
	public class ETCS_INFILL_FIXED_2_2 : EurobalizaConmutable
	{
        public ETCS_INFILL_FIXED_2_2()
        {
            BaliseReaction = 1;
        }
        protected override List<string> ConstruirMensajes() 
        {
            List<string> msg = new List<string>();
            msg.Add("{gradient}");
            msg.Add("{trackcond}");
            msg.AddRange(base.ConstruirMensajes());
            return msg;
        }
    }
    public class ETCS_PIE : EurobalizaConmutable
    {
        Aspecto prevAspecto;
        public ETCS_PIE()
        {
            EsPrimera = true;
            //BaliseReaction = 1;
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
            List<string> msg = new List<string>();
            Aspecto asp = GetAspectoSenal(NextSignalId("NORMAL"));
            switch(asp)
            {
                case Aspecto.RebaseAutorizado:
                case Aspecto.RebaseAutorizadoCortaDistancia:
                case Aspecto.MovimientoAutorizado:
                case Aspecto.IndicadoraDesviada:
                case Aspecto.IndicadoraDirecta:
                    msg.Add(create_packet(132, "1", 1));
                    break;
                default:
                    msg.Add(create_packet(132, "0", 1));
                    break;
            }
            switch(asp)
            {
                case Aspecto.Parada:
                case Aspecto.ParadaPermisiva:
                case Aspecto.ParadaSelectiva:
                case Aspecto.ParadaLZB:
                    msg.Add(create_packet(137, "0", 1));
                    break;
                case Aspecto.RebaseAutorizado:
                case Aspecto.RebaseAutorizadoCortaDistancia:
                {
                    bool shProfile = false;
                    LoadParameter(string.Format("NID_C.{0}", NID_C), "ShProfile", ref shProfile);
                    msg.Add(create_packet(137, shProfile ? "1" : "0", 1));
                    break;
                }
                default:
                    msg.Add(create_packet(137, "1", 1));
                    break;
            }
            msg.AddRange(base.ConstruirMensajes());
            return msg;
        }
    }
    public class ETCS_MAIN_N2 : ETCS_PIE
    {
        protected override List<string> ConstruirMensajes()
        {
            SendSignalMessage(NextSignalId("NORMAL"), "ETCS_N2");
            List<string> msg = new List<string>();
            msg.Add("{pk}");
            msg.AddRange(base.ConstruirMensajes());
            return msg;
        }
    }
	public class ETCS_RETROCESO : ETCS_PIE
	{
    }
	public class ETCS_DEFAULT_1_1 : EurobalizaFija
	{
        public ETCS_DEFAULT_1_1()
        {
            EsPrimera = true;
            BaliseProvidesLinking = 1;
        }
        public override void Initialize()
        {
            Faulty |= HasHead(2);
            base.Initialize();
        }
        protected override List<string> ConstruirMensajes() 
        {
            List<string> msg = new List<string>();
            msg.Add(get_linking());
            msg.AddRange(base.ConstruirMensajes());
            return msg;
        }
    }
	public class ETCS_DEFAULT_2_2 : EurobalizaFija
	{
    }
	public class ETCS_GENERIC : EurobalizaConmutable
	{
        public override void Initialize()
        {
            EsPrimera |= HasHead(1);
            base.Initialize();
        }
    }
    [Obsolete("Deprecated, insert the message packet to any balise instead")]
    public class ETCS_SECCIONAMIENTO_1_1 : EurobalizaFija
	{
        public ETCS_SECCIONAMIENTO_1_1()
        {
            EsPrimera = true;
        }
        protected override List<string> ConstruirMensajes() 
        {
            double dist = 0;
            double length = 600;
            List<string> msg = new List<string>();
            string txt = "Cierre del Regulador";
            byte[] ascii = System.Text.Encoding.GetEncoding(28591).GetBytes(txt); 
            string packet = "01" + format_binary(1,2) + "0" + format_etcs_distance(dist) + format_binary(15,4) + format_binary(5,3) + format_etcs_distance(length) + format_binary(1023,10) + format_binary(15,4) + format_binary(5,3) + format_binary(0,2) + format_binary(ascii.Length, 8);   
            for (int i=0; i<ascii.Length; i++)
            {
                packet += format_binary((int)ascii[i],8);
            }
            msg.Add(create_packet(72,packet,1));
            return msg;
        }
    }
    [Obsolete("Deprecated, insert a level transition packet to any balise instead")]
	public class ETCS_LEVELTR_ANNOUNCEMENT_0_FIJA_1_2 : EurobalizaFija
    {
        public ETCS_LEVELTR_ANNOUNCEMENT_0_FIJA_1_2()
        {
            EsPrimera = true;
            BaliseReaction = 1;
        }
        protected override List<string> ConstruirMensajes()
        {
            List<string> msg = new List<string>();
            float dist = 0;
            for (int i = 0; i < 5; i++)
            {
                if (HasHead(i + 1)) dist += 20 * (1 << i);
            }
            if (dist == 0) dist = 500;
            msg.Add(level_tr(dist, level_table(new List<int> { 1 }, dist / 2)));
            return msg;
        }
    }
    [Obsolete("Deprecated, insert a level transition packet to any balise instead")]
	public class ETCS_LEVELTR_ANNOUNCEMENT_1_FIJA_1_2 : EurobalizaFija
	{
        public ETCS_LEVELTR_ANNOUNCEMENT_1_FIJA_1_2()
        {
            EsPrimera = true;
            BaliseReaction = 1;
            BaliseProvidesLinking = 1;
        }
        protected override List<string> ConstruirMensajes() 
        {
            List<string> msg = new List<string>();
            msg.Add(get_linking());
            msg.Add(level_tr(-1, level_table(new List<int>{2,5,1}, 500)));
            return msg;
        }
    }
    [Obsolete("Deprecated, insert a level transition packet to any balise instead")]
    public class ETCS_LEVELTR_ORDER_0_FIJA_1_2 : EurobalizaFija
	{
        public ETCS_LEVELTR_ORDER_0_FIJA_1_2()
        {
            EsPrimera = true;
            BaliseReaction = 1;
        }
        protected override List<string> ConstruirMensajes() 
        {
            List<string> msg = new List<string>();
            msg.Add(level_tr(0, level_table(new List<int>{1}, 0)));
            return msg;
        }
    }
    [Obsolete("Deprecated, insert a level transition packet to any balise instead")]
	public class ETCS_LEVELTR_ANNOUNCEMENT_LINKED_1_2 : EurobalizaConmutable
	{
        public ETCS_LEVELTR_ANNOUNCEMENT_LINKED_1_2()
        {
            EsPrimera = true;
            BaliseReaction = 1;
            BaliseProvidesLinking = 1;
        }
        protected override List<string> ConstruirMensajes() 
        {
            List<string> msg = new List<string>();
            msg.Add(get_linking());
            int levelId = NextSignalId("ETCS_LEVEL");
            int lsig = IdSignalLocalVariable(levelId, 601);
            if (levelId >= 0 && (lsig == NextSignalId("NORMAL", 0)  || lsig == NextSignalId("NORMAL", 1)))
            {
                msg.Add(level_tr(-1, level_table(levelId, 500)));
            }
            return msg;
        }
    }
    [Obsolete("Deprecated, insert a level transition packet to any balise instead")]
	public class ETCS_LEVELTR_ORDER_LINKED_1_2 : EurobalizaConmutable
	{
        public ETCS_LEVELTR_ORDER_LINKED_1_2()
        {
            EsPrimera = true;
            BaliseReaction = 1;
            BaliseProvidesLinking = 1;
        }
        protected override List<string> ConstruirMensajes() 
        {
            List<string> msg = new List<string>();
            msg.Add(get_linking());
            int levelId = NextSignalId("ETCS_LEVEL");
            int lsig = IdSignalLocalVariable(levelId, 601);
            if (levelId >= 0 && (lsig == NextSignalId("NORMAL", 0)  || lsig == NextSignalId("NORMAL", 1)))
            {
                int lv = IdSignalLocalVariable(levelId, 602);
                if (lv == 0 || lv > 4) // Only for NTC and level 0: otherwise would lead to train trip
                {
                    msg.Add(level_tr(0, level_table(levelId, 0)));
                }
            }
            return msg;
        }
    }
}
