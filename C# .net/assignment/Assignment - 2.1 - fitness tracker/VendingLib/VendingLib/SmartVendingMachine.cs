using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VendingLib
{

    //product class to manage the product
    public class Product
    {
        public string Name { get; }
        private int price;
        private int stock;

        public Product(string Name, int price,int stock)
        {
            this.Name = Name;
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
        private int SetPrice
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
        public int UpdateStock
        {
            set
            {
                stock = value;
            }
        }

    }

    public class SmartVendingMachine
    {

        //intializing products
        Product cola = new Product("cola", 20, 25);
        Product sprite = new Product("sprite", 15, 25);
        Product maza = new Product("maza", 25, 25);
        Product saltedChips = new Product("SaltedChips", 10, 25);
        Product snekars = new Product("snekars", 5, 25);

        //making aproduct list
        Product[] productList ;

        //constructor that ads all the products in procudctslist
        public SmartVendingMachine()
        {
            productList = new Product[]
            {
                cola,sprite,maza,saltedChips,snekars
            };
        }

        //display method that will display the product in webpage
        public string Display()
        {
            string str = "";
            int count = 0 ;
            foreach(Product p in productList)
            {
                str += "Srno :"+ (count+1) + " | Name : " + p.Name + " | Price : " + p.GetPrice + " | Quantity : " + p.GetStock+ "<br>";
                count++;
            }
            return str;
        }

        //logic to calculate the price
        public int CalcPrice (int srno, int quantity)
        {
            int price = productList[srno - 1].GetPrice;
            if(quantity> productList[srno - 1].GetStock)
            {
                HttpContext.Current.Response.Write("Item Insufficient");
                return 10000;
            }
            else
            {
                return price * quantity;
            }
            
        }

        //logic to buy the product
        public string Buy(int srno, int totalPrice, int quantity)
        {
            productList[srno - 1].UpdateStock = productList[srno - 1].GetStock - quantity;
            return "Thank You For buying";
        }

    }
}
