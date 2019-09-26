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
        List<Bitmap> bmpa = new List<Bitmap>();
        private void preview_Load(object sender, EventArgs e)
        {
            string picturepath = @"C:\RWStudio\png.png";
            Bitmap bmp = new Bitmap(picturepath);
            int width = bmp.Width / 3;
            pictureBox1.Width = width;
            pictureBox1.Height = bmp.Height;
            for (int i = 0; i<3; i++) {
                Rectangle cropRect = new Rectangle(width*i, 0, width, bmp.Height);
                bmpa.Add(cropImage(bmp, cropRect));
            }
                   Thread tht = new Thread(anim);
                   tht.Start();
        }
        private void anim()
        {
            while(!stop)
            {
                for (int i2 = 0; i2 < 3; i2++)
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                    Graphics g = Graphics.FromImage(bmpa[i2]);
                    g.DrawEllipse(new Pen(Color.LimeGreen,2), pictureBox1.Width, pictureBox1.Height, bmpa[i2].Height, bmpa[i2].Height);
                    pictureBox1.Image = bmpa[i2];
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
    }
}
