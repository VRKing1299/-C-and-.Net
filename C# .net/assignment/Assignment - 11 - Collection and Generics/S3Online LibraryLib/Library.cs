using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Online_LibraryLib
{
    /// <summary>
    /// generic class that is used to add item and display item
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Library<T>
    {
        //private T item;
        //code to add item
        public string AddItem(T item)
        {
            //this.item = item;
            return "item added " + item;
        }
        //code to display item
        public string DisplayItem(T item)
        {
            return "Displayed : " + item;
        }
    }
}
