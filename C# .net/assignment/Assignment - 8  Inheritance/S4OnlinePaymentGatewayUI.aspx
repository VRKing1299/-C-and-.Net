<%@ Page Language="C#" AutoEventWireup="true" CodeFile="S4OnlinePaymentGatewayUI.aspx.cs" Inherits="S4OnlinePaymentGatewayUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        /*.auto-style1 {
            width: 836px;
        }
        .auto-style3 {
            width: 278px;
        }*/
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Transaction Id : </td>
                <td colspan="2">
                    <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Amount : </td>
                <td colspan="2">
                    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Payment Date : </td>
                <td colspan="2">
                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="btnPayCreditCard" runat="server" Text="Credit Card" OnClick="btnPayCreditCard_Click" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnPayNetBanking" runat="server" Text="Net Banking" OnClick="btnPayNetBanking_Click" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnPayUPI" runat="server" Text="UPI Payment" OnClick="btnPayUPI_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
