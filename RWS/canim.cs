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
    public partial class canim : Form
    {
        public canim()
        {
            InitializeComponent();
        }

        private void castomanim_Load(object sender, EventArgs e)
        {
            if (editUnit.lastanim != null)
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
                        txt[i].Text = data["animation_" + editUnit.lastanim][txt[i].Tag.ToString()];
                }
                for (int i = 0; i < cb.Count; i++)
                {
                    if (cb[i].Tag != null)
                        cb[i].Text = data["animation_" + editUnit.lastanim][cb[i].Tag.ToString()];
                }
                for (int i = 0; i < ch.Count; i++)
                {
                    if (ch[i].Tag != null)
                        ch[i].Checked = Convert.ToBoolean(data["animation_" + editUnit.lastanim][ch[i].Tag.ToString()]);
                }
                namee.Text = editUnit.lastanim;
                string[] strings = data.ToString().Split(new[] { '\r', '\n' });
                foreach (string s in strings)
                {
                    if (s.Contains("#")) ;
                    else
                    {
                        if (s.Contains("arm") && s.Contains("_") && s.Contains("s"))
                        {
                            textBox3.Text = textBox3.Text + s + Environment.NewLine;
                        }
                        if (s.Contains("leg") && s.Contains("_") && s.Contains("s"))
                        {
                            textBox3.Text = textBox3.Text + s + Environment.NewLine;
                        }
                        if (s.Contains("body") && s.Contains("_") && s.Contains("s"))
                        {
                            textBox3.Text = textBox3.Text + s + Environment.NewLine;
                        }
                    }
                }
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
            data["animation_" + namee.Text].RemoveAllKeys();
            for (int i = 0; i < txt.Count; i++)
            {   if (txt[i].Tag != null && txt[i].Tag.ToString() != "")
                {
                    if (txt[i].Text != "" && txt[i].Text != " " && txt[i].Enabled)
                    {

                        data["animation_" + namee.Text][txt[i].Tag.ToString()] = txt[i].Text;
                    }
                    else if (data["animation_" + namee.Text][txt[i].Tag.ToString()] != null)
                    {
                        data["animation_" + namee.Text].RemoveKey(txt[i].Tag.ToString());
                    }
                }
            }
            for (int i = 0; i < cb.Count; i++)
            {
                if (cb[i].Text != "" && cb[i].Text != " " && cb[i].Enabled)
                {
                    if (cb[i].Tag.ToString() != "")
                        data["animation_" + namee.Text][cb[i].Tag.ToString()] = cb[i].Text;
                }
                else if (data["animation_" + namee.Text][cb[i].Tag.ToString()] != null)
                {
                    data["animation_" + namee.Text].RemoveKey(cb[i].Tag.ToString());
                }
            }
            for (int i = 0; i < ch.Count; i++)
            {
                if (ch[i].Tag.ToString() != "")
                    data["animation_" + namee.Text][ch[i].Tag.ToString()] = ch[i].Checked.ToString();
            }
            string[] strings = textBox3.Text.Split(new[] { '\r', '\n' });
            foreach (string s in strings)
            {
                if (s.Contains("#")) ;
                else if (s.Contains(":"))
                {
                    data["animation_" + namee.Text].RemoveKey(s.Split(new char[] { ':' }, 2, StringSplitOptions.None)[0]);
                    data["animation_" + namee.Text][s.Split(new char[] { ':' }, 2, StringSplitOptions.None)[0]] = s.Split(new char[] { ':' }, 2, StringSplitOptions.None)[1];
                }

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
