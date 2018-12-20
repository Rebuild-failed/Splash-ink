using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Splash_ink
{
    class Painter
    {
        PictureBox picMain;
        PictureBox picSource;
        Bitmap btMain;
        Bitmap btSource;
        SolidBrush brush = new SolidBrush(Color.Black);
        Random ra = new Random();
        int pointMinSize = 2;
        int pointSize;

        public Boolean CanPinter = true;
        public Boolean OverPinting = false;

        public enum PaintType
        {
            Tile,
            Roller,
            Raindrop,
            Splash
        }

        private InkPoint RandomPoint
        {
            get => new InkPoint(new Point(ra.Next(picMain.Size.Width), ra.Next(picMain.Size.Height)), ra.Next(pointMinSize,pointSize));
        }

        public Painter(PictureBox pb1, PictureBox pb2, int gr)
        {
            picMain = pb1;
            picSource = pb2;
            pointSize = gr;
            btMain = new Bitmap(picMain.Size.Width, picMain.Size.Height);
            btSource = new Bitmap(picSource.Size.Width, picSource.Size.Height);
            picMain.DrawToBitmap(btMain, new Rectangle(0, 0, picMain.Width, picMain.Height));
            picSource.DrawToBitmap(btSource, new Rectangle(0, 0, picSource.Width, picSource.Height));
        }

        public void Paint(String type)
        {
            switch(Enum.Parse(typeof(PaintType), type))
            {
                case PaintType.Tile:
                    new Thread(Tile).Start();
                    break;
                case PaintType.Roller:
                    new Thread(Roller).Start();
                    break;
                case PaintType.Raindrop:
                    new Thread(Raindrop).Start();
                    break;
                case PaintType.Splash:
                    new Thread(Splash).Start();
                    break;
            }
        }

        public Boolean Save()
        {
            picMain.DrawToBitmap(btMain, new Rectangle(0, 0, picMain.Width, picMain.Height));
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "图片|*.jpg;*.png";
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                btMain.Save(sfd.FileName.ToString(), System.Drawing.Imaging.ImageFormat.Png);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Tile()
        {
            Graphics graphics = picMain.CreateGraphics();
            Graphics bg = Graphics.FromImage(btMain);
            for (int alpha = 20; alpha < 50; alpha++)
            {
                if (!CanPinter) return;
                for (int x = 0; x < picMain.Width; x++)
                {
                    if (OverPinting) return;
                    for (int y = 0; y < picMain.Height; y++)
                    {
                        brush.Color = GetColor(new Point(x, y), alpha);
                        bg.FillEllipse(brush, new Rectangle(x, y, pointMinSize, pointMinSize));
                    }
                    graphics.DrawImage(btMain, new Point(0, 0));
                }
            }
        }

        private void Roller()
        {
            Graphics graphics = picMain.CreateGraphics();
            Graphics bg = Graphics.FromImage(btMain);
            for (int alpha = 20; alpha < 50; alpha++)
            {
                if (!CanPinter) return;
                pointSize = pointSize > pointMinSize ? pointSize - 3 : pointMinSize;
                for (int x = 0; x < picMain.Width; x++)
                {
                    if (OverPinting) return;
                    for (int y = 0; y < picMain.Height; y++)
                    {
                        brush.Color = GetColor(new Point(x, y), 255);
                        bg.FillEllipse(brush, new Rectangle(x, y, pointSize, pointSize));
                    }
                    graphics.DrawImage(btMain, new Point(0, 0));
                }
            }
        }

        private void Raindrop()
        {
            Graphics graphics = picMain.CreateGraphics();
            Graphics bg = Graphics.FromImage(btMain);
            while (pointSize >= pointMinSize)
            {
                for (int i = 0; i < 1000; i++)
                {
                    if (!CanPinter || OverPinting) return;
                    for (int alpha = 20; alpha < 50; alpha++)
                    {
                        GenerateRandomPoint(bg, alpha);
                    }
                    graphics.DrawImage(btMain, new Point(0, 0));
                }
                pointSize -= 2;
            }
        }

        private void Splash()
        {

        }

        private void DrawMainImage()
        {
            Graphics graphics = picMain.CreateGraphics();
            Graphics bg = Graphics.FromImage(btMain);
            Bitmap bt = (Bitmap)picMain.Image;
            Bitmap bitmap = ConvertToGray(bt);
            for (int x = 0; x < bitmap.Width; x++)
            {
                for(int y = 0; y < bitmap.Height; y++)
                {
                    if(bitmap.GetPixel(x, y) == Color.FromArgb(255,0,0,0))
                    {
                        brush.Color = bitmap.GetPixel(x, y);
                        bg.FillEllipse(brush, new Rectangle(x,y,2,2));
                    }
                }
                graphics.DrawImage(btMain, new Point(0, 0));
            }
        }

        private void GenerateRandomPoint(Graphics bg, int alpha)
        {
            brush.Color = GetColor(RandomPoint.Center, alpha);
            bg.FillEllipse(brush, RandomPoint.Rectangle);
        }

        private Color GetColor(Point p,int alpha)
        {
            Color color = btSource.GetPixel(p.X, p.Y);
            return Color.FromArgb(alpha, color.R,color.G,color.B);
        }


        private static Bitmap ConvertToGray(Bitmap img)
        {
            int w = img.Width;
            int h = img.Height;
            Bitmap bmp = new Bitmap(w, h, PixelFormat.Format1bppIndexed);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);
            for (int y = 0; y < h; y++)
            {
                byte[] scan = new byte[(w + 7) / 8];
                for (int x = 0; x < w; x++)
                {
                    Color c = img.GetPixel(x, y);
                    if (c.GetBrightness() >= 0.5) scan[x / 8] |= (byte)(0x80 >> (x % 8));
                }
                Marshal.Copy(scan, 0, (IntPtr)((int)data.Scan0 + data.Stride * y), scan.Length);
            }
            bmp.UnlockBits(data);
            return bmp;
        }
    }
}
