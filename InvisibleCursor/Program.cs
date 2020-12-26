using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace InvisibleCursor
{
    class Program
    {
        private static string m_arrowCursor, m_handCursor; // Stores the initial cursors for Arrow and Hand
        // Function is called to force a reload of the Windows Registry
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern bool SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        static void Main(string[] args)
        {
            string path = @"C:\Windows\Cursors\invisible.cur";

            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Control Panel\Cursors");

            if (rk != null)
            {
                m_arrowCursor = (string)rk.GetValue("Arrow");
                m_handCursor = (string)rk.GetValue("Hand");
                rk.Close();
            }

            ShowCursor(false, path);
        }

        private static void ShowCursor(bool show, string path)
        {
            // 3 variables are needed for forcing the registry reload
            const int SPI_SETCURSORS = 0x0057;
            const int SPIF_UPDATEINIFILE = 0x01;
            const int SPIF_SENDCHANGE = 0x02;

            if (!show)
            {
                // Change the default arrow cursor
                Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Cursors", "Arrow", path);
                Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Cursors", "Hand", path);
                // Force the registry reload
                SystemParametersInfo(SPI_SETCURSORS, 0, null, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            }
            else
            {
                // restore the default cursors
                Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Cursors", "Arrow", @"C:\Windows\Cursors\arrow.cur");
                Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Cursors", "Hand", @"C:\Windows\Cursors\hand.cur");
                // Force the registry reload
                SystemParametersInfo(SPI_SETCURSORS, 0, null, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            }
        }
    }
}
