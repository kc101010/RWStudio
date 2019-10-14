using IniParser;
using IniParser.Model;
using System;
using System.IO;
using System.Windows.Forms;

namespace RWS
{
    public partial class canBuild : Form
    {
        public canBuild()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void canBuild_Load(object sender, EventArgs e)
        {
            if(editUnit.lastcb != null)
            {
                string[] sss = Directory.GetFiles(editUnit.path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                name.Enabled = false;
                name.Text = editUnit.lastcb;
                uname.Text = data["canBuild_" + editUnit.lastcb]["name"];
                pos.Text = data["canBuild_" + editUnit.lastcb]["pos"];
                locked.Text = data["canBuild_" + editUnit.lastcb]["isLocked"];
                lockedmess.Text = data["canBuild_" + editUnit.lastcb]["isLockedMessage"];
                price.Value = Convert.ToInt32(data["canBuild_" + editUnit.lastcb]["price"]);
                level.Text = data["canBuild_" + editUnit.lastcb]["tech"];
                fn.Checked = Convert.ToBoolean(data["canBuild_" + editUnit.lastcb]["forceNano"]);

                if (data["canBuild_" + editUnit.lastcb]["isVisible"] != null)
                    vb.Checked = Convert.ToBoolean(data["canBuild_" + editUnit.lastcb]["isVisible"]);
                else
                    vb.Checked = true;
            }
            else
            {
                name.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] sss = Directory.GetFiles(editUnit.path, "*.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);

            if (name.Enabled)
                editUnit.lastcb = name.Text;

            writeFromTextbox(uname, "canBuild_" + editUnit.lastcb, "name", data);
            writeFromTextbox(pos, "canBuild_" + editUnit.lastcb, "pos", data);
            writeFromTextbox(locked, "canBuild_" + editUnit.lastcb, "isLocked", data);
            writeFromTextbox(lockedmess, "canBuild_" + editUnit.lastcb, "isLockedMessage", data);
            writeFromTextbox(level, "canBuild_" + editUnit.lastcb, "tech", data);
            writeFromNumeric(price, "canBuild_" + editUnit.lastcb, "price", data);
            writeFromCheck(vb, "canBuild_" + editUnit.lastcb, "isVisible", data);
            writeFromCheck(fn, "canBuild_" + editUnit.lastcb, "forceNano", data);
            parser.WriteFile(sss[0], data);
            editUnit.lastcb = null;
            Close();
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
        private void writeFromCheck(CheckBox txt, string section, string param, IniData data)
        {
            if (txt.Enabled)
            {
                data[section][param] = txt.Checked.ToString();
            }
            else if (data[section][param] != null)
            {
                data[section].RemoveKey(param);
            }
        }
    }
}
