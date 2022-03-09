using System;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace libProgramacionSoftware.BaseDatos
{
    public class clsTipoTelefono
    {
        #region Constructor
        public clsTipoTelefono()
        {

        }
        #endregion
        //sólo se está haciendo el código de llenar el combo, no se agregan más atributos
        #region Propiedades/Atributos
        public DropDownList cboTipoTelefono { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public bool LlenarCombo()
        {
            //Hay que crear la instrución SQL
            SQL = "SELECT	    intCodigo_TITE AS ColumnaValor, strNombre_TITE AS ColumnaTexto " +
                  "FROM         tblTIpoTElefono " +
                  "WHERE        blnActivo_TITE = 1 " +
                  "ORDER BY     strNombre_TITE; ";

            //Crear el objeto combo
            clsCombos oCombo = new clsCombos();
            //Se pasa el combo vacío
            oCombo.cboGenericoWeb = cboTipoTelefono;
            //Se pasa el sql
            oCombo.SQL = SQL;
            //Se pasan los nombres de las columnas
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {
                cboTipoTelefono = oCombo.cboGenericoWeb;
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
