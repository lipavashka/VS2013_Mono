using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Timers;
// using Mono_GPIO;

namespace Mono_GPIO
{
    class Program
    {
        static string text;
        static int cnt;
        static GPIO GPIO_3;
        static void Main()
        {
            GPIO_3 = new GPIO ();
            GPIO_3.Init_GPIO("3", "out");
            System.Timers.Timer t1, t2;
            cnt = 0;

            try
            {
                int p = (int)Environment.OSVersion.Platform;
                if ((p == 4) || (p == 6) || (p == 128))
                {
                    Console.WriteLine("Running on Unix");
                }
                else
                {
                    Console.WriteLine("NOT running on Unix");
                }

                t1 = new System.Timers.Timer(1000);
                t1.Elapsed += new ElapsedEventHandler(OnTimeEvent);
                t1.Interval = 100;
                t2 = new System.Timers.Timer(1000);
                t2.Elapsed += new ElapsedEventHandler(OnTime2Event);
                t2.Interval = 1000;                
                Thread.Sleep(100);
                t1.Enabled = true;
                Thread.Sleep(10);
                t2.Enabled = true;
            }
            catch
            {
                Console.WriteLine("Error Execution command");
            }
            Console.WriteLine("\n\nPress any key to exit.");
            Console.ReadLine();
        }

        static private void OnTimeEvent(object source, ElapsedEventArgs e)
        {
            if (text == "0")
            {
                text = "1";
            }
            else
            {
                text = "0";
            }
            GPIO_3.Set_GPIO(text);
            cnt++;
        }
        static private void OnTime2Event(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Cnt: " + cnt.ToString());
            cnt = 0;
        }
    }
}
