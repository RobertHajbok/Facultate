using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter log = !File.Exists("LogFile.txt")
                ? new StreamWriter("LogFile.txt")
                : File.AppendText("LogFile.txt");
            log.AutoFlush = true;

            Process[] existingProcesses = Process.GetProcesses();
            foreach (Process theprocess in existingProcesses)
            {
                log.WriteLine(theprocess.ProcessName);
            }
        }
    }
}
