using System;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;

namespace libProgramacionSoftware.BaseDatos
{
    public class clsEmpleado
    {
        #region Constructor
        public clsEmpleado()
        {

        }
        #endregion
        #region Propiedades/Atributos
        public DropDownList cboEmpleado { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public bool LLenarCombo()
        {
            //Hay que crear la instrución SQL
            SQL = "SELECT		dbo.tblEMpleadoCArgo.intCodigo_EMCA AS ColumnaValor, dbo.tblEMPLeado.strNombre_EMPL + ' ' " +
                                " + dbo.tblEMPLeado.strPrimerApellido_EMPL + ' ' + dbo.tblEMPLeado.strSegundoApellido_EMPL AS ColumnaTexto " +
                  "FROM         dbo.tblEMPLeado INNER JOIN dbo.tblEMpleadoCArgo " +
                                " ON dbo.tblEMPLeado.strDocumento_EMPL = dbo.tblEMpleadoCArgo.strDocumento_EMPL " +
                 "WHERE         dbo.tblEMpleadoCArgo.intCodigo_CARG = 1 " +
                 "ORDER BY    ColumnaTexto; ";

            //Crear el objeto combo
            clsCombos oCombo = new clsCombos();
            //Se pasa el combo vacío
            oCombo.cboGenericoWeb = cboEmpleado;
            //Se pasa el sql
            oCombo.SQL = SQL;
            //Se pasan los nombres de las columnas
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {
                cboEmpleado = oCombo.cboGenericoWeb;
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
