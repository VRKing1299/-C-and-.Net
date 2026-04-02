using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment1Lib;


/// <summary>
/// Code-behind class for the Default.aspx page that handles various basic
/// programming exercises and user interactions through ASP.NET Web Forms controls.
///
/// This page performs multiple operations including:
/// arithmetic calculations, number swapping, average calculations,
/// pattern printing, logical checks between integers, conditional summation,
/// sentence word reversal, natural number sequence generation, summation of numbers,
/// average calculation of multiple inputs, cube calculation of numbers,
/// and palindrome number validation.
///
/// Each operation is triggered through button click events that read input
/// from textboxes, process the logic in C#, and display results using labels
/// or response output on the webpage.
/// </summary>

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    //1)program to calculate few equations
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        try
        {
            // Get user input from textboxes
            lblAns1.Text = Convert.ToString(-1 + (4 * 6));
            lblAns2.Text = Convert.ToString((35 + 5) % 7);
            lblAns3.Text = Convert.ToString(14 + -((4 * 6) / 11));
            lblAns4.Text = Convert.ToString(2 + ((15 / 6) * 1) - (7 % 2));

            // make labels visible
            lblAns1.Visible = true;
            lblAns2.Visible = true;
            lblAns3.Visible = true;
            lblAns4.Visible = true;
        }
        catch (Exception ex)
        {

        }
    }

    //2)program to swap 2 numbs
    protected void btnSwap_Click(object sender, EventArgs e)
    {
        try
        {
            // Get user input from textboxes
            int numA = Convert.ToInt16(txtNumA.Text);
            int numB = Convert.ToInt16(txtNumB.Text);

            int temp = numA;// store first value
            numA = numB;    // assign second value to first
            numB = temp;    // assign stored value to second

            // Display the result in label
            lblSwapResult.Text = "A = " + Convert.ToString(numA) + " | B = " + Convert.ToString(numB);
        }
        catch(Exception ex)
        {

        }
    }
    

    //3) program to calculate the avg of 4 nums
    protected void btnCalcAvg_Click(object sender, EventArgs e)
    {
        try
        {
            // Get user input from textboxes
            int n1 = Convert.ToInt16(txtNum1.Text);
            int n2 = Convert.ToInt16(txtNum2.Text);
            int n3 = Convert.ToInt16(txtNum3.Text);
            int n4 = Convert.ToInt16(txtNum4.Text);

            // Display the average of 4 in label
            lblAvg.Text = Convert.ToString(((n1 + n2 + n3 + n4) / 4));
        }
        catch(Exception ex)
        {

        }
    }

    // 4) code to print rectangle of the given number
    protected void btnPTR_Click(object sender, EventArgs e)
    {
        try
        {
            // Get user input from textboxes
            int num = Convert.ToInt16(lblRectangleInput.Text);
            for(int i = 1; i<=5; i++)//rows
            {
                for(int j = 1; j <= 3; j++)//columns
                {
                    if(i==1 || i == 5)//this checks for length
                    {
                        Response.Write(num);//prints length
                    }
                    else
                    {
                        if (j == 2)
                        {
                            Response.Write("&nbsp;");//prints the space in between
                        }
                        else
                        {
                            Response.Write(num);//prints the width
                        }
                    }
                }
                Response.Write("<br>");//for next line
            }
        }catch(Exception ex)
        {

        }
    }


    //5) program to check two given integers and return true if one is negative and one is positive.
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        try
        {
            // Get user input from textboxes
            int num1 = Convert.ToInt16(txtCheckNum1.Text);
            int num2 = Convert.ToInt16(txtCheckNum2.Text);

            // Display the result in label
            if ((num1<0 && num2>0) || (num1>0 && num2 < 0))
            {
                lblCheck.Text = "True";
            }
            else
            {
                lblCheck.Text = "False";
            }
        }
        catch(Exception ex)
        {

        }
    }

    //program to compute the sum of two given integers, if two values are equal then it returns the triple of their sum.
    protected void btnSum_Click(object sender, EventArgs e)
    {
        try
        {
            // Get user input from textboxes
            int num1 = Convert.ToInt16(txtSumNum1.Text);
            int num2 = Convert.ToInt16(txtSumNum2.Text);

            if (num1 == num2)
            {
                lblSum.Text = Convert.ToString(AS1.Add(num1,num2) * 3);
            }
            else
            {
                //display the reselt in label
                lblSum.Text = Convert.ToString(AS1.Add(num1, num2));
            }
        }catch (Exception ex)
        {

        }
    }

    //program to check the sum of the two given integers and return true if one of the integer is 20 or if their sum is 20.
    protected void btnSum2_Click(object sender, EventArgs e)
    {
        try
        {
            // Get user input from textboxes
            int num1 = Convert.ToInt16(txtSum2Num1.Text);
            int num2 = Convert.ToInt16(txtSum2Num2.Text);

            lblSum2.Text = AS1.TwentyCheck(num1, num2) ? "true " + Convert.ToString(AS1.Add(num1, num2)) : Convert.ToString(AS1.Add(num1, num2));

        }
        catch (Exception ex) { }


    }

    //program to reverse the words of a sentence.
    protected void btnReverseSentence_Click(object sender, EventArgs e)
    {
        try
        {
            // Get user input from textboxes
            string str = txtSentence.Text;
            string reverse = "";
            string word = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    word += str[i];
                }
                else
                {
                    reverse = word + " " + reverse;
                    word = "";
                }
            }

            reverse = word + " " + reverse;

            lblReverseSentence.Text = reverse;
        }catch(Exception ex)
        {

        }
    }
    //program to display n terms of natural number and their sum
    protected void btnDisplay_Click(object sender, EventArgs e)
    {
        try
        {
            // Get user input from textboxes
            int nNum = Convert.ToInt16(txtNNaturalNum.Text);
            string res = "";
            int total = 0;
            for (int i = 1; i <= nNum; i++)
            {
                res += "" + i + ", ";
                total += i;
            }

            res += "Total :" + total;
            lblDisplay.Text = res;
        }
        catch(Exception ex)
        {

        }
    }

    //program to find the sum of first 10 natural numbers.
    protected void btnDisplaySum_Click(object sender, EventArgs e)
    {
        int total = 0;
        for(int i = 1; i <= 10; i++)
        {
            total += i;
        }
        lblDisplaySum.Text = "Sum of first 10 natural numbers : " + total;
    }

    // read 10 numbers from keyboard and find their sum and average
    protected void btnCalculateAvgOf10Num_Click(object sender, EventArgs e)
    {
        try
        {
            // Get user input from textboxes
            string nums = txtAvgOf10.Text + " ";
            string number = "";
            int total = 0;
            int numCount = 0;
            foreach (char c in nums)
            {
                if (c != ' ')
                {
                    number += c;
                }
                else
                {
                    if (number != "")
                    {
                        total += Convert.ToInt32(number);
                        numCount++;
                        number = "";
                    }


                }
            }
            lblAvgOf10.Text = numCount == 10 ? "avg of 10 nums : " + total / 10 : " enter only 10 numbers";
        }catch(Exception ex)
        {

        }

    }


    //code to print the the cube of numbers till given number
    protected void btnCalcCube_Click(object sender, EventArgs e)
    {
        try
        {
            // Get user input from textboxes
            int num = Convert.ToInt16(txtCubeCalc.Text);
            string final = "";
            for (int i = 1; i <= num; i++)
            {
                final += " cube of  " + i + " = " + (i * i * i) + "<br>";
            }
            lblCalccube.Text = final;
        }
        catch (Exception ex)
        {

        }
    }

    //code to check if number is palindrome or not 
    protected void btnCheckPalindrome_Click(object sender, EventArgs e)
    {
        try
        {
            // Get user input from textboxes
            int num = Convert.ToInt16(txtPalindrome.Text);
            int rev = 0;
            int original = num;

            while (num > 0)
            {
                int temp = num % 10;
                rev = rev * 10 + temp;
                num = num / 10;
            }

            lblPalindrom.Text = (rev == original) ? "palindrome" : "not Palindrome";
        }
        catch(Exception ex)
        {

        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        int num1 = Convert.ToInt32(TextBox1.Text);
        int num2 = Convert.ToInt32(TextBox2.Text);

        int a = num1;
        int b = num2;

        // Find HCF
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        int hcf = a;

        Label1.Text = "" + hcf;
    }

    //finds the least common multiple
    protected void btnLcm_Click(object sender, EventArgs e)
    {
        int num1 = Convert.ToInt32(txtLcmN1.Text);
        int num2 = Convert.ToInt32(txtLcmN2.Text);

        int a = num1;
        int b = num2;

        // Find HCF
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        int hcf = a;
        int lcm = (num1 * num2) / hcf;

        lblLCM.Text=("The LCM of " + num1 + " and " + num2 + " is : " + lcm);
    }
}
