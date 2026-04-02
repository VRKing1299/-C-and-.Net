using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestLib
{
    public abstract class MyAbstractClass
    {
        public abstract int Add(int a, int b);

        public abstract int Sub(int a, int b );
    }

    public abstract class MySecondAbstractClass : MyAbstractClass
    {
        public override int Add(int a , int b)
        {
            return a + b;
        }

        public abstract int Mul(int a, int b );
    }
}
