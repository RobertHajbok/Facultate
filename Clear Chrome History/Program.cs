using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace Clear_Chrome_History
{
    public class Program
    {
        static void Main()
        {
            LaunchProcess("taskkill.exe", "-f -im chrome.exe");

            var googlePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\Google\Chrome\User Data\Default\";
            //string MozillaPath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Roaming\Mozilla\Firefox\";
            //string Opera1 = Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\Opera\Opera";
            //string Opera2 = Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Roaming\Opera\Opera";
            //string Safari1 = Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\Apple Computer\Safari";
            //string Safari2 = Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Roaming\Apple Computer\Safari";
            //string IE1 = Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\Microsoft\Intern~1";
            //string IE2 = Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\Microsoft\Windows\History";
            //string IE3 = Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\Microsoft\Windows\Tempor~1";
            //string IE4 = Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Roaming\Microsoft\Windows\Cookies";
            //string Flash = Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Roaming\Macromedia\Flashp~1";

            Thread.Sleep(250);

            //Call This Method ClearAllSettings and Pass String Array Param
            ClearAllSettings(new[] { googlePath });
            //ClearAllSettings(new string[] { GooglePath, MozillaPath, Opera1, Opera2, Safari1, Safari2, IE1, IE2, IE3, IE4, Flash });
        }

        private static void LaunchProcess(string name, string arguments)
        {
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                CreateNoWindow = true,
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                FileName = name,
                Arguments = arguments
            };

            System.Diagnostics.Process.Start(psi);
        }

        public static void ClearAllSettings(string[] clearPath)
        {
            foreach (var historyPath in clearPath.Where(Directory.Exists))
            {
                DoDelete(new DirectoryInfo(historyPath));
            }
        }

        static void DoDelete(DirectoryInfo folder)
        {
            try
            {

                foreach (var file in folder.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                }
                foreach (var subfolder in folder.GetDirectories())
                {
                    DoDelete(subfolder);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
    