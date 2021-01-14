using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;
using ChangeBackgroundWin;

namespace ChangeBackgroundControlPanel
{
    public partial class Form1 : Form
    {
        vars vars = new vars();
        public Form1()
        {
            InitializeComponent();
        }
        ProcessStartInfo startProgram = new ProcessStartInfo("ChangeBackgroundWin.exe");
        ProcessStartInfo theProcess = new ProcessStartInfo("ChangeBackgroundWin.exe");
        private void Button1_Click(object sender, EventArgs e)
        {
            Process.Start(startProgram);
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("ChangeBackgroundWin"))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            theProcess.Arguments = "1";
            Process.Start(theProcess);
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            theProcess.Arguments = "2";
            Process.Start(theProcess);
        }

        private void UpdateNSFWList()
        {
            string txtPath = vars.nsfwPath;
            new WebClient().DownloadFile(vars.nsfwUrl, txtPath);
        }
        private void UpdateFineList()
        {
            string txtPath = vars.finePath;
            new WebClient().DownloadFile(vars.fineUrl, txtPath);
        }

        //private void UpdateExtensions()
        //{
        //    if (Directory.Exists(Directory.GetCurrentDirectory() + @"\extension"))
        //        Directory.Delete(Directory.GetCurrentDirectory() + @"\extension", true);
        //    if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\extension"))
        //        Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\extension");
        //    string url = "http://5.175.25.50/ChangeBackgroundWin/extension/rainmeter.zip";
        //    string zippath = Directory.GetCurrentDirectory() + @"\extension\rainmeter.zip";
        //    new WebClient().DownloadFile(url, zippath);
        //    ZipFile.ExtractToDirectory(zippath, Directory.GetCurrentDirectory() + @"\extension");
        //    File.Delete(zippath);
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            if(File.Exists(Path.Combine(vars.pathToDir, "NewUpdate.exe")))
            {
                File.Delete(Path.Combine(vars.pathToDir, "Update.exe"));
                File.Move(Path.Combine(vars.pathToDir, "NewUpdate.exe"), Path.Combine(vars.pathToDir, "Update.exe"));
                Properties.Settings.Default.Upgrade();
            }

            if (!Properties.Settings.Default.RunBefore)
            {
                Form4 frm = new Form4();
                frm.Show();
            }

            theProcess.WindowStyle = ProcessWindowStyle.Hidden;
            theProcess.CreateNoWindow = true;
            startProgram.WindowStyle = ProcessWindowStyle.Hidden;
            startProgram.CreateNoWindow = true;
        }

        private void UpdateExtensionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //UpdateExtensions()
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void NSFWURLListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateNSFWList();
        }

        private void FineURLListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateFineList();
        }

        private void UpdateListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //UpdateNSFWList();
            //UpdateFineList();
        }
    }
}
