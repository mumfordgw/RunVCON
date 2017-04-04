using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Proof of concept code to call the VCON executable
// Graham Mumford, 4th April 2017

namespace RunVCON
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var process = new System.Diagnostics.Process();
            string directoryName;
            bool debug = false;

            // command line arguments

            //System.Console.WriteLine("Number of command line parameters = {0}", args.Length);
            foreach (string s in args)
            {
                bool argProcessed = false;
                if (string.Equals(s, "-Debug", StringComparison.OrdinalIgnoreCase))
                {
                    debug = true;
                    argProcessed = true;
                    break;
                }
                if (!argProcessed)
                {
                    Console.Error.WriteLine("Unexpected argument {0}", s);                    
                    return;
                }
            }

            // Determine the URI of the directory that holds this executable file
            // The directory will also contain the VCON executable, ONLINE.EXE
            directoryName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (debug) Console.WriteLine("GetDirectoryName returned " + directoryName);

            // drop the "file:\" prefix from the URI 
            directoryName = directoryName.Replace(@"file:\", "");
            if (debug) Console.WriteLine("DirectoryName after replace " + directoryName);

            // set up the properties for the new process that will run VCON.
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                //WorkingDirectory = @"The\Process\Working\Directory",
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                // add the VCON executable - ONLINE.EXE
                FileName = directoryName + @"\online.exe",
                RedirectStandardInput = true,
                UseShellExecute = false
            };
            if (debug) Console.WriteLine("FileName " + startInfo.FileName);

            // attempt to run the command in a new process.
            try
            {
                process.StartInfo = startInfo;
                process.Start();
            }
            catch (Exception Ex)
            {
                Console.WriteLine("{0} Error running command {1}", Ex, startInfo.FileName);
                if (debug)
                {
                    Console.WriteLine("Press any key to exit.");
                    System.Console.ReadKey();
                }
                return;
            }

            if (debug)
            {
                Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();

            }
        }
    }
}
