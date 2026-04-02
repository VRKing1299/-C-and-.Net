<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GstForm.aspx.cs" Inherits="GstForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        td{
            border:solid 1px black;
        }
        /*.auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 30px;
        }*/
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="height: 26px" Text="Calculate Gst" />
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:Label ID="lblGst" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
