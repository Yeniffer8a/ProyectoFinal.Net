<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VentaMinutosDatos.aspx.cs" Inherits="pSitioWEB_Prog.ReglasNegocio.VentaMinutosDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td colspan="2" style="font-weight: 700; text-align: center; font-size: x-large">
                <br />
                <span style="font-size: xx-large">VENTA DE MINUTOS</span></td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>VALOR RECARGA:</b></td>
            <td>
                <asp:DropDownList ID="cboValorRecarga" runat="server" style="font-size: x-large">
                    <asp:ListItem Value="1000">$ 1.000</asp:ListItem>
                    <asp:ListItem Value="2000">$ 2.000</asp:ListItem>
                    <asp:ListItem Value="5000">$ 5.000</asp:ListItem>
                    <asp:ListItem Value="10000">$ 10.000</asp:ListItem>
                    <asp:ListItem Value="20000">$ 20.000</asp:ListItem>
                    <asp:ListItem Value="25000">$ 25.000</asp:ListItem>
                    <asp:ListItem Value="30000">$ 30.000</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 22px; font-size: x-large"><b>NÚMERO CELULAR:</b></td>
            <td style="height: 22px">
                <asp:TextBox ID="txtNumeroCelular" runat="server" style="font-size: x-large"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <strong>
                <asp:Button ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click" Text="REGISTRAR VENTA" style="font-size: xx-large; font-weight: bold;" BackColor="#000066" ForeColor="White" Height="60px" Width="391px" />
                </strong>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <em>
                <asp:Label ID="lblError" runat="server" style="font-size: x-large" ForeColor="Red"></asp:Label>
                </em>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large"><strong>Porcentaje extra:</strong></td>
            <td>
                <asp:Label ID="lblPorcentajeExtra" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>Minutos comprados:</b></td>
            <td>
                <asp:Label ID="lblMinutosComprados" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>Minutos adicionales:</b></td>
            <td>
                <asp:Label ID="lblMinutosAdicionales" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>Total minutos:</b></td>
            <td>
                <asp:Label ID="lblTotalMinutos" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
	<tr>
            <td style="font-size: x-large"><b>Datos comprados:</b></td>
            <td>
                <asp:Label ID="lblDatosComprados" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>Datos adicionales:</b></td>
            <td>
                <asp:Label ID="lblDatosAdicionales" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>Total datos:</b></td>
            <td>
                <asp:Label ID="lblTotalDatos" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
