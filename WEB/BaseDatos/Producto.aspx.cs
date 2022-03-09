using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using libProgramacionSoftware.BaseDatos;

namespace pSitioWEB_Prog.BaseDatos
{
    public partial class Producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hay un objeto en .net: Page, que tiene la propiedad .IsPostBac, es un booleano
            //que cuando está en true (V), ya hay postback y cuando está en falso no hay postback
            //es decir, es la primera vez que se llama la página
            //El combo se debe llenar exclusivamente, cuando se llena la primera vez
            //if (Page.IsPostBack== false)
            if (!Page.IsPostBack)
            {
                //Es la primera vez, se invoca el llenao del combo
                LlenarComboTipoProducto();
                //Lleno el grid
                LlenarGridProducto();
            }
        }
        private void LlenarComboTipoProducto()
        {
            //Creamos el objeto tipo producto, pasamos el combo vacío e invocamos el método
            clsTipoProducto oTipoProducto = new clsTipoProducto();
            oTipoProducto.cboTipoProducto = cboTipoProducto;
            if (!oTipoProducto.LlenarCombo())
            {
                lblError.Text = oTipoProducto.Error;
            }
        }
        private void LlenarGridProducto()
        {
            clsProducto oProducto = new clsProducto();
            oProducto.grdProducto = grdProducto;
            if (!oProducto.LlenarGrid())
            {
                lblError.Text = oProducto.Error;
            }
        }
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string Nombre, Descripcion;
            Int32 CodigoTipoProducto, ValorUnitario;
            Int16 Cantidad;

            Nombre = txtNombre.Text;
            Cantidad = Convert.ToInt16(txtCantidad.Text);
            ValorUnitario = Convert.ToInt32(txtValorUnitario.Text);
            CodigoTipoProducto = Convert.ToInt32(cboTipoProducto.SelectedValue);
            Descripcion = txtDescripcion.Text;

            clsProducto oProducto = new clsProducto();

            oProducto.Nombre = Nombre;
            oProducto.Descripcion = Descripcion;
            oProducto.ValorUnitario = ValorUnitario;
            oProducto.Cantidad = Cantidad;
            oProducto.CodigoTipoProducto = CodigoTipoProducto;

            if (oProducto.Insertar())
            {
                lblError.Text = "Se insertó correctamente en la base de datos el producto: " + Nombre;
                LlenarGridProducto();
            }
            else
            {
                lblError.Text = oProducto.Error;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string Nombre, Descripcion;
            Int32 Codigo, CodigoTipoProducto, ValorUnitario;
            Int16 Cantidad;

            Codigo = Convert.ToInt32(txtCodigo.Text);
            Nombre = txtNombre.Text;
            Cantidad = Convert.ToInt16(txtCantidad.Text);
            ValorUnitario = Convert.ToInt32(txtValorUnitario.Text);
            CodigoTipoProducto = Convert.ToInt32(cboTipoProducto.SelectedValue);
            Descripcion = txtDescripcion.Text;

            clsProducto oProducto = new clsProducto();

            oProducto.Codigo = Codigo;
            oProducto.Nombre = Nombre;
            oProducto.Descripcion = Descripcion;
            oProducto.ValorUnitario = ValorUnitario;
            oProducto.Cantidad = Cantidad;
            oProducto.CodigoTipoProducto = CodigoTipoProducto;

            if (oProducto.Actualizar())
            {
                lblError.Text = "Se actualizó correctamente en la base de datos el producto de código: " + Codigo;
                LlenarGridProducto();
            }
            else
            {
                lblError.Text = oProducto.Error;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 Codigo;

            Codigo = Convert.ToInt32(txtCodigo.Text);
            
            clsProducto oProducto = new clsProducto();

            oProducto.Codigo = Codigo;
            
            if (oProducto.Eliminar())
            {
                lblError.Text = "Se eliminó correctamente en la base de datos el producto de código: " + Codigo;
                LlenarGridProducto();
            }
            else
            {
                lblError.Text = oProducto.Error;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Int32 Codigo;

            Codigo = Convert.ToInt32(txtCodigo.Text);

            clsProducto oProducto = new clsProducto();

            oProducto.Codigo = Codigo;

            if (oProducto.Consultar())
            {
                lblError.Text = "";

                txtCodigo.Text = oProducto.Codigo.ToString();
                txtValorUnitario.Text = oProducto.ValorUnitario.ToString();
                txtDescripcion.Text = oProducto.Descripcion;
                txtCantidad.Text = oProducto.Cantidad.ToString();
                txtNombre.Text = oProducto.Nombre;
                cboTipoProducto.SelectedValue = oProducto.CodigoTipoProducto.ToString();
            }
            else
            {
                lblError.Text = oProducto.Error;
                txtCodigo.Text = "";
                txtValorUnitario.Text = "";
                txtDescripcion.Text = "";
                txtCantidad.Text = "";
                txtNombre.Text = "";
            }
        }

        protected void grdProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Evento que se ejecuta al seleccionar un elemento del grid
            txtCodigo.Text = grdProducto.SelectedRow.Cells[3].Text;
            txtNombre.Text = grdProducto.SelectedRow.Cells[4].Text;
            txtDescripcion.Text = grdProducto.SelectedRow.Cells[5].Text;
            txtCantidad.Text = grdProducto.SelectedRow.Cells[6].Text;
            txtValorUnitario.Text = grdProducto.SelectedRow.Cells[7].Text;
            cboTipoProducto.SelectedValue = grdProducto.SelectedRow.Cells[1].Text;
            lblError.Text = "";
        }
    }
}