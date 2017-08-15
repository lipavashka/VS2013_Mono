using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using System.IO;

namespace Mono_Temp_ADC_AD7298
{
    class Program
    {
        static System.Timers.Timer t1;
        static string OS_str;
        static Process proc_temp_raw, proc_temp_offset, proc_temp_scale;
        public static void Main(string[] args)
        {
            // Temp RAW
            proc_temp_raw = new Process();
            proc_temp_raw.EnableRaisingEvents = false;
            proc_temp_raw.StartInfo.UseShellExecute = false;
            proc_temp_raw.StartInfo.RedirectStandardOutput = true;
            proc_temp_raw.StartInfo.FileName = "cat";
            proc_temp_raw.StartInfo.Arguments = @"/sys/bus/iio/devices/iio:device0/in_temp0_raw";
            proc_temp_raw.Start();

            // Temp Offset
            proc_temp_offset = new Process();
            proc_temp_offset.EnableRaisingEvents = false;
            proc_temp_offset.StartInfo.UseShellExecute = false;
            proc_temp_offset.StartInfo.RedirectStandardOutput = true;
            proc_temp_offset.StartInfo.FileName = "cat";
            proc_temp_offset.StartInfo.Arguments = @"/sys/bus/iio/devices/iio:device0/in_temp0_offset";
            proc_temp_offset.Start();

            // Temp Scale
            proc_temp_scale = new Process();
            proc_temp_scale.EnableRaisingEvents = false;
            proc_temp_scale.StartInfo.UseShellExecute = false;
            proc_temp_scale.StartInfo.RedirectStandardOutput = true;
            proc_temp_scale.StartInfo.FileName = "cat";
            proc_temp_scale.StartInfo.Arguments = @"/sys/bus/iio/devices/iio:device0/in_temp0_scale";
            proc_temp_scale.Start();

            Read_Temp_Data();
       
            System.OperatingSystem osInfo;
            // One second timer
            t1 = new System.Timers.Timer(1000);
            t1.Elapsed += new ElapsedEventHandler(OneSeconTimeEvent);
            t1.Interval = 250;
            


            Console.WriteLine("Read Quark temperature");
            // determine the OS 
            osInfo = System.Environment.OSVersion;
            Console.WriteLine("OS is " + osInfo.Platform); // 		Win32NT
            OS_str = osInfo.Platform.ToString();
            if (OS_str == "Win32NT")
            {
                Console.WriteLine("In the Win32NT not support MCU temperature");
            }
            else if (OS_str == "Unix")
            {
                Console.WriteLine("Temperature MCU: " + get_ADC_Temp());
            }
            else
            {
                Console.WriteLine("ERROR OS");
            }
            Console.WriteLine("This is a message was writtin in C#.");
            Console.WriteLine("Mono runs .Net applications in Linux.");
            Console.WriteLine("Press any key to exit.....");
            t1.Enabled = true;
            Console.ReadKey();
        }

        private static void Read_Temp_Data()
        {

            Process proc;
            // Temp RAW
            proc = new Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.FileName = "cat";
            proc.StartInfo.Arguments = @"/sys/bus/iio/devices/iio:device0/in_temp0_raw";
            proc.Start();
            proc.WaitForExit();



        
            //proc_temp_raw.Start();
            // Synchronously read the standard output of the spawned process. 
            StreamReader reader = proc.StandardOutput;
            proc = null;
            string output = reader.ReadToEnd();
            Console.WriteLine("Raw: " + output);
            
            //reader = proc_temp_offset.StandardOutput;
            //output = reader.ReadToEnd();
            //Console.WriteLine("Offset: " + output);

            //reader = proc_temp_scale.StandardOutput;
            //output = reader.ReadToEnd();
            //Console.WriteLine("Scale: " + output);
        }

        static int get_ADC_Temp()
        {
            try
            {
                string tmp_file = System.IO.File.ReadAllText(@"/sys/bus/iio/devices/iio:device0/in_temp0_raw");
                string tmp_str = tmp_file.ToString();
                // Console.WriteLine("Raw: " + tmp_str);
                return (Convert.ToInt32(Convert.ToDouble(tmp_str))) / 1;
            }
            catch
            {
                return 1234567890;
            }
        }
        static int get_ADC_Scale()
        {
            try
            {
                string tmp_file = System.IO.File.ReadAllText(@"/sys/bus/iio/devices/iio:device0/in_temp0_scale");
                string tmp_str = tmp_file.ToString();
                return (Convert.ToInt32(Convert.ToDouble(tmp_str))) / 1;
            }
            catch
            {
                return 1224567890;
            }
        }
        static int get_ADC_Offset()
        {
            try
            {
                string tmp_file = System.IO.File.ReadAllText(@"/sys/bus/iio/devices/iio:device0/in_temp0_offset");
                string tmp_str = tmp_file.ToString();
                return (Convert.ToInt32(Convert.ToDouble(tmp_str))) / 1;
            }
            catch
            {
                return 1334567890;
            }
        }

        static void OneSeconTimeEvent(object source, ElapsedEventArgs e)
        {
            t1.Enabled = false;
            if (OS_str == "Win32NT")
            {
                Console.WriteLine("In the Win32NT not support MCU temperature");
            }
            else if (OS_str == "Unix")
            {
                try
                {
                DateTime now = DateTime.Now;              
                float temp = (get_ADC_Temp() + get_ADC_Offset()) * get_ADC_Scale();  //Calculate temperature in milli-degrees celcius
                temp /= 1000;                         //divide by 1000 to convert to degrees celcius
                Console.WriteLine(now.TimeOfDay.ToString() + " Temperature ADC: " + temp.ToString("F2"));
                }
                catch { }
            }
            else
            {
                Console.WriteLine("ERROR OS");
            }
            t1.Enabled = true;
        }

    }
}




