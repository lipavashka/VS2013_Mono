using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    class Program_TCPClient
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Console.Title = "Client";
            string IP_Adr;
            int Port = 8080;
            TcpClient client = new TcpClient();
            Console.WriteLine("Connecting...");
            try
            {
                // determine the OS
                System.OperatingSystem osInfo = System.Environment.OSVersion;
                Console.WriteLine("OS is " + osInfo.Platform);
                string OS_str = osInfo.Platform.ToString();
                if (OS_str == "Win32NT")
                {
                    Console.Title = "Client";
                    IP_Adr = "192.168.0.177";
                    // client.Connect("192.168.0.177", 8080);
                }
                else if (OS_str == "Unix")
                {
                    IP_Adr = "192.168.0.5";
                    // client.Connect("192.168.0.5", 8080);
                }
                else
                {
                    IP_Adr = "127.0.0.1";
                    Console.WriteLine("ERROR OS");
                }

                Console.WriteLine("Connected: IP " + IP_Adr + ":" + Port);
                client.Connect(IP_Adr, Port);
                NetworkStream netstream = client.GetStream();
                StreamWriter streamWriter = new StreamWriter(netstream);
                StreamReader streamReader = new StreamReader(netstream);
            }
            catch
            {
                Console.WriteLine("Error:");
            }           

            Console.Read();

        }
    }
}
