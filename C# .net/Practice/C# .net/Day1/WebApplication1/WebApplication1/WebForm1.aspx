<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            height: 23px;
            width: 322px;
        }
        .auto-style3 {
            width: 322px;
        }
        .auto-style4 {
            height: 23px;
            width: 208px;
        }
        .auto-style5 {
            width: 208px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="Add" runat="server" Text="Add" Width="113px" />
                </td>
                <td class="auto-style5">
                    <asp:Button ID="sub" runat="server" Text="Sub" Width="111px" />
                </td>
                <td>
                    <asp:Button ID="mul" runat="server" Text="Multiply" Width="105px" />
                </td>
            </tr>
        </table>
    <div>
    
    </div>
    </form>
    </body>
</html>
