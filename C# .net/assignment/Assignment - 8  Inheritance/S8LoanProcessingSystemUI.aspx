<%@ Page Language="C#" AutoEventWireup="true" CodeFile="S8LoanProcessingSystemUI.aspx.cs" Inherits="S8LoanProcessingSystemUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <table border="1" style="width:100%;">

            <tr>
                <th colspan="2">Loan Processing System</th>
            </tr>

            <tr>
                <td>Loan Id</td>
                <td>
                    <asp:TextBox ID="txtLoanId" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Customer Name</td>
                <td>
                    <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Loan Amount</td>
                <td>
                    <asp:TextBox ID="txtLoanAmount" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Button ID="btnHomeLoan" runat="server"
                        Text="Home Loan (8%)"
                        OnClick="btnHomeLoan_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td>
                    <asp:Button ID="btnCarLoan" runat="server"
                        Text="Car Loan (10%)"
                        OnClick="btnCarLoan_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td>
                    <asp:Button ID="btnPersonalLoan" runat="server"
                        Text="Personal Loan (12%)"
                        OnClick="btnPersonalLoan_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td colspan="2">
                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                </td>
            </tr>

        </table>

    </form>
</body>
</html>
