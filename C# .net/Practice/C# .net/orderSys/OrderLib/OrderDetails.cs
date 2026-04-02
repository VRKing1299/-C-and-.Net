using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLib
{
    public class Items
    {
        public string name;
        public int price;

        public Items(string name , int price)
        {
            this.name = name;
            this.price = price;
        }
    }
    public class OrderDetails
    {
        public int totalPrice;
        public int TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                if (value >= 100)
                {
                    totalPrice = Convert.ToInt16(value - (value * 0.10));
                }
                else
                {
                    totalPrice = value;
                }
            }
        }

        private static int num = 0;
        public int orderNum = num++;
        public Items items;

        private OrderDetails(Items I, int totalPrice)
        {
            items = I;
            TotalPrice = totalPrice;
        }

        public static OrderDetails GetOrder(Items I, int quant)
        {
            int totalPrice = I.price * quant;
            return new OrderDetails(I, totalPrice);
        }
    }
}
