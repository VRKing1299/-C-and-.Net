<%@ Page Language="C#" AutoEventWireup="true" CodeFile="S1StorePaymentSystem.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        /*.auto-style1 {
            width: 100%;
        }*/
        td,th{
            padding : 5px;
        }
        table{
            border:solid black 1px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <th colspan="3">Payment </th>
            </tr>
            <tr>
                <td colspan="3">Please Insets Amount : <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnUpi" runat="server" Text="UPI Payment" OnClick="btnUpi_Click" />
                </td>
                <td>
                    <asp:Button ID="btnNetBanking" runat="server" Text="Net Banking" OnClick="btnNetBanking_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCreditCard" runat="server" Text="Credit Card Payment" OnClick="btnCreditCard_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblPaymentProcess" runat="server" Text="Payment Process  : "></asp:Label>
                </td>
            </tr>
        </table>
    <div>
    
    </div>
    </form>
</body>
</html>
