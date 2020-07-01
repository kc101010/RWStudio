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
       public static string inipath; 
        public unitList()
        {
            InitializeComponent();
            loadUnits();
        }
        private void loadUnits()
        {
            string errorHolder = "";
            try
            {
                listView1.Clear();
                imageList1.Dispose();

                string[] s = Directory.EnumerateDirectories(openMod.modPath).ToArray();
                label2.Text = openMod.modPath;
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
                                    errorHolder = errorHolder + "Err: I cant find unit image file in folder " + s[a] + Environment.NewLine + Environment.NewLine;
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
                                errorHolder = errorHolder + "Err: I cant see image param in [graphics] section" + Environment.NewLine + Environment.NewLine;
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
                            errorHolder = errorHolder + "Warn: I found " + sss.Length.ToString() + " ini files in folder " + s[a] + ", loading: " + sss[0] + Environment.NewLine + Environment.NewLine;
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
                                    errorHolder = errorHolder + "Err: I cant find unit image file in folder " + s[a] + Environment.NewLine + Environment.NewLine;
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
                                errorHolder = errorHolder + "Err: I cant see image param in [graphics]" + Environment.NewLine + Environment.NewLine;
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
                            errorHolder = errorHolder + "Err: I cant find ini file in folder " + s[a] + Environment.NewLine + Environment.NewLine;
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
                    if (errorHolder != "")
                    {

                        MessageBox.Show(errorHolder, "Ghmm...", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Units parse err:\n" + ex,"Erorr",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            //Edit by kc101010 - bugfix prevents app from crashing when User tries to edit a unit without selecting one
            try
            {
                inipath = listView1.SelectedItems[0].Tag.ToString();
                New_edit ed = new New_edit();
                Hide();
                ed.ShowDialog();
                Close();
            } catch (Exception why) 
            {
                MessageBox.Show("A unit has not been selected, please select a unit to edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(why.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Edit by kc101010 - bugfix for user trying to delete a unit without selecting one 
            try
            {
                Directory.Delete(listView1.SelectedItems[0].Tag.ToString(), true);
                loadUnits();
            }
            catch (Exception)
            {
                MessageBox.Show("A unit has not been selected, please select a unit to delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                    ZipFile.CreateFromDirectory(openMod.modPath, saveFileDialog1.FileName);
                    pw.Close();
                    Show();
                    MessageBox.Show("Comressed!", "Success",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                }
                catch(Exception EX)
                {
                    MessageBox.Show("Compression error: "+Environment.NewLine + EX, "Oh...",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start(openMod.modPath);//s is Mod path
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
