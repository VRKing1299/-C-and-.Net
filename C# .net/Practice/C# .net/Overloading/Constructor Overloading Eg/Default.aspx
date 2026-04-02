<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>Name of pizza :
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td>Quantity of pizza :
                    <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                </td>
                <td>Toppings on the pizza :
                    <asp:TextBox ID="txtToppings" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnOrder" runat="server" OnClick="btnOrder_Click" Text="Place Order" />
                </td>
                <td colspan="2">
                    <asp:Label ID="lblOrder" runat="server" Text="Your order Here"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
