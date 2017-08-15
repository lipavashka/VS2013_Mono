using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
//using System.Windows.Forms;

namespace tcp_udp
{
    class Program_udp_server
    {

        public struct Received
        {
            public IPEndPoint Sender;
            public string Message;
        }

        abstract class UdpBase
        {
            protected UdpClient Client;

            protected UdpBase()
            {
                Client = new UdpClient();
            }

            public async Task<Received> Receive()
            {
                var result = await Client.ReceiveAsync();
                return new Received()
                {
                    Message = Encoding.ASCII.GetString(result.Buffer, 0, result.Buffer.Length),
                    Sender = result.RemoteEndPoint
                };
            }
        }

        //Server
        class UdpListener : UdpBase
        {
            private IPEndPoint _listenOn;

            public UdpListener()
                : this(new IPEndPoint(IPAddress.Any, 32000)) // this(new IPEndPoint(IPAddress.Any, 32123))
            {
            }

            public UdpListener(IPEndPoint endpoint)
            {
                _listenOn = endpoint;
                Client = new UdpClient(_listenOn);
            }

            public void Reply(string message, IPEndPoint endpoint)
            {
                var datagram = Encoding.ASCII.GetBytes(message);
                Client.Send(datagram, datagram.Length, endpoint);
            }

        }

        [STAThread]
        static void Main()
        {
            
            //create a new server
            var server = new UdpListener();
            // var serve_r = new Mono_UDP_Server();
            bool enable = true;
            //start listening for messages and copy the messages back to the client
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    var received = await server.Receive();
                    // server.Reply("copy " + received.Message, received.Sender);
                    server.Reply(received.Message, received.Sender);
                    // server.Reply("Hello from Server! Your message: " + received.Message, received.Sender);
                    Console.WriteLine("RX message: " + received.Message);
                    if (received.Message == "quit")
                    {
                        enable = false;
                        break;
                    }
                }
            });

          

            //type ahead :-)
            string read;
            bool start = true;
            do
            {
                // if (start == true)
                // {
                    start = false;
                    Console.WriteLine("Server running...");
                // }
                read = Console.ReadLine();
                // client.Send(read);
            } // while (enable != false); 
            while ((enable != false) && (read != "quit"));

        }

    }
}
