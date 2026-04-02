using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OrderProcessingSystemLib
{
    /// <summary>
    /// this class OrderProcess is used to process the order with the help of different methods(GenerateInvoice, SendEmailConfirmation, UpdateInventory)
    /// </summary>
    public class OrderProcess
    {
        string str;
        //code to generate the invoice
        public string GenerateInvoice(double amount)
        {
            return "Generating Invoice : " + amount+"<br>";
            HttpContext.Current.Response.Write(str);
        }

        //code to send the mail
        public string SendEmailConfirmation(double amount)
        {
            return str = "sending emial : " + amount + "<br>";
            HttpContext.Current.Response.Write(str);
        }

        //code to update the inventory
        public string UpdateInventory(double amount)
        {
            return  str = "Updating Inventory : " + amount;
            HttpContext.Current.Response.Write(str);
        }

        //code to logorder activity
        public string LogOrderActivity(double amount)
        {
            return str = "printing Log : " + amount + "<br>";
            HttpContext.Current.Response.Write(str);
        }
    }
}
