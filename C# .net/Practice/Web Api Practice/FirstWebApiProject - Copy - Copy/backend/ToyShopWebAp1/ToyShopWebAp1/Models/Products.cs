using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToyShopWebAp1.Models
{
    /// <summary>
    /// this class is used to redpresent the product
    /// </summary>
    public class Products
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}