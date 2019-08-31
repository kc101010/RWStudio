using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RWS
{
    public partial class RWS : Form
    {
        public RWS()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            if (!Directory.Exists(@"C:\RWStudio"))
            {
                Directory.CreateDirectory(@"C:\RWStudio");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            openMod openMod = new openMod();
            Hide();
            openMod.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newMod newMod = new newMod();
            newMod.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/rustedwarfare");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            preview prw = new preview();
            prw.ShowDialog();
        }
    }
}
