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
            - code aspects copied from editUnit.cs and are written by тestName
            
 
 
 
 
 */

namespace RWS
{
    public partial class New_edit : Form
    {
        public static string path;  //Var path used to store .ini path of selected unit
        

        public New_edit()
        {
            path = unitList.inipath;
            InitializeComponent();
        }
        private void writeFromNumeric(NumericUpDown txt, string section, string param, IniData data)
        {
            if (txt.Value != 0 && txt.Enabled)
            {
                data[section][param] = txt.Value.ToString();
            }
            else if (data[section][param] != null)
            {
                data[section].RemoveKey(param);
            }
        }

        private void writeFromTextbox(TextBox txt, string section, string param, IniData data)
        {
            if (txt.Text != null && txt.Text != "" && txt.Text != " " && txt.Enabled)
            {
                data[section][param] = txt.Text;
            }
            else if (data[section][param] != null)
            {
                data[section].RemoveKey(param);
            }
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
            //Declare components for ini data processing
            string[] iniFilesList = Directory.GetFiles(path, "*.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(iniFilesList[0]);

            //write all data from this UI 
            writeFromNumeric(hp, "core", "maxHp", data);
            writeFromNumeric(price, "core", "price", data);
            writeFromNumeric(mass, "core", "mass", data);
            data["core"]["class"] = "CustomUnitMetadata";
            writeFromTextbox(buildspeed, "core", "buildSpeed", data);
            writeFromNumeric(level, "core", "techLevel", data);
            writeFromNumeric(radius, "core", "radius", data);
            writeFromNumeric(dradius, "core", "displayRadius", data);
            data["core"]["displayDescription"] = descript.Text.Replace(Environment.NewLine, "\\n");
            writeFromTextbox(name, "core", "displayText", data);


        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            unitList ul = new unitList();
            Hide();
            ul.ShowDialog();
            Close();
        }
    }
}
