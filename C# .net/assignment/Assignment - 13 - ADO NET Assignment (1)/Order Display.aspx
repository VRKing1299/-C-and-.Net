<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order Display.aspx.cs" Inherits="Order_Display" %>

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
    <form id="form1" runat="server">
    <div>
    <h1>View Orders</h1>
        <div class="navDiv">
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Home.aspx">Home</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server" N NavigateUrl="~/CustomerMaster.aspx">Customer Manager</asp:HyperLink>
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/BooksMaster.aspx">Booking Manager</asp:HyperLink>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/BillingMaster.aspx">Billing</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Order Display.aspx" ForeColor="#CC00FF">View Orders</asp:HyperLink>
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Login.aspx">LogOut</asp:HyperLink>
        </div>
        <table class="auto-style1">
            <tr>
                <td>Select Order Id :</td>
                <td><asp:DropDownList ID="OrderIdDropDown" runat="server" OnSelectedIndexChanged="OrderIdDropDown_SelectedIndexChanged" AutoPostBack="True" style="height: 22px">
                </asp:DropDownList></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:GridView ID="gvBooksData" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
