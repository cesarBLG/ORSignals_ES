using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
	public class ETCS_MAIN_MA_1_2 : EurobalizaConmutable
	{
        bool soloN1;
        public ETCS_MAIN_MA_1_2()
        {
            BaliseReaction = 1;
            //EsPrimera = true;
        }
        public override void Initialize()
        {
            soloN1 = HasHead(1);
            base.Initialize();
        }
        protected override List<string> ConstruirMensajes() 
        {
            if (!soloN1) SendSignalMessage(NextSignalId("NORMAL"), "ETCS_N2");
            List<string> msg = new List<string>();
            msg.Add("{ma}");
            msg.Add("{ssp}");
            msg.Add(get_linking());
            Aspecto asp = GetAspectoSenal(NextSignalId("NORMAL"));
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
                    msg.Add(create_packet(137, "0", 1));
                    break;
                default:
                    msg.Add(create_packet(137, "1", 1));
                    break;
            }
            if (asp == Aspecto.RebaseAutorizado || asp == Aspecto.RebaseAutorizadoCortaDistancia)
            {
                string prof = "01" + format_etcs_distance(0) + "01" + "1111111" + format_binary(32767, 15) + format_etcs_distance(0) + "0" + "00000";
                msg.Add(create_packet(80, prof, 1));
            }
            else if (asp == Aspecto.RebaseAutorizadoDestellos)
            {
                int start = 0;
                int end = 1;
                bool sigfound = false;
                for (int i=0; ; i++)
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
                for (int i=start+1; ; i++)
                {
                    end = i;
                    int id = NextSignalId("NORMAL", i);
                    if (id < 0) break;
                    if (IdSignalHasNormalSubtype(id, "RETROCESO") || IdSignalHasNormalSubtype(id, "PANTALLA_ERTMS")) continue;
                    break;
                }
                string prof = "01" + "{NextSignalDistanceM("+start+")-bgref}" + "00" + "1111111" + "{NextSignalDistanceM("+end+")-NextSignalDistanceM("+start+")}" + format_etcs_distance(300) + "1" + "00000";
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
            /*int levelId = NextSignalId("ETCS_LEVEL");
            if (levelId >= 0 && NextSignalId("NORMAL", 1) == IdSignalLocalVariable(levelId, 601))
            {
                msg.Add(level_tr(0, level_table(levelId, 0)));
            }*/
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
        public ETCS_INFILL_MA_1_2()
        {
            EsPrimera = true;
            BaliseReaction = 1;
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
                msg.Add("{ma_infill}");
                Aspecto asp = GetAspectoSenal(NextSignalId("NORMAL"));
                if (asp == Aspecto.RebaseAutorizadoDestellos)
                {
                    int start = 0;
                    int end = 1;
                    bool sigfound = false;
                    for (int i=0; ; i++)
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
            /*int levelId = NextSignalId("ETCS_LEVEL");
            if (levelId >= 0 && NextSignalId("NORMAL", 1) == IdSignalLocalVariable(levelId, 601))
            {
                msg.Add(level_tr(-1, level_table(levelId, 500)));
            }*/
            msg.AddRange(base.ConstruirMensajes());
            return msg;
        }
    }
    public class ETCS_MAIN_N2 : EurobalizaConmutable
    {
        public ETCS_MAIN_N2()
        {
            EsPrimera = true;
        }
        protected override List<string> ConstruirMensajes() 
        {
            SendSignalMessage(NextSignalId("NORMAL"), "ETCS_N2");
            List<string> msg = new List<string>();
            Aspecto asp = GetAspectoSenal(NextSignalId("NORMAL"));
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
                    msg.Add(create_packet(137, "0", 1));
                    break;
                default:
                    msg.Add(create_packet(137, "1", 1));
                    break;
            }
            msg.AddRange(base.ConstruirMensajes());
            return msg;
        }
    }
	public class ETCS_RETROCESO : EurobalizaConmutable
	{
        public ETCS_RETROCESO()
        {
            EsPrimera = true;
            BaliseReaction = 1;
        }
        protected override List<string> ConstruirMensajes() 
        {
            var msg = base.ConstruirMensajes();
            msg.Add(get_linking());
            Aspect asp = IdSignalAspect(NextSignalId("NORMAL"),"NORMAL");
            msg.Add(create_packet(132, (asp == Aspect.Stop || asp == Aspect.Restricting) ? "0" : "1", 1));
            msg.Add(create_packet(137, (asp == Aspect.Stop || asp == Aspect.Restricting || asp == Aspect.StopAndProceed) ? "0" : "1", 1));
            return msg;
        }
    }
	public class ETCS_DEFAULT_1_1 : EurobalizaFija
	{
        public ETCS_DEFAULT_1_1()
        {
            EsPrimera = true;
        }
        protected override List<string> ConstruirMensajes() 
        {
            List<string> msg = new List<string>();
            msg.Add(get_linking());
            msg.AddRange(base.ConstruirMensajes());
            return msg;
        }
		Dictionary<string, Aspecto> textoAAspecto;
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
            float dist=0;
            for (int i=0; i<5; i++)
            {
                if (HasHead(i+1)) dist += 20*(1<<i);
            }
            if (dist == 0) dist=500;
            msg.Add(level_tr(dist, level_table(new List<int>{1}, dist/2)));
            return msg;
        }
    }
	public class ETCS_LEVELTR_ANNOUNCEMENT_1_FIJA_1_2 : EurobalizaFija
	{
        public ETCS_LEVELTR_ANNOUNCEMENT_1_FIJA_1_2()
        {
            EsPrimera = true;
            BaliseReaction = 1;
        }
        protected override List<string> ConstruirMensajes() 
        {
            List<string> msg = new List<string>();
            msg.Add(get_linking());
            msg.Add(level_tr(-1, level_table(new List<int>{2,5,1}, 500)));
            return msg;
        }
    }
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

	public class ETCS_LEVELTR_ANNOUNCEMENT_LINKED_1_2 : EurobalizaConmutable
	{
        public ETCS_LEVELTR_ANNOUNCEMENT_LINKED_1_2()
        {
            EsPrimera = true;
            BaliseReaction = 1;
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

	public class ETCS_LEVELTR_ORDER_LINKED_1_2 : EurobalizaConmutable
	{
        public ETCS_LEVELTR_ORDER_LINKED_1_2()
        {
            EsPrimera = true;
            BaliseReaction = 1;
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
    
    public class ETCS_LEVELTR : PaqueteETCS
    {
        public ETCS_LEVELTR()
        {
            Reaction = 1;
        }
        public override void UpdatePacket()
        {
            Packet = "";
            float dist=0;
            for (int i=0; i<7; i++)
            {
                if (HasHead(i+1)) dist += 50*(1<<i);
            }
            
            int levelId = NextSignalId("ETCS_LEVEL");
            int lsig = IdSignalLocalVariable(levelId, 601);
            if (levelId >= 0 && (lsig == NextSignalId("NORMAL", 0)  || lsig == NextSignalId("NORMAL", 1)))
            {
                Packet = level_tr(dist, level_table(levelId, Math.Min(350, dist/2+50)));
            }
            base.UpdatePacket();
        }
    }
    
    public class ETCS_STOPSR : PaqueteETCS
	{
        public ETCS_STOPSR()
        {
            Reaction = 1;
        }
        public override void UpdatePacket()
        {
            Packet = create_packet(137, "0", 1);
            base.UpdatePacket();
        }
    }
    public class ETCS_MSG_TUNNEL : PaqueteETCS
    {
        public override void UpdatePacket()
        {
            Packet = "{tunnel_msg(0)}";
            base.UpdatePacket();
        }
    }
    public class ETCS_MSG_VIADUCTO : PaqueteETCS
    {
        public override void UpdatePacket()
        {
            Packet = "{viaducto_msg(0)}";
            base.UpdatePacket();
        }
    }
    public class ETCS_MSG_BRIDGE : PaqueteETCS
    {
        public override void UpdatePacket()
        {
            Packet = "{puente_msg(0)}";
            base.UpdatePacket();
        }
    }
}
