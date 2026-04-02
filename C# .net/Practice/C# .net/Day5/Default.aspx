<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="BtnFindGT" runat="server" OnClick="BtnFindGT_Click" Text="Find Golden Ticket" />
        <asp:Button ID="BtnAddMArray" runat="server" OnClick="BtnAddMArray_Click" Text="Print addition of Multi Dimensional Array" />
        <asp:Button ID="BtnJackedArray" runat="server" OnClick="BtnJackedArray_Click" Text="Print Jacked Array" />
    
    </div>
    </form>
</body>
</html>
