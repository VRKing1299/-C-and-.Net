<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BooksMaster.aspx.cs" Inherits="BooksMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .navDiv {
        text-align: center;   /* centers the content */
        }

        .navDiv a {
            margin: 0 10px;       /* space between links */
            text-decoration: none;
        }
        body{
            display:flex;
            flex-direction:column;
            align-items: center;
        }
    </style>
</head>
<body>
    <h1>BOOK MASTER</h1>
        <div class="navDiv">
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Home.aspx">Home</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server" N NavigateUrl="~/CustomerMaster.aspx">Customer Manager</asp:HyperLink>
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/BooksMaster.aspx" ForeColor="#CC00FF">Booking Manager</asp:HyperLink>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/BillingMaster.aspx">Billing</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Order Display.aspx">View Orders</asp:HyperLink>
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Login.aspx">LogOut</asp:HyperLink>
        </div>
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
                <asp:Button ID="btnAddQuant" runat="server" OnClick="btnAddQuant_Click" Text="Add Quantity" Visible="False" />
                <asp:TextBox ID="txtQuantity" runat="server" Enabled="False" Visible="False"></asp:TextBox>
                <asp:Button ID="btnSubtractQuant" runat="server" OnClick="btnSubtractQuant_Click" Text="Subtract Quantitiy" Visible="False" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            </td>
            <td>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" Enabled="False" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Enabled="False" Text="Save" OnClick="btnSave_Click" />
            </td>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Enabled="False" Text="Update" OnClick="btnUpdate_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
            </td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" Enabled="False" OnClick="btnDelete_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </div>
        <br /> <br />
    <div>
    </div>
    </form>
    
</body>
</html>
