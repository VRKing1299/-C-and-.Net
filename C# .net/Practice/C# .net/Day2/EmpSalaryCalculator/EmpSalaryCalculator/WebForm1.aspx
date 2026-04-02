<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EmpSalaryCalculator.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="LblId" runat="server" Text="id"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbId" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEname" runat="server" Text="ename"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbEname" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblBSal" runat="server" Text="Basic Salary"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbBsal" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblHRA" runat="server" Text="HRA"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbHra" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblDA" runat="server" Text="DA"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbDF" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="LblPf" runat="server" Text="PF"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="tbPf" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="button" runat="server" OnClick="button_Click" Text="submit" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>empId</td>
                <td>
                    <asp:Label ID="empId" runat="server" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Employee sal</td>
                <td>
                    <asp:Label ID="empName" runat="server" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Net Salary</td>
                <td>
                    <asp:Label ID="empSal" runat="server" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
        <p>
            <asp:Label ID="errorMsg" runat="server" Visible="False"></asp:Label>
        </p>
    </form>
</body>
</html>
