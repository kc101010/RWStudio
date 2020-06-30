using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RWS
{
    public partial class newMod : Form
    {
        public newMod()
        {
            InitializeComponent();
        }
        private bool newM = true;
        private void button1_Click(object sender, EventArgs e)
        {
           

            if (newM)
            {
                /*  ##  Commented out to easily revert back ##
                if (Directory.Exists(@"C:\RWStudio\" + textBox1.Text.Replace('\\', '_').Replace('/', '_').Replace('.', '_').Replace(',', '_').Replace('%', '_')))
                {
                    MessageBox.Show("You cant create mods with same names!", "You cant...");
                    if (File.Exists(Path.Combine(@"C:\RWStudio\" + textBox1.Text.Replace('\\', '_').Replace('/', '_').Replace('.', '_').Replace(',', '_').Replace('%', '_'), "mod-info.txt")))
                        File.Create(Path.Combine(@"C:\RWStudio\" + textBox1.Text.Replace('\\', '_').Replace('/', '_').Replace('.', '_').Replace(',', '_').Replace('%', '_'), "mod-info.txt")).Close();
                }
                else
                {
                    Directory.CreateDirectory(@"C:\RWStudio\" + textBox1.Text.Replace('\\', '_').Replace('/', '_').Replace('.', '_').Replace(',', '_').Replace('%', '_'));
                    File.Create(Path.Combine(@"C:\RWStudio\" + textBox1.Text.Replace('\\', '_').Replace('/', '_').Replace('.', '_').Replace(',', '_').Replace('%', '_'), "mod-info.txt")).Close();
                }*/

                //Edit by kc101010 - Cleaned code up, implemented try-catch in case of errors with directories, also implemented new error messages
                try
                {

                    if (Directory.Exists(@"C:\RWStudio\" + textBox1.Text.Replace('\\', '_').Replace('/', '_').Replace('.', '_').Replace(',', '_').Replace('%', '_')))
                    {
                        MessageBox.Show("Mod already exists; Mod name cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (File.Exists(Path.Combine(@"C:\RWStudio\" + textBox1.Text.Replace('\\', '_').Replace('/', '_').Replace('.', '_').Replace(',', '_').Replace('%', '_'), "mod-info.txt")))
                            File.Create(Path.Combine(@"C:\RWStudio\" + textBox1.Text.Replace('\\', '_').Replace('/', '_').Replace('.', '_').Replace(',', '_').Replace('%', '_'), "mod-info.txt")).Close();
                    }
                    else //This else statement prevents messages from appearing as if the mod was being created and prevents user from losing other mod details
                    {
                        Directory.CreateDirectory(@"C:\RWStudio\" + textBox1.Text.Replace('\\', '_').Replace('/', '_').Replace('.', '_').Replace(',', '_').Replace('%', '_'));
                        File.Create(Path.Combine(@"C:\RWStudio\" + textBox1.Text.Replace('\\', '_').Replace('/', '_').Replace('.', '_').Replace(',', '_').Replace('%', '_'), "mod-info.txt")).Close();

                        var parser = new FileIniDataParser();
                        IniData data = parser.ReadFile(Path.Combine(@"C:\RWStudio\" + textBox1.Text.Replace('\\', '_').Replace('/', '_').Replace('.', '_').Replace(',', '_').Replace('%', '_'), "mod-info.txt"));
                        data["mod"]["title"] = textBox1.Text;
                        data["mod"]["description"] = textBox2.Text.Replace(Environment.NewLine, "\\n");
                        data["mod"]["tags"] = textBox3.Text;
                        if (File.Exists(@"C:\RWStudio\" + textBox1.Text.Replace('\\', '_').Replace('/', '_').Replace('.', '_').Replace(',', '_').Replace('%', '_') + "\\thumbnail.png"))
                            data["mod"]["thumbnail"] = "thumbnail.png";
                        parser.WriteFile(Path.Combine(@"C:\RWStudio\" + textBox1.Text.Replace('\\', '_').Replace('/', '_').Replace('.', '_').Replace(',', '_').Replace('%', '_'), "mod-info.txt"), data);
                        openMod f2 = new openMod();
                        Hide();
                        f2.ShowDialog();
                        Close();
                    }
                }
                catch (Exception dirError)
                {
                    MessageBox.Show("Error: " + dirError.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                
            }
            else
            {
                if (!File.Exists(Path.Combine(openMod.s, "mod-info.txt")))
                    File.Create(Path.Combine(openMod.s, "mod-info.txt")).Close();

                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(Path.Combine(openMod.s, "mod-info.txt"));
                data["mod"]["title"] = textBox1.Text;
                data["mod"]["description"] = textBox2.Text.Replace(Environment.NewLine, "\\n");
                data["mod"]["tags"] = textBox3.Text;
                if (File.Exists(openMod.s + "\\thumbnail.png"))
                    data["mod"]["thumbnail"] = "thumbnail.png";
                if (checkBox1.Checked)
                {
                    writeFromCheck(checkBox2, "music", "whenUsingUnitsFromThisMod_playExclusively", data);
                    writeFromCheck(checkBox3, "music", "addToNormalPlaylist", data);
                }
                parser.WriteFile(Path.Combine(openMod.s, "mod-info.txt"),data);
                openMod f2 = new openMod();
                Hide();
                f2.ShowDialog();
                openMod.s = null;
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openMod f2 = new openMod();
            Hide();
           f2.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (string a in listBox1.SelectedItems)
            {
                File.Delete(openMod.s + "\\music\\" + a);
                list();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (openMod.s != null)
            {
                checkBox2.Enabled = checkBox3.Enabled = checkBox1.Checked;
                if (!File.Exists(Path.Combine(openMod.s, "mod-info.txt")))
                    File.Create(Path.Combine(openMod.s, "mod-info.txt")).Close();

                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(Path.Combine(openMod.s, "mod-info.txt"));
                if (checkBox1.Checked)
                {
                    Directory.CreateDirectory(openMod.s + "\\music\\");
                    if (!File.Exists(Path.Combine(openMod.s, "mod-info.txt")))
                        File.Create(Path.Combine(openMod.s, "mod-info.txt")).Close();
                    data["music"]["sourceFolder"] = "music\\";
                }
                else
                {
                    data.Sections.RemoveSection("music");
                }
                parser.WriteFile(Path.Combine(openMod.s, "mod-info.txt"), data);
            }
            else
            {
                checkBox1.Checked = false;
                MessageBox.Show("Please, set thumbnail", "Sorry...");
            }
        }
        private void writeFromCheck(CheckBox txt, string section, string param, IniData data)
        {
            if (txt.Enabled)
            {
                data[section][param] = txt.Checked.ToString();
            }
        }
        private void list()
        {
                listBox1.Items.Clear();
            List<string> dirs = new List<string>(Directory.EnumerateFiles(openMod.s + @"\music"));
                    foreach (string dir in dirs)
                    {
                        listBox1.Items.Add(dir.Split('\\')[dir.Split('\\').Length-1]);
                    }
                    dirs.Clear();
        }
        private void newMod_Load(object sender, EventArgs e)
        {
            if (openMod.s != null && openMod.s != "")
            {
                newM = false;
                Text = "RWStudio: Edit mod";
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(Path.Combine(openMod.s, "mod-info.txt"));
                textBox1.Text = data["mod"]["title"];
                try
                {
                    textBox2.Text = data["mod"]["description"].Replace("\\n", Environment.NewLine);
                }
                catch { }
                textBox3.Text = data["mod"]["tags"];
                if (data["music"]["sourceFolder"] != null)
                {
                    list();
                    checkBox1.Checked = true;
                    checkBox2.Checked = Convert.ToBoolean(data["music"]["whenUsingUnitsFromThisMod_playExclusively"]);
                    checkBox3.Checked = Convert.ToBoolean(data["music"]["addToNormalPlaylist"]);
                }
                if (File.Exists(openMod.s +"\\"+ data["mod"]["thumbnail"]))
                    pictureBox2.BackgroundImage = new Bitmap(openMod.s +"\\"+ data["mod"]["thumbnail"]);

            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please, set mod name", "Sorry...");
            }
            else
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Browse PNG file",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "png",
                    Filter = "png files (*.png)|*.png",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.BackgroundImage = new Bitmap(openFileDialog1.FileName);
                    if (newM)
                    {
                        Directory.CreateDirectory(@"C:\RWStudio\" + textBox1.Text.Replace('\\', '_').Replace('/', '_').Replace('.', '_').Replace(',', '_').Replace('%', '_'));
                        newM = false;
                        checkBox1.Enabled = true;
                        openMod.s = @"C:\RWStudio\" + textBox1.Text.Replace('\\', '_').Replace('/', '_').Replace('.', '_').Replace(',', '_').Replace('%', '_');
                        File.Copy(openFileDialog1.FileName, Path.Combine(@"C:\RWStudio\" + textBox1.Text.Replace('\\', '_').Replace('/', '_').Replace('.', '_').Replace(',', '_').Replace('%', '_'), "thumbnail.png"), true);
                    }
                    else
                        File.Copy(openFileDialog1.FileName, Path.Combine(openMod.s, "thumbnail.png"), true);
                }
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string picture_path;
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse file",

                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = true,
                DefaultExt = "png",
                Filter = "wav files(*.wav)|*.wav|ogg files(*.ogg)|*.ogg",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Directory.CreateDirectory(openMod.s + "\\music\\");
                foreach (string pp in openFileDialog1.FileNames)
                {
                    picture_path = pp;
                    File.Copy(picture_path, Path.Combine(openMod.s, "music", new DirectoryInfo(picture_path).Name.Replace(" ", "_")), true);

                }
                list();
            }
        
        }
    }
}
