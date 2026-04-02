<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 30px;
        }
        .auto-style3 {
            width: 177px;
        }
        .auto-style4 {
            width: 256px;
        }
        .auto-style6 {
            width: 89px;
        }
        .auto-style7 {
            width: 229px;
        }
        .auto-style8 {
            width: 441px;
        }
        
        .auto-style9 {
            width: 441px;
            height: 44px;
        }
        .auto-style10 {
            height: 44px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1" border="1">
            <tr>
                <td>
                    <asp:Label ID="lble1" runat="server" Text="-1 + 4 * 6"></asp:Label>
                </td>
                <td rowspan="4">
                    <asp:Button ID="btnCalculate" runat="server" Text="calculate" OnClick="btnCalculate_Click" style="height: 26px" />
                </td>
                <td>
                    <asp:Label ID="lblAns1" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lble2" runat="server" Text="( 35+ 5 ) % 7"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:Label ID="lblAns2" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lble3" runat="server" Text="14 + -4 * 6 / 11"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAns3" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lble4" runat="server" Text="2 + 15 / 6 * 1 - 7 % 2"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAns4" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
    
    </div>

            <tr>
                <td class="auto-style3">Write a C# Sharp program to swap two numbers.</td>
                <td class="auto-style6">
                    <asp:Button ID="btnSwap" runat="server" OnClick="btnSwap_Click" Text="Swap" />
                </td>
                <td class="auto-style7">A :
                    <asp:TextBox ID="txtNumA" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="auto-style4">B :
                    <asp:TextBox ID="txtNumB" runat="server" Width="144px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblSwapResult" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Button ID="btnCalcAvg" runat="server" OnClick="btnCalcAvg_Click" Text="Calculate AVG of 4 Number" />
                </td>
                <td>
                    num 1 :
                    <asp:TextBox ID="txtNum1" runat="server"></asp:TextBox>
                </td>
                <td>
                    Num 2 :
                    <asp:TextBox ID="txtNum2" runat="server"></asp:TextBox>
                </td>
                <td>
                    Num 3 :
                    <asp:TextBox ID="txtNum3" runat="server"></asp:TextBox>
                </td>
                <td>
                    Num 4 :
                    <asp:TextBox ID="txtNum4" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblAvg" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Button ID="btnPTR" runat="server" OnClick="btnPTR_Click" Text="Print the rectangle" />
                </td>
                <td>
                    Enter a number :
                    <asp:TextBox ID="lblRectangleInput" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>program to check two given integers and return true if one is negative and one is positive.</td>
                <td>
                    <asp:Button ID="btnCheck" runat="server" OnClick="btnCheck_Click" Text="Check" />
                </td>
                <td>
                    <asp:TextBox ID="txtCheckNum1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtCheckNum2" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblCheck" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>program to compute the sum of two given integers, if two values are equal then return the triple of their sum.</td>
                <td>
                    <asp:Button ID="btnSum" runat="server" OnClick="btnSum_Click" Text="Sum" />
                </td>
                <td>
                    <asp:TextBox ID="txtSumNum1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtSumNum2" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblSum" runat="server"></asp:Label>
                </td>
            </tr>


        <tr>
            <td class="auto-style8">program to check the sum of the two given integers and return true if one of the integer is 20 or if their sum is 20.</td>
            <td>
                <asp:Button ID="btnSum2" runat="server" OnClick="btnSum2_Click" Text="Sum" />
            </td>
            <td>
                <asp:TextBox ID="txtSum2Num1" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtSum2Num2" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblSum2" runat="server"></asp:Label>
            </td>
        </tr>


        <tr>
            <td class="auto-style8">program to reverse the words of a sentence.</td>
            <td>
                <asp:Button ID="btnReverseSentence" runat="server" OnClick="btnReverseSentence_Click" Text="Reverse Sentence" />
            </td>
            <td>
                <asp:TextBox ID="txtSentence" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblReverseSentence" runat="server"></asp:Label>
            </td>
        </tr>


        <tr>
            <td class="auto-style8">&nbsp;to display n terms of natural number and their sum</td>
            <td>
                <asp:Button ID="btnDisplay" runat="server" OnClick="btnDisplay_Click" Text="display" />
            </td>
            <td>
                <asp:TextBox ID="txtNNaturalNum" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblDisplay" runat="server"></asp:Label>
            </td>
        </tr>


        <tr>
            <td class="auto-style8">program to find the sum of first 10 natural numbers.</td>
            <td>
                <asp:Button ID="btnDisplaySum" runat="server" OnClick="btnDisplaySum_Click" Text="Display Sum" />
            </td>
            <td>
                <asp:Label ID="lblDisplaySum" runat="server"></asp:Label>
            </td>
        </tr>


        <tr>
            <td class="auto-style9">Sharp to read 10 numbers from keyboard and find their sum and average</td>
            <td class="auto-style10">
                <asp:Button ID="btnCalculateAvgOf10Num" runat="server" OnClick="btnCalculateAvgOf10Num_Click" Text="Calculate Avg of 10 num" />
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="txtAvgOf10" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style10">
                <asp:Label ID="lblAvgOf10" runat="server"></asp:Label>
            </td>
        </tr>


        <tr>
            <td class="auto-style9">display the cube of the number up to given an integer.</td>
            <td class="auto-style10">
                <asp:Button ID="btnCalcCube" runat="server" OnClick="btnCalcCube_Click" Text="Calculate cube" />
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="txtCubeCalc" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style10">
                <asp:Label ID="lblCalccube" runat="server"></asp:Label>
            </td>
        </tr>


        <tr>
            <td class="auto-style9">program to check whether a number is a palindrome or not.</td>
            <td class="auto-style10">
                <asp:Button ID="btnCheckPalindrome" runat="server" OnClick="btnCheckPalindrome_Click" Text="Check Palindrome Number" />
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="txtPalindrome" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style10">
                <asp:Label ID="lblPalindrom" runat="server"></asp:Label>
            </td>
        </tr>


        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style10">
                <asp:Button ID="Button1" runat="server" Text="Highest Common Factor" OnClick="Button1_Click" />
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>


        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style10">
                <asp:Button ID="btnLcm" runat="server" Text="Least common multiple" OnClick="btnLcm_Click" />
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="txtLcmN1" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="txtLcmN2" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblLCM" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    
    </form>
        
</body>
</html>
