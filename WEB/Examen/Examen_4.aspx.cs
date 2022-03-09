using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libExamen4.Examen_4;

namespace WEBExamen4.Examen_4
{
    public partial class Examen_4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarComboTipoUrgencia();
                LlenarGridUrgencias();
            }
        }
        private void LlenarComboTipoUrgencia()
        {
            clsTipoUrgencia oTipoUrgencia = new clsTipoUrgencia();
            oTipoUrgencia.cboTipoUrgencia = cboTipoUrgencia;
            if (oTipoUrgencia.LlenarCombo() == false)
            {
                lblError.Text = oTipoUrgencia.Error;
            }
        }
        private void LlenarGridUrgencias()
        {
            clsUrgencia oUrgencia = new clsUrgencia();
            oUrgencia.grdUrgencia = grdUrgencias;
            if (!oUrgencia.LlenarGrid())
            {
                lblError.Text = oUrgencia.Error;
            }
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string Documento, NombrePaciente, NombreAcompañante, EPS;
            Int32 TipoUrgencia;
            DateTime FechaHora;

            Documento = txtDocumento.Text;
            NombrePaciente = txtNombrePaciente.Text;
            NombreAcompañante = txtNombreAcompañante.Text;
            EPS = cboEPS.Text;
            TipoUrgencia = Convert.ToInt32(cboTipoUrgencia.SelectedValue);
            FechaHora = Convert.ToDateTime(txtFechaUrgencia.Text);

            clsUrgencia oUrgencia = new clsUrgencia();

            oUrgencia.DocumentoPaciente = Documento;
            oUrgencia.NombrePaciente = NombrePaciente;
            oUrgencia.NombreAcompañante = NombreAcompañante;
            oUrgencia.EPS = EPS;
            oUrgencia.TipoUrgencia = TipoUrgencia;
            oUrgencia.FechaHora = FechaHora;

            if (oUrgencia.Insertar())
            {
                lblError.Text = "";
                LlenarGridUrgencias();
            }
            else
            {
                lblError.Text = oUrgencia.Error;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string Documento, NombrePaciente, NombreAcompañante, EPS;
            Int32 Codigo, TipoUrgencia;
            DateTime FechaHora;

            Codigo = Convert.ToInt32(lblCodigo.Text);
            Documento = txtDocumento.Text;
            NombrePaciente = txtNombrePaciente.Text;
            NombreAcompañante = txtNombreAcompañante.Text;
            EPS = cboEPS.Text;
            TipoUrgencia = Convert.ToInt32(cboTipoUrgencia.SelectedValue);
            FechaHora = Convert.ToDateTime(txtFechaUrgencia.Text);

            clsUrgencia oUrgencia = new clsUrgencia();

            oUrgencia.Codigo = Codigo;
            oUrgencia.DocumentoPaciente = Documento;
            oUrgencia.NombrePaciente = NombrePaciente;
            oUrgencia.NombreAcompañante = NombreAcompañante;
            oUrgencia.EPS = EPS;
            oUrgencia.TipoUrgencia = TipoUrgencia;
            oUrgencia.FechaHora = FechaHora;

            if (oUrgencia.Actualizar())
            {
                lblError.Text = "";
                LlenarGridUrgencias();
            }
            else
            {
                lblError.Text = oUrgencia.Error;
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Int32 Codigo;

            Codigo = Convert.ToInt32(lblCodigo.Text);

            clsUrgencia oUrgencia = new clsUrgencia();

            oUrgencia.Codigo = Codigo;

            if (oUrgencia.Eliminar())
            {
                lblError.Text = "";
                LlenarGridUrgencias();
            }
            else
            {
                lblError.Text = oUrgencia.Error;
            }
        }

        protected void grdUrgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCodigo.Text = grdUrgencias.SelectedRow.Cells[3].Text;
            txtDocumento.Text = grdUrgencias.SelectedRow.Cells[4].Text;
            txtNombrePaciente.Text = grdUrgencias.SelectedRow.Cells[5].Text;
            txtNombreAcompañante.Text = grdUrgencias.SelectedRow.Cells[6].Text;
            cboEPS.SelectedValue = grdUrgencias.SelectedRow.Cells[8].Text;
            cboTipoUrgencia.SelectedValue = grdUrgencias.SelectedRow.Cells[1].Text;
            txtFechaUrgencia.Text= grdUrgencias.SelectedRow.Cells[7].Text;
        }
    }
}