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
    class Program_udp_client
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

        //Client
        class UdpUser : UdpBase
        {
            private UdpUser() { }

            public static UdpUser ConnectTo(string hostname, int port)
            {
                var connection = new UdpUser();
                connection.Client.Connect(hostname, port);
                return connection;
            }

            public void Send(string message)
            {
                var datagram = Encoding.ASCII.GetBytes(message);
                Client.Send(datagram, datagram.Length);
            }
        }

        [STAThread]
        static void Main()
        {
            //create a new client 5000
            var client_2 = UdpUser.ConnectTo("192.168.0.177", 32000); // var client = UdpUser.ConnectTo("127.0.0.1", 32123);
            UdpUser client;
            client = UdpUser.ConnectTo("192.168.0.177", 32000);
            //wait for reply messages from server and send them to console 
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    try
                    {
                        var received = await client.Receive();
                        Console.WriteLine(received.Message);
                        if (received.Message.Contains("quit"))
                            break;
                    }
                    catch (Exception ex)
                    {
                        // Debug.Write(ex);
                    }
                }
            });

            //type ahead :-)
            string read;
            do
            {
                read = Console.ReadLine();
                client.Send(read);
            } while (read != "quit");

        }

    }
}








//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using System.Net;
//using System.Net.Sockets;
////using System.Windows.Forms;

//namespace tcp_udp
//{
//    class Program
//    {

//        public struct Received
//        {
//            public IPEndPoint Sender;
//            public string Message;
//        }

//        abstract class UdpBase
//        {
//            protected UdpClient Client;

//            protected UdpBase()
//            {
//                Client = new UdpClient();
//            }

//            public async Task<Received> Receive()
//            {
//                var result = await Client.ReceiveAsync();
//                return new Received()
//                {
//                    Message = Encoding.ASCII.GetString(result.Buffer, 0, result.Buffer.Length),
//                    Sender = result.RemoteEndPoint
//                };
//            }
//        }

//        ////Server
//        //class UdpListener : UdpBase
//        //{
//        //    private IPEndPoint _listenOn;

//        //    public UdpListener()
//        //        : this(new IPEndPoint(IPAddress.Any, 32123))
//        //    {
//        //    }

//        //    public UdpListener(IPEndPoint endpoint)
//        //    {
//        //        _listenOn = endpoint;
//        //        Client = new UdpClient(_listenOn);
//        //    }

//        //    public void Reply(string message, IPEndPoint endpoint)
//        //    {
//        //        var datagram = Encoding.ASCII.GetBytes(message);
//        //        Client.Send(datagram, datagram.Length, endpoint);
//        //    }

//        //}

//        //Client
//        class UdpUser : UdpBase
//        {
//            private UdpUser() { }

//            public static UdpUser ConnectTo(string hostname, int port)
//            {
//                var connection = new UdpUser();
//                connection.Client.Connect(hostname, port);
//                return connection;
//            }

//            public void Send(string message)
//            {
//                var datagram = Encoding.ASCII.GetBytes(message);
//                Client.Send(datagram, datagram.Length);
//            }
//        }

//        [STAThread]
//        static void Main()
//        {
//            ////create a new server
//            //var server = new UdpListener();

//            ////start listening for messages and copy the messages back to the client
//            //Task.Factory.StartNew(async () =>
//            //{
//            //    while (true)
//            //    {
//            //        var received = await server.Receive();
//            //        server.Reply("copy " + received.Message, received.Sender);
//            //        if (received.Message == "quit")
//            //            break;
//            //    }
//            //});

//            //create a new client
//            var client_2 = UdpUser.ConnectTo("192.168.0.6", 5000); // var client = UdpUser.ConnectTo("127.0.0.1", 32123);
//            UdpUser client;
//            client = UdpUser.ConnectTo("192.168.0.6", 5000);
//            //wait for reply messages from server and send them to console 
//            Task.Factory.StartNew(async () =>
//            {
//                while (true)
//                {
//                    try
//                    {
//                        var received = await client.Receive();
//                        Console.WriteLine(received.Message);
//                        if (received.Message.Contains("quit"))
//                            break;
//                    }
//                    catch (Exception ex)
//                    {
//                        // Debug.Write(ex);
//                    }
//                }
//            });

//            //type ahead :-)
//            string read;
//            do
//            {
//                read = Console.ReadLine();
//                client.Send(read);
//            } while (read != "quit");

//        }

//    }
//}
