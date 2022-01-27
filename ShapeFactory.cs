using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laba_6._5
{
    public class ShapeFactory : AbstractFactory
    {

        public override Shape createShape(string shape)
        {

            Shape obj=null;
            switch (shape)
            {
                case "Circle":
                    obj = new Circle();
                    break;
                case "Square":
                    obj = new Square();
                    break;
                case "Section":
                    obj = new Section();
                    break;

                case "SGroup":
                    obj = new SGroup();
                    break;
                default:
                    break;
            }
            return obj;
        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }
    }
}
