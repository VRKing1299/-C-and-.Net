<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BankingApplicationUi.aspx.cs" Inherits="BankingApplicationUi" %>

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
        <table class="auto-style1">
            <tr>
                <td>User1 Name :
                    <asp:TextBox ID="txtNameU1" runat="server"></asp:TextBox>
                </td>
                <td>User1 AccountNo :
                    <asp:TextBox ID="txtAccNoU1" runat="server"></asp:TextBox>
                </td>
                <td>User1 Balance :
                    <asp:TextBox ID="txtBalanceU1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>User2 Name : <asp:TextBox ID="txtNameU2" runat="server"></asp:TextBox>
                </td>
                <td>User2 AccountNo :
                    <asp:TextBox ID="txtAccNoU2" runat="server"></asp:TextBox>
                </td>
                <td>User2 Balance :
                    <asp:TextBox ID="txtBalanceU2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>Transfer amount :
                    <asp:TextBox ID="txtTransferAmount" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnTransferAmount" runat="server" OnClick="btnTransferAmount_Click" Text="Transfer Amount" />
                </td>
                <td>
                    <asp:Label ID="lblremainingBalanceU1" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblremainingBalanceU2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    <div>
    
    </div>
    </form>
</body>
</html>
