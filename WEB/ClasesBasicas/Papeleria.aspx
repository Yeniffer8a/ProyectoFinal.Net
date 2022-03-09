<%@ Page Title="Papelería" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Papeleria.aspx.cs" Inherits="pSitioWEB_Prog.ClasesBasicas.Papeleria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td class="text-center" colspan="2"><strong><span style="font-size: xx-large">PAPELERÍA</span></strong>&nbsp;</td>
            </tr>
            <tr>
                <td style="font-size: x-large"><strong>Cantidad fotocopias a blanco y negro</strong></td>
                <td class="text-center">
                    <asp:TextBox ID="txtCantidadFotoByN" runat="server" style="font-size: x-large" TextMode="Number">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-size: x-large"><strong>Cantidad fotocopias a color</strong></td>
                <td class="text-center">
                    <asp:TextBox ID="txtCantidadFotoColor" runat="server" style="font-size: x-large" TextMode="Number">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-size: x-large"><strong>Cantidad impresiones blanco y negro</strong></td>
                <td class="text-center">
                    <asp:TextBox ID="txtCantidadImprByN" runat="server" style="font-size: x-large" TextMode="Number">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-size: x-large"><strong>Cantidad impresiones color</strong></td>
                <td class="text-center">
                    <asp:TextBox ID="txtCantidadImprColor" runat="server" style="font-size: x-large" TextMode="Number">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Button ID="btnCalcular" runat="server" BackColor="#0033CC" Font-Bold="True" ForeColor="White" OnClick="btnCalcular_Click" style="font-size: xx-large" Text="CALCULAR" Width="280px" />
                </td>
                <td class="text-center">
                    <asp:Button ID="btnLimpiar" runat="server" BackColor="#0033CC" Font-Bold="True" ForeColor="White" style="font-size: xx-large" Text="LIMPIAR" Width="280px" OnClick="btnLimpiar_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblError" runat="server" style="font-size: x-large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="font-size: x-large"><strong>Subtotal</strong></td>
                <td class="text-center">
                    <asp:Label ID="lblSubtotal" runat="server" style="font-size: x-large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="font-size: x-large"><strong>Valor IVA</strong></td>
                <td class="text-center">
                    <asp:Label ID="lblValorIVA" runat="server" style="font-size: x-large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="font-size: x-large"><strong>Total a pagar</strong></td>
                <td class="text-center">
                    <asp:Label ID="lblTotal" runat="server" style="font-size: x-large"></asp:Label>
                </td>
            </tr>
        </table>
    </p>
</asp:Content>


