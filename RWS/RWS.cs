using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RWS
{
    public partial class RWS : Form
    {
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);
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
            Application.Exit();
        }
        private void F_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);

        }

        private void F_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void F_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }

        }
    }
}