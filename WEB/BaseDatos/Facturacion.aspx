<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="pSitioWEB_Prog.BaseDatos.Facturacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td colspan="4" style="text-align: center"><strong><span style="font-size: x-large">
                <br />
                FACTURACIÓN</span></strong>&nbsp;</td>
        </tr>
        <tr style="font-size: large">
            <td class="text-left"><strong>Número factura:</strong></td>
            <td>
                <asp:Label ID="lblNumeroFactura" runat="server"></asp:Label>
            </td>
            <td style="width: 172px" class="text-left"><strong>Fecha:</strong></td>
            <td>
                <asp:Label ID="lblFecha" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="font-size: large">
            <td class="text-left"><strong>Documento cliente:</strong></td>
            <td>
                <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox>
                <asp:ImageButton ID="btnBuscarCliente" runat="server" Height="25px" ImageUrl="~/Imagenes/Buscar.jpg" Width="26px" OnClick="btnBuscarCliente_Click" />
            </td>
            <td colspan="2" class="text-left">
                <asp:Label ID="lblNombreCliente" runat="server"></asp:Label>
            &nbsp;<asp:Button ID="btnCrearCliente" runat="server" BackColor="#0000CC" ForeColor="White" Text="CREAR" Width="103px" OnClick="btnCrearCliente_Click" Visible="False" />
            </td>
        </tr>
        <tr style="font-size: large">
            <td style="height: 30px" class="text-left"><strong>Empleado:</strong></td>
            <td style="height: 30px">
                <asp:DropDownList ID="cboEmpleado" runat="server" style="font-size: large">
                </asp:DropDownList>
            </td>
            <td style="height: 30px; width: 172px;" class="text-left"><strong>Tipo producto:</strong></td>
            <td style="height: 30px">
                <asp:DropDownList ID="cboTipoProducto" runat="server" style="font-size: large" AutoPostBack="True" OnSelectedIndexChanged="cboTipoProducto_SelectedIndexChanged" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 19px; font-size: large" class="text-left"><strong>Producto:</strong></td>
            <td style="height: 19px">
                <asp:DropDownList ID="cboProducto" runat="server" style="font-size: large" AutoPostBack="True" OnSelectedIndexChanged="cboProducto_SelectedIndexChanged" >
                </asp:DropDownList>
            </td>
            <td style="height: 19px; font-size: large; width: 172px;" class="text-left"><strong>Valor unitario:</strong></td>
            <td style="height: 19px">
                <asp:Label ID="lblValor" runat="server" style="font-size: large" ></asp:Label>
                <asp:Label ID="lblValorUnitario" runat="server" style="font-size: large" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr style="font-size: large">
            <td class="text-left" style="height: 27px"><strong>Cantidad:</strong></td>
            <td style="height: 27px">
                <asp:TextBox ID="txtCantidad" runat="server" OnTextChanged="txtCantidad_TextChanged" TextMode="Number" AutoPostBack="True" >1</asp:TextBox>
            </td>
            <td style="width: 172px; height: 27px;" class="text-left"><strong>Subtotal:</strong></td>
            <td style="height: 27px">
                <asp:Label ID="lblSubtotal" runat="server" style="font-size: large"></asp:Label>
            </td>
        </tr>
        <tr style="font-size: large">
            <td style="font-size: large" class="text-left"><strong>Total:</strong></td>
            <td style="font-size: large">
                <strong>
                <asp:Label ID="lblTotal" runat="server" style="font-size: large"></asp:Label>
                </strong>
            </td>
            <td style="font-size: large; width: 172px;">
                <asp:TextBox ID="txtDetalleFactura" runat="server" Visible="False"  ></asp:TextBox>
            </td>
            <td style="font-size: large">
                &nbsp;</td>
        </tr>
        <tr style="font-size: large">
            <td class="text-center" colspan="2" style="font-size: large; height: 27px"><strong>
                <asp:Button ID="btnGrabar" runat="server" BackColor="#0000CC" ForeColor="White" 
                    Height="40px" style="font-size: x-large; font-weight: bold" Text="GRABAR" 
                    Width="300px" OnClick="btnGrabar_Click" />
                </strong></td>
            <td class="text-center" colspan="2" style="font-size: large; height: 27px">
                <asp:Button ID="btnTerminar" runat="server" BackColor="#0000CC" 
                    ForeColor="White" Height="40px" style="font-size: x-large; font-weight: bold" 
                    Text="TERMINAR" Width="300px" OnClick="btnTerminar_Click" />
            </td>
        </tr>
        <tr style="font-size: large">
            <td class="text-center" colspan="2" style="font-size: large; height: 27px"><strong>
                <asp:Button ID="btnActualizar" runat="server" BackColor="#0000CC" ForeColor="White" 
                    Height="40px" style="font-size: x-large; font-weight: bold" Text="ACTUALIZAR" 
                    Width="300px" OnClick="btnActualizar_Click" Visible="False"  />
                </strong></td>
            <td class="text-center" colspan="2" style="font-size: large; height: 27px">
                <strong>
                <asp:Button ID="btnEliminar" runat="server" BackColor="#0000CC" ForeColor="White" 
                    Height="40px" style="font-size: x-large; font-weight: bold" Text="ELIMINAR" 
                    Width="300px" OnClick="btnEliminar_Click" Visible="False" />
                </strong>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 22px" class="text-left">
                <asp:Label ID="lblError" runat="server" style="font-size: large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text-center" colspan="4">
                <asp:GridView ID="grdFactura" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" style="font-size: large" OnSelectedIndexChanged="grdFactura_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Editar.png" ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
