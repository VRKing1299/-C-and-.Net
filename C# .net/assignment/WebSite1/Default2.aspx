<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style6 {
            width: 205px;
        }
        .auto-style7 {
            width: 218px;
        }
        .auto-style8 {
            width: 168px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style8">
                    <asp:Button ID="BtnCalcPrice" runat="server" OnClick="btnCalcPrice_Click" Text="Calculate Price" />
                </td>
                <td class="auto-style7">SRNO : <asp:TextBox ID="txtSrno" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style6">Quantity :
                    <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    <br />
    <table class="auto-style1">
        <tr>
            <td>
                <asp:Button ID="btnBuy" runat="server" OnClick="btnBuy_Click" Text="Buy" Visible="False" />
            </td>
            <td>
                <asp:Label ID="lblBuyMsg" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </form>
    </body>
</html>
