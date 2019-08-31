using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;

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
            try
            {
                listView1.Clear();
                imageList1.Dispose();
                string[] s = Directory.EnumerateDirectories(openMod.s).ToArray();
                label2.Text = openMod.s;
                for (int a = 0; a < s.Length; a++)
                {
                    var parser = new FileIniDataParser();
                    string[] sss = Directory.GetFiles(s[a], "*.ini");
                    IniData data = parser.ReadFile(sss[0]);
                    Bitmap tmp = new Bitmap(Path.Combine(s[a], data["graphics"]["image"].Replace(" ", string.Empty)));
                    Bitmap bmp = new Bitmap(tmp);
                    imageList1.Images.Add(bmp);
                    tmp.Dispose();
                }
                listView1.LargeImageList = imageList1;
                for (int i = 0; i < s.Length; i++)
                {
                    ListViewItem listViewItem = new ListViewItem(new string[] {Path.GetFileName(s[i])});
                    listViewItem.ImageIndex = i;
                    listViewItem.Tag = s[i];
                    listView1.Items.Add(listViewItem);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Units parse err:\n"+ ex);
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
            try
            {
               
                f = listView1.SelectedItems[0].Tag.ToString();
               editUnit ed = new editUnit();
                Hide();
                ed.ShowDialog();
                Close();
         }
            catch
            {
                MessageBox.Show("Select unit");
            }
        }
    }
}
