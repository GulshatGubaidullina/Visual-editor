using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laba_6._5
{
    class Square:Shape
    {
       

        public Square(Point cursorpoint)
        {
            point = cursorpoint;
            pointMin = new Point(point.X - R, point.Y - R);
            pointMax = new Point(point.X + R, point.Y + R);
        }
        public Square()
        {
        }
        override public bool check(Point p)
        {
            if ((p.X > point.X - R) && (p.Y > point.Y - R) && (p.X < point.X + R) && (p.Y < point.Y + R))
            {
                return true;
            }
            else return false;
        }

        override public void create(Graphics gr)
        {
            objcol = getcolor();
            if (objcol == "Pink")
            {
                colored = Color.Pink;
                color = "Pink";
                gr.FillRectangle(Brushes.Pink, point.X - R, point.Y - R, 2 * R, 2 * R);
            }
           
            else if (objcol == "Purple")
            {
                color = "Purple";
                colored = Color.Purple;
                gr.FillRectangle(Brushes.Purple, point.X - R, point.Y - R, 2 * R, 2 * R);
            }
            else if (objcol == "Green")
            {
                color = "Green";
                colored = Color.Green;
                gr.FillRectangle(Brushes.Green, point.X - R, point.Y - R, 2 * R, 2 * R);
            }
            else if (objcol == "Yellow")
            {
                color = "Yellow";
                colored = Color.Yellow;
                gr.FillRectangle(Brushes.Yellow, point.X - R, point.Y - R, 2 * R, 2 * R);
            }
            gr.DrawRectangle(normPen, point.X - R, point.Y - R, 2 * R, 2 * R);
        }

        override public void createframe(Graphics gr)
        {
            gr.DrawRectangle(blackPen, point.X - R, point.Y - R, 2 * R, 2 * R);
        }
        public override string GetData()
        {
            return "Square: X=" + point.X.ToString() + " Y=" + point.Y.ToString() + " Size=" + R.ToString() + " Color=" + getcolor().ToString();
        }
        public override string getClassname()
        {
            return "Square";
        }
        public override void Save(StreamWriter stream)
        {
           // string text = getClassname() + "\n" + colored.ToString() + "\n" + point.X.ToString() + "\n" + point.Y.ToString() + "\n" +R;
            stream.WriteLine(getClassname());
            stream.WriteLine(point.X + "\n" + point.Y + "\n" + R + "\n" + objcol);

        }
        public override void Load(StreamReader stream, AbstractFactory factory)
        {
            /*string[] data = stream.ReadLine().Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            point.X = int.Parse(data[0]);
            point.Y = int.Parse(data[1]);
            R = int.Parse(data[2]);
            string colorr = (data[3].ToString());*/


            
             this.point.X = Convert.ToInt32(stream.ReadLine());
             this.point.Y = Convert.ToInt32(stream.ReadLine());

             R = Convert.ToInt32(stream.ReadLine());
            string colorr = stream.ReadLine();
            colorselect(colorr);
            /*if (colorr == "Color [Pink]")
                 colored = Color.Pink;
             if (colorr == "Color [Purple]")
                 colored = Color.Purple;
             if (colorr == "Color [Green]")
                 colored = Color.Green;
             if (colorr == "Color [Yellow]")
                 colored = Color.Yellow;*/
        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }
    }
}
