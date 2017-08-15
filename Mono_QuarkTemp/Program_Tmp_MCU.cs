using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Mono_QuarkTemp
{
    class Program_Tmp_MCU
    {
        static string OS_str;
        public static void Main(string[] args)
        {
            System.Timers.Timer t1;
            System.OperatingSystem osInfo;
            // One second timer
            t1 = new System.Timers.Timer(1000);
            t1.Elapsed += new ElapsedEventHandler(OneSeconTimeEvent);
            t1.Interval = 150;
            


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
                Console.WriteLine("Temperature MCU: " + getQuarkTemp());
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
        static int getQuarkTemp()
        {

            //FILE* fp;

            //fp = fopen("/sys/class/thermal/thermal_zone0/temp", "r");
            //fgets(temp_raw, 5, fp);
            //fclose(fp);

            //int temp = atoi(temp_raw);
            //temp /= 100;
            //return temp;

            try
            {
                string tmp_file = System.IO.File.ReadAllText(@"/sys/class/thermal/thermal_zone0/temp");
                string tmp_str = tmp_file.ToString();
                return (Convert.ToInt32(tmp_str)) / 1000;
            }
            catch 
            {
                return 12345678;
            }
        }

        static int get_ADC_Temp()
        {
            try
            {
                string tmp_file = System.IO.File.ReadAllText(@"/sys/bus/iio/devices/iio:device0/in_temp0_raw");
                string tmp_str = tmp_file.ToString();
                return (Convert.ToInt32(tmp_str)) / 1000;
            }
            catch
            {
                return 1234567890;
            }
        }


        static void OneSeconTimeEvent(object source, ElapsedEventArgs e)
        {
            if (OS_str == "Win32NT")
            {
                Console.WriteLine("In the Win32NT not support MCU temperature");
            }
            else if (OS_str == "Unix")
            {
                DateTime now = DateTime.Now;
                Console.WriteLine(now.TimeOfDay.ToString() + " Temperature MCU: " + getQuarkTemp());
                Console.WriteLine(now.TimeOfDay.ToString() + " Temperature ADC: " + get_ADC_Temp());
            }
            else
            {
                Console.WriteLine("ERROR OS");
            }
        }
    }
}
