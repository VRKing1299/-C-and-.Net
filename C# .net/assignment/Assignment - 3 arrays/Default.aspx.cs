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
    /// This class is used to perform the the operations on the array 
    /// these operations include reverse of an array,sum of all elements in an array, creating copy of an array, to check duplicate elements in an array,
    /// merge two array and sort them in assending order, to get the frequency of an element in an array, find maximum and minimum elements in an array,
    /// to create two sepearate arrays of even and odd , print array in descendig order, print the second smallest element in an array
    /// 
    /// all the functions are performed on the user click and output is displayed in UI using lable
    /// </summary>

    //code for reversing an array
    protected void btnC1_Click(object sender, EventArgs e)
    {
        try
        {
            //original array
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };

            //call reverse function
            int[] arrAns = Reverse(arr);

            //display reversed array
            lblA1.Text = "Reverse of an array : " + string.Join(",", arrAns);
        }
        catch (Exception ex)
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

            //loop through array and add elements
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                ans = ans + arr[i];
            }

            //display result
            lblA2.Text = "Sum of all elements : " + Convert.ToString(ans);
        }
        catch (Exception ex)
        {

        }
    }

    //creating a copy of an array
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };

            //create empty array of same size
            int[] arr2 = new int[arr.Length];

            int arrPos = 0;

            //copy elements from arr to arr2
            for (int i = 0; i < arr.Length; i++)
            {
                arr2[arrPos++] = arr[i];
            }

            //display copied array
            lblA3.Text = "Copied array : " + string.Join(" ,", arr2);
        }
        catch (Exception ex)
        {

        }
    }

    //logic to check for duplicate elements in an array
    protected void btnc4_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 3, 3, 4, 4 };
            int count = 0;

            //compare each element with remaining elements
            for (int i = 0; i < arr.Length; i++)
            {
                #region
                for (int j = i + 1; j < arr.Length; j++)
                {
                    #region
                    if (arr[i] == arr[j])
                    {
                        count++;
                        break;
                    }
                    #endregion
                }
                #endregion
            }

            //display duplicate count
            lblA4.Text = Convert.ToString(count);
        }
        catch (Exception ex)
        {

        }
    }

    //code to merge two arrays and sort them
    protected void btnC5_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            int[] arr1 = { 2, 5, 3, 6, 1, 22 };
            int[] arr2 = { 4, 8, 7, 9, 10, 23 };
            int m = 0;

            //create array large enough to store both arrays
            int[] result = new int[arr1.Length + arr2.Length];

            //copy first array
            for (int i = 0; i < arr1.Length; i++)
            {
                result[m++] = arr1[i];
            }

            //copy second array
            for (int i = 0; i < arr2.Length; i++)
            {
                result[m++] = arr2[i];
            }

            //sort merged array
            int[] sortedArr = Sorted(result);

            //display sorted array
            lblA5.Text = string.Join(",", sortedArr);
            #endregion
        }
        catch (Exception ex)
        {

        }
    }

    //code to get frequency of elements in an array
    protected void btnC6_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr = { 1, 2, 1, 1, 3, 4, 4, 5, 5 };

            List<int> arr1 = new List<int>(); //stores processed numbers
            string str = "";

            //loop through array
            for (int i = 0; i < arr.Length; i++)
            {
                int count = 1;

                //skip already counted numbers
                if (arr1.Contains(arr[i]))
                {
                    continue;
                }
                else
                {
                    arr1.Add(arr[i]);

                    //count frequency
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

            //display frequencies
            lblA6.Text = str;
        }
        catch (Exception ex)
        {

        }
    }

    //code to find minimum and maximum element
    protected void btnC7_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };

            string str = "";

            //call helper functions
            str = str + "Minumum element : " + Minimum(arr) + " and Maximum element : " + Maximum(arr);
            lblA7.Text = str;
        }
        catch (Exception ex) { }
    }

    //code to separate even and odd numbers
    protected void btnA8_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
            List<int> even = new List<int>();
            List<int> odd = new List<int>();

            //check each element
            foreach (int i in arr)
            {
                #region
                if (i % 2 == 0)
                {
                    even.Add(i); //add to even list
                }
                else
                {
                    odd.Add(i); //add to odd list
                }
                #endregion
            }

            //display even and odd arrays
            lblA8.Text = " Even Elements " + string.Join(",", even) + "  |  Odd elements " + string.Join(",", odd);
        }
        catch (Exception ex) { }
    }

    //code to print array in descending order
    protected void btnCalcDescArray_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };

            //sort array
            arr = Sorted(arr);

            //reverse sorted array to get descending order
            arr = Reverse(arr);

            lblA9.Text = string.Join(",", arr);
        }
        catch (Exception ex) { }
    }

    //code to print the second smallest number
    protected void btnSecondSmallest_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr = { 1, 3, 2, 4, 5, 6, 7, 8 };

            int smallest = Minimum(arr);
            int secondSmalest = Maximum(arr);

            //find second smallest value
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
        }
        catch (Exception ex)
        {

        }
    }

    //Functions =======================

    //function to reverse an array
    public int[] Reverse(int[] arr)
    {
        string ans = "";
        int[] arrAns = new int[arr.Length];
        int arrPos = 0;

        //copy elements in reverse order
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            arrAns[arrPos++] = arr[i];
        }

        //build reversed string (not used in output)
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            ans = ans + arr[i] + " ";
        }

        return arrAns;
    }

    //function to sort array using simple swapping logic
    public int[] Sorted(int[] result)
    {
        for (int i = 0; i < result.Length - 1; i++)
        {
            if (result[i] > result[i + 1])
            {
                int temp = result[i];
                result[i] = result[i + 1];
                result[i + 1] = temp;

                i = (-1); //restart sorting
            }
        }
        return result;
    }

    //function to find minimum value
    public int Minimum(int[] arr)
    {
        int num = arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            if (num > arr[i])
            {
                num = arr[i];
            }
        }

        return num;
    }

    //function to find maximum value
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