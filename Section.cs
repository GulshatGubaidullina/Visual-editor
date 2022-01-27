using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laba_6._5
{
    class Section : Shape
    {
        private Point point1;
        private Point point2;
        Pen pen;
        private Color colored;

        public Section(Point cursorpoint)
        {
            point = cursorpoint;

            point1 = new Point(point.X + R, point.Y + R);
            point2 = new Point(point.X - R, point.Y - R);


            pointMin = new Point(point.X - R, point.Y - R);
            pointMax = new Point(point.X + R, point.Y + R);

            blackPen = new Pen(Color.Red);
            blackPen.Width = 5;
        }
        public Section()
        {

        }

        public override void resize(int x, Point begin, Point end)
        {
            if (x >= 0)
            {
                if ((point1.X + x <= end.X) && (point1.Y + x <= end.Y) && (point2.X - x >= begin.X) && (point2.Y - x >= begin.Y))// +    +
                {
                    point1.X += x;
                    point1.Y += x;
                    point2.X -= x;
                    point2.Y -= x;
                }
            }
            else
            {
                if (point1.X + x > point2.X - x)
                {
                    point1.X += x;
                    point1.Y += x;
                    point2.X -= x;
                    point2.Y -= x;
                }
            }
           /* point1.X = point.X + R;
            point1.Y = point.Y + R;
            point2.X = point.X - R;
            point2.Y = point.Y - R;*/

            pointMin.X = point.X - R;
            pointMin.Y = point.Y - R;
            pointMax.X = point.X + R;
            pointMax.Y = point.Y + R;
        }


        override public bool check(Point p)
        {
            if (((p.X <= point1.X + 10) && (p.Y <= point1.Y + 10) && (p.X >= point1.X - 10) && (p.Y >= point1.Y - 10)) || ((p.X <= point2.X + 10) && (p.Y <= point2.Y + 10) && (p.X >= point2.X - 10) && (p.Y >= point2.Y - 10)))
                return true;
            else
                return false;
        }

        override public void create(Graphics gr, Shape obj)
        {
            string objcol = obj.getcolor();
            if (objcol == "Pink")
            {
                colored = Color.Pink;
                pen = new Pen(Color.Pink);
                pen.Width = 3;
                gr.DrawLine(pen, point1, point2);
            }

            else if (objcol == "Purple")
            {
                colored = Color.Purple;
                pen = new Pen(Color.Purple);
                pen.Width = 3;
                gr.DrawLine(pen, point1, point2);
            }
            else if (objcol == "Green")
            {
                colored = Color.Green;
                pen = new Pen(Color.Green);
                pen.Width = 3;
                gr.DrawLine(pen, point1, point2);
            }
            else if (objcol == "Yellow")
            {
                colored = Color.Yellow;
                pen = new Pen(Color.Yellow);
                pen.Width = 3;
                gr.DrawLine(pen, point1, point2);
            }
        }

        override public void createframe(Graphics gr)
        {
            gr.DrawLine(blackPen, point1, point2);
        }

        public override void move(int dx, int dy, Point beg, Point end)
        {
            if (observers != null && observers.getSize() != 0 && sticky == true)
            {
                for (int i = 0; i < observers.getSize(); i++)
                {
                    if (find(observers[i]) == true && observers[i] != this)
                    {
                        if (observers[i].sticky == false)
                        {
                            observers[i].select2(true);
                            observers[i].move(dx, dy, beg, end);
                        }
                    }
                }
            }
            if (dy == 0)                                    //движемся по х
            {
                if ((point1.X + dx <= end.X) && (point2.X + dx >= beg.X))
                {
                    point1.X += dx;
                    point2.X += dx;
                }
            }
            else if (dx == 0)                               //движемся по y
            {
                if ((point1.Y + dy <= end.Y) && (point2.Y + dy >= beg.Y))
                {
                    point1.Y += dy;
                    point2.Y += dy;
                }
            }
            /*point1.X = point.X + R;
            point1.Y = point.Y + R;
            point2.X = point.X - R;
            point2.Y = point.Y - R;*/

            pointMin.X = point.X - R;
            pointMin.Y = point.Y - R;
            pointMax.X = point.X + R;
            pointMax.Y = point.Y + R;
        }

        public override string GetData()
        {
            return "Section: X=" + point.X.ToString() + " Y=" + point.Y.ToString() + " Size=" + R.ToString() + " Color=" + getcolor().ToString();
        }
        public override string getClassname()
        {
            return "Section";
        }
        public override void Save(StreamWriter stream)
        {
           // string text = getClassname() + "\n" +
               // colored.ToString() + "\n" + point.X.ToString() + "\n" + point.Y.ToString();
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

            R = Convert.ToInt32(stream.ReadLine());
            string colorr = stream.ReadLine();
            point1 = new Point(point.X + R, point.Y + R);
            point2 = new Point(point.X - R, point.Y - R);

            blackPen = new Pen(Color.Red);
            blackPen.Width = 5;

            if (colorr == "Color [Pink]")
                colored = Color.Pink;
            if (colorr == "Color [Purple]")
                colored = Color.Purple;
            if (colorr == "Color [Green]")
                colored = Color.Green;
            if (colorr == "Color [Yellow]")
                colored = Color.Yellow;
        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }
    }
}

