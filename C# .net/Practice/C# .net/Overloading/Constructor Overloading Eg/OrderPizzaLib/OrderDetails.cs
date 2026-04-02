using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPizzaLib
{
    public class OrderDetails
    {
        public static string OrderPizza(string name)
        {
            return " Order for pizza " + name;
        }
        public static string OrderPizza(string name, int quantity)
        {
            return " Order for pizza " + name + " with quantity : " + quantity;
        }
        public static string OrderPizza(string name, string toppings)
        {
            return " Order for pizza " + name + " with toppings : " + toppings;
        }
        public static string OrderPizza(string name, string toppings, int quantity)
        {
            return " Order for pizza " + name + " with quantity : " + quantity + " and toppings of " +toppings;
        }
    }
}
