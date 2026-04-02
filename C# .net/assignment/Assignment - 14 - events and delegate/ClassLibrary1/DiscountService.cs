using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClassLibrary1
{
    public class DiscountService
    {
        public void Pay(Student obj, FeePayment fp)
        {
            HttpContext.Current.Response.Write(" student : " + obj.Name + 
                " has paid full fees at once of rs "
                + fp.Payment + " and now is elegible for the next year discount");
        }
    }
}
