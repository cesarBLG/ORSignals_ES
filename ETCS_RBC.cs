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
    public class EtcsRbcManager
    {
        public static EtcsRbcManager DefaultRbc;

        static Assembly RbcAssembly;
        static bool AssemblyLoadTried;
        object Rbc;
        MethodInfo? RbcUpdate;

        public bool Active { get; private set; }

        public int NID_C { get; private set; }
        public int NID_RBC { get; private set; }
        public ulong NID_RADIO { get; private set; } = 0xFFFFFFFFFFFFFFFFUL;

        Task<string> ipTask;

        public EtcsRbcManager(int nid_c)
        {
            NID_C = nid_c;

            byte[] firstMacAddress = NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Select(nic => nic.GetPhysicalAddress().GetAddressBytes())
                .FirstOrDefault();
            if (firstMacAddress != null)
            {
                if (firstMacAddress.Length > 1) NID_RBC = ((firstMacAddress[firstMacAddress.Length - 2] << 8) | firstMacAddress[firstMacAddress.Length - 1]) & 16383;
                else if (firstMacAddress.Length > 0) NID_RBC = firstMacAddress[0] & 255;
            }

            ipTask = GetIpAddress();

            try
            {
                if (!AssemblyLoadTried)
                {
                    AssemblyLoadTried = true;
                    byte[] bytes = System.IO.File.ReadAllBytes(Path.Combine(ETCS.RouteDirectoryPath, "RBC.dll"));
                    byte[] bytesPdb = null;
                    var pdbPath = Path.Combine(ETCS.RouteDirectoryPath, "RBC.pdb");
                    if (File.Exists(pdbPath)) bytesPdb = System.IO.File.ReadAllBytes(pdbPath);
                    RbcAssembly = bytesPdb != null ? Assembly.Load(bytes, bytesPdb) : Assembly.Load(bytes);
                }
                if (RbcAssembly != null)
                {
                    var ty = RbcAssembly.GetType("RBC.RBC");
                    var ctor = ty.GetConstructor(new[] { typeof(int), typeof(int), typeof(int) });
                    Rbc = ctor.Invoke(new object[] { NID_C, NID_RBC, 0x7911 });
                    RbcUpdate = ty.GetMethod("Update");
                    Active = true;
                }
                else
                {
                    Active = false;
                }
            }
            catch (Exception e)
            {
                Active = false;
                Console.WriteLine(e);
            }
        }
        public void Update()
        {
            if (ipTask != null && ipTask.IsCompleted)
            {
                string localIP = ipTask.Result;
                Console.WriteLine("IP RBC: " + localIP);
                ulong IP = 0;
                string[] bytes = localIP.Split('.');
                for (int i = 0; i < bytes.Length; i++)
                {
                    IP = IP << 8 | ulong.Parse(bytes[i]);
                }
                NID_RADIO = ulong.Parse((IP << 16 | 30993).ToString(), System.Globalization.NumberStyles.HexNumber);
                ipTask = null;
            }
            if (Rbc != null)
            {
                try
                {
                    RbcUpdate.Invoke(Rbc, null);
                }
                catch (Exception e)
                {
                    Active = false;
                    Rbc = null;
                    Console.WriteLine(e);
                }
            }
        }
        
        public static async Task<string> GetIpAddress()
        {
            string localIP = null;
            try
            {
                /*if (MPManager.IsMultiPlayer())
                {
                    //localIP = (await new HttpClient().GetStringAsync("http://ipv4.icanhazip.com")).Replace("\\r\\n", "").Replace("\\n", "").Trim();
                    localIP = "127.0.0.1";
                }
                else*/
                foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
                {
                    // Check if the interface is Hamachi (it typically contains "Hamachi" in its name)
                    if (netInterface.Name.Contains("Hamachi") && netInterface.OperationalStatus == OperationalStatus.Up)
                    {
                        // Get the unicast IP addresses for this interface
                        foreach (UnicastIPAddressInformation ipAddress in netInterface.GetIPProperties().UnicastAddresses)
                        {
                            // We are interested in IPv4 addresses (ignoring IPv6 for simplicity)
                            if (ipAddress.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                localIP = ipAddress.Address.ToString();
                                break;
                            }
                        }
                    }
                }
                if (localIP == null)
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
            return localIP;
        }
    }
}