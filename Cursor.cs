using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laba_6._5
{
    class Cursor:Shape
    {
        public Cursor(int x, int y)
        {
            R = 10;
            point.X = x;
            point.Y = y;
            
        }

        /*override public void create(Graphics gr, Shape obj)
        {
            gr.FillEllipse(Brushes.Black, point.X - R, point.Y - R, 2 * R, 2 * R);
        }*/

        public void replace(Point end)
        {
            point.X = end.X / 2;
            point.Y = end.Y / 2;
        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }
    }
}
