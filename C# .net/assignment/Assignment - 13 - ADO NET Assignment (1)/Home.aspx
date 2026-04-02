<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .navDiv {
        text-align: center;   /* centers the content */
        }

        .navDiv a {
            font-size:20px;
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
    <form id="form1" runat="server">
    <div>
    <h1>Home</h1>
        <div class="navDiv">
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Home.aspx" ForeColor="#CC00FF">Home</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server" N NavigateUrl="~/CustomerMaster.aspx">Customer Manager</asp:HyperLink>
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/BooksMaster.aspx">Booking Manager</asp:HyperLink>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/BillingMaster.aspx">Billing</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Order Display.aspx">View Orders</asp:HyperLink>
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Login.aspx">LogOut</asp:HyperLink>
        </div>
    </div>
    </form>
</body>
</html>
