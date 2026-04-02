using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PrePract : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            List<int> intList = new List<int>() { 10, 20, 30 };

            Response.Write("<br>List Capacity:" + intList.Capacity);
            intList.Add(40);
            intList.Add(50);
            intList.Add(60);

            Response.Write("<br>List Capacity:" + intList.Capacity);
            PrintLS(intList);

            #region
            //List<string> nameList = new List<string>();
            //nameList.Add("Smith");
            //nameList.Add("John");
            //nameList.Add("Alina");

            //foreach(string nm in nameList)
            //{
            //    Response.Write("<br>"+nm);
            //}
            #endregion
        }
        catch (Exception ex) { }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            //create reference variable for List class & create object of List class
            List<int> myList = new List<int>(5) { 10, 20, 30 };

            //add new element at the end of existing collection
            myList.Add(40);
            myList.Add(50);

            //another collection
            List<int> otherList = new List<int>() { 50, 60, 70 };

            //adding another collection to existing collection
            // otherList.AddRange(myList);
            myList.AddRange(otherList);

            //read elements using foreach loop
            PrintLS(myList);
            #endregion
        }
        catch (Exception ex) { }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            List<int> myList = new List<int>() { 10, 20, 30, 40, 50, 40 };

            //search for 40
            int n = myList.IndexOf(40);
            Response.Write("<br>40 found at " + n);

            #region ////search for 60
            int n2 = myList.IndexOf(60);
            if (n2 >= 0)
            {
                Response.Write("<br>60 found at " + n2);
            }
            else
            {
                Response.Write("<br>60 is not found");
            }
            #endregion

            //search for second occurrence of 40
            int n3 = myList.IndexOf(40, n + 1);
            Response.Write("<br>Second occurrence of 40 is " + n3);

            //collection for binary search
            List<int> myList2 = new List<int>() { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };//returns index
            int n4 = myList2.BinarySearch(1001);
            Response.Write("<br>Binary search of 80: " + n4);

            ////contains
            bool b = myList2.Contains(110);
            Response.Write("<br>110 is found in myList2: " + b);
        }catch(Exception ex) { }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            //create reference variable for List class & create object of List class
            List<int> myList = new List<int>(10) { 10, 20, 30 };

            //insert element at position 1
            myList.Insert(1, 100);

            //insert elements at position 2
            List<int> otherList = new List<int>() { 200, 300, 400 };
            myList.InsertRange(1, otherList);

            #region//read elements using foreach loop
            Response.Write("<br>Using foreach loop:");
            foreach (int item in myList)
            {
                Response.Write("<br>" + item);
            }
            #endregion
        }
        catch (Exception ex) { }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        try
        {
            #region//collection
            List<int> ls = new List<int>() { 10, 20, 30, 40, 50, 40, 30, 20, 30 };
            Response.Write("<br>Existing List");
            PrintLS(ls);

            //remove 30, it remmoves first element it finds
            ls.Remove(30);
            Response.Write("<br> after removing first 30 : ");
            PrintLS(ls);

            //removing at index 2
            int ind = 2;
            if (ls.Count > ind)
            {
                ls.RemoveAt(ind);
            }
            Response.Write("<br> after removing element at index 2 : ");
            PrintLS(ls);

            //removes the range of elements starting from the index no
            ls.RemoveRange(1, 3);
            Response.Write("<br> after deleting 3 elements starting from index 1 : ");
            PrintLS(ls);

            //code to remove all the occurence of element 30 
            ls.RemoveAll(r => r == 30);
            Response.Write("<br> after deleting all occurence of element 30 : ");
            PrintLS(ls);

            //code to remove all element from the index 
            ls.Clear();
            ls.Add(10);
            Response.Write("<br> after deleting all element and adding one element in list : ");
            PrintLS(ls);
            #endregion
        }
        catch (Exception) { }

    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        try
        {
            List<double> myNumbers = new List<double>() { 170, 150, 445, 120, 10, 4, 661, 4};
            Response.Write("<br> existing list : ");
            PrintLS(myNumbers);

            Response.Write("<br><br> last index of 4 : "+ myNumbers.LastIndexOf(4));
            //sorts the list in ascending order
            myNumbers.Sort();

            //reverse the list
            myNumbers.Reverse();

            Response.Write("<br> list in descending order list : ");
            PrintLS(myNumbers);

        }catch(Exception ex) { }
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        try
        {
             SortedList<int, string> employees = new SortedList<int, string>()
            {
                 #region
                { 102, "Smith" },
                { 105, "James" },
                { 103, "Allen" },
                { 101, "Scott" },
                { 104, "Jones" }
                 #endregion
            };
            

            employees.Add(106, "Anna");
            //employees.Add(106, "banana"); this will cause an error
            Response.Write("printing the first list  :  ");
            PrintSL(employees);

            employees.Remove(103);
            Response.Write("<br> <br> sorted list after removing 103 : ");
            PrintSL(employees);

            //get value based on key
            Response.Write("<br> <br>  getting the vlue based on the key ");
            string eName = employees[105];
            Response.Write("<br>Employee name at 105: " + eName);

            //search for specific key
            Response.Write("<br> <br> checking if sorted list contains the key ");
            bool k = employees.ContainsKey(105);
            Response.Write("<br> 105 exists: " + k);

            //search for specific value
            Response.Write("<br> <br> checking if sorted list contains the value ");
            bool v = employees.ContainsValue("Scott");
            Response.Write("<br>Scott exists: " + v);

            //index of specific key
            Response.Write("<br> <br> getting index of a specific key ");
            int ki = employees.IndexOfKey(101);
            Response.Write("<br>Index of 101: " + ki);

            //index of specific value
            Response.Write("<br> <br> getting index of a specific value ");
            int vi = employees.IndexOfValue("Smith");
            Response.Write("<br>Index of Smith: " + vi);

            //iterating over Keys
            Response.Write("<br> <br> Keys:");
            foreach (int key in employees.Keys)
            {
                Response.Write("" + key + " | ");
            }

            // iterating over the Values
            Response.Write("<br> <br> Values:");
            foreach (string item in employees.Values)
            {
                Response.Write("" + item + " | ");
            }
        }catch(Exception ex) { }
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        try
        {
            //collection with marks of student
            List<int> marks = new List<int>() { 30, 95, 14, 70, 26, 81 };

            #region//exist checks if the student ifailed 
            Response.Write(" checking if student have passed in all the subject : <br>");
            bool b = marks.Exists(m => m <= 35);
            if (b)
            {
                Response.Write("student have failed in one or more subjects");
            }
            else
            {
                Response.Write("student have passed in all the subjects");
            }
            #endregion

            //Find: Get marks of first failed subject
            Response.Write("<br> <br> finding the first failded subject");
            int firstFailedMarks = marks.Find(m => m < 35);
            Response.Write("<br>First failed marks: " + firstFailedMarks);

            //FindIndex: Get index of marks of first failed subject
            Response.Write("<br><br> getting index of first faied subject : ");
            int firstFailedMarksIndex = marks.FindIndex(m => m < 35);
            Response.Write("<br>First failed marks index: " + firstFailedMarksIndex);

            //FindLast: Get marks of last failed subject
            Response.Write("<br> <br>  getting marks of last failed subject : ");
            int lastFailedMarks = marks.FindLast(m => m < 35);
            Response.Write("<br>Last failed marks: " + lastFailedMarks);

            //FindLastIndex: Get index of marks of last failed subject
            Response.Write("<br> <br> getting index of last failed subject : ");
            int lastFailedMarksIndex = marks.FindLastIndex(m => m < 35);
            Response.Write("<br>Last failed marks index: " + lastFailedMarksIndex);
            PrintLS(marks);

            //FindAll: Get all failed subjects marks
            Response.Write("<br> <br>getting list of all failed subject");
            List<int> allFailedMarks = marks.FindAll(m => m < 35);
            Response.Write("<br>Failed marks:");
            PrintLS(allFailedMarks);
        }catch(Exception ex) { }
    }


    //code to print the list
    public void PrintLS<T>(List<T> ls)
    {
        foreach (T item in ls)
        {
            Response.Write("" + item + ", ");
        }
    }


    //code to print the sorted list
    public void PrintSL<TKey, TValue>(SortedList<TKey, TValue> sl)
    {
        foreach (KeyValuePair<TKey, TValue> item in sl)
        {
            Response.Write("" + item.Key + " , " + item.Value + "  |  ");
        }
    }


}

