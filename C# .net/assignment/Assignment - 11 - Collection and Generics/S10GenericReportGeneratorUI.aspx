<%@ Page Language="C#" AutoEventWireup="true" CodeFile="S10GenericReportGeneratorUI.aspx.cs" Inherits="S10GenericReportGeneratorUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnEmployeeReport" runat="server" Text="employee Report" OnClick="btnEmployeeReport_Click" />
        <asp:Button ID="btnProductReport" runat="server" Text="Product Report" OnClick="btnProductReport_Click" />
        <asp:Button ID="btnOrderReport" runat="server" Text="Order Report" OnClick="btnOrderReport_Click" />
    </div>
    </form>
</body>
</html>
