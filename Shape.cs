using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laba_6._5
{
     public class Shape: ObjectObserved
    {
        private bool selected = false;
        private bool selected2 = false;
        protected string color = "Pink";
        protected int R = 50;
        protected Point point = new Point(0, 0);
        protected Pen blackPen = new Pen(Color.Red, 5);
        protected string objcol;
        //private int field;
        protected Point pointMax;
        protected Point pointMin= new Point(0, 0);
        public bool sticky;
        protected Pen redPen = new Pen(Color.Red, 5);
        protected Pen RedPen = new Pen(Color.Red, 3);

        protected Pen normPen = new Pen(Color.Transparent, 5);
        protected Color colored;
        public bool Selected { get { return selected; } }
        virtual public Point getcord()
        {
            return point;
        }
        public bool GetSticky()
        {
            return sticky;
        }
        public int getrad()
        {
            return R;
        }
        public void setPointVax(int MaxH,int MaxW)
        {
            pointMax.X = MaxH;
            pointMax.Y = MaxW;
        }
        public Point getpointMin()
        {
            return pointMin;
        }

        public Point getpointMax()
        {
            return pointMax;
        }
        virtual public void create(Graphics gr, Shape obj) { }

        virtual public void createframe(Graphics gr)
        {
            gr.DrawRectangle(redPen, point.X - R, point.Y - R, 2 * R, 2 * R);
        }

        virtual public void createframe2(Graphics gr)
        {
            gr.DrawRectangle(RedPen, point.X - R, point.Y - R, 2 * R, 2 * R);
        }
        virtual public string GetData()
        {
            return "";
        }
        virtual public void colorselect(string color1)
        {
            color = color1;
        }

        public string getcolor()
        {
            return color;
        }

        public void select(bool t)
        {
            selected = t;
        }

        public bool getselect()
        {
            return selected;
        }

        virtual public void move(int dx, int dy, Point beg, Point end)
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
                if (dx > 0)
                {
                    if (point.X + R + dx <= end.X)
                        point.X = point.X + dx;
                }
                else
                {
                    if (point.X - R + dx >= beg.X)//R+dx
                        point.X = point.X + dx;
                }
            else if (dx == 0)                               //движемся по y
                if (dy > 0)
                {
                    if (point.Y + R + dy <= end.Y)
                        point.Y = point.Y + dy;
                }
                else
                {
                    if ((point.Y - R + dy >= beg.Y))//R+dy
                        point.Y = point.Y + dy;
                }
            pointMin.X = point.X - R;
            pointMin.Y = point.Y - R;
            pointMax.X = point.X + R;
            pointMax.Y = point.Y + R;
        }

        virtual public void resize(int dx, Point begin, Point end)
        {
            if (dx >= 0)//////
            {
                if ((point.X + R + dx < end.X) && (point.Y + R + dx < end.Y) && (point.X - R - dx > begin.X) && (point.Y - R - dx > begin.Y))// -   -
                    if (2 * R + dx < 600)
                        R = R + dx;
            }
            else
            {
                if (2 * R + dx > 10)
                    R = R + dx;
            }
            pointMin.X = point.X - R;
            pointMin.Y = point.Y - R;
            pointMax.X = point.X + R;
            pointMax.Y = point.Y + R;
        }

        virtual public bool check(Point p)              //входит ли курсор в фигуру
        {
               return false;
        }

        

        public virtual void Save(StreamWriter stream) { }
        public virtual void Load(StreamReader stream, AbstractFactory factory) { }
        public virtual string getClassname()
        {
            return "Shape";
        }

        virtual public bool isgroup()
        {
            return false;
        }
        public void SetSticky(bool a)
        {
            sticky = a;
        }
        public void select2(bool t)
        {
            selected2 = t;
        }

        public bool getselect2()
        {
            return selected2;
        }
        virtual public bool find(Shape xobj)
        {
            if (xobj.pointMax.X > pointMin.X && xobj.pointMin.X < pointMax.X)
                if (xobj.pointMax.Y > pointMin.Y && xobj.pointMin.Y < pointMax.Y)
                    return true;
            return false;
        }
    }

}