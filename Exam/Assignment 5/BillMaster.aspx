<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillMaster.aspx.cs" Inherits="BillMaster" %>

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
    <h1>Billing Manager</h1>
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
                <td>Customer Number :</td>
                <td>
                    <asp:DropDownList ID="CustNumberDropDown" runat="server" OnSelectedIndexChanged="CustNumberDropDown_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Product Name : </td>
                <td>
                    <asp:DropDownList ID="ProductNameDropDown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ProductNameDropDown_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>Available Quantity :
                    <asp:Label ID="lblAvailableQuantity" runat="server" Text="0"></asp:Label>
                </td>
                <td>Price :
                    <asp:Label ID="lblPrice" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Enter the Buy Quantity :</td>
                <td>
                    <asp:TextBox ID="txtBuyQuantity" runat="server" AutoPostBack="True" OnTextChanged="txtBuyQuantity_TextChanged"></asp:TextBox>
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Taotal Bill : </td>
                <td>
                    <asp:Label ID="lblTotalBill" runat="server" Text="0"></asp:Label>
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Button" />
                </td>
                <td>
                    <asp:Button ID="btnBuy" runat="server" Text="Buy" Enabled="False" OnClick="btnBuy_Click" />
                </td>
                <td></td>
                <td></td>
            </tr>
            </table>
        
    </div>
        <asp:GridView ID="gvCurrentBill" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
