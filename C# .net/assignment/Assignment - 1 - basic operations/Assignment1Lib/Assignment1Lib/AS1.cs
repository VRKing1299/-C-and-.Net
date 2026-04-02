using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1Lib
{
    public class AS1
    {
        public static int Add(int a,int b)
        {
            return a + b;
        }

        public static double AddDouble(int a, int b)
        {
            return a + b;
        }

        public static bool TwentyCheck(int num1, int num2)
        {
            if ((num1 == 20) || (num2 == 20) || (num1 + num2 == 20))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
