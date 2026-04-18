using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DelegateAndEventLib
{
    public class Subscriber
    {
        public string Name { get; set; }

        public void UploadNotification(Object obj, VideoUploadEventArgs args)
        {
            HttpContext.Current.Response.Write(Name + ": Notification for " + args.Title);
        }
    }
}
