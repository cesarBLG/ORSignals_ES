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
            base.Initialize();
            string nom = SignalTypeName.Substring(14);
            LoadParameter("Estaciones", nom, ref Estacion);
        }
        public override void UpdatePacket(bool backfacing)
        {
            double end = 0;
            for (int i = 0; i < 8; i++)
            {
                if (HasHead(i + 1)) end += (1 << i) * 50;
            }
            if (end == 0) end = 1000;
            string txt = "Próx. Estación " + Estacion;
            byte[] ascii = System.Text.Encoding.GetEncoding(28591).GetBytes(txt);
            string pack = "01" + format_binary(0, 2) + "0" + format_etcs_distance(0) + format_binary(15, 4) + format_binary(5, 3) + format_etcs_distance(end) + format_binary(1023, 10) + format_binary(15, 4) + format_binary(5, 3) + format_binary(0, 2) + format_binary(ascii.Length, 8);
            for (int i = 0; i < ascii.Length; i++)
            {
                pack += format_binary((int)ascii[i], 8);
            }
            Packet = create_packet(72, pack, backfacing ? 0 : 1);
            base.UpdatePacket(backfacing);
        }
    }
    public class ETCS_BIFURCACION : PaqueteETCS
    {
        string Mensaje = "";
        public ETCS_BIFURCACION()
        {
        }
        Aspect aspect;
        int id;
        public override void Initialize()
        {
            base.Initialize();
            string dir = "";
            LoadParameter("Bifurcaciones", SignalTypeName.Substring(17), ref dir);
            float dist = 2300;
            float distHead = 0;
            for (int i = 0; i < 7; i++)
            {
                if (HasHead(i + 1)) distHead += (1 << i) * 50;
            }
            if (distHead > 0) dist = distHead;
            Mensaje = get_bifurcacion(dir, dist);
        }
        public override void Update()
        {
            int next_id = NextSignalId("NORMAL");
            var next_state = IdSignalAspect(id, "NORMAL");
            if (next_id != id || next_state != aspect) SharedVariables[KeyPacketNeedsUpdate] = 1;
            id = next_id;
            aspect = next_state;
            base.Update();
        }
        public override void UpdatePacket(bool backfacing)
        {
            bool show = false;
            if (Enabled && CurrentBlockState == BlockState.Clear)
            {
                var route_block_state = RouteClearedToSignal(id);
                var next_state = IdSignalAspect(id, "NORMAL");
                if (route_block_state == BlockState.Clear && aspect != Aspect.Stop && aspect != Aspect.StopAndProceed && aspect != Aspect.Restricting && RouteSet)
                {
                    show = true;
                }
            }
            Packet = show ? create_packet(72, Mensaje, backfacing ? 0 : 1) : "";
            base.UpdatePacket(backfacing);
        }
        string get_bifurcacion(string nombre, float length)
        {
            string txt = "Dir. " + nombre;
            byte[] ascii = System.Text.Encoding.GetEncoding(28591).GetBytes(txt);
            string msg = "10" + format_binary(1, 2) + "1" + format_binary(0, 15) + format_binary(0, 4) + format_binary(5, 3) + format_binary((int)(length / 10), 15) + format_binary(1023, 10) + format_binary(15, 4) + format_binary(5, 3) + format_binary(0, 2) + format_binary(ascii.Length, 8);
            for (int i = 0; i < ascii.Length; i++)
            {
                msg += format_binary((int)ascii[i], 8);
            }
            return msg;
        }
    }
    public class ETCS_MSG_TUNNEL : PaqueteETCS
    {
        public override void UpdatePacket(bool backfacing)
        {
            int ahead = 0;
            for (int i = 0; i < 5; i++)
            {
                if (HasHead(i + 1)) ahead += (1 << i);
            }
            if (!backfacing) Packet = "{tunnel_msg(" + ahead + ")}";
            base.UpdatePacket(backfacing);
        }
    }
    public class ETCS_MSG_VIADUCTO : PaqueteETCS
    {
        public override void UpdatePacket(bool backfacing)
        {
            int ahead = 0;
            for (int i = 0; i < 5; i++)
            {
                if (HasHead(i + 1)) ahead += (1 << i);
            }
            if (!backfacing) Packet = "{viaducto_msg(" + ahead + ")}";
            base.UpdatePacket(backfacing);
        }
    }
    public class ETCS_MSG_BRIDGE : PaqueteETCS
    {
        public override void UpdatePacket(bool backfacing)
        {
            int ahead = 0;
            for (int i = 0; i < 5; i++)
            {
                if (HasHead(i + 1)) ahead += (1 << i);
            }
            if (!backfacing) Packet = "{puente_msg(" + ahead + ")}";
            base.UpdatePacket(backfacing);
        }
    }
    public class ETCS_MSG_SALIDA_ERTMS : PaqueteETCS
    {
        public override void UpdatePacket(bool backfacing)
        {
            double dist = 0;
            for (int i = 0; i < 5; i++)
            {
                if (HasHead(i + 1)) dist += (1 << i) * 50;
            }
            string txt = (new string[] { "Salida de ERTMS", "Salida ERTMS" })[SignalId % 2];
            byte[] ascii = System.Text.Encoding.GetEncoding(28591).GetBytes(txt);
            string packet = "01" + format_binary(1, 2) + "0" + format_etcs_distance(0) + format_binary(15, 4) + format_binary(5, 3) + format_etcs_distance(dist) + format_binary(1023, 10) + format_binary(15, 4) + format_binary(5, 3) + format_binary(0, 2) + format_binary(ascii.Length, 8);
            for (int i = 0; i < ascii.Length; i++)
            {
                packet += format_binary((int)ascii[i], 8);
            }
            Packet = create_packet(72, packet, backfacing ? 0 : 1);
            base.UpdatePacket(backfacing);
        }
    }
    public class ETCS_MSG_ENTRADA_ERTMS : PaqueteETCS
    {
        public override void UpdatePacket(bool backfacing)
        {
            double dist = 0;
            for (int i = 0; i < 5; i++)
            {
                if (HasHead(i + 1)) dist += (1 << i) * 50;
            }
            string txt = "Entrada ERTMS";
            byte[] ascii = System.Text.Encoding.GetEncoding(28591).GetBytes(txt);
            string packet = "01" + format_binary(1, 2) + "0" + format_etcs_distance(0) + format_binary(15, 4) + format_binary(5, 3) + format_etcs_distance(dist) + format_binary(1023, 10) + format_binary(15, 4) + format_binary(5, 3) + format_binary(0, 2) + format_binary(ascii.Length, 8);
            for (int i = 0; i < ascii.Length; i++)
            {
                packet += format_binary((int)ascii[i], 8);
            }
            Packet = create_packet(72, packet, backfacing ? 0 : 1);
            base.UpdatePacket(backfacing);
        }
    }
    
	public class ETCS_MSG_APROXIMACIONZN : PaqueteETCS
    {
        public ETCS_MSG_APROXIMACIONZN()
        {
            Reaction = 1;
        }
        public override void UpdatePacket(bool backfacing)
        {
            double dist=0;
            for (int i=0; i<5; i++)
            {
                if (HasHead(i+1)) dist += (1<<i)*50;
            }
            string txt = "Aproximación a Zona Neutra";
            byte[] ascii = System.Text.Encoding.GetEncoding(28591).GetBytes(txt);
            string msg = "01" + format_binary(1,2) + "0" + format_etcs_distance(dist) + format_binary(15,4) + format_binary(5,3) + format_binary(32767,15) + format_binary(15,10) + format_binary(15,4) + format_binary(5,3) + format_binary(0,2) + format_binary(ascii.Length, 8);
            for (int i=0; i<ascii.Length; i++)
            {
                msg += format_binary((int)ascii[i],8);
            }
            Packet = create_packet(72, msg, backfacing ? 0 : 1);
            base.UpdatePacket(backfacing);
        }
    }
	public class ETCS_MSG_LLEGADAZN : PaqueteETCS
    {
        public ETCS_MSG_LLEGADAZN()
        {
            Reaction = 1;
        }
        public override void UpdatePacket(bool backfacing)
        {
            double dist=0;
            for (int i=0; i<5; i++)
            {
                if (HasHead(i+1)) dist += (1<<i)*50;
            }
            if (dist == 0) dist = 1000;
            double start = Math.Max(0, dist-1000);
            double end = dist-start;
            string txt = "Llegada a Zona Neutra";
            byte[] ascii = System.Text.Encoding.GetEncoding(28591).GetBytes(txt);
            string pack = "01" + format_binary(1,2) + "0" + format_etcs_distance(start) + format_binary(15,4) + format_binary(5,3) + format_etcs_distance(end) + format_binary(1023,10) + format_binary(15,4) + format_binary(5,3) + format_binary(0,2) + format_binary(ascii.Length, 8);
            for (int i=0; i<ascii.Length; i++)
            {
                pack += format_binary((int)ascii[i],8);
            }
            Packet = create_packet(72, pack, backfacing ? 0 : 1);
            base.UpdatePacket(backfacing);
        }
    }
	public class ETCS_MSG_APROXIMACIONZCT : PaqueteETCS
    {
        public override void UpdatePacket(bool backfacing)
        {
            double dist=0;
            for (int i=0; i<5; i++)
            {
                if (HasHead(i+1)) dist += (1<<i)*50;
            }
            string txt = "Aproximación a Zona de Cambio de Tensión";
            byte[] ascii = System.Text.Encoding.GetEncoding(28591).GetBytes(txt);
            string msg = "01" + format_binary(1,2) + "0" + format_etcs_distance(dist) + format_binary(15,4) + format_binary(5,3) + format_binary(32767,15) + format_binary(15,10) + format_binary(15,4) + format_binary(5,3) + format_binary(0,2) + format_binary(ascii.Length, 8);
            for (int i=0; i<ascii.Length; i++)
            {
                msg += format_binary((int)ascii[i],8);
            }
            Packet = create_packet(72, msg, backfacing ? 0 : 1);
            base.UpdatePacket(backfacing);
        }
    }
	public class ETCS_MSG_LLEGADAZCT : PaqueteETCS
    {
        public override void UpdatePacket(bool backfacing)
        {
            double dist=0;
            for (int i=0; i<5; i++)
            {
                if (HasHead(i+1)) dist += (1<<i)*50;
            }
            if (dist == 0) dist = 1000;
            double start = 0;
            double end = dist-start;
            string txt = "Llegada a Zona de Cambio de Tensión";
            byte[] ascii = System.Text.Encoding.GetEncoding(28591).GetBytes(txt);
            string pack = "01" + format_binary(1,2) + "0" + format_etcs_distance(start) + format_binary(15,4) + format_binary(5,3) + format_etcs_distance(end) + format_binary(1023,10) + format_binary(15,4) + format_binary(5,3) + format_binary(0,2) + format_binary(ascii.Length, 8);
            for (int i=0; i<ascii.Length; i++)
            {
                pack += format_binary((int)ascii[i],8);
            }
            Packet = create_packet(72, pack, backfacing ? 0 : 1);
            base.UpdatePacket(backfacing);
        }
    }
    public class ETCS_MSG_SECCIONAMIENTO : PaqueteETCS
	{
        public override void UpdatePacket(bool backfacing)
        {
            double dist = 0;
            for (int i=0; i<5; i++)
            {
                if (HasHead(i+1)) dist += (1<<i)*50;
            }
            double length = 600;
            string txt;
            if (SignalTypeName.Contains("lamina")) txt = "Seccionamiento de lámina";
            else if (SignalTypeName.Contains("aislador")) txt = "Aislador de sección";
            else txt = (new string[] { "Cierre del Regulador", "Cierre de regulador", "Cierre de Regulador" })[SignalId % 3];
            byte[] ascii = System.Text.Encoding.GetEncoding(28591).GetBytes(txt); 
            string packet = "01" + format_binary(1,2) + "0" + format_etcs_distance(dist) + format_binary(15,4) + format_binary(5,3) + format_etcs_distance(length) + format_binary(1023,10) + format_binary(15,4) + format_binary(5,3) + format_binary(0,2) + format_binary(ascii.Length, 8);   
            for (int i=0; i<ascii.Length; i++)
            {
                packet += format_binary((int)ascii[i],8);
            }
            Packet = create_packet(72, packet, backfacing ? 0 : 1);
            base.UpdatePacket(backfacing);
        }
    }
}
