<%@ Page Language="C#" AutoEventWireup="true" CodeFile="S5HospitalManagementSystemUI.aspx.cs" Inherits="S5HospitalManagementSystemUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <table border="1" style="width:100%;">

        <tr>
            <th colspan="2">General Physician</th>
            <th colspan="2">Surgeon</th>
            <th colspan="2">Visiting Doctor</th>
        </tr>

        <tr>
            <td>
                Doctor Id:</td>

            <td>
                <asp:TextBox ID="txtGPId" runat="server"></asp:TextBox>
            </td>

            <td>
                Doctor Id:
                </td>

            <td>
                <asp:TextBox ID="txtSId" runat="server"></asp:TextBox>
            </td>

            <td>
                Doctor Id:</td>
            <td>
                <asp:TextBox ID="txtVId" runat="server" OnTextChanged="txtVId_TextChanged"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                Name:</td>

            <td>
                <asp:TextBox ID="txtGPName" runat="server"></asp:TextBox>
            </td>

            <td>
                Name:</td>

            <td>
                <asp:TextBox ID="txtSName" runat="server"></asp:TextBox>
            </td>

            <td>
                Name:</td>
            <td>
                <asp:TextBox ID="txtVName" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td rowspan="2">
                Consultation Fee:</td>

            <td rowspan="2">
                <asp:TextBox ID="txtGPFee" runat="server"></asp:TextBox>
            </td>

            <td rowspan="2">
                Consultation Fee:</td>

            <td rowspan="2">
                <asp:TextBox ID="txtSFee" runat="server"></asp:TextBox>
            </td>

            <td>
                Consultation Fee:</td>
            <td>
                <asp:TextBox ID="txtVFee" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                Travel Allowance:</td>
            <td>
                <asp:TextBox ID="txtTravel" runat="server" OnTextChanged="txtTravel_TextChanged"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Button ID="btnGP" runat="server"
                    Text="Calculate"
                    OnClick="btnGP_Click" />
            </td>

            <td>
                <asp:Label ID="lblGPResult" runat="server"></asp:Label>
            </td>

            <td>
                <asp:Button ID="btnSurgeon" runat="server"
                    Text="Calculate"
                    OnClick="btnSurgeon_Click" />
            </td>

            <td>
                <asp:Label ID="lblSResult" runat="server"></asp:Label>
            </td>

            <td>
                <asp:Button ID="btnVisiting" runat="server"
                    Text="Calculate"
                    OnClick="btnVisiting_Click" />
            </td>
            <td>
                <asp:Label ID="lblVResult" runat="server"></asp:Label>
            </td>
        </tr>

    </table>

</form>
</body>
</html>
