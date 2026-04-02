<%@ Page Language="C#" AutoEventWireup="true" CodeFile="S1BusinessUi.aspx.cs" Inherits="S1BusinessUi" %>

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
                <th>Permanant Employee details </th>
                <th>Temparary Employee details</th>
            </tr>
            <tr>
                <td>Emp Id : <asp:TextBox ID="txtPid" runat="server"></asp:TextBox>
                </td>
                <td>Emp Id :
                    <asp:TextBox ID="txtCid" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Emp Name :
                    <asp:TextBox ID="txtPname" runat="server"></asp:TextBox>
                </td>
                <td>Emp Name :<asp:TextBox ID="txtCname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Emp Salary :
                    <asp:TextBox ID="txtPsal" runat="server"></asp:TextBox>
                </td>
                <td>Emp Salary :
                    <asp:TextBox ID="txtCsal" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCalcPsal" runat="server" OnClick="btnCalcPsal_Click" Text="Calculate Sal" />
                </td>
                <td>
                    <asp:Button ID="btnCalcCsal" runat="server" OnClick="btnCalcCsal_Click" Text="Calculate Sal" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPFinalSal" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCFinalsal" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
