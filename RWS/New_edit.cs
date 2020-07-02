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


/*
            NEW EDIT UNIT PAGE - Rusted Warfare Studio
            - Designed by kc101010
            - code are written by тestName 
*/

namespace RWS
{
    public partial class New_edit : Form
    {
        public static string path;    //Var path used to store .ini path of selected unit
        public static string lastcb;  //holds selected canbuit
        public static string lastt;   //holds selected turret
        public static string lastprj; //holds selected projectile
        public static string namE;    //holds something, also i dont remember why last latter is big
        public static string lastbf;  //holds selected buildFrom
        public static string lastact; //holds selected action
        public static string lastleg; //holds selected leg
        public static string lastanim;//holds selected animation

        public New_edit()
        {
            path = unitList.inipath;
            InitializeComponent();
        }
        private void unit_picture_Click(object sender, EventArgs e)
        {
            string picture_path;
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
                unit_picture.BackgroundImage = new Bitmap(picture_path);

                File.Copy(picture_path, Path.Combine(path, new DirectoryInfo(picture_path).Name.Replace(" ", string.Empty)));

                string[] sss = Directory.GetFiles(path, "*.ini");
                var parser = new FileIniDataParser();

                IniData data = parser.ReadFile(sss[0]);

                data["graphics"]["image"] = new DirectoryInfo(picture_path).Name.Replace(" ", string.Empty);
                parser.WriteFile(sss[0], data);
            }
        }

        private void unit_dead_Click(object sender, EventArgs e)
        {
            string picture_path;
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
                picture_path = openFileDialog1.FileName;                                                                            //Save filepath to variable
                unit_dead.BackgroundImage = new Bitmap(picture_path);                                                               //Set dead image picbox to users img

                File.Copy(picture_path, Path.Combine(path, new DirectoryInfo(picture_path).Name.Replace(" ", string.Empty)));       //Copy the img file into unit directory

                string[] sss = Directory.GetFiles(path, "*.ini");                                                                   //Get the units ini file
                var parser = new FileIniDataParser();                                                                               //Declare new ini parser

                IniData data = parser.ReadFile(sss[0]);                                                                             //Read ini file w/ parser

                data["graphics"]["image_dead"] = new DirectoryInfo(picture_path).Name.Replace(" ", string.Empty);                   //load new data to ini file in the correct data section
                parser.WriteFile(sss[0], data);                                                                                     //write ini data

            }

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            List<Control> txt = dynamicArea.Controls.OfType<TextBox>().Cast<Control>().ToList();  //get all texboxes from form
            List<Control> cb = dynamicArea.Controls.OfType<ComboBox>().Cast<Control>().ToList();  //all comboboxes
            List<CheckBox> ch = dynamicArea.Controls.OfType<CheckBox>().Cast<CheckBox>().ToList();//all checkboxes
            string[] sss = Directory.GetFiles(path, "*.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);
            //tag format
            //section`parameter
            //example:
            //core`mass
            for (int i = 0; i < txt.Count-1; i++)
            {
                if (!string.IsNullOrWhiteSpace(txt[i].Text) && txt[i].Enabled && !string.IsNullOrWhiteSpace(txt[i].Tag.ToString())) //if textbox enabled and not empty
                        data[txt[i].Tag.ToString().Split('`')[0]][txt[i].Tag.ToString().Split('`')[1]] = txt[i].Text.Replace(Environment.NewLine, "\\n"); //write data to ini file

                else if (!string.IsNullOrWhiteSpace(data[txt[i].Tag.ToString().Split('`')[0]][txt[i].Tag.ToString().Split('`')[1]]))
                    data[txt[i].Tag.ToString().Split('`')[0]].RemoveKey(txt[i].Tag.ToString().Split('`')[1]); //delete data from ini
            }
            //same s*t
            for (int i = 0; i < cb.Count-1; i++)
            {
                if (!string.IsNullOrWhiteSpace(cb[i].Text) && cb[i].Enabled && !string.IsNullOrWhiteSpace(cb[i].Tag.ToString()))
                        data[cb[i].Tag.ToString().Split('`')[0]][cb[i].Tag.ToString().Split('`')[1]] = cb[i].Text;

                else if (!string.IsNullOrWhiteSpace(data[cb[i].Tag.ToString().Split('`')[0]][cb[i].Tag.ToString().Split('`')[1]]))
                    data[cb[i].Tag.ToString().Split('`')[0]].RemoveKey(cb[i].Tag.ToString().Split('`')[1]);
            }
            //same s*t
            for (int i = 0; i < ch.Count-1; i++)
            {
                if (!string.IsNullOrWhiteSpace(ch[i].Tag.ToString()) && ch[i].Enabled)
                    data[ch[i].Tag.ToString().Split('`')[0]][ch[i].Tag.ToString().Split('`')[1]] = ch[i].Checked.ToString();

                else if (!string.IsNullOrWhiteSpace(data[ch[i].Tag.ToString().Split('`')[0]][ch[i].Tag.ToString().Split('`')[1]]))
                    data[ch[i].Tag.ToString().Split('`')[0]].RemoveKey(ch[i].Tag.ToString().Split('`')[1]);
            }
            parser.WriteFile(sss[0], data); //save data
            unitList ul = new unitList();
            Hide();
            ul.ShowDialog();
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            unitList ul = new unitList();
            Hide();
            ul.ShowDialog();
            Close();
        }

        private Form active = null;
        private void childForm(Form child) 
        {
            if (active != null)
                active.Close();
            active = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            dynamicArea.Controls.Add(child);
            dynamicArea.Tag = child;
            child.BringToFront();
            child.Show();
        }

        private void button_Core_Click(object sender, EventArgs e)
        {
            // new editCore().ShowDialog();
            childForm(new editCore()    );
        }
    }
}
