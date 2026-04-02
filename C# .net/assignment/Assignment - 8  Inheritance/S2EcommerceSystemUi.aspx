<%@ Page Language="C#" AutoEventWireup="true" CodeFile="S2EcommerceSystemUi.aspx.cs" Inherits="S2EcommerceSystemUi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 431px;
        }
        table,td,tr{
            border: 1px solid black;
            min-height:20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="auto-style1">
            <tr>
                <th class="auto-style2">Store Order details </th>
                <th>Online Order details</th>
            </tr>
            <tr>
                <td class="auto-style2">Order Id : <asp:TextBox ID="txtSid" runat="server"></asp:TextBox>
                </td>
                <td>Order Id :
                    <asp:TextBox ID="txtOid" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Customer Name : <asp:TextBox ID="txtSname" runat="server"></asp:TextBox>
                </td>
                <td>Customer Name :<asp:TextBox ID="txtOname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Order Amount : <asp:TextBox ID="txtSsal" runat="server"></asp:TextBox>
                </td>
                <td>Order Amount :
                    <asp:TextBox ID="txtOsal" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnCalcSamount" runat="server" OnClick="btnCalcSamount_Click" Text="Calculate Total Price" />
                </td>
                <td>
                    <asp:Button ID="btnCalcOamount" runat="server" OnClick="btnCalcOamount_Click" Text="Calculate Total Price" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblSTotalPrice" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOTotalPrice" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
    </div>
    </form>
</body>
</html>
