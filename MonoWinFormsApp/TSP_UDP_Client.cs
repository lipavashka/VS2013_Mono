using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;

//using System.Threading;
using SensorsDataLib;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace MonoWinFormsApp
{
    public partial class MainForm : Form
    {
        static UdpUser client;
        static bool RxEnDataFromServer = false;
        static string RxDataFromServer = null;

        static bool RxEnObjectDataFromServer = false;
        static string RxObjectDataFromServer = null;

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
            public void Send(byte [] message)
            {
                Client.Send(message, message.Length);
            }
        }




        [STAThread]
        static void Init_UDP_Client()
        {
            //create a new client
            // var client_2 = UdpUser.ConnectTo("192.168.0.177", 5000); // var client = UdpUser.ConnectTo("127.0.0.1", 32123);
            // UdpUser client;
            // client_3 = UdpUser.ConnectTo("192.168.0.177", 5000);
            client = UdpUser.ConnectTo("192.168.0.177", 5000);
            //wait for reply messages from server and send them to console 
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    try
                    {
                        var received = await client.Receive();
                        // Console.WriteLine(received.Message);
                        RxEnDataFromServer = true;
                        RxDataFromServer = received.Message;
                        // byte[] data = new byte[received.Message.Length];


                        byte[] data = new byte[received.Message.Length * sizeof(char)];
                        System.Buffer.BlockCopy(received.Message.ToCharArray(), 0, data, 0, data.Length);

                        data = Encoding.ASCII.GetBytes(received.Message);

                        // Serialyze MemoryStream
                        //BinaryFormatter bf = new BinaryFormatter();
                        //using (var ms = new MemoryStream())
                        //{
                        //    bf.Serialize(ms, received);
                        //    data = ms.ToArray();
                        //}


                        // DeSerialyze MemoryStream
                        using (var memStream = new MemoryStream())
                        {
                            var binForm = new BinaryFormatter();
                            memStream.Write(data, 0, data.Length);
                            memStream.Seek(0, SeekOrigin.Begin);
                            var obj = binForm.Deserialize(memStream);
                            Sensor_B = (SensorData)obj;
                            RxObjectDataFromServer = Sensor_B.Name;
                            RxEnObjectDataFromServer = true;
                           // textBox_Tab_TSP_UDP_Rx.Text = Sensor_B.Name;
                        }

                        // asyncRes = sd.BeginInvoke(received.Message, null, null);

                        //if (received.Message.Contains("quit"))
                        //    break;
                    }
                    catch (Exception ex)
                    {
                        // Debug.Write(ex);
                    }
                }
            });

            //type ahead :-)
            //string read = " ";
            //do
            //{
            //    read = Console.ReadLine();
            //    client.Send(read);
            //} while (read != "quit");

        }

        void SendMessageToServer(string msg)
        {
            try
            {
                client.Send(msg);
            }
            catch { }
        }

        void SendMessageToServer(byte [] msg)
        {
            try
            {
                client.Send(msg);
            }
            catch { }
        }

        string RxMesageFromServer()
        {
            string msg = null;
            return msg;
        }

        void UpdateTextbox1(string text)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<string>(UpdateTextbox1), text);
                }
                else
                {
                    textBox_Tab_TSP_UDP_Rx.AppendText(text);
                    textBox_Tab_TSP_UDP_Rx.AppendText("\r\n");
                }
            }
            catch { }
        }

    }
}