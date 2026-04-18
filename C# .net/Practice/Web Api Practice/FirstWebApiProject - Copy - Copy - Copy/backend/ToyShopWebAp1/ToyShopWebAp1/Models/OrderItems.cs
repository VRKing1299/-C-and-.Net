using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToyShopWebAp1.Models
{
    public class OrderItems
    {
        public int OrderItemsId { get; set; }
        public int OrderId { get; set; }
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public int Quantity { get; set; }
        public double PriceAtPurchase { get; set; }
    }
}