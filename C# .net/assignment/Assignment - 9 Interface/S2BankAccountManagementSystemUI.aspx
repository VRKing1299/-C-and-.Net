<%@ Page Language="C#" AutoEventWireup="true" CodeFile="S2BankAccountManagementSystemUI.aspx.cs" Inherits="S2BankAccountManagementSystemUI" %>

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
                <td colspan="2">
                    <asp:Label ID="lblCurrentAccount" runat="server"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label ID="lblSavingAccount" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <th colspan="2">Current Account </th>
                <th colspan="2">Saving Account</th>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSavingDeposit" runat="server" OnClick="btnSavingDeposit_Click" Text="Deposit" />
                </td>
                <td>
                    <asp:TextBox ID="txtDepositSaving" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnCurrentDeposit" runat="server" Text="Deposit" OnClick="btnCurrentDeposit_Click" />
                </td>
                <td>
                    <asp:TextBox ID="txtDepositCurrent" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSavingWidraw" runat="server" Text="Widraw" OnClick="btnSavingWidraw_Click" />
                </td>
                <td>
                    <asp:TextBox ID="txtWidrawSaving" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnCurrentWidraw" runat="server" Text="Widraw" OnClick="btnCurrentWidraw_Click" />
                </td>
                <td>
                    <asp:TextBox ID="txtWidrawCurrent" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSavingCheckBalance" runat="server" Text="Check Balance" OnClick="btnSavingCheckBalance_Click" />
                </td>
                <td>
                    <asp:Label ID="lblSavingCheckBalance" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnCurrentCheckBalance0" runat="server" Height="26px" Text="Check Balance" Width="132px" OnClick="btnCurrentCheckBalance0_Click" />
                </td>
                <td>
                    <asp:Label ID="lblCurrentCheckBalance" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblResultSaving" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblResultCurrent" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
