<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillingMaster.aspx.cs" Inherits="BillingMaster" %>

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
    <h1>Billing Master</h1>
        <div class="navDiv">
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Home.aspx">Home</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server" N NavigateUrl="~/CustomerMaster.aspx">Customer Manager</asp:HyperLink>
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/BooksMaster.aspx">Booking Manager</asp:HyperLink>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/BillingMaster.aspx" ForeColor="#9900CC">Billing</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Order Display.aspx">View Orders</asp:HyperLink>
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Login.aspx">LogOut</asp:HyperLink>
        </div>
    <form id="form1" runat="server">
    <div>
        <table class="auto-style1">
        <tr>
            <td>Bill Id : </td>
            <td>
                <asp:TextBox ID="txtBillId" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Customer PhoneNumber :</td>
            <td>
                <asp:DropDownList ID="CustomerPhNoDropDown" runat="server" OnSelectedIndexChanged="CustomerPhNoDropDown_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Book Name :</td>
            <td>
                <asp:DropDownList ID="BookNameDropDown" runat="server" OnSelectedIndexChanged="BookNameDropDown_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>
                Quantity Available :
                <asp:Label ID="lblProdQuantity" runat="server" Text="0"></asp:Label>
&nbsp;</td>
            <td>
                Price :
                <asp:Label ID="lblPrice" runat="server" Text="0"></asp:Label>
&nbsp;</td>
        </tr>
        <tr>
            <td>Purchase Quantity :</td>
            <td>
                <asp:TextBox ID="txtPurchaseQuant" runat="server" AutoPostBack="True" OnTextChanged="txtPurchaseQuant_TextChanged1" ></asp:TextBox>
            </td>
            <td>
                Purchase Quantity : <asp:Label ID="lblPurchaseQuant" runat="server" Text="0"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Total Price :</td>
            <td>
                <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnNewBill" runat="server" Text="New Bill" OnClick="btnNewBill_Click" />
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Enabled="False" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </div>
        <br /> <br />
    <div>
        <asp:GridView ID="gvBooksData" runat="server">
        </asp:GridView>
    </div>
    </form>
    
</body>
</html>
