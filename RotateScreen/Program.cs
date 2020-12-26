using System;

namespace RotateScreen
{
    internal class Program
    {
        private static readonly int[] OrientationValues =
        {
            NativeMethods.DmdoDefault,
            NativeMethods.Dmdo90,
            NativeMethods.Dmdo180,
            NativeMethods.Dmdo270
        };

        private static void Main()
        {
            RotateClockwise();
            RotateClockwise();
        }

        private static void RotateClockwise()
        {
            // obtain current settings
            var dm = NativeMethods.CreateDevmode();
            GetSettings(ref dm);

            //swap height and width
            var temp = dm.dmPelsHeight;
            dm.dmPelsHeight = dm.dmPelsWidth;
            dm.dmPelsWidth = temp;

            // set the orientation value to what's next clockwise
            var index = Array.IndexOf(OrientationValues, (object) dm.dmDisplayOrientation);
            var newIndex = (index == 0) ? 3 : index - 1;
            dm.dmDisplayOrientation = OrientationValues[newIndex];

            // switch to new settings
            ChangeSettings(dm);
        }

        private static void GetSettings(ref Devmode dm)
        {
            // helper to obtain current settings
            GetSettings(ref dm, NativeMethods.EnumCurrentSettings);
        }

        private static void GetSettings(ref Devmode dm, int iModeNum)
        {
            // helper to wrap EnumDisplaySettings Win32 API
            NativeMethods.EnumDisplaySettings(null, iModeNum, ref dm);
        }


        private static void ChangeSettings(Devmode dm)
        {
            // helper to wrap ChangeDisplaySettings Win32 API

            var iRet = NativeMethods.ChangeDisplaySettings(ref dm, 0);
            switch (iRet)
            {
                case NativeMethods.DispChangeSuccessful:
                    break;
                case NativeMethods.DispChangeRestart:
                    Console.WriteLine("Please restart your system");
                    break;
                case NativeMethods.DispChangeFailed:
                    Console.WriteLine("ChangeDisplaySettigns API failed");
                    break;
                case NativeMethods.DispChangeBaddualview:
                    Console.WriteLine("The settings change was unsuccessful because system is DualView capable.");
                    break;
                case NativeMethods.DispChangeBadflags:
                    Console.WriteLine("An invalid set of flags was passed in.");
                    break;
                case NativeMethods.DispChangeBadparam:
                    Console.WriteLine(
                        "An invalid parameter was passed in. This can include an invalid flag or combination of flags.");
                    break;
                case NativeMethods.DispChangeNotupdated:
                    Console.WriteLine("Unable to write settings to the registry.");
                    break;
                default:
                    Console.WriteLine("Unknown return value from ChangeDisplaySettings API");
                    break;
            }
        }
    }
}
