<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="pSitioWEB_Prog.BaseDatos.Producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td colspan="2" style="font-size: large" class="text-center"><strong><span style="font-size: x-large">ADMINISTRACIÓN DE PRODUCTOS</span></strong></td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; font-size: large;">CÓDIGO:</td>
                <td class="text-center">
                    <asp:TextBox ID="txtCodigo" runat="server" style="font-size: large" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; font-size: large;">NOMBRE:</td>
                <td class="text-center">
                    <asp:TextBox ID="txtNombre" runat="server" style="font-size: large"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; font-size: large;">DESCRIPCIÓN:</td>
                <td class="text-center">
                    <asp:TextBox ID="txtDescripcion" runat="server" style="font-size: large" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; font-size: large;">CANTIDAD:</td>
                <td class="text-center">
                    <asp:TextBox ID="txtCantidad" runat="server" style="font-size: large" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; font-size: large;">VALOR UNITARIO:</td>
                <td class="text-center">
                    <asp:TextBox ID="txtValorUnitario" runat="server" style="font-size: large" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-left" style="font-weight: bold; font-size: large;">TIPO DE PRODUCTO:</td>
                <td class="text-center">
                    
                    <asp:DropDownList ID="cboTipoProducto" runat="server" style="font-size: large">
                    </asp:DropDownList>
                    
                </td>
            </tr>
            <tr>
                <td class="text-center" style="font-size: x-large">
                    <strong>
                    <asp:Button ID="btnInsertar" runat="server" Width="250px" BackColor="#0000CC" Font-Bold="True" ForeColor="White" OnClick="btnInsertar_Click" style="font-size: x-large" Text="INSERTAR" />
                    </strong>
                </td>
                <td class="text-center">
                    <strong>
                    <asp:Button ID="btnActualizar" runat="server" Text="ACTUALIZAR" Width="250px" BackColor="#0000CC" Font-Bold="True" ForeColor="White" OnClick="btnActualizar_Click" style="font-size: x-large"  />
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="text-center" style="font-size: x-large">
                    <strong>
                    <asp:Button ID="btnEliminar" runat="server" Text="ELIMINAR" Width="250px" BackColor="#0000CC" Font-Bold="True" ForeColor="White" OnClick="btnEliminar_Click" style="font-size: x-large"  />
                    </strong>
                </td>
                <td class="text-center">
                    <strong>
                    <asp:Button ID="btnConsultar" runat="server" Text="CONSULTAR" Width="250px" BackColor="#0000CC" Font-Bold="True" ForeColor="White" OnClick="btnConsultar_Click" style="font-size: x-large" />
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="text-left">
                    <em>
                    <asp:Label ID="lblError" runat="server" style="font-size: large"></asp:Label>
                    </em>
                </td>
                <td class="text-left">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" class="text-center">
                    
                    <asp:GridView ID="grdProducto" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" style="font-size: large" OnSelectedIndexChanged="grdProducto_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Editar.png" ShowSelectButton="True" />
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
    </p>
</asp:Content>

