using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laba_6._5
{
    class Circle:Shape
    {
        private Color colored;
        public Circle(Point cursorpoint)
        {
            point = cursorpoint;
            pointMin = new Point(point.X - R, point.Y - R);
            pointMax = new Point(point.X + R, point.Y + R);
        }
        public Circle()
        {
            
        }
        private Color GetColor()
        {
            return colored;
        }
        override public void create(Graphics gr, Shape obj)
        {
            string objcol = obj.getcolor();
            if (objcol == "Pink")
            {
                colored = Color.Pink;
                gr.FillEllipse(Brushes.Pink, point.X - R, point.Y - R, 2 * R, 2 * R);
            }
           
            else if (objcol == "Purple")
            {
                colored = Color.Purple;
                gr.FillEllipse(Brushes.Purple, point.X - R, point.Y - R, 2 * R, 2 * R);
            }
            else if (objcol == "Green")
            {
                colored = Color.Green;
                gr.FillEllipse(Brushes.Green, point.X - R, point.Y - R, 2 * R, 2 * R);
            }
            else if (objcol == "Yellow")
            {
                colored = Color.Yellow;
                gr.FillEllipse(Brushes.Yellow, point.X - R, point.Y - R, 2 * R, 2 * R);
            }
            gr.DrawEllipse(normPen, point.X - R, point.Y - R, 2 * R, 2 * R);
        }

        public override void createframe(Graphics gr)
        {
            gr.DrawEllipse(blackPen, point.X - R - 2, point.Y - R - 2, 2 * R + 4, 2 * R + 4);
        }
        public override string GetData()
        {
            return "Circle: X=" + point.X.ToString() + " Y=" + point.Y.ToString() + " Size=" + R.ToString() + " Color=" + getcolor().ToString();
        }
        public override bool check(Point p)
        {
            return ((p.X - point.X) * (p.X - point.X) + (p.Y - point.Y) * (p.Y - point.Y) < R * R);
        }
        public override string getClassname()
        {
            return "Circle";
        }
        public override void Save(StreamWriter stream)
        {
            //string text = getClassname() + "\n" + colored.ToString() + "\n" + point.X.ToString() + "\n" + point.Y.ToString() + "\n" + R;
            stream.WriteLine(getClassname());
            stream.WriteLine(point.X + "\n" + point.Y + "\n" + R + "\n" + colored.ToString());


        }
        public override void Load(StreamReader stream, AbstractFactory factory)
        {
            /*string[] data = stream.ReadLine().Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            point.X = int.Parse(data[0]);
            point.Y = int.Parse(data[1]);
            R = int.Parse(data[2]);
            string colorr=(data[3].ToString());*/

            
            this.point.X = Convert.ToInt32(stream.ReadLine());
            this.point.Y = Convert.ToInt32(stream.ReadLine());
            //string colorr = sm.ReadLine();
            R = Convert.ToInt32(stream.ReadLine());
            string colorr = stream.ReadLine();

            if (colorr == "Color [Pink]")
                colored = Color.Pink;
            if (colorr == "Color [Purple]")
                colored = Color.Purple;
            if (colorr == "Color [Green]")
                colored = Color.Green;
            if (colorr == "Color [Yellow]")
                colored = Color.Yellow;
            pointMin = new Point(point.X - R, point.Y - R);
            pointMax = new Point(point.X + R, point.Y + R);
        }

        
    }
}
