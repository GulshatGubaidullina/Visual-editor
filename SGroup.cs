using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laba_6._5
{
    class SGroup:Shape
    {
        // максимально возможное количество фигур в группе
        private int _maxcount;
        // текущее количество фигур в группе
        private int _count;
        // массив ссылок на хранимые фигусы
        private Shape[] _shapes;
        private int width, height;
        //public Container<Shape> shapes { get; private set; }
        public SGroup(int maxcount)
        {
            Console.WriteLine(string.Format("CGroup::CGroup({0})", maxcount));
            _maxcount = maxcount; _count = 0;
            _shapes = new Shape[_maxcount];
            for (int i = 0; i < _maxcount; i++)
                _shapes[i] = null;
        }
        public SGroup(int width, int height)
        {

            this.width = width; this.height = height;
            pointMin = new Point(width, height);
            pointMax = new Point(0, 0);
            _maxcount = 10; 
            _count = 0;
            _shapes = new Shape[_maxcount];
            
        }
        public SGroup() 
        {
            
            _maxcount = 10; 
            _count = 0;
            _shapes = new Shape[_maxcount];
        }
        ~SGroup()
        {
           
            for (int i = 0; i < _count; i++)
                _shapes[i] = null;
            // очищаем сам массив
            _shapes = null;
            
        }
      
        public int getCount()
        {
            return _count;
        }
        public bool addShape(Shape shape)
        {
            if (_count >= _maxcount)
                return false;

            _count++;
            _shapes[_count - 1] = shape;
            return true;
        }

       
        public Shape getShape(int index)
        {
            if(index<0 || index>_count)
                throw new Exception();
            else
            {
                return _shapes[index];
            }


        }
        public override bool check(Point p)///////////////
        {
            
            int countCheck = 0;
            if (_shapes != null)
            {
                for (int i = 0; i <= _count - 1; i++)
                {
                    if (_shapes[i].check(p))
                        countCheck++;
                }
               
                if (countCheck != 0)
                    return true;
                else 
                    return false;
                 
            }
            else
                return false;
        }

        public override void create(Graphics gr) 
        {
            for (int i = 0; i < _count; i++)
                _shapes[i].create(gr);


        }


        public override void createframe(Graphics gr)
        {
            findframe();
            for (int i = 0; i < _count; i++)
                _shapes[i].createframe(gr);
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
                if (dx > 0)
                {
                    if (pointMax.X + dx <= end.X)
                        for (int i = 0; i < _count; i++)
                            _shapes[i].move(dx, dy, beg, end);
                }
                else
                {
                    if (pointMin.X + dx >= beg.X)
                        for (int i = 0; i < _count; i++)
                            _shapes[i].move(dx, dy, beg, end);
                }
            else if (dx == 0)                               //движемся по y
                if (dy > 0)
                {
                    if (pointMax.Y + dy <= end.Y)
                        for (int i = 0; i < _count; i++)
                            _shapes[i].move(dx, dy, beg, end);
                }
                else
                {
                    if ((pointMin.Y + dy >= beg.Y))
                        for (int i = 0; i <_count; i++)
                            _shapes[i].move(dx, dy, beg, end);
                }
            
            findframe();

        }

        public override void resize(int dx, Point begin, Point end)
        {
            if (dx > 0)
            {
                if ((pointMax.X + dx < end.X) && (pointMax.Y + dx < end.Y) && (pointMin.X - dx > begin.X) && (pointMin.Y - dx > begin.Y))
                {
                    for (int i = 0; i < _count; i++)
                        _shapes[i].resize(dx, begin, end);
                }
            }
            else
            {
                for (int i = 0; i < _count; i++)
                    _shapes[i].resize(dx, begin, end);
            }
            findframe();

        }
        public override void colorselect(string color1)
        {
            for (int i =_count - 1; i >= 0; i--)
                _shapes[i].colorselect(color1);
        }
        public override string getClassname()
        {
            return "SGroup";
        }
        public override void Save(StreamWriter stream)
        {
            stream.WriteLine(getClassname());
            stream.WriteLine(_count);

            
            for (int i = 0; i < _count; i++)
            {
                _shapes[i].Save( stream);
            }
        }
        public override void Load(StreamReader stream, AbstractFactory factory)
        {
            int numberOfShapes = Convert.ToInt32(stream.ReadLine());

            for (int i = 0; i < numberOfShapes; i++)
            {
                Shape shape;
                shape = factory.createShape(stream.ReadLine());

                shape.Load(stream, factory);

                addShape(shape);

            }
        }
        public override bool isgroup()
        {
            return true;
        }

       
        public Shape GetAndDel(int index)
        {

            if (index < 0 || index >= _shapes.Length)
                throw new Exception();

            if (_shapes[index] == null)
                throw new Exception();

            Shape tmp = _shapes[index];
            Shape [] new_arr = new Shape[_count-1];
            for (int i = 0; i < index; i++)
                new_arr[i] = _shapes[i];
            for (int i = index + 1; i < _count - 1; i++)
                new_arr[i - 1] = _shapes[i];
            _shapes = new_arr;
            _count--;
            return tmp;
        }
        public override string GetData()
        {
            return "SGroup";
        }
        public void Method()
        {
            throw new System.NotImplementedException();
        }
        private void findframe()
        {
            pointMin.X = width;
            pointMin.Y = height;
            pointMax.X = 0;
            pointMax.Y = 0;

            for (int i = 0; i < _count; i++)
            {
                if (_shapes[i].getpointMin().X <= pointMin.X)
                {
                    pointMin.X = _shapes[i].getpointMin().X;
                }

                if (_shapes[i].getpointMin().Y <= pointMin.Y)
                {
                    pointMin.Y = _shapes[i].getpointMin().Y;
                }


                if (_shapes[i].getpointMax().X >= pointMax.X)
                {
                    pointMax.X = _shapes[i].getpointMax().X;
                }


                if (_shapes[i].getpointMax().Y >= pointMax.Y)
                {
                    pointMax.Y = _shapes[i].getpointMax().Y;
                }
            }
        }
    }
}
