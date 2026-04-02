<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolManagementSystemUi.aspx.cs" Inherits="SchoolManagementSystemUi" %>

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
                <td>Name of Student :
                    <asp:TextBox ID="txtStudName" runat="server"></asp:TextBox>
                </td>
                <td>Roll No of Student :
                    <asp:TextBox ID="txtStudRollNo" runat="server"></asp:TextBox>
                </td>
                <td>Marks of Student :
                    <asp:TextBox ID="txtStudMarks" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCalcGrade" runat="server" OnClick="btnCalcGrade_Click" Text="Calculate Grade" />
                </td>
                <td>
                    <asp:Label ID="lblGrade" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
