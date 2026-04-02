using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        publisher p = new publisher();
        Subscriber s1 = new Subscriber() { name = "aj" };
        Subscriber s2 = new Subscriber() { name = "bb" };
        p.VideoUploadEvent += s1.OnVideoUploaded;
        p.VideoUploadEvent += s2.OnVideoUploaded;

        p.OnvideoUpload("c#");
    }
}

public class Student :IComparable<Student>
{
    public int id;
    public string name;
    public int marks;

    public int CompareTo(Student obj)
    {
        return this.id.CompareTo(obj.id);
    }
}

public class SortByMarks : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        return x.marks.CompareTo(y.marks);
    }
}

public static class MyExtension
{
    public static bool isPass(this Student stu)
    {
        return stu.marks > 35 ? true : false;
    }
}

public class publisher
{
    public event EventHandler<VideoEventArgs> VideoUploadEvent;

    public void OnvideoUpload(string title)
    {
        HttpContext.Current.Response.Write("title :" + title + " Video uplad");
        VideoEventArgs args = new VideoEventArgs();
        args.title = title;

        if (VideoUploadEvent != null)
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
    public string name;

    public void OnVideoUploaded(object obj, VideoEventArgs args)
    {
        HttpContext.Current.Response.Write(name + " hello , video  has been uploaded : " + args.title);
    }
}