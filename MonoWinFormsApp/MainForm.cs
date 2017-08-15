using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using SensorsDataLib;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace MonoWinFormsApp
{
    delegate void SomeDelegate(string msg);
    
    public partial class MainForm : Form
    {
        static bool t_continue = true;
        Thread t;
        static SomeDelegate sd;
        static IAsyncResult asyncRes;

        static SensorData Sensor_A, Sensor_B;
        FileStream SendSensorData;
        FileStream ReadSensorData;
        public MainForm()
        {
            InitializeComponent();
            Thread t = new Thread(new ThreadStart(Thread_Function_ReadDataFromServer));

            byte[] data;
            //using (var ms = new MemoryStream())
            //{
            //    Serializer.Serialize(ms, cust);
            //    data = ms.ToArray();
            //}

            Sensor_A = new SensorData();
            Sensor_A.Name = "Sensor A";

            // Serialyze MemoryStream
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, Sensor_A);
                data = ms.ToArray();
            }
            // DeSerialyze MemoryStream
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(data, 0, data.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                Sensor_B = (SensorData)obj;
                textBox_Tab_TSP_UDP_Rx.Text = Sensor_B.Name;
            }


            // Serialization File
            BinaryFormatter formatter = new BinaryFormatter();
            using (SendSensorData = new FileStream("./SensorsInfo.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(SendSensorData, Sensor_A);

            }
            // DeSerialization File
            //Восстановим состояние объекта
            using (var fStream = File.OpenRead("./SensorsInfo.dat"))
            {
                Sensor_B = (SensorData)formatter.Deserialize(fStream);

            }
            textBox_Tab_TSP_UDP_Rx.Text = Sensor_B.Name;




             sd = ParseMessageOverDelegate;
            // sd("Hello rfom Delegate");
            asyncRes = sd.BeginInvoke("Hello from Delegate", null, null);
            t.Start();            
        }

        // Convert an object to a byte array
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        // Convert a byte array to an Object
        public static Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }

        void ParseMessageOverDelegate(string msg)
        {
            Thread.Sleep(1000);
            AppendTextBox(msg);
            try
            {
                sd.EndInvoke(asyncRes);
            }
            catch { }
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            else
            {
                // textBox_Tab_TSP_UDP_Rx.Text += value;
                // textBox_Tab_TSP_UDP_Rx.Text += "\r\n";
                textBox_Tab_TSP_UDP_Rx.AppendText(value);
                textBox_Tab_TSP_UDP_Rx.AppendText("\r\n");
            }
        }

        void append_text(string msg)
        {
            try
            {
                // textBox_Tab_TSP_UDP_Rx.AppendText(msg);
                // textBox_Tab_TSP_UDP_Rx.AppendText("\r\n");
            }
            catch { }
        }

        public void Thread_Function_ReadDataFromServer()
        {

            while (t_continue == true)
            {
                if (RxEnDataFromServer == true)
                {
                    RxEnDataFromServer = false;
                    UpdateTextbox1(RxDataFromServer);
                }
                if (RxEnObjectDataFromServer == true)
                {
                    RxEnObjectDataFromServer = false;
                    UpdateTextbox1(RxObjectDataFromServer);
                }
                Thread.Sleep(0);
            }
        }

        private void button_Tab_TSP_UDP_Connect_Click(object sender, EventArgs e)
        {
            if (button_Tab_TSP_UDP_Connect.Text == "Connect")
            {
                button_Tab_TSP_UDP_Connect.Text = "Disconnect";
                Init_UDP_Client();
            }
            else
            {
                button_Tab_TSP_UDP_Connect.Text = "Connect";
            }
        }

        private void button_Tab_TSP_UDP_Send_Click(object sender, EventArgs e)
        {
            try
            {
                SendMessageToServer(textBox_Tab_TSP_UDP_Send.Text);
            }
            catch { }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((t != null) && (t.ThreadState == ThreadState.Running))
            {
                t.Join();
                Thread.Sleep(500);
            }
            t_continue = false;
        }

        private void textBox_Tab_TSP_UDP_Send_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox_Tab_TSP_UDP_Rx.AppendText(textBox_Tab_TSP_UDP_Send.Text);
                textBox_Tab_TSP_UDP_Rx.AppendText("\r\n");
                SendMessageToServer(textBox_Tab_TSP_UDP_Send.Text);
                textBox_Tab_TSP_UDP_Send.Clear();
            }
        }

        private void button_Send_Serialized_Obj_Click(object sender, EventArgs e)
        {
            try
            {
                //IEnumerable en = (IEnumerable)SendSensorData;
                //byte[] myBytes = en.OfType<byte>().ToArray();
                //SendMessageToServer(myBytes);

                byte[] data;
                // Serialyze MemoryStream
                BinaryFormatter bf = new BinaryFormatter();
                using (var ms = new MemoryStream())
                {
                    bf.Serialize(ms, Sensor_A);
                    data = ms.ToArray();
                    SendMessageToServer(data);
                }


            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
                throw;
            }
            finally
            {
                // fs.Close();
            }
        }
    }
}
