using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClassLibrary1
{
    public class publisher
    {
        public event EventHandler<VideoEventArgs> VideoUploadEvent;
        
        public void OnvideoUpload(string title)
        {
            HttpContext.Current.Response.Write("title :" + title + " Video uplad");
            VideoEventArgs args = new VideoEventArgs();
            args.title = title;

            if(VideoUploadEvent != null)
            {
                VideoUploadEvent(this, args);
            }
        }
    }

    public class VideoEventArgs : EventArgs
    {
        public string title;
    }

    public class Subscriber
    {
        string name;

        public void OnVideoUploaded(object obj, VideoEventArgs args)
        {
            HttpContext.Current.Response.Write(name + " hello , video  has been uploaded : " + args.title);
        }
    }
}
