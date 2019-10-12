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

    public partial class openMod : Form
    {
        public static string s;
        public openMod()
        {
            InitializeComponent();
            LoadMods();
        }
        private void LoadMods()
        {
            string s2 = "";
            try
            {
                listView1.Clear();
                imageList1.Dispose();

                string[] s = Directory.EnumerateDirectories(@"C:\RWStudio").ToArray();
                for (int a = 0; a < s.Length; a++)
                {
                    var parser = new FileIniDataParser();
                    string[] sss = Directory.GetFiles(s[a], "mod-info.txt");
                    IniData data = parser.ReadFile(sss[0]);
                    if (data["mod"]["thumbnail"] != null)
                    {
                        if (File.Exists(Path.Combine(s[a], data["mod"]["thumbnail"].Replace(" ", string.Empty))))
                        {
                            Bitmap tmp = new Bitmap(Path.Combine(s[a], data["mod"]["thumbnail"].Replace(" ", string.Empty)));
                            Bitmap bmp = new Bitmap(tmp);
                            imageList1.Images.Add(bmp);
                            tmp.Dispose();
                        }
                        else
                        {
                            s2 = s2 + "Err: I cant find unit image file in folder " + s[a] + "\n";
                            Bitmap bmp = new Bitmap(78, 78);
                            using (Graphics gr = Graphics.FromImage(bmp))
                            {
                                gr.Clear(Color.Gray);
                            }
                            imageList1.Images.Add(bmp);
                        }
                    }else
                    {
                        s2 = s2 + "Err: I cant see image param in [mod] section\n";
                        Bitmap fuck = new Bitmap(78, 78);
                        using (Graphics gr = Graphics.FromImage(fuck))
                        {
                            gr.Clear(Color.Gray);
                        }
                        imageList1.Images.Add(fuck);
                    }
                }
                listView1.LargeImageList = imageList1;
                for (int i = 0; i < s.Length; i++)
                {
                    ListViewItem listViewItem = new ListViewItem(new string[] { Path.GetFileName(s[i]) });
                    listViewItem.ImageIndex = i;
                    listViewItem.Tag = s[i];
                    listView1.Items.Add(listViewItem);
                }
                if (s2 != "")
                {

                    MessageBox.Show(s2, "Ghmm...", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Units parse err:\n" + ex);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0] != null)
            {
                s = listView1.SelectedItems[0].Tag.ToString();
                unitList f2 = new unitList();
                Hide();
                f2.ShowDialog();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RWS rws = new RWS();
            Hide();
            rws.ShowDialog();
            Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(listView1.SelectedItems[0].Tag.ToString() + "\\mod-info.txt");
                label1.Text = "Name: " + data["mod"]["title"];
                label2.Text = "Description:" + data["mod"]["description"].Replace("\\n",Environment.NewLine);
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0] != null)
            {
                Directory.Delete(listView1.SelectedItems[0].Tag.ToString(), true);
                LoadMods();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0] != null)
            {
                s = listView1.SelectedItems[0].Tag.ToString();
                newMod f2 = new newMod();
                Hide();
                f2.ShowDialog();
                Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            newMod f2 = new newMod();
            Hide();
            f2.ShowDialog();
            Close();
        }

        private void openMod_Load(object sender, EventArgs e)
        {

        }
    }
}

