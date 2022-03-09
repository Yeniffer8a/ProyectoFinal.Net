using System;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace libProgramacionSoftware.BaseDatos
{
    public class clsFacturacion
    {
        #region Constructor
        public clsFacturacion()
        {

        }
        #endregion
        #region Propiedades/Atributos
        public Int32 NumeroFactura { get; set; }
        public string DocumentoCliente { get; set; }
        public DateTime FechaFactura { get; set; }
        public Int32 EmpleadoCargo { get; set; }
        public Int32 CodigoDetalleFactura { get; set; }
        public Int32 Producto { get; set; }
        public Int16 Cantidad { get; set; }
        public Int32 ValorUnitario { get; set; }
        public GridView grdFacturacion { get; set; }
        public string Error { get; private set; }
        public Int32 Total { get; private set; }
        private string SQL;
        #endregion
        #region Metodos
        public bool Grabar()
        {
            if (NumeroFactura == 0)
            {
                //Es la primera vez que se invoca la clase, y por tanto se debe grabar en la tabla del encabezado (tblFactura) y en la
                //tabla del detalle tblDetalleFactura
                if (!GrabarEncabezado())
                {
                    return false;
                }
            }
            //Siempre se graba el detalle
            if (GrabarDetalle())
            {
                if (CalcularTotal())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private bool GrabarEncabezado()
        {
            //Antes de grabar se calcula el número de la factura
            if (!CalcularNumeroFactura())
            {
                return false;
            }
            //Capturo la fecha del sistema
            FechaFactura = DateTime.Now;
            //Hace un insert en la tabla tblFactura
            SQL = "INSERT INTO tblFactura (intNumero_FACT, strDocumento_CLIE, dtmFecha_FACT, intCodigo_EMCA) " +
                  "VALUES (@prNumeroFactura, @prDocumentoCliente, @prFechaFactura, @prEmpleado)";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prNumeroFactura", NumeroFactura);
            oConexion.AgregarParametro("@prDocumentoCliente", DocumentoCliente);
            oConexion.AgregarParametro("@prFechaFactura", FechaFactura);
            oConexion.AgregarParametro("@prEmpleado", EmpleadoCargo);

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
        private bool CalcularNumeroFactura()
        {
            SQL = "SELECT		MAX(isnull(intNumero_FACT, 0)) + 1 as NumeroFactura " +
                  "FROM         tblFactura"; 

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;

            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    NumeroFactura = oConexion.Reader.GetInt32(0);

                    oConexion.CerrarConexion();
                    return true;
                }
                else
                {
                    Error = "Hubo un error al calcular el número de la factura. Consulte con el admin del sistema";
                    return false;
                }
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        private bool GrabarDetalle()
        {
            //Hace un insert en la tabla tblDetalleFactura
            SQL = "INSERT INTO tblDetalleFactura (intNumero_FACT, intCodigo_PROD, intCantidad_DEFA, intValorUnitario_DEFA) " +
                  "VALUES (@prNumeroFactura, @prProducto, @prCantidad, @prValorUnitario)";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prNumeroFactura", NumeroFactura);
            oConexion.AgregarParametro("@prProducto", Producto);
            oConexion.AgregarParametro("@prCantidad", Cantidad);
            oConexion.AgregarParametro("@prValorUnitario", ValorUnitario);

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
        public bool LlenarGrid()
        {
            SQL = "SELECT		dbo.tblTIpoPRoducto.intCodigo_TIPR AS [COD TIPO PRODUCTO], dbo.tblTIpoPRoducto.strNombre_TIPR AS [TIPO PRODUCTO], " +
                                "dbo.tblPRODucto.intCodigo_PROD AS[COD PRODUCTO], dbo.tblPRODucto.strNombre_PROD AS PRODUCTO, " +
                			    "dbo.tblDEtalleFActura.intCantidad_DEFA AS CANTIDAD, dbo.tblDEtalleFActura.intValorUnitario_DEFA AS[VALOR UNITARIO], " +
                                "intValorUnitario_DEFA * intCantidad_DEFA as SUBTOTAL, dbo.tblDEtalleFActura.intCodigo_DEFA AS CÓDIGO " +
                  "FROM        dbo.tblDEtalleFActura INNER JOIN dbo.tblPRODucto " +
                                "ON dbo.tblDEtalleFActura.intCodigo_PROD = dbo.tblPRODucto.intCodigo_PROD " +
                                "INNER JOIN dbo.tblTIpoPRoducto " +
                                "ON dbo.tblPRODucto.intCodigo_TIPR = dbo.tblTIpoPRoducto.intCodigo_TIPR " +
                  "WHERE dbo.tblDEtalleFActura.intNumero_FACT = @prNumeroFactura " +
                  "ORDER BY    CÓDIGO DESC";

            //Se crea la clase grid
            clsGrid oGrid = new clsGrid();
            //Se pasa el grid vacío
            oGrid.grdGenerico = grdFacturacion;
            //Se pasa el sql
            oGrid.SQL = SQL;
            oGrid.AgregarParametro("@prNumeroFactura", NumeroFactura);
            //Se invoca el método para llenar el grid
            if (oGrid.LlenarGridWeb())
            {
                //Se pasa el grid lleno
                grdFacturacion = oGrid.grdGenerico;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                return false;
            }
        }
        private bool CalcularTotal()
        {
            SQL =   "SELECT		SUM(intCantidad_DEFA * intValorUnitario_DEFA) AS TOTAL " +
                    "FROM       dbo.tblDEtalleFActura " +
                    "WHERE      intNumero_FACT = @prNumeroFactura"; 

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prNumeroFactura", NumeroFactura);

            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    Total = oConexion.Reader.GetInt32(0);

                    oConexion.CerrarConexion();
                    return true;
                }
                else
                {
                    Error = "Hubo un error al calcular el total de la factura. Consulte con el admin del sistema";
                    return false;
                }
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        public bool ActualizarDetalle()
        {
            //Hace un insert en la tabla tblDetalleFactura
            SQL = "UPDATE       tblDetalleFactura " +
                  "SET          intCodigo_PROD = @prProducto, " +
                               "intCantidad_DEFA = @prCantidad, " +
                               "intValorUnitario_DEFA = @prValorUnitario " +
                  "WHERE        intCodigo_DEFA = @prCodigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", CodigoDetalleFactura);
            oConexion.AgregarParametro("@prProducto", Producto);
            oConexion.AgregarParametro("@prCantidad", Cantidad);
            oConexion.AgregarParametro("@prValorUnitario", ValorUnitario);

            if (oConexion.EjecutarSentencia())
            {
                if (CalcularTotal())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        public bool EliminarDetalle()
        {
            //Hace un insert en la tabla tblDetalleFactura
            SQL = "DELETE FROM      tblDetalleFactura " +
                  "WHERE            intCodigo_DEFA = @prCodigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", CodigoDetalleFactura);

            if (oConexion.EjecutarSentencia())
            {
                if (CalcularTotal())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Error = oConexion.Error;
                return false;
            }
        }
        #endregion
    }
}
