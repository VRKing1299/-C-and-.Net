<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{
            display:flex;
            flex-direction:column;
            align-items:center;
        }

        table{
            margin-top:20px;
            border:1px solid #444;
            border-collapse:collapse;
            padding:10px;
        }

        td{
            padding:8px;
        }

        input{
            padding:5px;
        }

        button{
            border-radius:5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Login</h1>
        <table class="auto-style1">
            <tr>
                <td>User Name : </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password :</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
