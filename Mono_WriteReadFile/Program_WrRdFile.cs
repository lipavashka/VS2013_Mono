﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Mono_WriteReadFile
{
    public class Program_WrRdFile
    {
        public static void Main(string[] args)
        {
            
            ////////// Read write file //////////////
            try
            {
                // Read the file as one string. 
                string[] text = new string[2];
                // determine the OS
                System.OperatingSystem osInfo = System.Environment.OSVersion;
                Console.WriteLine("OS is " + osInfo.Platform);
                string OS_str = osInfo.Platform.ToString();
                if (OS_str == "Win32NT")
                {
                    text[0] = System.IO.File.ReadAllText(@"someText.txt");                   
                }
                else if (OS_str == "Unix")
                {
                    text[0] = System.IO.File.ReadAllText(@"someText.txt");  
                    // text[0] = System.IO.File.ReadAllText(@"/src/someText.txt");
                }
                else
                {
                    Console.WriteLine("ERROR OS");
                }
                text[1] = "Write data to file";
                System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
                System.IO.File.WriteAllLines(@"someText.txt", text);
            }
            catch
            {
                Console.WriteLine("Error read file");
            }
            Console.WriteLine("This is a message was writtin in C#.");
            Console.WriteLine("Mono runs .Net applications in Linux.");
            Console.WriteLine("Press any key to exit.....");
            Console.ReadKey();
        }
    }
}
