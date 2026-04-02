<%@ Page Language="C#" AutoEventWireup="true" CodeFile="S6ShapeAreaCalculatorUI.aspx.cs" Inherits="S6ShapeAreaCalculatorUI" %>

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
                <th>Circle</th>
                <th>Rectangle</th>
                <th>Triangle</th>
            </tr>
            <tr>
                <td>Radius :
                    <asp:TextBox ID="txtRadius" runat="server"></asp:TextBox>
                </td>
                <td>Width :
                    <asp:TextBox ID="txtRectWidth" runat="server"></asp:TextBox>
                </td>
                <td>Base :<asp:TextBox ID="txtTriBase" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>Height<asp:TextBox ID="txtRectHeigh" runat="server"></asp:TextBox>
                </td>
                <td>Height :<asp:TextBox ID="txtTriHeight" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCArea" runat="server" Text="Calculate Circle Area" OnClick="btnCArea_Click" />
                </td>
                <td>
                    <asp:Button ID="btnRArea" runat="server" Text="Calculate Rectangle Area" OnClick="btnRArea_Click" />
                </td>
                <td>
                    <asp:Button ID="btnTArea" runat="server" Text="Calculate Triangle Area" OnClick="btnTArea_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCArea" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblRArea" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTArea" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
