using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VendingLib
{

    /// <summary>
    /// Represents a smart vending machine system that manages a collection of
    /// products and allows users to interact with them.
    ///  - The vending machine initializes several product items, each with its own name, price, and available stock quantity.
    ///  - Provides functionality to display all the products available
    ///  - CalcPrice function to calculate the price of the product based on product price and quantity
    ///  - Buy to buy the product and update the stock
    /// this class is used in user interface to simulate the smart vending machine user experience with calculat price and buy the product
    /// </summary>
    public class SmartVendingMachine
    {

        //initializing different products with name, price, and stock
        Product cola = new Product("cola", 20, 25);
        Product sprite = new Product("sprite", 15, 25);
        Product maza = new Product("maza", 25, 25);
        Product saltedChips = new Product("SaltedChips", 10, 25);
        Product snekars = new Product("snekars", 5, 25);

        //array to store all products available in the vending machine
        Product[] productList;

        //constructor that adds all the created products into the productList array
        public SmartVendingMachine()
        {
            productList = new Product[]
            {
                cola, sprite, maza, saltedChips, snekars
            };
        }

        //method used to display all products and their details on the webpage
        public string Display()
        {
            string str = "";
            int count = 0;

            //loop through each product and build display string
            foreach (Product p in productList)
            {
                #region
                //add product details 
                str += "Srno :" + (count + 1) + " | Name : " + p.Name + " | Price : " + p.GetPrice + " | Quantity : " + p.GetStock + "<br>";
                count++;
                #endregion
            }

            return str; //return formatted product list
        }

        //method to calculate total price based on selected product and quantity
        public int CalcPrice(int srno, int quantity)
        {
            //get price of selected product using serial number
            int price = productList[srno - 1].GetPrice;

            //check if requested quantity exceeds available stock
            if (quantity > productList[srno - 1].GetStock)
            {
                #region
                //display message if stock is insufficient
                HttpContext.Current.Response.Write("Item Insufficient");

                return 10000; //special value used to indicate insufficient stock
                #endregion
            }
            else
            {
                //calculate total price
                return price * quantity;
            }

        }

        //method used to purchase a product and update its stock
        public string Buy(int srno, int totalPrice, int quantity)
        {
            //reduce product stock after purchase
            productList[srno - 1].UpdateStock = productList[srno - 1].GetStock - quantity;

            //return confirmation message
            return "Thank You For buying";
        }

    }
}