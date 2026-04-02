using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Code-behind class for Default2.aspx that demonstrates different
/// pattern printing programs using nested loops.
/// Each pattern is generated when the corresponding button is clicked.
/// </summary>
public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Pattern 1: Right angled triangle using '*'
    protected void Button1_Click(object sender, EventArgs e)
    {
        string ans = "";

        for (int i = 1; i <= 4; i++) // rows
        {
            for (int j = 1; j <= i; j++) // print stars equal to row number
            {
                ans += "*";
            }
            ans += "<br>"; // move to next line
        }

        lblPattern1.Text = ans; // display result
    }

    // Pattern 2: Right angled triangle using increasing numbers
    protected void btnPrintPattern2_Click(object sender, EventArgs e)
    {
        string ans = "";

        for (int i = 1; i <= 4; i++) // rows
        {
            for (int j = 1; j <= i; j++) // print numbers from 1 to row number
            {
                ans += j;
            }
            ans += "<br>";
        }

        lblPattern2.Text = ans;
    }

    // Pattern 3: Right triangle with repeating row number
    protected void btnPrintPattern3_Click(object sender, EventArgs e)
    {
        string ans = "";

        for (int i = 1; i <= 4; i++) // rows
        {
            for (int j = 1; j <= i; j++) // repeat row number
            {
                ans += i;
            }
            ans += "<br>";
        }

        lblPattern3.Text = ans;
    }

    // Pattern 4: Right triangle with sequential numbers
    protected void btnPrintPattern4_Click(object sender, EventArgs e)
    {
        string ans = "";
        int count = 1; // number counter

        for (int i = 1; i <= 4; i++) // rows
        {
            for (int j = 1; j <= i; j++)
            {
                ans += count++; // increase number after printing
            }
            ans += "<br>";
        }

        lblPattern4.Text = ans;
    }

    // Pattern 5: Pyramid with increasing numbers
    protected void btnPiramid_Click(object sender, EventArgs e)
    {
        string ans = "";
        int count = 1;
        int rows = 4;

        for (int i = 1; i <= rows; i++)
        {
            // print spaces before numbers
            for (int j = rows / 2; j >= i; j--)
            {
                ans += "&nbsp;";
            }

            // print numbers
            for (int k = 1; k <= i; k++)
            {
                ans += count++;
            }

            ans += "<br>";
        }

        lblPiramid.Text = ans;
    }

    // Pattern 6: Equilibrium (symmetric) number pyramid
    protected void btnPiramidP2_Click(object sender, EventArgs e)
    {
        string ans = "";
        int rows = 4;

        for (int i = 1; i <= rows; i++)
        {
            // print spaces before pyramid
            for (int s = 1; s <= rows - i; s++)
            {
                ans += "&nbsp;&nbsp;";
            }

            // increasing numbers
            for (int n = 1; n <= i; n++)
            {
                ans += n;
            }

            // decreasing numbers
            for (int n = i - 1; n >= 1; n--)
            {
                ans += n;
            }

            ans += "<br>";
        }

        lblPiramid2.Text = ans;
    }

    // Pattern 7: Alphabet pyramid pattern
    protected void btnPrintAlphabetPiramid_Click(object sender, EventArgs e)
    {
        int num = 65; // ASCII value of 'A'
        int add = 1;  // controls extra characters per row
        string str = "";

        for (int i = 1; i <= 4; i++) // rows
        {
            int chars = (i == 1) ? 1 : i + add++; // calculate characters in row

            // print alphabets in increasing order
            for (int j = 0; j < chars / 2; j++)
            {
                str += ((char)(num++));
            }

            --num; // adjust character position

            // print alphabets in reverse order
            for (int k = (chars / 2) - 1; k >= 1; k--)
            {
                str += ((char)(--num));
            }

            num = 65; // reset back to 'A'
            str += "<br>";
        }

        lblAlphabetPiramid.Text = str;
    }
}