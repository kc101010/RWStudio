using IniParser;
using IniParser.Model;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RWS
{
    public partial class addUnit : Form
    {
        string picture_path;
        public addUnit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (picture_path != null)
                {
                    if (textBox2.Text.Length > 0 && !File.Exists(Path.Combine(openMod.s, textBox2.Text.Replace(" ", "_"), new DirectoryInfo(picture_path).Name)) && !File.Exists(Path.Combine(openMod.s, textBox2.Text.Replace(" ", "_"), textBox2.Text.Replace(" ", "_") + ".ini")))
                    {                      
                        Directory.CreateDirectory(Path.Combine(openMod.s, textBox2.Text.Replace(" ", "_")));
                        File.Copy(picture_path, Path.Combine(openMod.s, textBox2.Text.Replace(" ", "_"), new DirectoryInfo(picture_path).Name.Replace(" ", "_")));

                        File.Create(Path.Combine(openMod.s, textBox2.Text.Replace(" ", "_"), textBox2.Text.Replace(" ", "_") + ".ini")).Close();
                        var parser = new FileIniDataParser();
                        IniData data = parser.ReadFile(Path.Combine(openMod.s, textBox2.Text.Replace(" ", "_"), textBox2.Text.Replace(" ", "_") + ".ini"));
                        data["core"]["name"] = textBox2.Text.Replace(" ", "_");
                        data["core"]["displayText"] = textBox2.Text;
                        data["core"]["displayDescription"] = textBox3.Text.Replace(Environment.NewLine, "\\n");
                        data["graphics"]["image"] = new DirectoryInfo(picture_path).Name;
                        parser.WriteFile(Path.Combine(openMod.s, textBox2.Text.Replace(" ", "_"), textBox2.Text.Replace(" ", "_") + ".ini"), data);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Unit cant be without image :P");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unknow err:\n"+ex);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
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
                picture_path = openFileDialog1.FileName;
                pictureBox1.BackgroundImage = new Bitmap(picture_path);
            }          
        }
    }
}
