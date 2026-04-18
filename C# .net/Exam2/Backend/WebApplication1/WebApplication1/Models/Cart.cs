using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    //this class represents entity present inside class
    public class Cart
    {
        public int CartItemId { get; set; }
        public int UserId { get; set; }
        public int ProdId { get; set; }
        public int Quantity { get; set; }
        public string ProdName { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public string ImageUrl { get; set; }
        public int StockQuantity { get; set; }
    }
}