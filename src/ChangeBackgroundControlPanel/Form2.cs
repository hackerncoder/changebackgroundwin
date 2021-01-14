using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Windows.Forms;
using ChangeBackgroundWin;

namespace ChangeBackgroundControlPanel
{
    public partial class Form2 : Form
    {
        vars vars = new vars();

        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if (File.Exists(vars.settingsName))
            {
                string[] shouldBeChecked = File.ReadAllLines(vars.settingsName);
                if (shouldBeChecked.Length >= 1)
                {
                    string shouldbechecked0 = shouldBeChecked[0];
                    textBox1.Text = shouldbechecked0.Remove(shouldbechecked0.Length - 3, 3);
                    if (shouldBeChecked.Length >= 2)
                    {
                        switch (shouldBeChecked[1])
                        {
                            case "0":
                                radioButton1.Checked = true;
                                break;
                            case "1":
                                radioButton2.Checked = true;
                                break;
                            case "2":
                                radioButton4.Checked = true;
                                break;
                            case "3":
                                radioButton3.Checked = true;
                                break;
                        }
                        if (shouldBeChecked.Length >= 3)
                        {
                            //if (shouldBeChecked[2] == "true")
                            //{
                            //    foreach (string line in File.ReadAllLines(ImagesDir + "extraimg.txt"))
                            //    {
                            //        richTextBox1.AppendText(line + Environment.NewLine);
                            //    }
                            //}
                            try
                            {
                                if (shouldBeChecked[3] == "false" | shouldBeChecked[3] == "" | shouldBeChecked[3] == null)
                                {
                                    checkBox1.Checked = false;
                                }
                            } catch
                            {
                                checkBox1.Checked = false;
                            }
                        }
                    }
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "")
            {
                File.WriteAllText(vars.settingsName, "120000");
            } else
            {
                File.WriteAllText(vars.settingsName, textBox1.Text + "000");
            }
            if (radioButton1.Checked)
            {
                File.AppendAllText(vars.settingsName, Environment.NewLine + "0");
            } else if (radioButton2.Checked)
            {
                File.AppendAllText(vars.settingsName, Environment.NewLine + "1");
            } else if (radioButton4.Checked)
            {
                File.AppendAllText(vars.settingsName, Environment.NewLine + "2");
            } else if (radioButton3.Checked)
            {
                File.AppendAllText(vars.settingsName, Environment.NewLine + "3");
            }
            //if (richTextBox1.Text != null && )
            //{
            //    string lines = null;
            //    foreach (string line in richTextBox1.Lines)
            //    {
            //        if (line.StartsWith("http"))
            //        {
            //            if(line.EndsWith(".jpg") | line.EndsWith(".png"))
            //            {
            //                lines += line + Environment.NewLine;
            //            }
            //        }
            //    }
            //    File.WriteAllText(ImagesDir + "extraimg.txt", lines);
            //    if (radioButton3.Checked)
            //    {
            //        if(!File.Exists(ImagesDir + "fineurls_copy.txt"))
            //        {
            //            File.Copy(ImagesDir + "fineurls.txt", ImagesDir + "fineurls_copy.txt");
            //            File.AppendAllText(ImagesDir + "fineurls.txt", richTextBox1.Text);
            //        } else
            //        {
            //            File.Copy(ImagesDir + "fineurls_copy.txt", ImagesDir + "fineurls.txt", true);
            //            File.AppendAllText(ImagesDir + "fineurls.txt", richTextBox1.Text);
            //        }

            //    } else
            //    {
            //        if (File.Exists(ImagesDir + "fineurls_copy.txt"))
            //        {
            //            File.Copy(ImagesDir + "fineurls_copy.txt", ImagesDir + "fineurls.txt", true);
            //            File.Delete(ImagesDir + "fineurls_copy.txt");
            //        }
            //    }
            //    File.AppendAllText(SettingsACF, "true");
            //}
            //else
            //{
            File.AppendAllText(vars.settingsName, Environment.NewLine + "false");
            //}
            if (checkBox1.Checked)
            {
                File.AppendAllText(vars.settingsName, Environment.NewLine + "true");
            } else
            {
                File.AppendAllText(vars.settingsName, Environment.NewLine + "false");
            }
            Close();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                string input = Interaction.InputBox("Enter pre-release code", "Enter code", "zNmgCHw2agTifrurXG04Suce4x5we9");
                bool CorrectInput = input == "zNmgCHw2agTifrurXG04Suce4x5we9";
                if (input == null | input == "" | !CorrectInput)
                {
                    checkBox1.Checked = false;
                }
                else
                {
                    File.WriteAllText("prerelease.code", input);
                }
            }
        }
    }
}
