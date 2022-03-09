<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgenciaViajes.aspx.cs" Inherits="pSitioWEB_Prog.ReglasNegocio.AgenciaViajes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td colspan="2" style="text-align: center; font-weight: 700; font-size: large">
                <br style="font-size: x-large" />
                <span style="font-size: xx-large">AGENCIA DE VIAJES - VENTA PAQUETES TURÍSTICOS</span></td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>DESTINO:</b></td>
            <td>
                <asp:DropDownList ID="cboDestino" runat="server" style="font-size: x-large">
                    <asp:ListItem>CANCÚN</asp:ListItem>
                    <asp:ListItem>ORLANDO</asp:ListItem>
                    <asp:ListItem>MIAMI</asp:ListItem>
                    <asp:ListItem>CUBA</asp:ListItem>
                    <asp:ListItem>BOGOTÁ</asp:ListItem>
                    <asp:ListItem>CARTAGENA</asp:ListItem>
                    <asp:ListItem>SAN ANDRÉS</asp:ListItem>
                    <asp:ListItem>ARMENIA</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>CANTIDAD PAQUETES:</b></td>
            <td>
                <asp:TextBox ID="txtCantidad" runat="server" style="font-size: x-large" TextMode="Number">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center; font-size: large">
                <asp:Button ID="btnCalcular" runat="server" Height="54px" Text="CALCULAR" Width="249px" OnClick="btnCalcular_Click" style="font-size: xx-large" BackColor="Blue" Font-Bold="True" ForeColor="White" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblError" runat="server" ForeColor="#CC3300" style="font-size: x-large; font-style: italic"></asp:Label>
            </td>
        </tr>
        <tr style="font-size: medium">
            <td style="font-size: x-large"><b>VALOR ANTES DE DESCUENTO:&nbsp;</b></td>
            <td style="font-size: x-large; margin-left: 40px;">
                <asp:Label ID="lblValorAntesDescuento" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="font-size: medium">
            <td style="font-size: x-large"><b>VALOR DESCUENTO:</b></td>
            <td style="font-size: x-large">
                <asp:Label ID="lblValorDescuento" runat="server"></asp:Label>
            </td>
        </tr>
	<tr style="font-size: medium">
            <td style="height: 22px; font-size: x-large;"><strong>VALOR ANTES DE IVA:</strong></td>
            <td style="height: 22px; font-size: x-large;">
                <asp:Label ID="lblValorAntesIVA" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="font-size: medium">
            <td style="height: 22px; font-size: x-large;"><strong>VALOR IVA:</strong></td>
            <td style="height: 22px; font-size: x-large;">
                <asp:Label ID="lblValorIVA" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="font-size: medium">
            <td style="font-size: x-large"><b>TOTAL A PAGAR:</b></td>
            <td style="font-size: x-large">
                <asp:Label ID="lblTotalPagar" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

