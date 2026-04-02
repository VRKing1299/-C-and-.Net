<%@ Page Language="C#" AutoEventWireup="true" CodeFile="S3EmployeeSalaryCalculatorUI.aspx.cs" Inherits="S3EmployeeSalaryCalculatorUI" %>

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
                <td>Enter employee Name : </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Enter employee Salary : </td>
                <td>
                    <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCalculateBonus" runat="server" OnClick="btnCalculateBonus_Click" Text="Calculate Bonus" />
                </td>
                <td>
                    <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    <div>
    
    </div>
    </form>
</body>
</html>
