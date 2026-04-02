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
                <td>id :
                    <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                </td>
                <td>Name :
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td>Base Salary :
                    <asp:TextBox ID="txtBaseSalary" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCalcNetSal" runat="server" OnClick="btnCalcNetSal_Click" Text="Calculate Net Salary" />
                </td>
                <td>
                    <asp:Label ID="lblFinalSal" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
