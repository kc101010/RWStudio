using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                if (textBox1.Text.Length > 0 && !File.Exists(Path.Combine(openMod.s, textBox1.Text, new DirectoryInfo(picture_path).Name)) && !File.Exists(Path.Combine(openMod.s, textBox1.Text, textBox1.Text + ".ini")))
                {
                    Directory.CreateDirectory(Path.Combine(openMod.s, textBox1.Text));
                    File.Copy(picture_path, Path.Combine(openMod.s, textBox1.Text, new DirectoryInfo(picture_path).Name.Replace(" ", string.Empty)));
 
                    File.Create(Path.Combine(openMod.s, textBox1.Text, textBox1.Text + ".ini")).Close();
                    var parser = new FileIniDataParser();
                    IniData data = parser.ReadFile(Path.Combine(openMod.s, textBox1.Text, textBox1.Text + ".ini"));
                    data["core"]["name"] = textBox1.Text;
                    data["core"]["displayText"] = textBox2.Text;
                    data["core"]["displayDescription"] = textBox3.Text.Replace(Environment.NewLine, "\\n");
                    data["graphics"]["image"] = new DirectoryInfo(picture_path).Name;
                    parser.WriteFile(Path.Combine(openMod.s, textBox1.Text, textBox1.Text + ".ini"), data);
                    Close();
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
