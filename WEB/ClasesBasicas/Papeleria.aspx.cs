using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libProgramacionSoftware.ClasesBasicas;

namespace pSitioWEB_Prog.ClasesBasicas
{
    public partial class Papeleria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            Int16 CantidadFotocopiasColor, CantidadFotocopiasByN, CantidadImpresionesColor, CantidadImpresionesByN;

            CantidadFotocopiasColor = Convert.ToInt16(txtCantidadFotoColor.Text);
            CantidadFotocopiasByN = Convert.ToInt16(txtCantidadFotoByN.Text);
            CantidadImpresionesColor = Convert.ToInt16(txtCantidadImprColor.Text);
            CantidadImpresionesByN = Convert.ToInt16(txtCantidadImprByN.Text);

            clsPapeleria oPapeleria = new clsPapeleria();

            oPapeleria.CantidadFotocopiasColor = CantidadFotocopiasColor;
            oPapeleria.CantidadFotocopiasByN = CantidadFotocopiasByN;
            oPapeleria.CantidadImpresionesColor = CantidadImpresionesColor;
            oPapeleria.CantidadImpresionesByN = CantidadImpresionesByN;

            //Un método que retorna un valor booleano, se invoca a través del IF
            if (oPapeleria.CalcularTotal())
            {
                //Si la respuesta es verdadera, es que hizo el cálculo correctamente, se presentan las respuestas
                lblSubtotal.Text = "$ " + oPapeleria.Subtotal.ToString("#,###");
                lblTotal.Text = "$ " + oPapeleria.Total.ToString("#,###");
                lblValorIVA.Text = "$ " + oPapeleria.ValorIVA.ToString("#,###");
                //Limpiar el error
                lblError.Text = "";
            }
            else
            {
                //Hubo un problema y se debe presentar el error
                lblError.Text = oPapeleria.Error;
                //Limpiar las respuestas
                lblSubtotal.Text = "";
                lblTotal.Text = "";
                lblValorIVA.Text = "";
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Limpia las respuestas, tanto las correctas como el error
            lblValorIVA.Text = "";
            lblTotal.Text = "";
            lblSubtotal.Text = "";
            lblError.Text = "";
            //Limpiar los datos de entrada
            txtCantidadFotoByN.Text = "0";
            txtCantidadFotoColor.Text = "0";
            txtCantidadImprByN.Text = "0";
            txtCantidadImprColor.Text = "0";
        }
    }
}