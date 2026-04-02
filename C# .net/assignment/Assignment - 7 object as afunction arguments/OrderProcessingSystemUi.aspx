<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderProcessingSystemUi.aspx.cs" Inherits="OrderProcessingSystemUi" %>

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
                <td>order Id :
                    <asp:TextBox ID="txtOrderId" runat="server"></asp:TextBox>
                </td>
                <td>order Amount :
                    <asp:TextBox ID="txtOrderAmount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Check Discount" />
                </td>
                <td>
                    <asp:Label ID="lblDiscountMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
