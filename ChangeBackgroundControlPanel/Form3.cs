using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace ChangeBackgroundControlPanel
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("Rainmeter");
            if (pname.Length == 0)
                Process.Start(Directory.GetCurrentDirectory() + @"\extension\Rainmeter.exe");
            else
            {
                ProcessStartInfo rainmeter = new ProcessStartInfo();
                rainmeter.CreateNoWindow = true;
                rainmeter.FileName = Directory.GetCurrentDirectory() + @"\extension\Rainmeter.exe";
                rainmeter.Arguments = "!Toggle \"\"\"Spectrum\"\"\"";
                Process.Start(rainmeter);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\extension"))
            {
                label1.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                groupBox1.Text = "ERR";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("Rainmeter");
            if (pname.Length == 0)
                Process.Start(Directory.GetCurrentDirectory() + @"\extension\Rainmeter.exe");
            else
            {
                ProcessStartInfo rainmeter = new ProcessStartInfo();
                rainmeter.CreateNoWindow = true;
                rainmeter.FileName = Directory.GetCurrentDirectory() + @"\extension\Rainmeter.exe";
                rainmeter.Arguments = @"!DeactivateConfig ""Elegant Clock\Dark Clock"" ""DarkClock.ini""";
                Process.Start(rainmeter);

                rainmeter.CreateNoWindow = true;
                rainmeter.FileName = Directory.GetCurrentDirectory() + @"\extension\Rainmeter.exe";
                rainmeter.Arguments = @"!ToggleConfig ""Elegant Clock\Light Clock"" ""LightClock.ini""";
                Process.Start(rainmeter);

                placeClock(true);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("Rainmeter");
            if (pname.Length == 0)
                Process.Start(Directory.GetCurrentDirectory() + @"\extension\Rainmeter.exe");
            else
            {
                ProcessStartInfo rainmeter = new ProcessStartInfo();
                rainmeter.CreateNoWindow = true;
                rainmeter.FileName = Directory.GetCurrentDirectory() + @"\extension\Rainmeter.exe";
                rainmeter.Arguments = @"!DeactivateConfig ""Elegant Clock\Light Clock"" ""LightClock.ini""";
                Process.Start(rainmeter);

                rainmeter.CreateNoWindow = true;
                rainmeter.FileName = Directory.GetCurrentDirectory() + @"\extension\Rainmeter.exe";
                rainmeter.Arguments = @"!ToggleConfig ""Elegant Clock\Dark Clock"" ""DarkClock.ini""";
                Process.Start(rainmeter);

                placeClock(false);
            }
        }

        private void placeClock(bool lightClock)
        {
            string xAndy = getXandY(lightClock);
            string[] split = xAndy.Split(';');

            ProcessStartInfo rainmeter = new ProcessStartInfo();
            rainmeter.CreateNoWindow = true;
            rainmeter.FileName = Directory.GetCurrentDirectory() + @"\extension\Rainmeter.exe";

            rainmeter.Arguments = string.Format(@"!Move ""{0}"" ""{1}"" ""{2}""", split[0], split[1], lightClock ? "Elegant Clock\\Light Clock" : "Elegant Clock\\Dark Clock");

            Process.Start(rainmeter);
        }

        private string getXandY(bool lightClock)
        {
            string[] rainmeterini = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\extension\Rainmeter.ini");
            string xPos = "0";
            string yPos = "0";
            if (lightClock)
            {
                xPos = rainmeterini[34].Remove(0, 8);
                yPos = rainmeterini[35].Remove(0, 8);
            } else
            {
                xPos = rainmeterini[25].Remove(0, 8);
                yPos = rainmeterini[26].Remove(0, 8);
            }
            return xPos + ";" + yPos;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("Rainmeter");
            if (pname.Length == 0)
            {} else
            {
                pname[0].Kill();
            }
        }
    }
}
