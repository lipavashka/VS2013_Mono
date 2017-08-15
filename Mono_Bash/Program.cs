
/*$ cat /tmp/bash.sh 
 * #!/bin/bash
 * echo "bla $1"
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
//using System.ComponentModel;
using System.IO;

namespace Mono_Bash
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "bash.sh";
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;

            //string strOutput = psi.StandardOutput.ReadToEnd();
            //psi.WaitForExit();
            //Console.WriteLine(strOutput);




            //psi.Arguments = "test";
            //Process p = Process.Start(psi);
            //strOutput = p.StandardOutput.ReadToEnd();
            //p.WaitForExit();
            //Console.WriteLine(strOutput);
        }
    }
}
