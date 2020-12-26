using System;
using System.Runtime.InteropServices;

namespace RotateScreen
{
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
	public struct Devmode 
	{
		[MarshalAs(UnmanagedType.ByValTStr,SizeConst=32)]
		public string dmDeviceName;
		
		public short  dmSpecVersion;
		public short  dmDriverVersion;
		public short  dmSize;
		public short  dmDriverExtra;
		public int    dmFields;
		public int    dmPositionX;
		public int    dmPositionY;
		public int    dmDisplayOrientation;
		public int    dmDisplayFixedOutput;
		public short  dmColor;
		public short  dmDuplex;
		public short  dmYResolution;
		public short  dmTTOption;
		public short  dmCollate;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string dmFormName;

		public short  dmLogPixels;
		public short  dmBitsPerPel;
		public int    dmPelsWidth;
		public int    dmPelsHeight;
		public int    dmDisplayFlags;
		public int    dmDisplayFrequency;
		public int    dmICMMethod;
		public int    dmICMIntent;
		public int    dmMediaType;
		public int    dmDitherType;
		public int    dmReserved1;
		public int    dmReserved2;
		public int    dmPanningWidth;
		public int    dmPanningHeight;
	};

	public class NativeMethods
	{
		// PInvoke declaration for EnumDisplaySettings Win32 API
		[DllImport("user32.dll", CharSet=CharSet.Ansi)]
		public static extern int EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref Devmode lpDevMode);         

		// PInvoke declaration for ChangeDisplaySettings Win32 API
		[DllImport("user32.dll", CharSet=CharSet.Ansi)]
		public static extern int ChangeDisplaySettings(ref Devmode lpDevMode, int dwFlags);

		// helper for creating an initialized DEVMODE structure
		public static Devmode CreateDevmode()
		{
			var dm = new Devmode {dmDeviceName = new String(new char[32]), dmFormName = new String(new char[32])};
		    dm.dmSize = (short)Marshal.SizeOf(dm);
			return dm;
		}

		// constants
		public const int EnumCurrentSettings = -1;
		public const int DispChangeSuccessful = 0;
		public const int DispChangeBaddualview = -6;
		public const int DispChangeBadflags = -4;
		public const int DispChangeBadmode = -2;
		public const int DispChangeBadparam = -5;
		public const int DispChangeFailed = -1;
		public const int DispChangeNotupdated = -3;
		public const int DispChangeRestart = 1;
		public const int DmdoDefault = 0;
		public const int Dmdo90 = 1;
		public const int Dmdo180 = 2;
		public const int Dmdo270 = 3;
	}
}
