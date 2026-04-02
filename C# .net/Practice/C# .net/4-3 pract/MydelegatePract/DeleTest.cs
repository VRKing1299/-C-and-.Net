using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MydelegatePract
{
    public delegate int MyDelegate(int a, int b);
    public class DeleTest
    {
        public int MyMethod(int a, int b , MyDelegate m)
        {
            int res = m(a, b);
            return res;
        }
    }
}
