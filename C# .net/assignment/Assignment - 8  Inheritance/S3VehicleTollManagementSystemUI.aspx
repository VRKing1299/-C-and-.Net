<%@ Page Language="C#" AutoEventWireup="true" CodeFile="S3VehicleTollManagementSystemUI.aspx.cs" Inherits="S3VehicleTollManagementSystemUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 431px;
        }
        table,td,tr{
            border: 1px solid black;
            min-height:20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

    <table border="1" >

        <tr>
            <th>Car</th>
            <th>Truck</th>
            <th>Bus</th>
        </tr>

        <tr>
            <td>
                Vehicle No:
                <asp:TextBox ID="txtCarId" runat="server"></asp:TextBox>
                <br />
                Owner Name:
                <asp:TextBox ID="txtCarOwner" runat="server"></asp:TextBox>
                <br />
                Base Toll:
                <asp:TextBox ID="txtCarAmount" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnCar" runat="server"
                    Text="Calculate"
                    OnClick="btnCar_Click" />
                <br />
                <asp:Label ID="lblCarResult" runat="server"></asp:Label>
            </td>

            <td>
                Vehicle No:
                <asp:TextBox ID="txtTruckId" runat="server"></asp:TextBox>
                <br />
                Owner Name:
                <asp:TextBox ID="txtTruckOwner" runat="server"></asp:TextBox>
                <br />
                Base Toll:
                <asp:TextBox ID="txtTruckAmount" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnTruck" runat="server"
                    Text="Calculate"
                    OnClick="btnTruck_Click" />
                <br />
                <asp:Label ID="lblTruckResult" runat="server"></asp:Label>
            </td>

            <td>
                Vehicle No:
                <asp:TextBox ID="txtBusId" runat="server"></asp:TextBox>
                <br />
                Owner Name:
                <asp:TextBox ID="txtBusOwner" runat="server"></asp:TextBox>
                <br />
                Base Toll:
                <asp:TextBox ID="txtBusAmount" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnBus" runat="server"
                    Text="Calculate"
                    OnClick="btnBus_Click" />
                <br />
                <asp:Label ID="lblBusResult" runat="server"></asp:Label>
            </td>
        </tr>

    </table>

</form>
</body>
</html>
