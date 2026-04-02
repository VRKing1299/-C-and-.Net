<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserCreateAccountUi.aspx.cs" Inherits="UserCreateAccountUi" %>

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
                <td>User Name :
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
                <td>Phone No :
                    <asp:TextBox ID="txtPhno" runat="server"></asp:TextBox>
                </td>
                <td>Password :
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCreateAccount" runat="server" OnClick="btnCreateAccount_Click" Text="Create Account" />
                </td>
                <td>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <div>
    
    </div>
    </form>
</body>
</html>
