using System;
using libProgramacionSoftware.BaseDatos;

namespace pSitioWEB_Prog.BaseDatos
{
    public partial class TipoProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string Nombre;
            bool Activo;

            Nombre = txtNombre.Text;
            Activo = chkActivo.Checked;

            clsTipoProducto oTipoProducto = new clsTipoProducto();
            oTipoProducto.Nombre = Nombre;
            oTipoProducto.Activo = Activo;

            if (oTipoProducto.Insertar())
            {
                lblError.Text = "Insertó correctamente en la base de datos";
            }
            else
            {
                lblError.Text = oTipoProducto.Error;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Int32 Codigo;
            string Nombre;
            bool Activo;

            Codigo = Convert.ToInt32(txtCodigo.Text);
            Nombre = txtNombre.Text;
            Activo = chkActivo.Checked;

            clsTipoProducto oTipoProducto = new clsTipoProducto();
            oTipoProducto.Codigo = Codigo;
            oTipoProducto.Nombre = Nombre;
            oTipoProducto.Activo = Activo;

            if (oTipoProducto.Actualizar())
            {
                lblError.Text = "Actualizó correctamente en la base de datos el código: " + Codigo;
            }
            else
            {
                lblError.Text = oTipoProducto.Error;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 Codigo;

            Codigo = Convert.ToInt32(txtCodigo.Text);

            clsTipoProducto oTipoProducto = new clsTipoProducto();
            oTipoProducto.Codigo = Codigo;

            if (oTipoProducto.Borrar())
            {
                lblError.Text = "Se eliminó correctamente de la base de datos el código: " + Codigo;
            }
            else
            {
                lblError.Text = oTipoProducto.Error;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Int32 Codigo;

            Codigo = Convert.ToInt32(txtCodigo.Text);

            clsTipoProducto oTipoProducto = new clsTipoProducto();
            oTipoProducto.Codigo = Codigo;

            if (oTipoProducto.Consultar())
            {
                lblError.Text = "";
                txtNombre.Text = oTipoProducto.Nombre;
                chkActivo.Checked = oTipoProducto.Activo;
            }
            else
            {
                lblError.Text = oTipoProducto.Error;
            }
        }
    }
}