using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClassAct.Website.BL.Helpers
{
   public static class CHelper
    {
        public static void doSomething(string hostname)
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(hostname);
            foreach(IPAddress ip in host.AddressList)
            {
                Console.WriteLine(ip.ToString());
            }
        }
        public static void doSomething()
        {
            IPHostEntry ohost;
            string host = Dns.GetHostName();

         var ipAddresses = Dns.GetHostAddresses(host);
          //  IPEndPoint endpoint = //;
         Console.Write(ipAddresses.ToString());
        //  IPAddress.
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
