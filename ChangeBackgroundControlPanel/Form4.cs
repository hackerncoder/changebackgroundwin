using System;
using System.Windows.Forms;
using File = System.IO.File;
using Directory = System.IO.Directory;
using ChangeBackgroundWin;

namespace ChangeBackgroundControlPanel
{
    public partial class Form4 : Form
    {
        vars vars = new vars();

        public Form4()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "")
            {
                File.WriteAllText(vars.settingsName, "120000");
            }
            else
            {
                if(comboBox1.Text == "Minutes")
                {
                    int timetowait = Convert.ToInt32(textBox1.Text) * 60000;
                    File.WriteAllText(vars.settingsName, timetowait.ToString());
                } else if (comboBox1.Text == "Seconds")
                {
                    int timetowait = Convert.ToInt32(textBox1.Text) * 1000;
                    File.WriteAllText(vars.settingsName, timetowait.ToString());
                }
            }

            File.AppendAllText(vars.settingsName, Environment.NewLine + "false");

            if (checkBox2.Checked)
            {
                File.AppendAllText(vars.settingsName, Environment.NewLine + vars.Level.SELE.ToString());
            }
            else
            {
                File.AppendAllText(vars.settingsName, Environment.NewLine + vars.Level.RAND.ToString());
            }
            savesettings();

            Directory.CreateDirectory(vars.imagesDir);
            Directory.CreateDirectory(vars.urlDir);

            Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            TopMost = true;
            Focus();
        }

        private void savesettings()
        {

        }
    }
}
