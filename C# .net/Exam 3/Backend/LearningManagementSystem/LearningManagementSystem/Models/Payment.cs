using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; } // Debit / Credit
        public DateTime PaymentDate { get; set; }
        public int InvoiceId { get; set; }
    }
}