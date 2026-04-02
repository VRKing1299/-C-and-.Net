<%@ Page Language="C#" AutoEventWireup="true" CodeFile="S1EcommerceWebsiteUI.aspx.cs" Inherits="S1EcommerceWebsiteUI" %>

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
                <td>Enter Payment amount&nbsp; :</td>
                <td colspan="2">
                    <asp:TextBox ID="txtamount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnBuyUPI" runat="server" OnClick="btnBuyUPI_Click" Text="UPI Payment" />
                </td>
                <td>
                    <asp:Button ID="btnCreditCardPayment" runat="server" Text="CreditCardPayment" OnClick="btnCreditCardPayment_Click" />
                </td>
                <td>
                    <asp:Button ID="btnNetBanking" runat="server" Text="Net Banking" OnClick="btnNetBanking_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
