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
            height: 26px;
        }
        .auto-style3 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>EmpID : </td>
                <td>
                    <asp:TextBox ID="txtEmpId" runat="server" Enabled="False"></asp:TextBox>
                    <asp:DropDownList ID="EmpIdDropDown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="EmpIdDropDown_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Name : </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;Salary : </td>
                <td>
                    <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">DeptName :</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DeptNameDropDown" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
                </td>
                <td>
                    <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" />
                </td>
                <td>
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="btnSave" runat="server" Enabled="False" OnClick="btnSave_Click" Text="Save" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnUpdate" runat="server" Enabled="False" OnClick="btnUpdate_Click" Text="Update" />
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
