<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 208px;
        }
        .auto-style3 {
            width: 208px;
            height: 30px;
        }
        .auto-style4 {
            height: 30px;
        }
        .auto-style5 {
            width: 337px;
        }
        .auto-style6 {
            height: 30px;
            width: 337px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" border="1">
    <div>
        
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">User Name:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtUserName" runat="server" Width="252px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnCalcFinalPrice" runat="server" OnClick="btnCalcFinalPrice_Click" Text="FinalPrice" Width="169px" />
                </td>
                <td class="auto-style5">Age:<asp:TextBox ID="txtAge" runat="server" Width="225px"></asp:TextBox>
                </td>
                <td>Membership :<asp:TextBox ID="txtMember" runat="server" Width="135px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblFinalPrice" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="btnPlankChallenge" runat="server" OnClick="btnPlankChallenge_Click" Text="Plank Challenge" Width="169px" />
                </td>
                <td class="auto-style6"></td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnCalcBmi" runat="server" OnClick="btnCalcBmi_Click" Text="Calculate Bmi" Width="169px" />
                </td>
                <td class="auto-style5">Height(In Meter):<asp:TextBox ID="txtHeight" runat="server" Width="149px"></asp:TextBox>
                </td>
                <td>Weight(in Kg) :
                    <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblBmi" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnRunLaps" runat="server" OnClick="btnRunLaps_Click" Text="run Laps" Width="170px" />
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnIntensity" runat="server" OnClick="btnIntensity_Click" Text="Work Out Type" Width="170px" />
                </td>
                <td class="auto-style5">Work Intensity (1-3) :
                    <asp:TextBox ID="txtIntensity" runat="server" Width="101px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblIntensity" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnProMedalCheck" runat="server" OnClick="btnProMedalCheck_Click" Text="Pro Medeal Check " />
                </td>
                <td class="auto-style5">Enter Steps : <asp:TextBox ID="txtSteps" runat="server" Width="175px"></asp:TextBox>
                </td>
                <td>Enter Active Days :<asp:TextBox ID="txtActiveDays" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblProMedalCheck" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
