<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmiCalcForm.aspx.cs" Inherits="EmiCalcForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    /*body {
        font-family: Arial, Helvetica, sans-serif;
        background-color: antiquewhite;
        margin: 0;
        padding: 20px;
    }

    table {
        width: 100%;
        border-collapse: collapse;
        background-color: white;
    }

    td, th {
        border: 1px solid black;
        padding: 10px;
        text-align: left;
        background-color: lightgrey;
    }

    input[type="text"] {
        width: 90%;
        padding: 5px;
        border: 1px solid black;
    }

    input[type="submit"] {
        padding: 8px 12px;
        background-color: green;
        color: white;
        border: none;
        cursor: pointer;
        border-radius:10px;
    }

    input[type="submit"]:hover {
        background-color: darkgreen;
    }

    label {
        font-weight: bold;
        color: blue;
    }

    #lblEmi {
        color: red;
    }*/
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>Principal Amount : <asp:TextBox ID="txtPrinciapAmount" runat="server"></asp:TextBox>
                </td>
                <td>Interest Rate :
                    <asp:TextBox ID="txtPrincipalRate" runat="server"></asp:TextBox>
                </td>
                <td>Borrow Period in Month :
                    <asp:TextBox ID="txtBorrowTime" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnCaculateEmi" runat="server" OnClick="btnCaculateEmi_Click" Text="Calculate Emi" />
                </td>
                <td>
                    <asp:Label ID="lblEmi" runat="server">Your emi will be displayed here</asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
