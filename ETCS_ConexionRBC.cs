using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
    public class ETCS_CONEXION_RBC : PaqueteETCS
    {
        int NID_C;
        int NID_RBC;
        ulong NID_RADIO = 0xFFFFFFFFFFFFFFFFUL;
        bool Connect;
        public ETCS_CONEXION_RBC()
        {
            /*IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName()).Where(ip => !Net.IPAddress.IsLoopback(ip));
            if (localIPs.Length > 0)
            {
                ulong IP = 0;
                var bytes = localIPs[0].GetAddressBytes();
                for (int i=0; i<bytes.Length; i++) {
                    IP = IP<<8 | bytes[i];
                }
                NID_RADIO = IP<<16 | 5015;
                Console.WriteLine("Conexion RBC:");
                Console.WriteLine(bytes);
                Console.WriteLine(NID_RADIO);
            }*/
        }
        public override void UpdatePacket()
        {
            Connect = !HasHead(1);
            Packet = create_packet(42, (Connect ? "1" : "0")+format_binary(NID_C, 10)+format_binary(NID_RBC, 14)+format_binary(NID_RADIO, 64)+"0", 1);
            base.UpdatePacket();
        }
    }
}
