<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KeyValuePair.aspx.cs" Inherits="KeyValuePair" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Dictionary" />
    <div>
    
        <asp:Button ID="btnSortedList" runat="server" OnClick="btnSortedList_Click" Text="SortedList" />
    
    </div>
        <asp:Button ID="btnHashTable" runat="server" OnClick="btnHashTable_Click" Text="Hash Table" />
    </form>
</body>
</html>
