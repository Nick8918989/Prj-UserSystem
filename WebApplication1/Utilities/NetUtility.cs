using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApplication1.Utilities
{
    public class NetUtility
    {
        public static string GetServerIPAddress()
        {
            IPAddress[] list = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var ip in list)
            {
                string ipString = ip.ToString();

                if (!IPAddress.IsLoopback(ip) && !ipString.StartsWith("169.254") && !ipString.StartsWith("fe80::", StringComparison.OrdinalIgnoreCase) &&
                    (ip.AddressFamily.Equals(System.Net.Sockets.AddressFamily.InterNetwork) /*|| ip.AddressFamily.Equals(System.Net.Sockets.AddressFamily.InterNetworkV6)*/))
                {
                    return ipString;
                }
            }
            return string.Empty;
        }
    }
}