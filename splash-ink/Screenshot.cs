using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Splash_ink
{
    public partial class Screenshot : Form
    {
        private Point StartPoint = Point.Empty;
        private bool CutStart = false;
        private Rectangle CutRect;
        private PictureBox sourcePictureBox;

        public Screenshot(PictureBox pictureBox)
        {
            InitializeComponent();
            sourcePictureBox = pictureBox;
        }

        public void Cut()
        {
            Bitmap CutBmp = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            Graphics g = Graphics.FromImage(CutBmp);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));
            g.Dispose();
            this.BackgroundImage = CutBmp;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.ShowDialog();
        }

        private void Screenshot_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!CutStart)
                {
                    CutStart = true;
                    StartPoint = new Point(e.X, e.Y);
                }
            }
        }

        private void Screenshot_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (CutStart)
                {
                    CutStart = false;
                    Bitmap CutBmp = new Bitmap(CutRect.Width, CutRect.Height);
                    Graphics g = Graphics.FromImage(CutBmp);
                    g.DrawImage(this.BackgroundImage, new Rectangle(0, 0, CutRect.Width, CutRect.Height), CutRect, GraphicsUnit.Pixel);
                    Clipboard.SetImage(CutBmp);
                    g.Dispose();
                    sourcePictureBox.Image = CutBmp;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void Screenshot_MouseMove(object sender, MouseEventArgs e)
        {
            Bitmap bitmap = (Bitmap)this.BackgroundImage.Clone();
            Graphics g = Graphics.FromImage(bitmap);
            if (CutStart)
            {
                Point lastPoint = StartPoint;
                if (e.X < StartPoint.X) lastPoint.X = e.X;
                if (e.Y < StartPoint.Y) lastPoint.Y = e.Y;
                CutRect = new Rectangle(lastPoint, new Size(Math.Abs(e.X - StartPoint.X), Math.Abs(e.Y - StartPoint.Y)));
                g.DrawRectangle(new Pen(Color.FromArgb(150, 255, 255, 255), 1), CutRect);
                g.FillRectangles(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), 
                    new Rectangle[] {
                        new Rectangle(0, 0, CutRect.X, this.Height),
                        new Rectangle(CutRect.X + CutRect.Width, 0, this.Width, this.Height),
                        new Rectangle(CutRect.X, 0, CutRect.Width, CutRect.Y),
                        new Rectangle(CutRect.X, CutRect.Y + CutRect.Height, CutRect.Width, this.Height)
                    });
                g.DrawLine(new Pen(Color.FromArgb(150, 255, 255, 255), 1), CutRect.X, 0, CutRect.X, this.Height);
                g.DrawLine(new Pen(Color.FromArgb(150, 255, 255, 255), 1), 0, CutRect.Y, this.Width, CutRect.Y);
            }
            g.DrawLine(new Pen(Color.FromArgb(150, 255, 255, 255), 1), e.X, 0, e.X, this.Height);
            g.DrawLine(new Pen(Color.FromArgb(150, 255, 255, 255), 1), 0, e.Y, this.Width, e.Y);
            g.Dispose();
            this.CreateGraphics().DrawImage(bitmap, new Point(0, 0));
            bitmap.Dispose();
        }
    }
}
