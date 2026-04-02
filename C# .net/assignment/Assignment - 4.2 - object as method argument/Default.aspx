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
    
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create" />
                </td>
                <td>Name : <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td>Roll No : <asp:TextBox ID="txtRollno" runat="server"></asp:TextBox>
                </td>
                <td>Grade : <asp:TextBox ID="txtGrade" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblDisplayName" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDisplayRollNo" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDisplayGrade" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
