using IniParser;
using IniParser.Model;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RWS
{

    public partial class openMod : Form
    {
        public static string modPath;
        public openMod()
        {
            InitializeComponent();
            LoadMods();
        }
        private void LoadMods()
        {
            string errorHolder = "";
            try
            {
                modList.Clear();
                imageList1.Dispose();

                string[] dirList = Directory.EnumerateDirectories(@"C:\RWStudio").ToArray();
                for (int a = 0; a < dirList.Length; a++)
                {

                    string[] sss = Directory.GetFiles(dirList[a], "mod-info.txt");
                    if (sss.Length < 1)
                    {
                        errorHolder = errorHolder + "Err: I cant find unit mod-info file in folder " + dirList[a] + Environment.NewLine + Environment.NewLine;
                        Bitmap bmp = new Bitmap(78, 78);
                        using (Graphics gr = Graphics.FromImage(bmp))
                        {
                            gr.Clear(Color.Gray);
                        }
                        imageList1.Images.Add(bmp);
                    }
                    else
                    {
                        var parser = new FileIniDataParser();
                        IniData data = parser.ReadFile(sss[0]);

                        if (data["mod"]["thumbnail"] != null)
                        {
                            if (File.Exists(Path.Combine(dirList[a], data["mod"]["thumbnail"].Replace(" ", string.Empty))))
                            {
                                Bitmap tmp = new Bitmap(Path.Combine(dirList[a], data["mod"]["thumbnail"].Replace(" ", string.Empty)));
                                Bitmap bmp = new Bitmap(tmp);
                                imageList1.Images.Add(bmp);
                                tmp.Dispose();
                            }
                            else
                            {
                                errorHolder = errorHolder + "Err: I cant find unit image file in folder " + dirList[a] + Environment.NewLine + Environment.NewLine;
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
                            errorHolder = errorHolder + "Err: I cant see image param in [mod] section" + Environment.NewLine + Environment.NewLine;
                            Bitmap fuck = new Bitmap(78, 78);
                            using (Graphics gr = Graphics.FromImage(fuck))
                            {
                                gr.Clear(Color.Gray);
                            }
                            imageList1.Images.Add(fuck);
                        }
                    }
                }
                modList.LargeImageList = imageList1;
                for (int i = 0; i < dirList.Length; i++)
                {
                    ListViewItem listViewItem = new ListViewItem(new string[] { Path.GetFileName(dirList[i]) });
                    listViewItem.ImageIndex = i;
                    listViewItem.Tag = dirList[i];
                    modList.Items.Add(listViewItem);
                    if (!File.Exists(dirList[i] + "\\.nomedia"))
                    {
                        File.Create(dirList[i] + "\\.nomedia").Close();
                    }
                }
                if (errorHolder != "")
                {

                    MessageBox.Show(errorHolder, "Ghmm...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mods parse err:" + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + ex.Data);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Edit by kc101010; Try-catch handles error when there is no user selection while trying to open a mod directory
            try
            {
                modPath = modList.SelectedItems[0].Tag.ToString();
                unitList f2 = new unitList();
                Hide();
                f2.ShowDialog();
                Close();
            }
            catch (Exception)
            {

                MessageBox.Show("A mod has not been selected, please select a mod to open", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (modList.SelectedItems[0].Tag != null)
                {
                    var parser = new FileIniDataParser();
                    IniData data = parser.ReadFile(modList.SelectedItems[0].Tag.ToString() + "\\mod-info.txt");
                    label1.Text = "Name: " + data["mod"]["title"];
                    label2.Text = "Description:" + data["mod"]["description"].Replace("\\n", Environment.NewLine);
                }
            }
            catch { label2.Text = label1.Text = "Err: $%#@^&*"; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Edit by kc101010; Try-Catch prevents app from crashing when user tries to delete a mod when they haven't selected anything
            try
            {
                Directory.Delete(modList.SelectedItems[0].Tag.ToString(), true);
                LoadMods();
            }
            catch (Exception)
            {
                //Displays this message instead of the entire error message
                MessageBox.Show("A mod has not been selected, please select a mod to delete","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Edit by kc101010; Implemented try-catch in similar way to Line 140
            try
            {
                modPath = modList.SelectedItems[0].Tag.ToString();
                newMod f2 = new newMod();
                Hide();
                f2.ShowDialog();
                Close();
            }
            catch (Exception) 
            {
                MessageBox.Show("A mod has not been selected, please select a mod to edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            modPath = null;
            newMod f2 = new newMod();
            Hide();
            f2.ShowDialog();
            Close();
        }
    }
}

