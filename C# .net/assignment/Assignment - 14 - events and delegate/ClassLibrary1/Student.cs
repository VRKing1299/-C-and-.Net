using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClassLibrary1
{

    //public delegate void Mydelegate(Student obj, FeePayment fp);
    public delegate void Mydelegate(Student obj, FeePayment fp);
    public class Student
    {
        public static double fullPayment = 50000;

        public int Id { get;}
        public string Name { get; }
        public double Amount { get; set; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }

        //public event EventHandler<FeePayment> OnFeePaymentEvent;
        public event Mydelegate OnFeePaymentEvent;

        public void Pay(double amount)
        {
            if (Amount == fullPayment)
            {
                HttpContext.Current.Response.Write("full salary has been paid");
            }
            else if (amount > fullPayment)
            {
                HttpContext.Current.Response.Write(" your are paying fee more than required");
            }
            else if (fullPayment < (Amount + amount))
            {
                HttpContext.Current.Response.Write("your total fee exceeds the total amount to be paid");
            }
            else
            {
                HttpContext.Current.Response.Write(" Student " + Name + " has paid amount of " + amount);
                Amount += amount;

                if (amount == fullPayment)
                {
                    FeePayment fPay = new FeePayment() { Payment = amount, StudName = Name };
                    if (OnFeePaymentEvent != null)
                    {
                        OnFeePaymentEvent(this, fPay);
                    }
                }
            }
        } 

    }

    public class FeePayment : EventArgs
    {
        public string StudName { get; set; }
        public double Payment { get; set; }
    }
}
