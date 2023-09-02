using Orts.MultiPlayer;
using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Reflection;

namespace ORTS.Scripting.Script
{
    public class ETCS_CONEXION_RBC : PaqueteETCS
    {
        static int NID_RBC;
        static ulong NID_RADIO = 0xFFFFFFFFFFFFFFFFUL;
        static Task<string> ipTask;
        bool Connect;
        public static bool RbcActive;
        public static bool RbcActiveChecked;
        object RBC;
        MethodInfo? RBCUpdate;
        public ETCS_CONEXION_RBC()
        {
            if (ipTask == null)
            {
                ipTask = GetIpAddress();
            }
        }
        public static async Task<string> GetIpAddress()
        {
            string localIP;
            try
            {
                /*if (MPManager.IsMultiPlayer())
                {
                    //localIP = (await new HttpClient().GetStringAsync("http://ipv4.icanhazip.com")).Replace("\\r\\n", "").Replace("\\n", "").Trim();
                    localIP = "127.0.0.1";
                }
                else*/
                {
                    using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                    {
                        await socket.ConnectAsync("8.8.8.8", 65530);
                        IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                        localIP = endPoint.Address.ToString();
                    }
                }
            }
            catch(Exception e)
            {
                localIP = "127.0.0.1";
            }
            byte[] firstMacAddress = NetworkInterface
                .GetAllNetworkInterfaces()
                .Where( nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback )
                .Select( nic => nic.GetPhysicalAddress().GetAddressBytes() )
                .FirstOrDefault();
            if (firstMacAddress != null) NID_RBC = ((firstMacAddress[firstMacAddress.Length-2]<<8)|firstMacAddress[firstMacAddress.Length-1]) & 16383;
            return localIP;
        }
        public override void Update()
        {
            base.Update();
            if (RBC != null)
            {
                RBCUpdate.Invoke(RBC, null);
            }
        }
        public override void UpdatePacket()
        {
            if (ipTask != null && ipTask.IsCompleted)
            {
                string localIP = ipTask.Result;
                Console.WriteLine("IP RBC: "+localIP);
                ulong IP = 0;
                string[] bytes = localIP.Split('.');
                for (int i=0; i<bytes.Length; i++)
                {
                    IP = IP<<8 | ulong.Parse(bytes[i]);
                }
                NID_RADIO = ulong.Parse((IP<<16 | 30993).ToString(), System.Globalization.NumberStyles.HexNumber);
                ipTask = null;
            }
            if (!RbcActiveChecked)
            {
                try
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(Path.Combine(RouteDirectoryPath, "RBC.dll"));
                    var ass = Assembly.Load(bytes);
                    var ty = ass.GetType("RBC.RBC");
                    var ctor = ty.GetConstructor(new[] {typeof(int), typeof(int), typeof(int)});
                    RBC = ctor.Invoke(new object[] {NID_C, NID_RBC, 0x7911});
                    RBCUpdate = ty.GetMethod("Update");
                    RbcActive = true;
                }
                catch (Exception e)
                {
                    RbcActive = false;
                    Console.WriteLine(e);
                }
                /*try
                {
                    using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                    {
                        socket.Connect("127.0.0.1", 30993);
                    }
                    RbcActive = true;
                }
                catch (Exception e)
                {
                    RbcActive = false;
                }*/
                RbcActiveChecked = true;
            }
            if (RbcActive)
            {
                Connect = !HasHead(1);
                Packet = create_packet(42, (Connect ? "1" : "0")+format_binary(NID_C, 10)+format_binary(NID_RBC, 14)+format_binary(NID_RADIO, 64)+"0", 1);
            }
            else
            {
                Packet = "";
            }
            base.UpdatePacket();
        }
    }
}
