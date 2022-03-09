<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="pSitioWEB_Prog.BaseDatos.Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td class="text-center" colspan="2" style="font-size: x-large"><strong>
                <br />
                ADMINISTRACIÓN DE CLIENTES</strong></td>
        </tr>
        <tr>
            <td style="font-size: large"><strong>DOCUMENTO:</strong></td>
            <td>
                <asp:TextBox ID="txtDocumento" runat="server" style="font-size: large"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: large"><strong>NOMBRE:</strong></td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" style="font-size: large"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: large"><strong>PRIMER APELLIDO:</strong></td>
            <td>
                <asp:TextBox ID="txtPrimerApellido" runat="server" style="font-size: large"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: large"><strong>SEGUNDO APELLIDO:</strong></td>
            <td>
                <asp:TextBox ID="txtSegundoApellido" runat="server" style="font-size: large"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: large"><strong>DIRECCIÓN:</strong></td>
            <td>
                <asp:TextBox ID="txtDireccion" runat="server" style="font-size: large"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="font-size: large; height: 30px;"><strong>FECHA NACIMIENTO:</strong></td>
            <td style="height: 30px">
                <asp:TextBox ID="txtFechaNacimiento" runat="server" style="font-size: large" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text-center" style="height: 22px">
                <asp:Button ID="btnIngresar" runat="server" style="font-size: x-large" Text="INGRESAR" Width="220px" BackColor="#0033CC" Font-Bold="True" ForeColor="White" OnClick="btnIngresar_Click" />
            </td>
            <td class="text-center" style="height: 22px">
                <asp:Button ID="btnActualizar" runat="server" style="font-size: x-large" Text="ACTUALIZAR" Width="220px" BackColor="#0033CC" Font-Bold="True" ForeColor="White" OnClick="btnActualizar_Click" />
            </td>
        </tr>
        <tr>
            <td class="text-center">
                <asp:Button ID="btnBorrar" runat="server" style="font-size: x-large" Text="BORRAR" Width="220px" BackColor="#0033CC" Font-Bold="True" ForeColor="White" OnClick="btnBorrar_Click" />
            </td>
            <td class="text-center">
                <asp:Button ID="btnConsultar" runat="server" style="font-size: x-large" Text="CONSULTAR" Width="220px" BackColor="#0033CC" Font-Bold="True" ForeColor="White" OnClick="btnConsultar_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="text-left">
                <asp:Label ID="lblError" runat="server" style="font-size: large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="text-left">
                <asp:GridView ID="grdClientes" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" style="font-size: large" OnSelectedIndexChanged="grdClientes_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Telefono.jpg" ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>



