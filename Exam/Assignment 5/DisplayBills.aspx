<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisplayBills.aspx.cs" Inherits="DisplayBills" %>

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
    <h1>Display Bills</h1>
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
                    <asp:DropDownList ID="ProcudctIdDropDown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ProcudctIdDropDown_SelectedIndexChanged" style="height: 22px">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    
    </div>
        <asp:GridView ID="gvDisplayBill" runat="server" Visible="False">
        </asp:GridView>
    </form>
</body>
</html>
