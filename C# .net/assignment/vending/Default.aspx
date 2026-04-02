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

        <br /><br />

        <table border="1">
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
                <td colspan="2">
                    <asp:Button ID="btnBuy" runat="server" Text="Buy Product" OnClick="btnBuy_Click" />
                </td>
            </tr>
        </table>

        <br />

        <asp:Label ID="lblResult" runat="server"></asp:Label>

    </div>
</form>
</body>
</html>
