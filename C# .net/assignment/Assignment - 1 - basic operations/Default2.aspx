<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

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
                <td>display the pattern like right angle triangle using an asterisk.</td>
                <td>
                    <asp:Button ID="btnPrintPattern1" runat="server" OnClick="Button1_Click" Text="Print PAttern1" />
                </td>
                <td>
                    <asp:Label ID="lblPattern1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>display the pattern like right angle triangle with a number</td>
                <td>
                    <asp:Button ID="btnPrintPattern2" runat="server" OnClick="btnPrintPattern2_Click" Text="Print Pattern2" />
                </td>
                <td>
                    <asp:Label ID="lblPattern2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>pattern like right angle triangle with a number which will repeat a number in a row</td>
                <td>
                    <asp:Button ID="btnPrintPattern3" runat="server" OnClick="btnPrintPattern3_Click" Text="Print Pattern3" />
                </td>
                <td>
                    <asp:Label ID="lblPattern3" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>pattern to make such a pattern like right angle triangle with number increased by 1</td>
                <td>
                    <asp:Button ID="btnPrintPattern4" runat="server" OnClick="btnPrintPattern4_Click" Text="Print Pattern4" />
                </td>
                <td>
                    <asp:Label ID="lblPattern4" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>to make such a pattern like a pyramid with numbers increased by 1.</td>
                <td>
                    <asp:Button ID="btnPiramid" runat="server" OnClick="btnPiramid_Click" Text="piramid" />
                </td>
                <td>
                    <asp:Label ID="lblPiramid" runat="server" Text="lblPiramid"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Program&nbsp; to display the such a pattern for n number of rows using a number which will start with the number 1 and the first and a last number of each row will be 1</td>
                <td>
                    <asp:Button ID="btnPiramidP2" runat="server" OnClick="btnPiramidP2_Click" Text="Piramid p2" />
                </td>
                <td>
                    <asp:Label ID="lblPiramid2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Program to display the pattern using the alphabet.</td>
                <td>
                    <asp:Button ID="btnPrintAlphabetPiramid" runat="server" OnClick="btnPrintAlphabetPiramid_Click" Text="Print Alphabet piramid" />
                </td>
                <td>
                    <asp:Label ID="lblAlphabetPiramid" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
