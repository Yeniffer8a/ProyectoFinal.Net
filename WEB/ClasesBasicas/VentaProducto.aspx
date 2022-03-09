<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VentaProducto.aspx.cs" Inherits="pSitioWEB_Prog.ClasesBasicas.VentaProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table align="center" style="width: 80%">
            <tr>
                <td class="text-center" colspan="2" style="font-size: xx-large; color: #000099"><strong>VENTA DE PRODUCTOS</strong></td>
            </tr>
            <tr>
                <td style="font-size: x-large"><strong>CANTIDAD:</strong></td>
                <td class="text-center">
                    <asp:TextBox ID="txtCantidad" runat="server" style="font-size: x-large"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-size: x-large"><strong>VALOR UNITARIO:</strong></td>
                <td class="text-center">
                    <asp:TextBox ID="txtValorUnitario" runat="server" style="font-size: x-large"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-center" colspan="2">
                    <asp:Button ID="btnCalcular" runat="server" BackColor="#000099" Font-Bold="True" ForeColor="White" OnClick="btnCalcular_Click" style="font-size: xx-large" Text="CALCULAR" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblError" runat="server" style="font-size: x-large"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="font-size: x-large"><strong>SUBTOTAL:</strong></td>
                <td class="text-center">
                    <asp:Label ID="lblSubtotal" runat="server" style="font-size: x-large" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="font-size: x-large"><strong>VALOR IVA:</strong></td>
                <td class="text-center">
                    <asp:Label ID="lblValorIVA" runat="server" style="font-size: x-large" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="font-size: x-large"><strong>TOTAL PAGAR:</strong></td>
                <td class="text-center">
                    <asp:Label ID="lblTotal" runat="server" style="font-size: x-large" Text="-"></asp:Label>
                </td>
            </tr>
        </table>
    </p>
</asp:Content>
