using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VendingLib
{

    /// <summary>
    /// Represents a product entity used in the vending machine system with name, price and stock attributes
    ///  - constructor to create the product entity with name price and stock
    ///  - get price that only returns the price
    ///  - set price with the validation logic so price cannot be negative
    ///  -  sotck with getstock and update stock properties 
    /// 
    /// The class is used by the vending machine system to manage
    /// product details and maintain inventory during purchase
    /// operations.
    /// </summary>
    public class Product
    {
        public string Name { get; }
        private int price;
        private int stock;

        public Product(string name, int price, int stock)
        {
            //initialize the feilds
            this.Name = name;
            this.price = price;
            this.stock = stock;
        }

        public int GetPrice
        {
            get
            {
                return price;
            }
        }
        private int SetPrice//price validation
        {
            set
            {
                if (value >= 0)
                {
                    price = value;
                }
                else
                {
                    price = 0;
                }

            }
        }

        public int GetStock
        {
            get
            {
                return stock;
            }
        }
        public int UpdateStock// to update the stock of an item
        {
            set
            {
                stock = value;
            }
        }

    }

    
}
