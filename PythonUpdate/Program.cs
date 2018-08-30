using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMJENKINS
{
    class PythonShell
    {
        static void Main(string[] args)
        {
            if (args.Length != 14)
            {
                Console.WriteLine("args.Length = " + args.Length);
                Console.WriteLine("args[0] = " + args[0]);
                Console.WriteLine("All arguments not provided");
            }
            else
            {
                string pythonpath = "python.exe";

                // create process i.e., the python program
                Process p = new Process();                           
                p.StartInfo.UseShellExecute = false;
                // make sure we can read the output from stdout
                p.StartInfo.RedirectStandardOutput = true;           
                p.StartInfo.FileName = pythonpath;
                // start the python program with parameters
                p.StartInfo.Arguments = string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13}",
                                         args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10], args[11], args[12], args[13]); 

                p.Start();                        
                StreamReader s = p.StandardOutput;
                String output = s.ReadToEnd();
                string[] r = output.Split(new char[] { ' ' }); // get the parameter
                Console.WriteLine(r[0]);
                p.WaitForExit();
                Console.ReadLine(); // wait for a key press
            }
        }
    }
}
