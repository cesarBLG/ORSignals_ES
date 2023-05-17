using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
	public class ETCS_MSG_APROXIMACIONZN : PaqueteETCS
    {
        public ETCS_MSG_APROXIMACIONZN()
        {
            Reaction = 1;
        }
        public override void UpdatePacket()
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
            Packet = create_packet(72, msg, 1);
            base.UpdatePacket();
        }
    }
	public class ETCS_MSG_LLEGADAZN : PaqueteETCS
    {
        public ETCS_MSG_LLEGADAZN()
        {
            Reaction = 1;
        }
        public override void UpdatePacket()
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
            Packet = create_packet(72, pack, 1);
            base.UpdatePacket();
        }
    }
	public class ETCS_MSG_APROXIMACIONZCT : PaqueteETCS
    {
        public override void UpdatePacket()
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
            Packet = create_packet(72, msg, 1);
            base.UpdatePacket();
        }
    }
	public class ETCS_MSG_LLEGADAZCT : PaqueteETCS
    {
        public override void UpdatePacket()
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
            Packet = create_packet(72, pack, 1);
            base.UpdatePacket();
        }
    }
    public class ETCS_MSG_SECCIONAMIENTO : PaqueteETCS
	{
        public override void UpdatePacket()
        {
            double dist = 0;
            for (int i=0; i<5; i++)
            {
                if (HasHead(i+1)) dist += (1<<i)*50;
            }
            double length = 600;
            string txt = (new string[]{"Cierre del Regulador", "Cierre de regulador", "Cierre de Regulador"})[SignalId%3];
            byte[] ascii = System.Text.Encoding.GetEncoding(28591).GetBytes(txt); 
            string packet = "01" + format_binary(1,2) + "0" + format_etcs_distance(dist) + format_binary(15,4) + format_binary(5,3) + format_etcs_distance(length) + format_binary(1023,10) + format_binary(15,4) + format_binary(5,3) + format_binary(0,2) + format_binary(ascii.Length, 8);   
            for (int i=0; i<ascii.Length; i++)
            {
                packet += format_binary((int)ascii[i],8);
            }
            Packet = create_packet(72,packet,1);
            base.UpdatePacket();
        }
    }
}
