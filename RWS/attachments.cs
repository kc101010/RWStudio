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
    public partial class attachments : Form
    {
        public attachments()
        {
            InitializeComponent();
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
            string[] sss = Directory.GetFiles(New_edit.path, "*.ini");
            var parser = new IniParser.FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);
            for (int i = 0; i < txt.Count; i++)
            {
                if (txt[i].Text != "" && txt[i].Text != " " && txt[i].Enabled)
                {
                    if (txt[i].Tag.ToString() != "")
                        data["attachment_" + namee.Text][txt[i].Tag.ToString()] = txt[i].Text;
                }
                else if (data["attachment_" + namee.Text][txt[i].Tag.ToString()] != null)
                {
                    data["attachment_" + namee.Text].RemoveKey(txt[i].Tag.ToString());
                }
            }
            for (int i = 0; i < cb.Count; i++)
            {
                if (cb[i].Text != "" && cb[i].Text != " " && cb[i].Enabled)
                {
                    if (cb[i].Tag.ToString() != "")
                        data["attachment_" + namee.Text][cb[i].Tag.ToString()] = cb[i].Text;
                }
                else if (data["attachment_" + namee.Text][cb[i].Tag.ToString()] != null)
                {
                    data["attachment_" + namee.Text].RemoveKey(cb[i].Tag.ToString());
                }
            }
            for (int i = 0; i < ch.Count; i++)
            {
                if (ch[i].Tag.ToString() != "")
                    data["attachment_" + namee.Text][ch[i].Tag.ToString()] = ch[i].Checked.ToString();
                else if (data["attachment_" + namee.Text][ch[i].Tag.ToString()] != null)
                {
                    data["attachment_" + namee.Text].RemoveKey(ch[i].Tag.ToString());
                }
            }
            parser.WriteFile(sss[0], data);
            Close();
        }

        private void attachments_Load(object sender, EventArgs e)
        {
            if (New_edit.lastact != null)
            {
                namee.Enabled = false;
                List<Control> txt = Controls.OfType<TextBox>().Cast<Control>().ToList();
                List<Control> cb = Controls.OfType<ComboBox>().Cast<Control>().ToList();
                List<CheckBox> ch = Controls.OfType<CheckBox>().Cast<CheckBox>().ToList();
                string[] sss = Directory.GetFiles(New_edit.path, "*.ini");
                var parser = new IniParser.FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                for (int i = 0; i < txt.Count; i++)
                {
                    if (txt[i].Tag != null && data["action_" + New_edit.lastact][txt[i].Tag.ToString()] != null)
                        txt[i].Text = data["action_" + New_edit.lastact][txt[i].Tag.ToString()].Replace("\\n", Environment.NewLine);
                }
                for (int i = 0; i < cb.Count; i++)
                {
                    if (cb[i].Tag != null)
                        cb[i].Text = data["action_" + New_edit.lastact][cb[i].Tag.ToString()];
                }
                for (int i = 0; i < ch.Count; i++)
                {
                    if (ch[i].Tag != null)
                        ch[i].Checked = Convert.ToBoolean(data["action_" + New_edit.lastact][ch[i].Tag.ToString()]);
                }
                namee.Text = New_edit.lastact;
            }
        }
    }
}
