<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 225px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                    Name :
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td>
                    Position :     
                    <asp:TextBox ID="txtPosition" runat="server"></asp:TextBox>
                </td>
                <td>
                    Salary :
                    <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnPromote" runat="server" OnClick="btnPromote_Click" Text="Promote" />
                </td>
                <td>
                    <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEmpBeforeSal" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAfterSalary" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
