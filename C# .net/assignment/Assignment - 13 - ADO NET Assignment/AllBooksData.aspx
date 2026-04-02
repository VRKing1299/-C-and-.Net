<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllBooksData.aspx.cs" Inherits="AllBooksData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        /*.auto-style1 {
            width: 100%;
        }*/
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="auto-style1">
        <tr>
            <td>Book Id : </td>
            <td>
                <asp:TextBox ID="txtBookId" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                <asp:DropDownList ID="BookIdDropDown" runat="server" OnSelectedIndexChanged="BookIdDropDown_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Book Name :</td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Book Price : </td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Available Quantity : </td>
            <td>
                <asp:Label ID="lblAvailabelQuant" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtQuantity" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Add" />
            </td>
            <td>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="BtnSave" runat="server" Enabled="False" Text="Save" />
            </td>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Enabled="False" Text="Update" OnClick="btnUpdate_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnReset" runat="server" Text="Reset" />
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </div>
        <br /> <br />
    <div>
        <asp:GridView ID="gvBooksData" runat="server"></asp:GridView>
    </div>
        <asp:Button ID="btnGetAllBooksData" runat="server" OnClick="btnGetAllBooksData_Click" Text="Display All Books" />
    </form>
    
</body>
</html>
