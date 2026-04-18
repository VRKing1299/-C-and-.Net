using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClassLibrary1
{
    public delegate void VideoUploadDelegate(Youtube y, UploadVideoEventArgs args);
    public class Youtube
    {
        public string Yname { get; set; }
        //public event EventHandler<UploadVideoEventArgs> OnVideoUploadEvent;
        public event VideoUploadDelegate OnVideoUploadEvent;
        public void UploadVideo(string title)
        {
            HttpContext.Current.Response.Write("Youtuber " + Yname + " has uploaded a vodeo<br>");
            UploadVideoEventArgs args = new UploadVideoEventArgs();
            args.Title = title;

            if(OnVideoUploadEvent != null)
            {
                OnVideoUploadEvent(this, args);
            }
        }
    }

    public class UploadVideoEventArgs : EventArgs
    {
        public string Title;
    }
}
