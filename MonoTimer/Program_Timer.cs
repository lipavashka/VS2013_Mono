using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MonoTimer
{
    public class Program_Timer
    {
        public static int cnt = 0;
        public static void Main(string[] args)
        {

            System.Timers.Timer t1, t_each_secod;

            // One second timer
            t_each_secod = new System.Timers.Timer(1000);
            t_each_secod.Elapsed += new ElapsedEventHandler(OneSeconTimeEvent);
            t_each_secod.Interval = 1000;
            t_each_secod.Enabled = true;


            t1 = new System.Timers.Timer(100);
            t1.Elapsed += new ElapsedEventHandler(OnTimeEvent);
            t1.Interval = 5;
            t1.Enabled = true;

            Console.WriteLine("Press any key to exit.....");
            Console.ReadKey();

            // Start timers
            t_each_secod.Start();
            t1.Start(); 
            
        }

        static private void OneSeconTimeEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Timer interrupt ... " + cnt.ToString());
            cnt = 0;
        }

        static private void OnTimeEvent(object source, ElapsedEventArgs e)
        {
            cnt++;
        }
    }
}
