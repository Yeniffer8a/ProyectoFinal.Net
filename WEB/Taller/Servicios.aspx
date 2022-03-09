<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="pSitioWEB_Prog.Taller.Servicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td colspan="2" style="font-weight: 700; text-align: center; font-size: x-large">
                <br />
                <span style="font-size: xx-large">VENTA DE MINUTOS</span></td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>CONSUMO AGUA:</b></td>
            <td>
                <asp:TextBox ID="txtConsumoAgua" runat="server" style="font-size: x-large" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 22px; font-size: x-large"><b>CONSUMO ENERGÍA:</b></td>
            <td style="height: 22px">
                <asp:TextBox ID="txtConsumoEnergia" runat="server" style="font-size: x-large" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 22px; font-size: x-large"><b>CONSUMO GAS:</b></td>
            <td style="height: 22px">
                <asp:TextBox ID="txtConsumoGas" runat="server" style="font-size: x-large" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <strong>
                <asp:Button ID="btnCalcular" runat="server" Text="CALCULAR" style="font-size: xx-large; font-weight: bold;" BackColor="#000066" ForeColor="White" Height="60px" Width="391px" OnClick="btnCalcular_Click" />
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
            <td style="font-size: x-large" class="text-center" colspan="2"><strong>SERVICIO AGUA</strong></td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>Tipo consumo</b></td>
            <td>
                <asp:Label ID="lblTipoConsumoAgua" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>Valor consumo:</b></td>
            <td>
                <asp:Label ID="lblValorConsumoAgua" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>Valor pagar:</b></td>
            <td>
                <asp:Label ID="lblValorPagarAgua" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
	     <tr>
            <td style="font-size: x-large" class="text-center" colspan="2"><strong>SERVICIO ENERGÍA</strong></td>
        </tr>
	    <tr>
            <td style="font-size: x-large"><b>Tipo consumo</b></td>
            <td>
                <asp:Label ID="lblTipoConsumoEnergia" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>Valor consumo:</b></td>
            <td>
                <asp:Label ID="lblValorConsumoEnergia" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>Valor pagar:</b></td>
            <td>
                <asp:Label ID="lblValorPagarEnergia" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large" class="text-center" colspan="2"><strong>SERVICIO GAS</strong></td>
        </tr>
	    <tr>
            <td style="font-size: x-large"><b>Tipo consumo</b></td>
            <td>
                <asp:Label ID="lblTipoConsumoGas" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>Valor consumo:</b></td>
            <td>
                <asp:Label ID="lblValorConsumoGas" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>Valor pagar:</b></td>
            <td>
                <asp:Label ID="lblValorPagarGas" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

