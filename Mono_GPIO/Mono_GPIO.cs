using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mono_GPIO
{
    class GPIO
    {
        public void Init_GPIO(string port, string dir)
        {
            try
            {
                Console.WriteLine("Set_Enviroment");
                System.IO.File.WriteAllText(@"/sys/class/gpio/export", port);
                Console.WriteLine("Set Enviroment");
                Thread.Sleep(100);
                System.IO.File.WriteAllText(@"/sys/class/gpio/gpio3/direction", dir);
                Thread.Sleep(100);
            }
            catch 
            {
                Console.WriteLine("Enviroment already set");
            }
        }
        public void Set_GPIO(string state)
        {
            Console.WriteLine("Set GPIO: " + state);
            System.IO.File.WriteAllText(@"/sys/class/gpio/gpio3/value", state);
        }
    }
}
