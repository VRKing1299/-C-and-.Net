using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementLib.Models
{
    public class Book
    {
        public int BookId { get;}
        public string BookName { get; set; }
        private double bookPrice { get; set; }
        public double BookPrice
        {
            get { return bookPrice; }
            set
            {
                if (value <= 0) throw new Exception("price canot be negative or zero");
                else bookPrice = value;
            }
        }
        public int BookQuantity { get; set; }

        public Book (int id)
        {
            this.BookId = id;
        }
    }
}
