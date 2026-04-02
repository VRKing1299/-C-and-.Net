<%@ Page Language="C#" AutoEventWireup="true" CodeFile="S7SubscriptionBasedOTTPlatformUI.aspx.cs" Inherits="S7SubscriptionBasedOTTPlatformUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <table border="1" style="width:100%;">

        <tr>
            <th colspan="2">Basic Plan</th>
        </tr>

        <tr>
            <td>User Name</td>
            <td><asp:TextBox ID="txtBUser" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Duration (Months)</td>
            <td><asp:TextBox ID="txtBDuration" runat="server" ></asp:TextBox></td>
        </tr>

        <tr>
            <td>Base Price</td>
            <td><asp:TextBox ID="txtBPrice" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>
                <asp:Button ID="btnBasic" runat="server"
                    Text="Basic Plan"
                    OnClick="btnBasic_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Button ID="btnPremium" runat="server"
                    Text="Premium Plan"
                    OnClick="btnPremium_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:Button ID="btnFamily" runat="server"
                    Text="Family Plan"
                    OnClick="btnFamily_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td colspan="2"><asp:Label ID="lblBasic" runat="server"></asp:Label></td>
        </tr>

    </table>

</form>
</body>
</html>
