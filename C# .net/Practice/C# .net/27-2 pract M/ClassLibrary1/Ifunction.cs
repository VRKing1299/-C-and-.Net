using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    interface Ifunction
    {
        int CC { get; }
        string Start();

        //interface cannot contain constructors
        //public Ifunction(int cc)
        //{
        //    CC = cc;
        //}
    }
}
