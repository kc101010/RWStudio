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
            if(New_edit.lastcb != null)
            {
                string[] sss = Directory.GetFiles(New_edit.path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                name.Enabled = false;
                name.Text = New_edit.lastcb;
                uname.Text = data["canBuild_" + New_edit.lastcb]["name"];
                pos.Text = data["canBuild_" + New_edit.lastcb]["pos"];
                locked.Text = data["canBuild_" + New_edit.lastcb]["isLocked"];
                lockedmess.Text = data["canBuild_" + New_edit.lastcb]["isLockedMessage"];
                price.Value = Convert.ToInt32(data["canBuild_" + New_edit.lastcb]["price"]);
                level.Text = data["canBuild_" + New_edit.lastcb]["tech"];
                fn.Checked = Convert.ToBoolean(data["canBuild_" + New_edit.lastcb]["forceNano"]);

                if (data["canBuild_" + New_edit.lastcb]["isVisible"] != null)
                    vb.Checked = Convert.ToBoolean(data["canBuild_" + New_edit.lastcb]["isVisible"]);
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
            string[] sss = Directory.GetFiles(New_edit.path, "*.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);

            if (name.Enabled)
                New_edit.lastcb = name.Text;

            writeFromTextbox(uname, "canBuild_" + New_edit.lastcb, "name", data);
            writeFromTextbox(pos, "canBuild_" + New_edit.lastcb, "pos", data);
            writeFromTextbox(locked, "canBuild_" + New_edit.lastcb, "isLocked", data);
            writeFromTextbox(lockedmess, "canBuild_" + New_edit.lastcb, "isLockedMessage", data);
            writeFromTextbox(level, "canBuild_" + New_edit.lastcb, "tech", data);
            writeFromNumeric(price, "canBuild_" + New_edit.lastcb, "price", data);
            writeFromCheck(vb, "canBuild_" + New_edit.lastcb, "isVisible", data);
            writeFromCheck(fn, "canBuild_" + New_edit.lastcb, "forceNano", data);
            parser.WriteFile(sss[0], data);
            New_edit.lastcb = null;
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
