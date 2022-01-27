using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laba_6._5
{
    public abstract class AbstractFactory
    {
        public virtual Shape createShape(string shape) { return null; }

        public void Method()
        {
            throw new System.NotImplementedException();
        }
    }
}
