using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToyShopWebAp1.Models
{
    public class Orders
    {
        public int OrderId { get; set; }//<--
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }//<--
        public int OrderItemsId { get; set; }
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public string Quantity { get; set; }
        public string PriceAtPurchase { get; set; }
    }
}