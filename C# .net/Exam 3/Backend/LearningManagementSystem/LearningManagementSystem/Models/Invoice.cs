using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}