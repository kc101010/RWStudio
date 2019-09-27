using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RWS
{
    public partial class action : Form
    {
        public action()
        {
            InitializeComponent();
        }

        private void action_Load(object sender, EventArgs e)
        {
            string[] s1ss = Directory.GetFiles(editUnit.path, "*.png");
            for (int i = 0; i < s1ss.Length; i++)
            {
                icon.Items.Add(new DirectoryInfo(s1ss[i]).Name);
            }
            string[] s1s1s = Directory.GetFiles(editUnit.path, "*.wav");
            for (int i = 0; i < s1s1s.Length; i++)
            {
                sound.Items.Add(new DirectoryInfo(s1s1s[i]).Name);
                gsound.Items.Add(new DirectoryInfo(s1s1s[i]).Name);
            }
            string[] s1s1s1 = Directory.GetFiles(editUnit.path, "*.ogg");
            for (int i = 0; i < s1s1s1.Length; i++)
            {
                sound.Items.Add(new DirectoryInfo(s1s1s1[i]).Name);
                gsound.Items.Add(new DirectoryInfo(s1s1s1[i]).Name);
            }
            if (editUnit.lastact != null)
            {
                namee.Enabled = false;
                List<Control> txt = Controls.OfType<TextBox>().Cast<Control>().ToList();
                List<Control> cb = Controls.OfType<ComboBox>().Cast<Control>().ToList();
                List<CheckBox> ch = Controls.OfType<CheckBox>().Cast<CheckBox>().ToList();
                string[] sss = Directory.GetFiles(editUnit.path, "*.ini");
                var parser = new IniParser.FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                for (int i = 0; i < txt.Count; i++)
                {
                    if (txt[i].Tag != null)
                        txt[i].Text = data["action_" + editUnit.lastact][txt[i].Tag.ToString()].Replace("\\n", Environment.NewLine);
                }
                for (int i = 0; i < cb.Count; i++)
                {
                    if (cb[i].Tag != null)
                        cb[i].Text = data["action_" + editUnit.lastact][cb[i].Tag.ToString()];
                }
                for (int i = 0; i < ch.Count; i++)
                {
                    if (ch[i].Tag != null)
                        ch[i].Checked = Convert.ToBoolean(data["action_" + editUnit.lastact][ch[i].Tag.ToString()]);
                }
                namee.Text = editUnit.lastact;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<Control> txt = Controls.OfType<TextBox>().Cast<Control>().ToList();
            List<Control> cb = Controls.OfType<ComboBox>().Cast<Control>().ToList();
            List<CheckBox> ch = Controls.OfType<CheckBox>().Cast<CheckBox>().ToList();
            string[] sss = Directory.GetFiles(editUnit.path, "*.ini");
            var parser = new IniParser.FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);
            for (int i = 0; i < txt.Count; i++)
            {
                if (txt[i].Text != "" && txt[i].Text != " " && txt[i].Enabled)
                {
                    if (txt[i].Tag.ToString() != "")
                        data["action_" + namee.Text][txt[i].Tag.ToString()] = txt[i].Text.Replace(Environment.NewLine, "\\n");
                }
            }
            for (int i = 0; i < cb.Count; i++)
            {
                if (cb[i].Text != "" && cb[i].Text != " " && cb[i].Enabled)
                {
                    if (cb[i].Tag.ToString() != "")
                        data["action_" + namee.Text][cb[i].Tag.ToString()] = cb[i].Text;
                }
            }
            for (int i = 0; i < ch.Count; i++)
            {
                    if (ch[i].Tag.ToString() != "")
                        data["action_" + namee.Text][ch[i].Tag.ToString()] = ch[i].Checked.ToString();
            }
            parser.WriteFile(sss[0], data);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
