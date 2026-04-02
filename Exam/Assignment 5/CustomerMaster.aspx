<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerMaster.aspx.cs" Inherits="CustomerMaster" %>

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
    <h1>Customer Manager</h1>
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
                <td>Customer Id</td>
                <td>
                    <asp:DropDownList ID="CustIdDropDown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CustIdDropDown_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Customer Name :</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Address : </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Mobile No :</td>
                <td>
                    <asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAddCust" runat="server" OnClick="btnAddCust_Click" Text="Add new Customer" />
                </td>
                <td>
                    <asp:Button ID="btnEditcust" runat="server" Enabled="False" OnClick="btnEditcust_Click" Text="Edit Customer" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSaveCust" runat="server" OnClick="btnSaveCust_Click" Text="Save New Customer" />
                </td>
                <td>
                    <asp:Button ID="btnUpdateCust" runat="server" Enabled="False" OnClick="btnUpdateCust_Click" Text="Update Customer" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" Text="Refresh" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
