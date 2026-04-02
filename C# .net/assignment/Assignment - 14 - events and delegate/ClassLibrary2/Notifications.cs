using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClassLibrary2
{
    public class Notifications
    {
        public void SendEmail(Object obj, SalaryIncerementArgs args)
        {
            HttpContext.Current.Response.Write("Email Send to Employee id : " + args.EmpId + " Name: " + args.EmpName + " has gotton salary increment of rs " +
                args.Increment + " , total salary : " + args.EmpSalary+"<br>");
        }

        public void UpdatePayRoll(Object obj, SalaryIncerementArgs args)
        {
            HttpContext.Current.Response.Write("PayRoll of Employee id : " + args.EmpId + " Name: " + args.EmpName + " has been Updated to total salary : " + args.EmpSalary+"<br>");
        }

        public void GenerateNotificatin(Object obj, SalaryIncerementArgs args)
        {
            HttpContext.Current.Response.Write("Notification has been send to Employee id : " + args.EmpId + " Name: " + args.EmpName +"<br>");
        }
    }
}
