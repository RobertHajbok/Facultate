using System;
using System.IO;
using System.Net.Mail;
using System.Net.NetworkInformation;
using Microsoft.Win32;

namespace WinLogin_Tracker
{
    class Program
    {
        private static string _mustUseRegistry;

        static void Main()
        {
            try
            {
                using (var sr = new StreamReader("Reg.txt"))
                {
                    _mustUseRegistry = sr.ReadToEnd();
                }

                if(_mustUseRegistry=="true")
                    UseRegistry();

                while (!NetworkInterface.GetIsNetworkAvailable())
                {
                }
                SendMail();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //finally
            //{
            //    Console.ReadKey();
            //}
        }

        private static void UseRegistry()
        {
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = Path.GetDirectoryName(path);

            var reg = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (directory != null) 
                if (reg != null) 
                    reg.SetValue("WinLogin Tracker", directory);

            using (var sw = new StreamWriter("Reg.txt"))
            {
                sw.Write("false");
            }
        }

        private static void SendMail()
        {
            var loggedUser = Environment.UserName;

            var gmail = new Gmail("hajbok.robert@gmail.com", "trop1234");
            //MailMessage msg = new MailMessage("hajbok.robert@gmail.com", "geta_bolda@yahoo.com");
            var msg = new MailMessage("hajbok.robert@gmail.com", "hajbok.robert@gmail.com")
            {
                Subject = "Login",
                Body = "S-a logat " + loggedUser + " pe calculatorul de acasa la ora " + DateTime.Now
            };

            //if ((int)DateTime.Now.DayOfWeek != 6 && (int)DateTime.Now.DayOfWeek != 7 && DateTime.Now.Hour >= 8 &&
            //    DateTime.Now.Hour < 16)
            gmail.Send(msg);
        }
    }
}
