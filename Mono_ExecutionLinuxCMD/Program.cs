using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Diagnostics;
//using System.ComponentModel;
using System.IO;

namespace Mono_ExecutionLinuxCMD
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Start execution command!");
                Process proc = new Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                //proc.StartInfo.FileName = "fdisk";// "ls";
                //proc.StartInfo.Arguments = "-l"; // "-l | grep NTFS";
                proc.StartInfo.FileName = "cat";// "fdisk";// "ls";
                proc.StartInfo.Arguments = @"/sys/bus/iio/devices/iio:device0/in_temp0_raw"; // "-l"; // "-l | grep NTFS";
                proc.Start();
                //proc.BeginOutputReadLine();
                //proc.WaitForExit();


                // Synchronously read the standard output of the spawned process. 
                StreamReader reader = proc.StandardOutput;
                string output = reader.ReadToEnd();

                // Write the redirected output to this application's window.
                Console.WriteLine(output);
                Console.WriteLine("Otput: " + output);

                proc.WaitForExit();
                proc.Close();

                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Error execution command!");
            }
        }
    }
}
