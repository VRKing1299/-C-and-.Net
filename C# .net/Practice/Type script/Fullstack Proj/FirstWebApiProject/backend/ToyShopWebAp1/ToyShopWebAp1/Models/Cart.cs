using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToyShopWebAp1.Models
{
    public class Cart
    {
        public int CartItemId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public string ImageUrl { get; set; }
        public int StockQuantity { get; set; }
    }
}