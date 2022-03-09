using System;
using libComunes.CapaDatos;
using libComunes.CapaObjetos; //Para llenar combos y grid
using System.Web.UI.WebControls;

namespace libProgramacionSoftware.BaseDatos
{
    public class clsTipoProducto
    {
        /* Se debe compilar la libreria libComunes, y agregar la referencia del .dll al proyecto (Sólo se hace una vez)
         * Luego se agrega el using libComunes.CapaDatos en todas las clases que requieran manipular datos (CRUD) de
         * la bd
         */
        #region Constructor
        public clsTipoProducto()
        {

        }
        #endregion
        #region Atributos/Propiedades
        public Int32 Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        //Se requiere agregar una propiedad tipo "DropDownList" (Combo), y para ello hay que referenciar la clase System.Web
        //Se agrega una referencia: Se busca en Ensamblados (Assemblies) y se selecciona System.Web
        //Finalmente, se pone el using: System.Web.UI.WebControls
        public DropDownList cboTipoProducto { get; set; }
        private string SQL; //Para crear la instrucción SQL que va a ejecutar la clase clsConexion
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public bool Insertar()
        {
            //Se crea la consulta parametrizada
            SQL = "INSERT INTO tblTipoProducto (strNombre_TIPR, blnActivo_TIPR) " +
                  "VALUES (@prNombre, @prActivo)";

            //Se crea el objeto Conexión
            clsConexion oConexion = new clsConexion();
            //Se pasa la instrucción sql
            oConexion.SQL = SQL;
            //Se crean los parametros con el método agregar parámetro, el nombre del parámetro va entre comillas dobles
            //el valor es la propiedad o atributo que tiene la información que se va a asignar al parámetro.
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prActivo", Activo);

            //Se invoca el método de "Ejecutar Sentencia", porque el insert, el update y el delete no devuelven valores
            if (oConexion.EjecutarSentencia())
            {
                //Ejecutó correctamente, se devuelve true
                return true;
            }
            else
            {
                //No pudo ejecutar, se captura el error y se devuelve false
                Error = oConexion.Error;
                return false;
            }
        }
        public bool Actualizar()
        {
            SQL = "UPDATE   tblTipoProducto " +
                  "SET      strNombre_TIPR = @prNombre, " +
                           "blnActivo_TIPR = @prActivo " +
                  "WHERE    intCodigo_TIPR = @prCodigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prActivo", Activo);
            oConexion.AgregarParametro("@prCodigo", Codigo);

            if (oConexion.EjecutarSentencia())
            {
                return true;
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        public bool Borrar()
        {
            SQL = "DELETE FROM  tblTipoProducto " +
                  "WHERE        intCodigo_TIPR = @prCodigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", Codigo);

            if (oConexion.EjecutarSentencia())
            {
                return true;
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        public bool Consultar()
        {
            SQL = "SELECT       strNombre_TIPR, blnActivo_TIPR " +
                  "FROM         tblTipoProducto " +
                  "WHERE        intCodigo_TIPR = @prCodigo";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", Codigo);
            //Se invoca el método consultar, que llena el objeto Reader con la información de la consulta
            //El objeto Reader tiene una propiedad .hasRows, que indica si llegaron datos o no de la consulta
            if (oConexion.Consultar())
            {
                //Se hizo la consulta, se debe validar si retornó datos o no
                if (oConexion.Reader.HasRows)
                {
                    //Hay datos en la consulta, lo primero es leer la información con el método .Read() del objeto Reader
                    oConexion.Reader.Read();
                    //Para leer los datos, estos quedan almacenados en el objeto Reader, como si fuera un vector
                    //donde en la posicion 0 está la primer columna de la consulta
                    //Para capturar los datos de respuesta de la consulta se utiliza el método .GetValue() que es
                    //genérico, o los métodos .GetInt32(n), .GetString(n), o .GetDouble(n), etc...
                    Nombre = oConexion.Reader.GetString(0);
                    Activo = oConexion.Reader.GetBoolean(1);
                    //Se debe cerrar la conexión
                    oConexion.CerrarConexion();
                    return true;
                    //Nombre = Convert.ToString(oConexion.Reader.GetValue(0));
                    //Activo = Convert.ToBoolean(oConexion.Reader.GetValue(1));
                }
                else
                {
                    //No hay datos de la consulta, para el usuario final es un error
                    Error = "No se encontraron datos para el código: " + Codigo;
                    return false;
                }
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        public bool LlenarCombo()
        {
            //Hay que crear la instrución SQL
            SQL = "SELECT	    intCodigo_TIPR AS ColumnaValor, strNombre_TIPR AS ColumnaTexto " +
                  "FROM         tblTIpoPRoducto " +
                  "WHERE        blnActivo_TIPR = 1 " +
                  "ORDER BY     strNombre_TIPR; ";

            //Crear el objeto combo
            clsCombos oCombo = new clsCombos();
            //Se pasa el combo vacío
            oCombo.cboGenericoWeb = cboTipoProducto;
            //Se pasa el sql
            oCombo.SQL = SQL;
            //Se pasan los nombres de las columnas
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {
                cboTipoProducto = oCombo.cboGenericoWeb;
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
