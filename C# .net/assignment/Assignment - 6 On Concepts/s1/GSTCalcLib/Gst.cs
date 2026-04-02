using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTCalcLib
{
    /// <summary>
    /// this class is used to perform gst calculation 
    ///  - it has one static method to calcualte the gst price
    /// </summary>
    public class Gst
    {
        const double gst = 1.18;//i will use const keyword since it cannot be changed or updated
        //read inly values can be changed and re assigned in a constructor so we cannot use read ony variable2
        //const varibale direcly uses value and does not get stored in any memory 
        public static double CalcGst(int price)
        {
            return (price * gst);
        }
    }
}
