using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laba_6._5
{
    public class ObjectObserved                            //наблюдаемый объект
    {
        public Container<Shape> observers;
        public void Add(Container<Shape> objects)
        {
            if (observers == null)
                observers = objects;
        }

    }
}
