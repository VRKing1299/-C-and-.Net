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
            width: 238px;
        }
        .auto-style3 {
            width: 236px;
        }
        .auto-style4 {
            width: 303px;
        }
        .auto-style5 {
            width: 299px;
        }
        .auto-style6 {
            width: 304px;
        }
        .auto-style7 {
            width: 235px;
        }
        .auto-style8 {
            width: 306px;
        }
        .auto-style9 {
            width: 233px;
        }
        .auto-style10 {
            width: 309px;
        }
        .auto-style11 {
            width: 237px;
        }
        .auto-style12 {
            width: 310px;
        }
        .auto-style13 {
            width: 231px;
        }
        .auto-style14 {
            width: 315px;
        }
        table{
            border:1px solid;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Write a program in C# Sharp to read n number of values in an array and display it in reverse order.</td>
                <td class="auto-style5">
                    <asp:Button ID="btnC1" runat="server" OnClick="btnC1_Click" Text="Calculate" />
                </td>
                <td>
                    <asp:Label ID="lblA1" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Write a program in C# Sharp to find the sum of all elements of the array</td>
                <td class="auto-style4">
                    <asp:Button ID="btnC2" runat="server" OnClick="btnC2_Click" Text="Calculate" />
                </td>
                <td>
                    <asp:Label ID="lblA2" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Write a program in C# Sharp to copy the elements one array into another array.</td>
                <td class="auto-style6">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Calculate" />
                </td>
                <td>
                    <asp:Label ID="lblA3" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style7">Write a program in C# Sharp to count a total number of duplicate elements in an array</td>
                <td class="auto-style8">
                    <asp:Button ID="btnc4" runat="server" OnClick="btnc4_Click" Text="calculate" />
                </td>
                <td>
                    <asp:Label ID="lblA4" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style9">Write a program in C# Sharp to merge two arrays of same size sorted in ascending order.</td>
                <td class="auto-style10">
                    <asp:Button ID="btnC5" runat="server" OnClick="btnC5_Click" Text="Calculate" />
                </td>
                <td>
                    <asp:Label ID="lblA5" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style11">Write a program in C# Sharp to count the frequency of each element of an array.</td>
                <td class="auto-style6">
                    <asp:Button ID="btnC6" runat="server" OnClick="btnC6_Click" Text="Calculate" />
                </td>
                <td>
                    <asp:Label ID="lblA6" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style11">Write a program in C# Sharp to find maximum and minimum element in an array.</td>
                <td class="auto-style6">
                    <asp:Button ID="btnC7" runat="server" OnClick="btnC7_Click" Text="Calculate" />
                </td>
                <td>
                    <asp:Label ID="lblA7" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style9">Write a program in C# Sharp to separate odd and even integers in separate arrays.</td>
                <td class="auto-style12">
                    <asp:Button ID="btnA8" runat="server" OnClick="btnA8_Click" Text="Calculate" />
                </td>
                <td>
                    <asp:Label ID="lblA8" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style13">Write a program in C# Sharp to sort elements of the array in descending order.</td>
                <td class="auto-style14">
                    <asp:Button ID="btnCalcDescArray" runat="server" OnClick="btnCalcDescArray_Click" Text="Calculate" />
                </td>
                <td>
                    <asp:Label ID="lblA9" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style13">Write a program in C# Sharp to find the second smallest element in an array.</td>
                <td class="auto-style14">
                    <asp:Button ID="btnSecondSmallest" runat="server" OnClick="btnSecondSmallest_Click" Text="Calculate" />
                </td>
                <td>
                    <asp:Label ID="lblA10" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
