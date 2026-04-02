using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class V12 : Ifunction
    {
        public int CC
        {
            get
            {
                return 180;
            }
        }

        public virtual string Start()
        {
            return " start";
        }
    }

    public class Audi:V12
    {
        public override string Start()
        {
            return "audi start ";
        }
    }
}
