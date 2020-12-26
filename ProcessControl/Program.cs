using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Threading;

namespace ProcessControl
{
    internal class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();
        private static void Main()
        {
            FreeConsole();
            var sr = new StreamReader("WhiteList.txt");
            var mainProcesses = new List<string>();
            while (sr.Peek() >= 0)
            {
                var readLine = sr.ReadLine();
                if (readLine == null) continue;
                var linie = readLine.Trim();
                if (linie != "")
                    mainProcesses.Add(linie);
            }

            for (int i = 0; i < mainProcesses.Count; i++)
            {
                mainProcesses[i] = mainProcesses[i].Trim();
            }


            if (!Directory.Exists(@"C:\Log"))
                Directory.CreateDirectory(@"C:\Log");

            if (!Directory.Exists(@"C:\Log\ProcessControl"))
                Directory.CreateDirectory(@"C:\Log\ProcessControl");

            StreamWriter log = !File.Exists(@"C:\Log\ProcessControl\LogFile.txt")
                ? new StreamWriter(@"C:\Log\ProcessControl\LogFile.txt")
                : File.AppendText("LogFile.txt");
            log.AutoFlush = true;


            //List<string> mainProcesses = File.ReadLines(Properties.Resources.WhiteList).ToList();

            //List<string> mainProcesses = new List<string>()
            //{
            //    "MSBuild",
            //    "svchost",
            //    "glcnd",
            //    "sqlwriter",
            //    "devenv",
            //    "wmpnetwk",
            //    "RuntimeBroker",
            //    "csrss",
            //    "dasHost",
            //    "dwm",
            //    "WUDFHost",
            //    "lsass",
            //    "MsMpEng",
            //    "taskhostex",
            //    "iexplore",
            //    "services",
            //    "svchost",
            //    "SearchIndexer",
            //    "wininit",
            //    "smss",
            //    "conhost",
            //    "ielowutil",
            //    "audiodg",
            //    "Task Manager.vshost",
            //    "winlogon",
            //    "NisSrv",
            //    "spoolsv",
            //    "System",
            //    "explorer",
            //    "taskhost",
            //    "Idle"                    
            //};

            log.WriteLine();
            log.WriteLine(DateTime.Now + @"   ---------------------White List---------------------");
            foreach (string mainProcess in mainProcesses)
            {
                log.WriteLine(DateTime.Now + @"   Process: " + mainProcess);
            }

            log.WriteLine();
            log.WriteLine(DateTime.Now + @"   ------------------Killed processes------------------");

            //Thread th = new Thread(()=>KillProcess(mainProcesses,log));

            KillProcess(mainProcesses, log);

        }

        // ReSharper disable once FunctionRecursiveOnAllPaths
        private static void KillProcess(List<string> mainProcesses, StreamWriter log)
        {
            Process[] existingProcesses = Process.GetProcesses();
            foreach (Process theprocess in existingProcesses)
            {
                bool isKilled = false;
                if (mainProcesses.Any(mainProcess => theprocess.ProcessName == mainProcess))
                {
                    string processToRemove = theprocess.ProcessName;
                    existingProcesses =
                        existingProcesses.Where(val => val.ProcessName != processToRemove).ToArray();
                    isKilled = true;
                }
                if (!isKilled)
                {
                    try
                    {
                        log.WriteLine(DateTime.Now + @"   Process killed: " + theprocess.ProcessName);
                        theprocess.Kill();

                    }
                    catch (Exception ex)
                    {
                        log.WriteLine(DateTime.Now + "   " + ex.Message + @" " + theprocess.ProcessName);
                    }
                }
            }
            Thread.Sleep(1000);
            KillProcess(mainProcesses, log);
        }
    }
}

