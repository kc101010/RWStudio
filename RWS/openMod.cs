using System;
using System.Collections.Generic;
using System.IO;
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
            listView1.Clear();

            List<string> dirs = new List<string>(Directory.EnumerateDirectories(@"C:\RWStudio"));
            foreach (string dir in dirs)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = dir;
                listView1.Items.Add(lvi);
            }
            dirs.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1) {
                s = listView1.SelectedItems[0].Text;
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
    }
}

