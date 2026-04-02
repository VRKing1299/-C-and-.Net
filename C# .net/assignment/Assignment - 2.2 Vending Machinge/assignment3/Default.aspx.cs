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

    /// <summary>
    /// different code implementations on an array
    /// </summary>

    //code for reversing an array
    protected void btnC1_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] arrAns = Reverse(arr);
            //int[] arrAns = new int[arr.Length];
            //int arrPos = 0;

            //for (int i = arr.Length - 1; i >= 0; i--)
            //{
            //    arrAns[arrPos++] = arr[i];
            //}

            //for (int i = arr.Length - 1; i >= 0; i--)
            //{
            //    ans = ans + arr[i] + " ";
            //}

            //lblA1.Text = "Reverse of an array : " + ans; //string.Join(",", arr.Reverse())
            lblA1.Text = "Reverse of an array : " + string.Join(",", arrAns); //string.Join(",", arr.Reverse())
        }catch(Exception ex)
        {

        }
    }

    //code for sum of all elements in an array
    protected void btnC2_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int ans = 0;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                ans = ans + arr[i];
            }

            lblA2.Text = "Sum of all elements : " + Convert.ToString(ans);
        }catch(Exception ex)
        {

        }
    }

    //creating a copy of an array
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] arr2 = new int[arr.Length];

            int arrPos = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                arr2[arrPos++] = arr[i];
            }

            //int[] arr3 = new int[3];
            //Array.Copy(arr, arr3, arr.Length);
            lblA3.Text = "Copied array : " + string.Join(" ,", arr2);
        }catch(Exception ex)
        {

        }
    }

    //logic to check for the duplicate element in an array
    protected void btnc4_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 3, 3, 4, 4 };
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        count++;
                        break;
                    }
                }
            }
            lblA4.Text = Convert.ToString(count);
        }catch(Exception ex)
        {

        }
    }

    //code to merge two array of same size and sorted in ascending order
    protected void btnC5_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr1 = { 2, 5, 3, 6, 1, 22 };
            int[] arr2 = { 4, 8, 7, 9, 10, 23 };
            int m = 0;

            int[] result = new int[arr1.Length + arr2.Length];

            for (int i = 0; i < arr1.Length; i++)
            {
                result[m++] = arr1[i];
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                result[m++] = arr2[i];
            }

            int[] sortedArr = Sorted(result);
            //for(int i = 0; i < result.Length-1; i++)
            //{
            //    if (result[i] > result[i + 1])
            //    {
            //        int temp = result[i];
            //        result[i] = result[i + 1];
            //        result[i + 1] = temp;


            //        i = (-1);
            //    }
            //}
            //Array.Sort(result);

            lblA5.Text = string.Join(",", sortedArr);
        }
        catch(Exception ex)
        {

        }
    }

    //code to to get the frequency of an element in an array
    protected void btnC6_Click(object sender, EventArgs e)
    {
        try
        {
            //int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 3, 3, 4, 4 };
            int[] arr = { 1, 2, 1, 1, 3, 4, 4, 5, 5 };
            int a = 0;

            List<int> arr1 = new List<int>(); //lis is a strongly typed collection of objects that can that can be accessed by index and can resize dynamically 
            string str = "";

            for (int i = 0; i < arr.Length; i++)
            {
                int count = 1;

                if (!arr1.Contains(arr[i]))
                {
                    arr1.Add(arr[i]);

                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i] == arr[j])
                        {
                            count++;
                        }
                    }
                    str = str + " Number : " + arr[i] + " -> Count : " + count + " | ";
                }
            }

            lblA6.Text = str;
        }catch(Exception ex)
        {

        }
    }

    //code to find maximum and minimum element in an array
    protected void btnC7_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };

            string str = "";

            str = str + "Minumum element : " + Minimum(arr) + " and Maximum element : " + Maximum(arr);
            lblA7.Text = str;
        }
        catch(Exception ex) { }
    }


    //code to seperate even and odd element in an array
    protected void btnA8_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
            List<int> even = new List<int>();
            List<int> odd = new List<int>();

            foreach (int i in arr)
            {
                if (i % 2 == 0)
                {
                    even.Add(i);
                }
                else
                {
                    odd.Add(i);
                }
            }

            lblA8.Text = " Even Elements " + string.Join(",", even) + "  |  Odd elements " + string.Join(",", odd);
        }
        catch(Exception ex) { }
    }


    //code to print array in descending order
    protected void btnCalcDescArray_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
            arr = Sorted(arr);
            arr = Reverse(arr);
            lblA9.Text = string.Join(",", arr);
        }
        catch (Exception ex) { }
    }


    //code to print the second smallest number in an array
    protected void btnSecondSmallest_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr = { 1, 3, 2, 4, 5, 6, 7, 8 };
            int smallest = Minimum(arr);
            int secondSmalest = Maximum(arr);

            foreach (int i in arr)
            {
                if (i < smallest)
                {
                    secondSmalest = smallest;
                    smallest = i;
                }
                else if (i < secondSmalest && i != smallest)
                {
                    secondSmalest = i;
                }
            }

            lblA10.Text = "second smallest" + Convert.ToString(secondSmalest);
        }catch(Exception ex)
        {

        }
    }

    //code to reverse an array
    public int[] Reverse(int[] arr)
    {
        string ans = "";
        int[] arrAns = new int[arr.Length];
        int arrPos = 0;

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            arrAns[arrPos++] = arr[i];
        }

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            ans = ans + arr[i] + " ";
        }
        return arrAns;
    }
    //different methods used in code
    public int[] Sorted(int[] result)
    {
        for (int i = 0; i < result.Length - 1; i++)
        {
            if (result[i] > result[i + 1])
            {
                int temp = result[i];
                result[i] = result[i + 1];
                result[i + 1] = temp;


                i = (-1);
            }
        }
        return result;
    } 
    

    //different methods
    //code to find minimum element of an array
    public int Minimum(int[] arr)
    {
        int num = arr[0];
        for(int i = 0; i < arr.Length; i++)
        {
            if (num > arr[i])
            {
                num = arr[i];
            }
        }
        return num;
    }
    //code to find maximum element of an array
    public int Maximum(int[] arr)
    {
        int num = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            if (num < arr[i])
            {
                num = arr[i];
            }
        }
        return num;
    }
}