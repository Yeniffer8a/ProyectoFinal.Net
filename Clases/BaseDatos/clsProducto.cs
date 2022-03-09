using System;
using libComunes.CapaDatos;
//Se requiere para invocar la clase que llena el grid
using libComunes.CapaObjetos;
//Se requiere para invocar el objeto gridView
using System.Web.UI.WebControls;

namespace libProgramacionSoftware.BaseDatos
{
    public class clsProducto
    {
        #region Constructor
        public clsProducto()
        {

        }
        #endregion
        #region Propiedades/Atributos
        public Int32 Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Int16 Cantidad { get; set; }
        public Int32 ValorUnitario { get; set; }
        public Int32 CodigoTipoProducto { get; set; }
        //Para el objeto del grid, se agrega el gridview
        public GridView grdProducto { get; set; }
        public DropDownList cboProducto { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public bool Insertar()
        {
            //Se crea la consulta parametrizada
            SQL = "INSERT INTO tblProducto (strNombre_PROD, strDescripcion_PROD, intCantidad_PROD, intValorUnitario_PROD, intCodigo_TIPR) " +
                  "VALUES (@prNombre, @prDescripcion, @prCantidad, @prValorUnitario, @prCodigoTipoProducto)";

            //Se crea el objeto Conexión
            clsConexion oConexion = new clsConexion();
            //Se pasa la instrucción sql
            oConexion.SQL = SQL;
            //Se crean los parametros con el método agregar parámetro, el nombre del parámetro va entre comillas dobles
            //el valor es la propiedad o atributo que tiene la información que se va a asignar al parámetro.
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prDescripcion", Descripcion);
            oConexion.AgregarParametro("@prCantidad", Cantidad);
            oConexion.AgregarParametro("@prValorUnitario", ValorUnitario);
            oConexion.AgregarParametro("@prCodigoTipoProducto", CodigoTipoProducto);

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
            SQL = "UPDATE   tblProducto " +
                  "SET      strNombre_PROD           = @prNombre, " +
                           "strDescripcion_PROD = @prDescripcion, " +
                           "intCantidad_PROD = @prCantidad,  " +
                           "intValorUnitario_PROD = @prValorUnitario, " +
                           "intCodigo_TIPR = @prCodigoTipoProducto " +
                  "WHERE    intCodigo_PROD = @prCodigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", Codigo);
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prDescripcion", Descripcion);
            oConexion.AgregarParametro("@prCantidad", Cantidad);
            oConexion.AgregarParametro("@prValorUnitario", ValorUnitario);
            oConexion.AgregarParametro("@prCodigoTipoProducto", CodigoTipoProducto);

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
        public bool Eliminar()
        {
            SQL = "DELETE FROM   tblProducto " +
                  "WHERE    intCodigo_PROD = @prCodigo";

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
            SQL = " SELECT      strNombre_PROD, strDescripcion_PROD, intCantidad_PROD, intValorUnitario_PROD, intCodigo_TIPR " +
                  " FROM        tblProducto " +
                  " WHERE       intCodigo_PROD = @prCodigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", Codigo);

            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    Nombre = oConexion.Reader.GetString(0);
                    Descripcion = oConexion.Reader.GetString(1);
                    Cantidad = Convert.ToInt16(oConexion.Reader.GetInt32(2));
                    ValorUnitario = oConexion.Reader.GetInt32(3);
                    CodigoTipoProducto = oConexion.Reader.GetInt32(4);

                    oConexion.CerrarConexion();
                    return true;
                }
                else
                {
                    Error = "No existen datos para el produco de código: " + Codigo;
                    return false;
                }
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        public bool LlenarGrid()
        {
            //Primero se crea el SQL
            SQL =   "SELECT			dbo.tblTIpoPRoducto.intCodigo_TIPR AS [COD TIPO PRODUCTO], " +
                                    "dbo.tblTIpoPRoducto.strNombre_TIPR AS[TIPO PRODUCTO], " +
                                    "dbo.tblPRODucto.intCodigo_PROD AS CÓDIGO, " +
				                    "dbo.tblPRODucto.strNombre_PROD AS PRODUCTO, " +
				                    "dbo.tblPRODucto.strDescripcion_PROD AS DESCRIPCIÓN, " +
				                    "dbo.tblPRODucto.intCantidad_PROD AS CANTIDAD, " +
				                    "dbo.tblPRODucto.intValorUnitario_PROD AS[VALOR UNITARIO] " +
                    "FROM           dbo.tblPRODucto INNER JOIN dbo.tblTIpoPRoducto " +
                                    "ON dbo.tblPRODucto.intCodigo_TIPR = dbo.tblTIpoPRoducto.intCodigo_TIPR " +
                    "ORDER BY       [TIPO PRODUCTO], PRODUCTO; ";

            //Se crea la clase grid
            clsGrid oGrid = new clsGrid();
            //Se pasa el grid vacío
            oGrid.grdGenerico = grdProducto;
            //Se pasa el sql
            oGrid.SQL = SQL;
            //Se invoca el método para llenar el grid
            if (oGrid.LlenarGridWeb())
            {
                //Se pasa el grid lleno
                grdProducto = oGrid.grdGenerico;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                return false;
            }
        }
        public bool LlenarCombo()
        {
            //Hay que crear la instrución SQL
            SQL =   "SELECT		intCodigo_PROD AS ColumnaValor, strNombre_PROD AS ColumnaTexto " +
                    "FROM       dbo.tblPRODucto " +
                    "WHERE       intCodigo_TIPR = @prTipoProducto " +
                    "ORDER BY    ColumnaTexto ";

            //Crear el objeto combo
            clsCombos oCombo = new clsCombos();
            //Se pasa el combo vacío
            oCombo.cboGenericoWeb = cboProducto;
            //Hay que agregar el parámetro a la clase de combos
            oCombo.AgregarParametro("@prTipoProducto", CodigoTipoProducto);
            //Se pasa el sql
            oCombo.SQL = SQL;
            //Se pasan los nombres de las columnas
            oCombo.ColumnaTexto = "ColumnaTexto";
            oCombo.ColumnaValor = "ColumnaValor";

            if (oCombo.LlenarComboWeb())
            {
                cboProducto = oCombo.cboGenericoWeb;
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
