using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RWS
{
    public partial class preview : Form
    {
        public preview()
        {
            InitializeComponent();
        }
        bool stop = false;
        private Bitmap[] bmpa = new Bitmap[2];
        private void preview_Load(object sender, EventArgs e)
        {
            string picturepath = @"C:\RWStudio\png.png";
            Bitmap bmp = new Bitmap(picturepath);
            int width = bmp.Width / 2;      
            for (int i = 0; i<2; i++) {
                Rectangle cropRect = new Rectangle(width*i, 0, width, bmp.Height);
                bmpa[i]= cropImage(bmp, cropRect); ;
            }
                   Thread tht = new Thread(anim);
                   tht.Start();
        }
        private void anim()
        {
            while(!stop)
            {
                for (int i2 = 0; i2 < 2; i2++)
                {
                    pictureBox1.BackgroundImage = bmpa[i2];
                    Thread.Sleep(100);
                }
            /*    for (int i2 = 2; i2 > 0; i2--)
                {
                    pictureBox1.BackgroundImage = bmpa[i2];
                    Thread.Sleep(280);
                }*/
            }
        }
        private static Bitmap cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        private void preview_FormClosed(object sender, FormClosedEventArgs e)
        {
            stop = true;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\r\n\rn\nrn\r\n\r\n\r\n\r\n\rn\n");
        }
    }
}
