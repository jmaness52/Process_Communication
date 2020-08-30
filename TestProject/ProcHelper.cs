using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class ProcHelper
    {

        public static StreamWriter ProcessInput { get; set; }
        public static Process StartProcess()
        {
            Process returnProc = new Process();
            StringBuilder args = new StringBuilder();
            args.Append("/RunInteractive");
            args.Append("/TestArgument");
            args.Append(" a");

            returnProc.StartInfo.FileName = "ServerProcess.exe";
            returnProc.StartInfo.Arguments = args.ToString();
            returnProc.StartInfo.UseShellExecute = false;
            returnProc.StartInfo.RedirectStandardError = true;
            returnProc.StartInfo.RedirectStandardOutput = true;
            returnProc.StartInfo.CreateNoWindow = true;

            //This was added by me,  before we did not redirect standard input
            returnProc.StartInfo.RedirectStandardInput = true;
            returnProc.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                Console.WriteLine(e.Data);
            });

            returnProc.ErrorDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                Console.WriteLine(e.Data);
            });

            if (!returnProc.Start())
            {
                Console.WriteLine("Process Didn't start");
            }

            returnProc.BeginOutputReadLine();
            returnProc.BeginErrorReadLine();

            //I found that if I didn't set the standardInput to a variable, I was getting an error regarding
            //a mix of synchronous and asynchronous streams
            ProcessInput = returnProc.StandardInput;

            return returnProc;
        }
    }
}
