<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HRSystemForm.aspx.cs" Inherits="HRSystemForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        table,td,th{
            border: 1px solid;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Button ID="btnCreateEmp" runat="server" OnClick="btnCreateEmp_Click" Text="Create Employe" />
                </td>
                <td>Emp Id :
                    <asp:TextBox ID="txtEmpId" runat="server"></asp:TextBox>
                </td>
                <td>Emp Name :
                    <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblEmpCount" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
