using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using System.IO.Compression;
using System.Diagnostics;
using System.Threading;

namespace RWS
{
    public partial class unitList : Form
    {
        public static string f;
        public unitList()
        {
            InitializeComponent();
            loadUnits();
        }
        private void loadUnits()
        {
            string s2 = "";
            try
            {
                listView1.Clear();
                imageList1.Dispose();

                string[] s = Directory.EnumerateDirectories(openMod.s).ToArray();
                label2.Text = openMod.s;
                for (int a = 0; a < s.Length; a++)
                {
                    if (s[a].Contains("music")) ;
                    else
                    {
                        var parser = new FileIniDataParser();
                        string[] sss = Directory.GetFiles(s[a], "*.ini");
                        if (sss.Length == 1)
                        {
                            IniData data = parser.ReadFile(sss[0]);
                            if (data["graphics"]["image"] != null)
                            {
                                if (File.Exists(Path.Combine(s[a], data["graphics"]["image"].Replace(" ", string.Empty))))
                                {
                                    Bitmap tmp = new Bitmap(Path.Combine(s[a], data["graphics"]["image"].Replace(" ", string.Empty)));
                                    Bitmap bmp = new Bitmap(tmp);
                                    imageList1.Images.Add(bmp);
                                    tmp.Dispose();
                                }
                                else
                                {
                                    s2 = s2 + "Err: I cant find unit image file in folder " + s[a] + Environment.NewLine + Environment.NewLine;
                                    Bitmap bmp = new Bitmap(78, 78);
                                    using (Graphics gr = Graphics.FromImage(bmp))
                                    {
                                        gr.Clear(Color.Gray);
                                    }
                                    imageList1.Images.Add(bmp);
                                }
                            }
                            else
                            {
                                s2 = s2 + "Err: I cant see image param in [graphics] section" + Environment.NewLine + Environment.NewLine;
                                Bitmap fuck = new Bitmap(78, 78);
                                using (Graphics gr = Graphics.FromImage(fuck))
                                {
                                    gr.Clear(Color.Gray);
                                }
                                imageList1.Images.Add(fuck);
                            }
                        }
                        else if (sss.Length > 1)
                        {
                            s2 = s2 + "Warn: I found " + sss.Length.ToString() + " ini files in folder " + s[a] + ", loading: " + sss[0] + Environment.NewLine + Environment.NewLine;
                            IniData data = parser.ReadFile(sss[0]);
                            if (data["graphics"]["image"] != null)
                            {
                                if (File.Exists(Path.Combine(s[a], data["graphics"]["image"].Replace(" ", string.Empty))))
                                {
                                    Bitmap tmp = new Bitmap(Path.Combine(s[a], data["graphics"]["image"].Replace(" ", string.Empty)));
                                    Bitmap bmp = new Bitmap(tmp);
                                    imageList1.Images.Add(bmp);
                                    tmp.Dispose();
                                }
                                else
                                {
                                    s2 = s2 + "Err: I cant find unit image file in folder " + s[a] + Environment.NewLine + Environment.NewLine;
                                    Bitmap bmp = new Bitmap(78, 78);
                                    using (Graphics gr = Graphics.FromImage(bmp))
                                    {
                                        gr.Clear(Color.Gray);
                                    }
                                    imageList1.Images.Add(bmp);
                                }
                            }
                            else
                            {
                                s2 = s2 + "Err: I cant see image param in [graphics]" + Environment.NewLine + Environment.NewLine;
                                Bitmap bmp = new Bitmap(78, 78);
                                using (Graphics gr = Graphics.FromImage(bmp))
                                {
                                    gr.Clear(Color.Gray);
                                }
                                imageList1.Images.Add(bmp);
                            }
                        }
                        else if (sss.Length < 1)
                        {
                            s2 = s2 + "Err: I cant find ini file in folder " + s[a] + Environment.NewLine + Environment.NewLine;
                            Bitmap bmp = new Bitmap(64, 64);
                            using (Graphics gr = Graphics.FromImage(bmp))
                            {
                                gr.Clear(Color.Gray);
                            }
                            imageList1.Images.Add(bmp);
                        }
                    }
                    listView1.LargeImageList = imageList1;
                    listView1.Clear();
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (!s[i].Contains("music"))
                        {
                            ListViewItem listViewItem = new ListViewItem(new string[] { Path.GetFileName(s[i]) });
                            listViewItem.ImageIndex = i;
                            listViewItem.Tag = s[i];
                            listView1.Items.Add(listViewItem);
                            if (!File.Exists(s[i] + "\\.nomedia"))
                            {
                                File.Create(s[i] + "\\.nomedia").Close();
                            }
                        }
                    }
                    if (s2 != "")
                    {

                        MessageBox.Show(s2, "Ghmm...", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Units parse err:\n" + ex);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            addUnit au = new addUnit();
            au.ShowDialog();
            loadUnits();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RWS rws = new RWS();
            Hide();
            rws.ShowDialog();
            Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0] != null)
            {
                f = listView1.SelectedItems[0].Tag.ToString();
                editUnit ed = new editUnit();
                Hide();
                ed.ShowDialog();
                Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0] != null)
            {
                Directory.Delete(listView1.SelectedItems[0].Tag.ToString(), true);
                loadUnits();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                try
                {
                    pleaseWait pw = new pleaseWait();
                    pw.Show();
                    Hide();
                    Application.DoEvents();
                    ZipFile.CreateFromDirectory(openMod.s, saveFileDialog1.FileName);
                    pw.Close();
                    Show();
                    MessageBox.Show("Comressed!", "Success");
                }
                catch(Exception EX)
                {
                    MessageBox.Show("Compression error: "+Environment.NewLine + EX, "Oh...");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start(openMod.s);
        }
    }
}
