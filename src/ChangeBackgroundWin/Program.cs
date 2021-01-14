using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;

namespace ChangeBackgroundWin
{
    class Program
    {
        static vars vars = new vars();

        static getImage getImage = new getImage();
        static string ImagePath;
        static int WaitTime = 120000;
        static bool isOnline = CheckForInternetConnection();
        static int ConfigReadInt = 0;

        [DllImport("Kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();
        [DllImport("User32.dll")]
        public static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

        static void Main(string[] args)
        {
            if (!isOnline)
            {
                Environment.Exit(177013);
            }
            string[] ConfigRead = File.ReadAllLines(vars.settingsName);
            if (File.Exists(vars.settingsName))
            {
                if (ConfigRead.Length >= 2)
                {
                    ConfigReadInt = Convert.ToInt32(ConfigRead[1]);
                }
            }
            if (args.Length > 0)
            {
                if (args[0] == "1")
                {
                    ImagePath = vars.imagesDir;
                    Set();
                    Environment.Exit(1);
                }
                else if (args[0] == "2")
                {
                    ImagePath = getImage.GetImage(ConfigReadInt);
                    Set();
                    Environment.Exit(2);
                }
            }
            Console.Title = "ChangeBackgroundWin";
            if (File.Exists(vars.settingsName))
            {
                WaitTime = Convert.ToInt32(ConfigRead[0]);
                IntPtr hWnd = GetConsoleWindow();
                if (hWnd != IntPtr.Zero)
                {
                    ShowWindow(hWnd, 0);
                }
            }
            if (!Directory.Exists(vars.imagesDir)) {
                Console.WriteLine(@"\Images\ does not exist, the program will automatically exit after 10 seconds.");
                Thread.Sleep(10000);
                Environment.Exit(0);
            }

            SetTimer();
            Console.ReadKey();
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        static int TimerTimes = 0;
        const int SetDeskWallpaper = 20;
        const int UpdateIniFile = 0x01;
        const int SendWinIniChange = 0x02;
        public static void Set()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            SystemParametersInfo(SetDeskWallpaper, 0, ImagePath, UpdateIniFile | SendWinIniChange);
            if (TimerTimes == 9)
            {
                ProcessStartInfo restart = new ProcessStartInfo("ChangeBackgroundWin.exe");
                restart.CreateNoWindow = true;
                restart.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(restart);
                Environment.Exit(0);
            }
            TimerTimes++;
        }

        static void TimerSet(object o)
        {
            ImagePath = getImage.GetImage(ConfigReadInt);
            Thread.Sleep(1000);
            Set();
        }

        private static void SetTimer()
        {
            Timer t = new Timer(TimerSet);
            t.Change(0, WaitTime);
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
