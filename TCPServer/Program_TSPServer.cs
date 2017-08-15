using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TCPServer
{
    class Program_TSPServer
    {
        static Socket client;
        static NetworkStream netstream;

        [STAThread]
        static void Main(string[] args)
        {
            // Console.Title = "Server";
            string IP_Adr;
            int Port = 8080;
            // determine the OS
            System.OperatingSystem osInfo = System.Environment.OSVersion;
            Console.WriteLine("OS is " + osInfo.Platform);
            string OS_str = osInfo.Platform.ToString();
            if (OS_str == "Win32NT")
            {
                Console.Title = "Server";
                IP_Adr = "192.168.0.5";
            }
            else if (OS_str == "Unix")
            {                        
                IP_Adr = "192.168.0.177";
            }
            else
            {
                IP_Adr = "127.0.0.1";
                Console.WriteLine("ERROR OS");
            }

            Console.WriteLine("Connected: IP " + IP_Adr + ":" + Port);
            IPAddress ipAddress = IPAddress.Parse(IP_Adr);
            TcpListener tcpListener = new TcpListener(ipAddress, Port);
            
                // IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                // IPAddress ipAddress = IPAddress.Parse("192.168.0.177");
                // TcpListener tcpListener = new TcpListener(ipAddress, 8080);
            try
            {
                tcpListener.Start();
                Console.WriteLine("Server is running");
            }
            catch
            {
                Console.WriteLine("Error Server");
            }

            try
            {
                while (true)
                {
                    client = tcpListener.AcceptSocket();

                    if (client.Connected)
                    {
                        Console.WriteLine("Client connected " + client.RemoteEndPoint.ToString());
                        Thread thread = new Thread(new ParameterizedThreadStart(listenClient));
                        thread.Start(client);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        static void listenClient(object data)
        {
            while (client.Connected)
            {
                try
                {
                    client = (Socket)data;
                    netstream = new NetworkStream(client);
                    StreamWriter streamWriter = new StreamWriter(netstream); // to client
                    StreamReader streamReader = new StreamReader(netstream); // from client
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
