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
    
        <asp:Label ID="lblProducts" runat="server"></asp:Label>
        <table class="auto-style1">
            <tr>
                <td>Enter Product Sr No:</td>
                <td>
                    <asp:TextBox ID="txtSrNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Enter Quantity:</td>
                <td>
                    <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCalcPrice" runat="server" Text="Calculate PRice" OnClick="btnCalcPrice_Click" />
                </td>
                <td>
                    <asp:Button ID="btnBuy" runat="server" OnClick="btnBuy_Click" Text="Buy" Visible="False" />
                </td>
            </tr>
        </table>
    
    </div>
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    </form>
</body>
</html>
