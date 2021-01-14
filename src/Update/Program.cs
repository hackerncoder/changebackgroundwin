using System.IO;
using System.Net;
using System.Reflection;
using System.Diagnostics;
using System.IO.Compression;
using System;
using ChangeBackgroundWin;

namespace Update
{
    class Program
    {
        static void Main(string[] args)
        {
            vars vars = new vars();
            try
            {
                    WebRequest wr = WebRequest.Create(vars.UpdateUrlBase + "version.txt");
                    WebResponse ws = wr.GetResponse();
                    StreamReader sr = new StreamReader(ws.GetResponseStream());

                    string currentversion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    string newversion = sr.ReadToEnd();

                    string[] Curints = currentversion.Split('.');
                    int CurIntRep = 0;
                    string[] Newints = newversion.Split('.');
                    int NewIntRep = 0;
                    foreach (string INTString in Curints)
                    {
                        CurIntRep += Convert.ToInt32(INTString);
                    }
                    foreach (string INTString in Newints)
                    {
                        NewIntRep += Convert.ToInt32(INTString);
                    }

                    if (CurIntRep >= NewIntRep)
                    { }
                    else
                    {
                        string url = vars.UpdateUrlBase + "update.zip";
                        string zippath = Path.Combine(vars.pathToDir, "update.zip");
                        new WebClient().DownloadFile(url, zippath);
                        using (ZipArchive archive = ZipFile.OpenRead(zippath))
                        {
                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {

                                if (!entry.Name.Contains("Update.exe"))
                                {
                                    // Gets the full path to ensure that relative segments are removed.
                                    string destinationPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), entry.FullName));

                                    // Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
                                    // are case-insensitive.
                                    entry.ExtractToFile(destinationPath, true);
                                }
                                else
                                {
                                    entry.ExtractToFile(Path.Combine(vars.pathToDir, "NewUpdate.exe"));
                                }
                            }
                        }
                        File.Delete(Path.Combine(vars.pathToDir, "update.zip"));
                    }
                if (File.ReadAllLines(vars.settingsName)[3] == "true")
                {
                    wr = WebRequest.Create(vars.UpdateUrlBase + "PreVersion.txt");
                    ws = wr.GetResponse();
                    sr = new StreamReader(ws.GetResponseStream());

                    currentversion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    newversion = sr.ReadToEnd();

                    Curints = currentversion.Split('.');
                    CurIntRep = 0;
                    Newints = newversion.Split('.');
                    NewIntRep = 0;
                    foreach (string INTString in Curints)
                    {
                        CurIntRep += Convert.ToInt32(INTString);
                    }
                    foreach (string INTString in Newints)
                    {
                        NewIntRep += Convert.ToInt32(INTString);
                    }

                    if (CurIntRep >= NewIntRep)
                    { }
                    else
                    {
                        string url = vars.UpdateUrlBase + "PreUpdate.zip";
                        string zippath = Path.Combine(vars.pathToDir, "update.zip");
                        new WebClient().DownloadFile(url, zippath);
                        using (ZipArchive archive = ZipFile.OpenRead(zippath))
                        {
                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {

                                if (!entry.Name.Contains("Update.exe"))
                                {
                                    // Gets the full path to ensure that relative segments are removed.
                                    string destinationPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), entry.FullName));

                                    // Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
                                    // are case-insensitive.
                                    entry.ExtractToFile(destinationPath, true);
                                }
                                else
                                {
                                    entry.ExtractToFile(Path.Combine(vars.pathToDir, "NewUpdate.exe"));
                                }
                            }
                        }
                        File.Delete(Path.Combine(vars.pathToDir,"update.zip"));
                    }
                }


                WebRequest wr2 = WebRequest.Create(vars.ListsUrlBase + "versions.txt");
                WebResponse ws2 = wr2.GetResponse();
                StreamReader sr2 = new StreamReader(ws2.GetResponseStream());

                string urlListsVersions = sr2.ReadToEnd();
                string[] urlListsArray = urlListsVersions.Split('\n');

                if (!File.Exists("URL.avf"))
                {
                    File.WriteAllText("URL.avf", urlListsVersions);
                }

                string currentUrlListsVer = File.ReadAllText("URL.avf");
                string[] currentUrlArray = currentUrlListsVer.Split('\n');

                string[] CurrentSplitArray = urlListsArray[0].Split('.');
                int CurrentIntRepres = 0;
                string[] NewSplitArray = urlListsArray[0].Split('.');
                int NewIntRepres = 0;
                foreach (string INTString in CurrentSplitArray)
                {
                    CurrentIntRepres += Convert.ToInt32(INTString);
                }
                foreach (string INTString in NewSplitArray)
                {
                    NewIntRepres += Convert.ToInt32(INTString);
                }

                if (CurIntRep >= NewIntRep)
                { }
                else
                {
                    string url = vars.nsfwUrl;
                    string txtPath = vars.nsfwPath;
                    new WebClient().DownloadFile(url, txtPath);

                    File.WriteAllText("URL.avf", urlListsVersions);
                }

                CurrentSplitArray = urlListsArray[1].Split('.');
                CurrentIntRepres = 0;
                NewSplitArray = urlListsArray[1].Split('.');
                NewIntRepres = 0;
                foreach (string INTString in CurrentSplitArray)
                {
                    CurrentIntRepres += Convert.ToInt32(INTString);
                }
                foreach (string INTString in NewSplitArray)
                {
                    NewIntRepres += Convert.ToInt32(INTString);
                }

                if (CurIntRep >= NewIntRep)
                { }
                else
                {
                    string url = vars.fineUrl;
                    string txtPath = vars.finePath;
                    new WebClient().DownloadFile(url, txtPath);

                    File.WriteAllText("URL.avf", urlListsVersions);
                }

                Process.Start("ChangeBackgroundControlPanel.exe");
            }
            catch
            {
                Process.Start("ChangeBackgroundControlPanel.exe");
            }
        }
    }
}
