using System;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace libExamen4.Examen_4
{
    public class clsTipoUrgencia
    {
        #region Constructor
        public clsTipoUrgencia()
        {

        }
        #endregion
        #region Propiedades/Atributos
        public Int32 Codigo { get; set; }
        public string Nombre { get; set; }
        //Agregar el combobox (DropDownList) del combo países.
        //Se necesita agregar la referencia: System.Web. Esta librería está en Ensamblados, y se agrega como una referencia
        //que uno construyó. Se agrega el using: System.Web.UI.WebControls;
        public DropDownList cboTipoUrgencia { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public bool LlenarCombo()
        {
            SQL = "SELECT		Codigo AS ColumnaValor, Nombre AS ColumnaTexto " +
                  "FROM         tblTipoUrgencia " +
                  "ORDER BY     Nombre; ";

            //Se crea el objeto combo
            clsCombos oCombo = new clsCombos();
            //Se pasa el SQL
            oCombo.SQL = SQL;
            //Se pasa el combo vacío
            oCombo.cboGenericoWeb = cboTipoUrgencia;
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {
                //Capturo el combo lleno
                cboTipoUrgencia = oCombo.cboGenericoWeb;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                return false;
            }
        }
        #endregion
    }
}
