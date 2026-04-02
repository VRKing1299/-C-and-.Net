<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            display:flex;
            flex-direction:column;
            align-items :center;
        }
        table{
            margin: 20px;
            border-spacing:20px 10px;
            border:2px solid black;
        }
    </style>
</head>
<body>
    <h1>Home</h1>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Home.aspx">Home</asp:HyperLink> &nbsp; &nbsp; 
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/CustomerMaster.aspx">Customer Manament</asp:HyperLink>&nbsp; &nbsp; 
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/DisplayBills.aspx">Display Bill</asp:HyperLink>&nbsp; &nbsp; 
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/ProductMasterUI.aspx">Product Management</asp:HyperLink>&nbsp; &nbsp; 
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/BillMaster.aspx">Bill Manager</asp:HyperLink>&nbsp; &nbsp; 
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Login.aspx">Log out</asp:HyperLink>&nbsp; &nbsp; 
        </div>
    </div>
    </form>
</body>
</html>
