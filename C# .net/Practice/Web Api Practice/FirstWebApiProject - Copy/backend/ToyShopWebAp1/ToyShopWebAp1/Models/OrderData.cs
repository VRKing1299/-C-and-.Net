using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToyShopWebAp1.Models
{

    //not using this
    public class OrderData
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public List<OrderItems> OrderItems { get; set; }
    }
}