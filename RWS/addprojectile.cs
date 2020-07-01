using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RWS
{
    public partial class addprojectile : Form
    {
        public addprojectile()
        {
            InitializeComponent();
            loadlist();
        }

        public static string projectile;
        private void ballistic_CheckedChanged(object sender, EventArgs e)
        {
            if (ballistic.Checked)
            {
                //groupBox4.Enabled = true;
            }
            else
            {
               // groupBox4.Enabled = false;
            }
        }
        private void loadlist()
        {
            string[] sss = Directory.GetFiles(New_edit.path, "*.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);
            string[] sss1 = Directory.GetFiles(New_edit.path, "*.png");
            for (int i = 0; i < sss1.Length; i++)
            {
                image.Items.Add(new DirectoryInfo(sss1[i]).Name);
            }
            string[] strings = data.ToString().Split(new[] { '\r', '\n' });
            bflist.Items.Clear();
            e1.Items.Clear();
            e2.Items.Clear();
            e3.Items.Clear();
            foreach (string s in strings)
            {
                if (s.Contains("#")) ;
                else
                {
                    if (s.Contains("[effect_") && s.Contains("]"))
                    {
                        string[] str;
                        str = s.Split(new char[] { '_', ']' });
                        e1.Items.Add(str[1]);
                        e2.Items.Add(str[1]);
                        e3.Items.Add(str[1]);
                    }
                    if (s.Contains("mutator") && (s.Contains("_ifUnitWithTags") || s.Contains("_ifUnitWithoutTags")) && !bflist.Items.Contains(s.Split(new char[] { 'r', '_' })[1]))
                    {
                        bflist.Items.Add(s.Split(new char[] { 'r', '_' })[1]);
                    }
                }
            }
        }
        private void addprojectile_Load(object sender, EventArgs e)
        {
                if (New_edit.lastprj != null)
                {
                    namee.Enabled = false;
                    List<Control> txt = Controls.OfType<TextBox>().Cast<Control>().ToList();
                    List<Control> cb = Controls.OfType<ComboBox>().Cast<Control>().ToList();
                    List<CheckBox> ch = Controls.OfType<CheckBox>().Cast<CheckBox>().ToList();
                    string[] sss = Directory.GetFiles(New_edit.path, "*.ini");
                    var parser = new FileIniDataParser();
                    IniData data = parser.ReadFile(sss[0]);
                    for (int i = 0; i < txt.Count; i++)
                    {
                        if (txt[i].Tag != null && data["projectile_" + New_edit.lastprj][txt[i].Tag.ToString()] != null)
                            txt[i].Text = data["projectile_" + New_edit.lastprj][txt[i].Tag.ToString()];
                    }
                    for (int i = 0; i < cb.Count; i++)
                    {
                        if (cb[i].Tag != null)
                            cb[i].Text = data["projectile_" + New_edit.lastprj][cb[i].Tag.ToString()];
                    }
                    for (int i = 0; i < ch.Count; i++)
                    {
                        if (ch[i].Tag != null)
                            ch[i].Checked = Convert.ToBoolean(data["projectile_" + New_edit.lastprj][ch[i].Tag.ToString()]);
                    }
                    namee.Text = New_edit.lastprj;
                button1.BackColor = ColorTranslator.FromHtml(color.Text);

                button2.BackColor = ColorTranslator.FromHtml(lighColor.Text);
                }
                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
         
        private void button4_Click(object sender, EventArgs e)
        {
            List<Control> txt = Controls.OfType<TextBox>().Cast<Control>().ToList();
            List<Control> cb = Controls.OfType<ComboBox>().Cast<Control>().ToList();
            List<CheckBox> ch = Controls.OfType<CheckBox>().Cast<CheckBox>().ToList();
            string[] sss = Directory.GetFiles(New_edit.path, "*.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(sss[0]);
            for (int i = 0; i < txt.Count; i++)
            {
                if (txt[i].Text != "" && txt[i].Text != " " && txt[i].Enabled && txt[i].Tag != null)
                {
                    if (txt[i].Tag.ToString() != "")
                        data["projectile_" + namee.Text][txt[i].Tag.ToString()] = txt[i].Text.Replace(Environment.NewLine, "\\n");
                }
                else if (txt[i].Tag != null)
                {
                    if (data["projectile_" + namee.Text][txt[i].Tag.ToString()] != null)
                    {
                        data["projectile_" + namee.Text].RemoveKey(txt[i].Tag.ToString());
                    }
                }
            }
            for (int i = 0; i < cb.Count; i++)
            {
                if (cb[i].Text != "" && cb[i].Text != " " && cb[i].Enabled && txt[1].Tag != null)
                {
                    if (cb[i].Tag.ToString() != "")
                        data["projectile_" + namee.Text][cb[i].Tag.ToString()] = cb[i].Text;
                }
                else if (data["projectile_" + namee.Text][cb[i].Tag.ToString()] != null)
                {
                    data["projectile_" + namee.Text].RemoveKey(cb[i].Tag.ToString());
                }
            }
            for (int i = 0; i < ch.Count; i++)
            {
                if (ch[i].Tag != null)
                {
                    if (ch[i].Tag.ToString() != "")
                    {
                        data["projectile_" + namee.Text][ch[i].Tag.ToString()] = ch[i].Checked.ToString();
                    }
                    else if (data["projectile_" + namee.Text][ch[i].Tag.ToString()] != null)
                    {
                        data["projectile_" + namee.Text].RemoveKey(ch[i].Tag.ToString());
                    }
                }
            }
            parser.WriteFile(sss[0], data);
            New_edit.lastprj = null;
            Close();
        }

        private void writeFromTextbox(TextBox txt, string section, string param, IniData data)
        {
            if (txt.Text != null && txt.Text != "" && txt.Text != " " && txt.Enabled)
            {
                data[section][param] = txt.Text;
            }
        }
        private void writeFromCombotbox(ComboBox txt, string section, string param, IniData data)
        {
            if (txt.Text != null && txt.Text != "" && txt.Text != " " && txt.Enabled)
            {
                data[section][param] = txt.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            button2.BackColor = colorDialog1.Color;
            lighColor.Text = HexConverter(colorDialog1.Color);
        }
        private static String HexConverter(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            button1.BackColor = colorDialog1.Color;
            color.Text = HexConverter(colorDialog1.Color);
        }

        private void instant_CheckedChanged(object sender, EventArgs e)
        {
            if (instant.Checked)
            {
                targetground.Checked = false;
                targetground.Enabled = false;
            }
            else
            {
                targetground.Enabled = true;
            }
        }

        private void targetground_CheckedChanged(object sender, EventArgs e)
        {
            if (targetground.Checked)
            {
               instant.Checked = false;
               instant.Enabled = false;
            }
            else
            {
                instant.Enabled = true;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            projectile = namee.Text;
            mutator r = new mutator();
            r.ShowDialog();
            loadlist();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (bflist.SelectedItem != null)
            {
                string[] sss = Directory.GetFiles(New_edit.path, "*.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(sss[0]);
                data.Sections.GetSectionData("projectile_" + namee.Text).Keys.RemoveKey("mutator" + bflist.SelectedItem.ToString() + "_ifUnitWithTags");
                data.Sections.GetSectionData("projectile_" + namee.Text).Keys.RemoveKey("mutator" + bflist.SelectedItem.ToString() + "_ifUnitWithoutTags");
                data.Sections.GetSectionData("projectile_" + namee.Text).Keys.RemoveKey("mutator" + bflist.SelectedItem.ToString() + "_directDamageMultiplier");
                data.Sections.GetSectionData("projectile_" + namee.Text).Keys.RemoveKey("mutator" + bflist.SelectedItem.ToString() + "_areaDamageMultiplier");
                parser.WriteFile(sss[0], data);
                loadlist();
            }
            else
            {
                MessageBox.Show("Select item first");
            }
        }
    }
}
