using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementLib.Models
{
    public class Order
    {
        public int BillNo { get; }
        public int CustId { get; set; }
        public int BookId { get; set; }
        private int buyQuantity;
        public int BuyQuantity
        {
            get { return buyQuantity; }
            set
            {
                if (value <= 0) throw new Exception("Quantatiy cannot be less than or eyal to zero");
                else buyQuantity = value;
            }
        }
        public double TotalBill { get; set; }
    }
}
