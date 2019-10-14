using System;
using System.IO;
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
            if (!File.Exists(@"C:\RWStudio\.nomedia"))
            {
                File.Create(@"C:\RWStudio\.nomedia").Close();
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
            Hide();
            newMod.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RWS_Load(object sender, EventArgs e)
        {

        }
    }
}
