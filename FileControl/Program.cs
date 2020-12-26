using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Threading;

namespace FileControl
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string path = args[0];
            var file = new StreamWriter(path + @"\Checksums.txt", false) {AutoFlush = true};


            var sr = new StreamReader(path + @"\FilesPath.txt");
            var filesPaths = new List<string>();
            while (sr.Peek() >= 0)
            {
                var readLine = sr.ReadLine();
                if (readLine == null) continue;
                var linie = readLine.Trim();
                if (linie != "")
                    filesPaths.Add(linie);
            }

            try
            {
                //Kill Softparc.Roullete, ProcessControl
                Process[] prs = Process.GetProcesses();
                foreach (Process pr in prs)
                {
                    if (pr.ProcessName == "Softparc.Roulette" || pr.ProcessName == "ProcessControl")
                    {
                        pr.Kill();
                    }
                }

                foreach (string fpath in filesPaths)
                {
                    file.WriteLine(fpath);
                    var dir = new DirectoryInfo(fpath);

                    FileInfo[] files = dir.GetFiles();

                    var hashSha1 = SHA1.Create();

                    foreach (FileInfo fInfo in files)
                    {
                        if (!(fInfo.Name.ToLower().Contains("log") && fInfo.Extension == ".txt"))
                        {
                            FileStream fileStream = fInfo.Open(FileMode.Open);
                            fileStream.Position = 0;

                            byte[] hashValue = hashSha1.ComputeHash(fileStream);

                            file.WriteLine(fInfo.Name + @": ");

                            int i;
                            for (i = 0; i < hashValue.Length; i++)
                            {
                                file.Write(@"{0:X2}", hashValue[i]);
                                if ((i%4) == 3) file.Write(@" ");
                            }

                            file.WriteLine();

                            fileStream.Close();
                            file.WriteLine("\n");
                        }
                    }
                }

                //Restarts the terminal after doing checksums
                Thread.Sleep(1000);
                LaunchProcess("shutdown.exe", "-r -t 0 -f");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                file.WriteLine(ex);
            }
        }

        public static void PrintByteArray(byte[] array)
        {
            int i;
            for (i = 0; i < array.Length; i++)
            {
                Console.Write(@"{0:X2}", array[i]);
                if ((i%4) == 3) Console.Write(@" ");
            }
            Console.WriteLine();
        }

        public static void LaunchProcess(string name, string arguments)
        {
            var psi = new ProcessStartInfo
            {
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = name,
                Arguments = arguments
            };

            Process.Start(psi);
        }
    }
}
