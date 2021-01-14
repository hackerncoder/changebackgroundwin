using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace ChangeBackgroundWin
{
    class getImage
    {
        vars vars = new vars();
        public string GetImage(int numRepresentation)
        {
            string WallpaperUrl = null;
            
            string ImageType;
            string Image;
            WebClient webClient = new WebClient();
            switch (numRepresentation)
            {
                case 0:
                    WallpaperUrl = GetJsonString();
                    break;
                case 1:
                    WallpaperUrl = isFine();
                    ImageType = WallpaperUrl.Remove(0, WallpaperUrl.Length - 4);
                    File.AppendAllText(vars.urlsPath, WallpaperUrl + Environment.NewLine);
                    Image = vars.imagesDir + "image" + ImageType;
                    webClient.DownloadFile(WallpaperUrl, Image);
                    return Image;
                case 2:
                    WallpaperUrl = GetExtraImg();
                    ImageType = WallpaperUrl.Remove(0, WallpaperUrl.Length - 4);
                    File.AppendAllText(vars.urlsPath, WallpaperUrl + Environment.NewLine);
                    Image = vars.imagesDir + "image" + ImageType;
                    webClient.DownloadFile(WallpaperUrl, Image);
                    return Image;
                case 3:
                    WallpaperUrl = isFine();
                    ImageType = WallpaperUrl.Remove(0, WallpaperUrl.Length - 4);
                    File.AppendAllText(vars.urlsPath, WallpaperUrl + Environment.NewLine);
                    Image = vars.imagesDir + "image" + ImageType;
                    webClient.DownloadFile(WallpaperUrl, Image);
                    return Image;
            }

            ImageType = WallpaperUrl.Remove(0, WallpaperUrl.Length - 4);
            Image = vars.imagesDir + "image" + ImageType;


            bool isNoGo = IsNoGo(WallpaperUrl);
            while (isNoGo)
            {
                WallpaperUrl = GetJsonString();
                isNoGo = IsNoGo(WallpaperUrl);
            }
            File.AppendAllText(vars.urlsPath, WallpaperUrl + Environment.NewLine);
            webClient.DownloadFile(WallpaperUrl, Image);
            
            return Image;
        }

        private string GetExtraImg()
        {
            string fineUrlsPath = vars.extraPath;
            string isFinePath = null;

            if (File.Exists(fineUrlsPath))
            {
                string[] fineUrlList = File.ReadAllLines(fineUrlsPath);
                Random random = new Random();
                int line = random.Next(fineUrlList.Length);
                isFinePath = fineUrlList[line];
            }
            return isFinePath;
        }

        public string GetJsonString()
        {
            string url = "https://nekos.life/api/v2/img/wallpaper";
            var jsonString = new WebClient().DownloadString(url);
            var ExtractedString = JsonConvert.DeserializeObject<response>(jsonString);
            return ExtractedString.url;
        }

        private class response
        {
            public string url { get; set; }
        }

        private bool IsNoGo(string WallpaperUrl)
        {
            bool NoGo = false;
            string file = vars.nsfwPath;
            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    if (WallpaperUrl == line)
                    {
                        NoGo = true;
                        break;
                    }
                }
            }
            return NoGo;

        }

        private string isFine()
        {
            string fineUrlsPath = vars.finePath;
            string isFinePath = null;

            if (File.Exists(fineUrlsPath))
            {
                string[] fineUrlList = File.ReadAllLines(fineUrlsPath);
                Random random = new Random();
                int line = random.Next(fineUrlList.Length);
                isFinePath = fineUrlList[line];
            }
            return isFinePath;
        }
    }
}
