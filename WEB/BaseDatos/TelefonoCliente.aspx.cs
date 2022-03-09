using System;
using System.Web.UI;
using libProgramacionSoftware.BaseDatos;

namespace pSitioWEB_Prog.BaseDatos
{
    public partial class TelefonoCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Se captura la información al cargar por primera vez
            if (!Page.IsPostBack)
            {
                //Se captura con el objeto Request, con el método QueryString.Get()
                //Documento como querystring
                //lblDocumento.Text = Request.QueryString.Get("Documento");
                //Documento como sesión
                lblDocumento.Text = Session["Documento"].ToString();
                lblNombre.Text = Request.QueryString.Get("Nombre");
                lblDireccion.Text = Request.QueryString.Get("Direccion");
                lblFechaNacimiento.Text = Request.QueryString.Get("Fecha");

                //Se llena el combo y el grid
                LlenarComboTipoTelefono();
                LlenarGridTelefonos();
            }
        }
        private void LlenarComboTipoTelefono()
        {
            //Creamos el objeto tipo producto, pasamos el combo vacío e invocamos el método
            clsTipoTelefono oTipoTelefono = new clsTipoTelefono();
            oTipoTelefono.cboTipoTelefono = cboTipoTelefono;
            if (!oTipoTelefono.LlenarCombo())
            {
                lblError.Text = oTipoTelefono.Error;
            }
        }
        private void LlenarGridTelefonos()
        {
            //Se debe definir el documento, leerlo y asignarlo a la clase
            clsCliente oCliente = new clsCliente();
            oCliente.grdTelefonos = grdTelefonos;
            oCliente.Documento = Session["Documento"].ToString();

            if (!oCliente.LlenarGridTelefonos())
            {
                lblError.Text = oCliente.Error;
            }
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string Documento, Telefono;
            Int32 TipoTelefono;

            TipoTelefono = Convert.ToInt32(cboTipoTelefono.SelectedValue);
            Documento = Session["Documento"].ToString();
            Telefono = txtNumeroTelefono.Text;

            clsCliente oCliente = new clsCliente();
            oCliente.NumeroTelefono = Telefono;
            oCliente.TipoTelefono = TipoTelefono;
            oCliente.Documento = Documento;

            if (oCliente.InsertarTelefono())
            {
                lblError.Text = "";
                LlenarGridTelefonos();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cliente.aspx");
        }

        protected void grdTelefonos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTipoTelefono.SelectedValue = grdTelefonos.SelectedRow.Cells[1].Text;
            txtCodigoTelefono.Text = grdTelefonos.SelectedRow.Cells[3].Text;
            txtNumeroTelefono.Text = grdTelefonos.SelectedRow.Cells[4].Text;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string Documento, Telefono;
            Int32 TipoTelefono, Codigo;

            Codigo = Convert.ToInt32(txtCodigoTelefono.Text);
            TipoTelefono = Convert.ToInt32(cboTipoTelefono.SelectedValue);
            Documento = Session["Documento"].ToString();
            Telefono = txtNumeroTelefono.Text;

            clsCliente oCliente = new clsCliente();
            oCliente.CodigoTelefono = Codigo;
            oCliente.NumeroTelefono = Telefono;
            oCliente.TipoTelefono = TipoTelefono;
            oCliente.Documento = Documento;

            if (oCliente.ActualizarTelefono())
            {
                lblError.Text = "";
                LlenarGridTelefonos();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 Codigo;

            Codigo = Convert.ToInt32(txtCodigoTelefono.Text);

            clsCliente oCliente = new clsCliente();
            oCliente.CodigoTelefono = Codigo;

            if (oCliente.EliminarTelefono())
            {
                lblError.Text = "";
                LlenarGridTelefonos();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
        }
    }
}