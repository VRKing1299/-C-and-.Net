using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementLib.Models
{
    public class Customer
    {
        public int CustId { get; }
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        private string mobileNumber;
        public string MobileNumber
        {
            get{return mobileNumber;}
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Moble number cannot be empty");
                }
                else if(value.Length != 10)
                {
                    throw new Exception("please enter right mobile number");
                }
                else if(!value.All(c=> c>='0' && c <= '9'))
                {
                    throw new Exception("mobile number must only be digits");
                }
                else
                {
                    mobileNumber = value;
                }
            }
        }

    }
}
