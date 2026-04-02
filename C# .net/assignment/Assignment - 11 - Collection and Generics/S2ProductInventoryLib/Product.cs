using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2ProductInventoryLib
{
    /// <summary>
    /// a product class that represents the product entity
    /// with product id and name
    /// has a constuctor with id and name parameter
    /// </summary>
    public class Product
    {
        public int ProductID { get; }
        public string ProductName { get; }

        //a constuctor with id and name parameter
        public Product(int id, string name)
        {
            ProductID = id;
            ProductName = name;
        }
    }
}
