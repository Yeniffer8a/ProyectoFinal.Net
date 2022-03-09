<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TipoProducto.aspx.cs" Inherits="pSitioWEB_Prog.BaseDatos.TipoProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td colspan="2" style="font-size: xx-large" class="text-center"><strong>ADMINISTRACIÓN DE TIPOS DE PRODUCTOS</strong></td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; font-size: x-large;">CÓDIGO:</td>
                <td>
                    <asp:TextBox ID="txtCodigo" runat="server" style="font-size: x-large"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; height: 22px; font-size: x-large;">NOMBRE:</td>
                <td style="height: 22px">
                    <asp:TextBox ID="txtNombre" runat="server" style="font-size: x-large"></asp:TextBox>
                </td>
            </tr>
            <tr style="font-size: x-large">
                <td class="text-left" style="font-weight: bold">ACTIVO:</td>
                <td>
                    <asp:CheckBox ID="chkActivo" runat="server" />
                </td>
            </tr>
           <tr>
                <td class="text-center">
                    <asp:Button ID="btnInsertar" runat="server" Text="INSERTAR" OnClick="btnInsertar_Click" Width="280px" style="font-size: x-large; height: 41px;" />
                </td>
                <td class="text-center">
                    <asp:Button ID="btnActualizar" runat="server" Text="ACTUALIZAR" OnClick="btnActualizar_Click" Width="280px" style="font-size: x-large" />
                </td>
            </tr>
            <tr>
                <td class="text-center">
                    <asp:Button ID="btnEliminar" runat="server" Text="ELIMINAR" OnClick="btnEliminar_Click" Width="280px" style="font-size: x-large" />
                </td>
                <td class="text-center">
                    <asp:Button ID="btnConsultar" runat="server" Text="CONSULTAR" Width="280px" style="font-size: x-large" OnClick="btnConsultar_Click" />
                </td>
            </tr>
            <tr>
                <td class="text-left" colspan="2">
                    <asp:Label ID="lblError" runat="server" style="font-size: x-large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    
                </td>
            </tr>
        </table>
    </p>
</asp:Content>

