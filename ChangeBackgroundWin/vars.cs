using System;
using System.IO;

namespace ChangeBackgroundWin
{
    public class vars
    {
        public string nsfwUrl = "http://5.175.25.50/ChangeBackgroundWin/urls/nogourls.txt";
        public string fineUrl = "http://5.175.25.50/ChangeBackgroundWin/urls/fineurls.txt";
        public string UpdateUrlBase = "http://5.175.25.50/ChangeBackgroundWin/update/";
        public string ListsUrlBase = "http://5.175.25.50/ChangeBackgroundWin/urls/";
        public string settingsName = "settings.acf";
        public static string pathToDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ChangeBackgroundWin");
        public string imagesDir = Path.Combine(pathToDir, "Images");
        public string urlDir = Path.Combine(pathToDir, "url");
        public static string urlDirPath = Path.Combine(pathToDir, "url");
        public string nsfwPath = Path.Combine(urlDirPath, "nogourls.txt");
        public string finePath = Path.Combine(urlDirPath, "fineurls.txt");
        public string urlsPath = Path.Combine(urlDirPath, "urls.txt");
        public string extraPath = Path.Combine(urlDirPath, "extraimg.txt");

        public enum Level
        {
            RAND = 0,
            SELE = 1,
            OWN = 2,
            DUBL = 3
        }
    }
}
