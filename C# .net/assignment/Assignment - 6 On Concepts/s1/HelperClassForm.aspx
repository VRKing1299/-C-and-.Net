<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HelperClassForm.aspx.cs" Inherits="HelperClassForm" %>

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
                    <asp:Button ID="btnLogging" runat="server" OnClick="btnLogging_Click" Text="Logging" />
                </td>
                <td>
                    <asp:Label ID="lblLoggingMsg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnValidation" runat="server" OnClick="btnValidation_Click" Text="Validation" />
                </td>
                <td>
                    <asp:Label ID="lblValidationMsg" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnConversion" runat="server" OnClick="btnConversion_Click" Text="Conversion" />
                </td>
                <td>
                    <asp:Label ID="lblConversionMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
