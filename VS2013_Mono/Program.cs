using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace HelloWorld
{
    public class ProgramHello
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // determine the OS
            System.OperatingSystem osInfo = System.Environment.OSVersion;
            Console.WriteLine("OS is " + osInfo.Platform);
            Console.WriteLine("This is a message was writtin in C#.");
            Console.WriteLine("Mono runs .Net applications in Linux.");
            Console.WriteLine("Press any key to exit.....");
            Console.ReadKey();
        }
    }
}

//Reference articles
//http://www.mono-project.com/docs/getting-started/install/linux/#debian-ubuntu-and-derivatives
//http://www.mono-project.com/docs/getting-started/mono-basics
