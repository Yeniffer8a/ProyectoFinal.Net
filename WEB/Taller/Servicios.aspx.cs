using System;
using libProgramacionSoftware.Taller;

namespace pSitioWEB_Prog.Taller
{
    public partial class Servicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            Int16 ConsumoAgua, ConsumoGas, ConsumoEnergia;

            ConsumoAgua = Convert.ToInt16(txtConsumoAgua.Text);
            ConsumoEnergia = Convert.ToInt16(txtConsumoEnergia.Text);
            ConsumoGas = Convert.ToInt16(txtConsumoGas.Text);

            clsServicios oServicios = new clsServicios();
            oServicios.ConsumoAgua = ConsumoAgua;
            oServicios.ConsumoEnergia = ConsumoEnergia;
            oServicios.ConsumoGas = ConsumoGas;

            if (oServicios.CalcularPagoServicios())
            {
                lblError.Text = "";

                lblTipoConsumoAgua.Text = oServicios.TipoCobroAgua + ": " + (oServicios.PorcentajeCargoAgua * 100).ToString() + " %";
                lblValorConsumoAgua.Text = "$ " + oServicios.ValorConsumoAgua.ToString("#,###");
                lblValorPagarAgua.Text = "$ " + oServicios.ValorTotalAgua.ToString("#,###");

                lblTipoConsumoEnergia.Text = oServicios.TipoCobroEnergia + ": " + (oServicios.PorcentajeCargoEnergia * 100).ToString() + " %";
                lblValorConsumoEnergia.Text = "$ " + oServicios.ValorConsumoEnergia.ToString("#,###");
                lblValorPagarEnergia.Text = "$ " + oServicios.ValorTotalEnergia.ToString("#,###");

                lblTipoConsumoGas.Text = oServicios.TipoCobroGas + ": " + (oServicios.PorcentajeCargoGas * 100).ToString() + " %";
                lblValorConsumoGas.Text = "$ " + oServicios.ValorConsumoGas.ToString("#,###");
                lblValorPagarGas.Text = "$ " + oServicios.ValorTotalGas.ToString("#,###");
            }
            else
            {
                lblError.Text = oServicios.Error;

                lblTipoConsumoAgua.Text = "";
                lblValorConsumoAgua.Text = "";
                lblValorPagarAgua.Text = "";

                lblTipoConsumoEnergia.Text = "";
                lblValorConsumoEnergia.Text = "";
                lblValorPagarEnergia.Text = "";

                lblTipoConsumoGas.Text = "";
                lblValorConsumoGas.Text = "";
                lblValorPagarGas.Text = "";
            }
        }
    }
}