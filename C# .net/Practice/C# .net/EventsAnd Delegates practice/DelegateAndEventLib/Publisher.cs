using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DelegateAndEventLib
{
    //public delegate void VideoUploadHandlerDele(object obj, VideoUploadEventArgs args);
    public class Publisher
    {
        //public event VideoUploadHandlerDele OnVideoUploadEvent;
        public event EventHandler<VideoUploadEventArgs> OnVideoUploadEvent;
        public void OnVideoUpload(string title)
        {
            HttpContext.Current.Response.Write("Title : " + title + " Video uploaded");
            VideoUploadEventArgs args = new VideoUploadEventArgs();
            args.Title = title;

            if(OnVideoUploadEvent != null)
            {
                OnVideoUploadEvent(this, args);
            }
        }
    }

    public class VideoUploadEventArgs : EventArgs
    {
        public string Title;
    }
}
