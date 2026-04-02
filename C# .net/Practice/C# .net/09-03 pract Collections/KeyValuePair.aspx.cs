using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class KeyValuePair : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Dictionary<int, string> di = new Dictionary<int, string>()
        {
            {1,"a" },
            {2,"b" },
            {3,"c" },
            {5,"e" }
        };

        //di.Add(4, "e");
        PrintDi(di);

        //Response.Write("<br> <br>after removing : <br>");

        //di.Remove(5);
        //PrintDi(di);

        foreach(var k in di.Keys)
        {
            Response.Write("" + k + "<br>");
        }
        foreach (var k in di.Values)
        {
            Response.Write("" + k + "<br>");
        }
        foreach (KeyValuePair<int, string> item in di)
        {
            Response.Write(""+item.Key + "|" + item.Value);
        }


    }

    public void PrintDi(Dictionary<int, string> di)
    {
        foreach(var item in di)
        {
            Response.Write("Keys : "+item.Key + ", Value : " + item.Value+"<br>");
        }
    }

    protected void btnSortedList_Click(object sender, EventArgs e)
    {
        SortedList<int, string> di = new SortedList<int, string>()
        {
            {1,"a" },
            {2,"b" },
            {3,"c" },
            {5,"e" }
        };

        foreach (var k in di.Keys)
        {
            Response.Write("" + k + "<br>");
        }
        foreach (var k in di.Values)
        {
            Response.Write("" + k + "<br>");
        }
        foreach (KeyValuePair<int, string> item in di)
        {
            Response.Write("" + item.Key + "|" + item.Value);
        }
    }

    protected void btnHashTable_Click(object sender, EventArgs e)
    {
        Hashtable di = new Hashtable()
        {
            {1,"a" },
            {2,"b" },
            {3,"c" },
            {5,"e" }
        };
        di.Add(7, "g");
        di.Remove(1);
        Response.Write("containts key 7 : " + di.Contains(7)+"<br>");
        Response.Write("containts key 7 : " + di.ContainsKey(7) + "<br>");
        Response.Write("Contains value e : " + di.ContainsValue("e") + "<br>");
        di[3] = "hh";
        foreach (var k in di.Keys)
        {
            Response.Write("" + k + "<br>");
        }
        
        foreach (var k in di.Values)
        {
            Response.Write("" + k + "<br>");
        }

        di.Clear();
        foreach (DictionaryEntry item in di)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }


        //foreach (var item in di)
        //{
        //    Response.Write("" + item.Key + "|" + item.Value);
        //}
    }
}