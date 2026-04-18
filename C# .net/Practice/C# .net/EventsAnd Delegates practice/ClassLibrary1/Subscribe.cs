using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClassLibrary1
{
    public class Subscribe
    {
        public string SName { get; set; }
        public void Notification(Youtube y, UploadVideoEventArgs args)
        {
            HttpContext.Current.Response.Write("subscriber " + SName + " , youtuber " + y.Yname + " has uploaded a video " + args.Title + "<br>");
        }
    }
}
