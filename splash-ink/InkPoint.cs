using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splash_ink
{
    class InkPoint
    {
        public Point Center;
        public int Diameter;
        public Rectangle Rectangle;

        public InkPoint(Point center, int diameter)
        {
            Center = center;
            Diameter = diameter;
            Rectangle = new Rectangle(center.X, center.Y, diameter, diameter);
        }
    }
}
