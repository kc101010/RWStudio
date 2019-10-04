using IniParser.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RWS
{
    public partial class arms : Form
    {
        public arms()
        {
            InitializeComponent();
        }

        private void arms_Load(object sender, EventArgs e)
        {
            string[] s1ss = System.IO.Directory.GetFiles(editUnit.path, "*.png");
            for (int i = 0; i < s1ss.Length; i++)
            {
                icon.Items.Add(new System.IO.DirectoryInfo(s1ss[i]).Name);
                lm.Items.Add(new System.IO.DirectoryInfo(s1ss[i]).Name);
            }
            if (editUnit.lastleg != null)
            {
                namee.Enabled = false;
                List<Control> txt = Controls.OfType<TextBox>().Cast<Control>().ToList();
                List<Control> cb = Controls.OfType<ComboBox>().Cast<Control>().ToList();
                List<CheckBox> ch = Controls.OfType<CheckBox>().Cast<CheckBox>().ToList();
                string[] sss = System.IO.Directory.GetFiles(editUnit.path, "*.ini");
                var parser = new IniParser.FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                for (int i = 0; i < txt.Count; i++)
                {
                    if (txt[i].Tag != null)
                        txt[i].Text = data["arm_" + editUnit.lastleg][txt[i].Tag.ToString()];
                }
                for (int i = 0; i < cb.Count; i++)
                {
                    if (cb[i].Tag != null)
                        cb[i].Text = data["arm_" + editUnit.lastleg][cb[i].Tag.ToString()];
                }
                for (int i = 0; i < ch.Count; i++)
                {
                    if (ch[i].Tag != null)
                        ch[i].Checked = Convert.ToBoolean(data["arm_" + editUnit.lastleg][ch[i].Tag.ToString()]);
                }
                namee.Text = editUnit.lastleg;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                List<Control> txt = Controls.OfType<TextBox>().Cast<Control>().ToList();
                List<Control> cb = Controls.OfType<ComboBox>().Cast<Control>().ToList();
                List<CheckBox> ch = Controls.OfType<CheckBox>().Cast<CheckBox>().ToList();
                string[] sss = System.IO.Directory.GetFiles(editUnit.path, "*.ini");
                var parser = new IniParser.FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                for (int i = 0; i < txt.Count; i++)
                {
                    if (txt[i].Text != "" && txt[i].Text != " " && txt[i].Enabled)
                    {
                        if (txt[i].Tag.ToString() != "")
                            data["arm_" + namee.Text][txt[i].Tag.ToString()] = txt[i].Text.Replace(Environment.NewLine, "\\n");
                    }
                }
                for (int i = 0; i < cb.Count; i++)
                {
                    if (cb[i].Text != "" && cb[i].Text != " " && cb[i].Enabled)
                    {
                        if (cb[i].Tag.ToString() != "")
                            data["arm_" + namee.Text][cb[i].Tag.ToString()] = cb[i].Text;
                    }
                }
                for (int i = 0; i < ch.Count; i++)
                {
                    if (!ch[i].Enabled) ;

                    if (ch[i].Tag.ToString() != "")
                        data["arm_" + namee.Text][ch[i].Tag.ToString()] = ch[i].Checked.ToString();
                }
                parser.WriteFile(sss[0], data);
                Close();
        }
    }
}
