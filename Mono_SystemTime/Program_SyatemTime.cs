using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Mono_SystemTime
{

    class Program_SyatemTime
    {


        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }


 


        static string OS_str;
        public static void Main(string[] args)
        {
            System.Timers.Timer t1;
            System.OperatingSystem osInfo;

            Console.WriteLine("get current time");
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
                DateTime now = DateTime.Now;
                Console.WriteLine("Current time: " + now.ToString());

                now = DateTime.Now;
                Console.WriteLine("Changed Current time: " + now.ToString());

            }
            else
            {
                Console.WriteLine("ERROR OS");
            }
            Console.WriteLine("This is a message was writtin in C#.");
            Console.WriteLine("Mono runs .Net applications in Linux.");
            // Console.WriteLine("Press any key to exit.....");
            // Console.ReadKey();
        }
    }
}
