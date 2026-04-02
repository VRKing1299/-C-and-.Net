<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
    <form id="form1" runat="server">
    <div>
        
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Button ID="btnCalc" runat="server" OnClick="btnCalc_Click" Text="avg" />
                </td>
                <td>
                    <asp:Label ID="lblAvg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAddOne" runat="server" OnClick="btnAddOne_Click" Text="Add One" />
                </td>
                <td>
                    <asp:Label ID="lblAddOne" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
