<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductMasterUI.aspx.cs" Inherits="ProductMasterUI" %>

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
    <h1>Product Management</h1>
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Home.aspx">Home</asp:HyperLink> &nbsp; &nbsp; 
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/CustomerMaster.aspx">Customer Manament</asp:HyperLink>&nbsp; &nbsp; 
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/DisplayBills.aspx">Display Bill</asp:HyperLink>&nbsp; &nbsp; 
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/ProductMasterUI.aspx">Product Management</asp:HyperLink>&nbsp; &nbsp; 
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/BillMaster.aspx">Bill Manager</asp:HyperLink>&nbsp; &nbsp; 
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Login.aspx">Log out</asp:HyperLink>&nbsp; &nbsp; 
        </div>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>Select Product Id :</td>
                <td>
                    <asp:DropDownList ID="ProductIdDropDown" runat="server" OnSelectedIndexChanged="ProductIdDropDown_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Product Name :</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Price :</td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Quantity</td>
                <td>
                    <asp:TextBox ID="txtQuant" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" Visible="False" />
                    <asp:TextBox ID="txtUpdateQuantity" runat="server" Visible="False"></asp:TextBox>
                    <asp:Button ID="btnSub" runat="server" OnClick="btnSub_Click" Text="Sub" Visible="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAddNewProduct" runat="server" Text="Add New Procuct" OnClick="btnAddNewProduct_Click" />
                </td>
                <td>
                    <asp:Button ID="btnEdit" runat="server" Enabled="False" Text="Edit" OnClick="btnEdit_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Enabled="False" />
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
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" style="height: 26px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
