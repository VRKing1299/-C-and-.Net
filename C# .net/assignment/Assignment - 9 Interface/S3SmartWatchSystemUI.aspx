<%@ Page Language="C#" AutoEventWireup="true" CodeFile="S3SmartWatchSystemUI.aspx.cs" Inherits="S3SmartWatchSystemUI" %>

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
    <table class="auto-style1">
        <tr>
            <th colspan="2">Smart Watch</th>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnBluetooth" runat="server" OnClick="btnBluetooth_Click" Text="Connect Bluetooth" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSteps" runat="server" OnClick="btnSteps_Click" Text="Todays Steps" />
            </td>
            <td>
                <asp:Label ID="lblStepCount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnNotifications" runat="server" OnClick="btnNotifications_Click" Text="Notifications" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div>
    
    </div>
    </form>
</body>
</html>
