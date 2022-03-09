using System;
using libProgramacionSoftware.ReglasNegocio;

namespace pSitioWEB_Prog.ReglasNegocio
{
    public partial class AgenciaViajes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            string CiudadDestino;
            Int16 NumeroPaquetes;
            CiudadDestino = cboDestino.Text;
            NumeroPaquetes = Convert.ToInt16(txtCantidad.Text);

            clsAgenciaViajes oAgencia = new clsAgenciaViajes();
            oAgencia.CiudadDestino = CiudadDestino;
            oAgencia.NumeroPaquetes = NumeroPaquetes;
            if(oAgencia.CalcularTotal())
            {
                lblTotalPagar.Text = "$ " + oAgencia.TotalPagar.ToString("#,###");
                lblValorAntesDescuento.Text = "$ " + oAgencia.ValorAntesDescuento.ToString("#,###");
                lblValorAntesIVA.Text = "$ " + oAgencia.ValorAntesIVA.ToString("#,###");
                lblValorDescuento.Text = "$ " + oAgencia.ValorDescuento.ToString("#,###");
                lblValorIVA.Text = "$ " + oAgencia.ValorIVA.ToString("#,###");

                lblError.Text = "";
            }
            else
            {
                lblError.Text = oAgencia.Error;

                lblTotalPagar.Text = "";
                lblValorAntesDescuento.Text = "";
                lblValorAntesIVA.Text = "";
                lblValorDescuento.Text = "";
                lblValorIVA.Text = "";
            }
        }
    }
}