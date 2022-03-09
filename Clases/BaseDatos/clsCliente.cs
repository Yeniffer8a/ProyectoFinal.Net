using System;
using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace libProgramacionSoftware.BaseDatos
{
    public class clsCliente
    {
        #region Constructor
        public clsCliente()
        {

        }
        #endregion
        #region Propiedades/Atributos
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NombreApellidos
        {
            get{ return Nombre + " " + PrimerApellido + " " + SegundoApellido;}
        }
        public string ApellidosNombre
        {
            get { return PrimerApellido + " " + SegundoApellido + " " + Nombre; }
        }
        public string Direccion { get; set; }
        public GridView grdClientes { get; set; }
        public GridView grdTelefonos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        private string SQL;
        public string Error { get; private set; }
        public Int32 CodigoTelefono { get; set; }
        public string NumeroTelefono { get; set; }
        public Int32 TipoTelefono { get; set; }
        #endregion
        #region Metodos
        public bool Insertar()
        {
            SQL = "INSERT INTO tblCliente (strDocumento_CLIE, strNombre_CLIE, strPrimerApellido_CLIE, strSegundoApellido_CLIE, " +
                                           "strDireccion_CLIE, FechaNacimiento) "+
                  "VALUES (@prDocumento, @prNombre, @prPrimerApellido, @prSegundoApellido, @prDireccion, @prFechaNacimiento)";

            clsConexion oConexion = new clsConexion();
            
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prPrimerApellido", PrimerApellido);
            oConexion.AgregarParametro("@prSegundoApellido", SegundoApellido);
            oConexion.AgregarParametro("@prDireccion", Direccion);
            oConexion.AgregarParametro("@prFechaNacimiento", FechaNacimiento);

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
        public bool Actualizar()
        {
            SQL = "UPDATE       tblCliente " +
                  "SET          strNombre_CLIE=@prNombre, " +
                               "strPrimerApellido_CLIE=@prPrimerApellido, " +
                               "strSegundoApellido_CLIE=@prSegundoApellido, " +
                               "strDireccion_CLIE=@prDireccion, " +
                               "FechaNacimiento=@prFechaNacimiento " +
                 "WHERE         strDocumento_CLIE=@prDocumento";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prPrimerApellido", PrimerApellido);
            oConexion.AgregarParametro("@prSegundoApellido", SegundoApellido);
            oConexion.AgregarParametro("@prDireccion", Direccion);
            oConexion.AgregarParametro("@prFechaNacimiento", FechaNacimiento);

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
            SQL = "DELETE FROM tblCliente WHERE strDocumento_CLIE=@prDocumento";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);

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
            SQL = " SELECT       strNombre_CLIE, strPrimerApellido_CLIE, strSegundoApellido_CLIE, " +
                               "strDireccion_CLIE, isnull(FechaNacimiento, '1900/01/01') as FechaNacimiento " +
                  " FROM         tblCliente " +
                  " WHERE        strDocumento_CLIE=@prDocumento";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);

            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    Nombre = oConexion.Reader.GetString(0);
                    PrimerApellido = oConexion.Reader.GetString(1);
                    SegundoApellido = oConexion.Reader.GetString(2);
                    Direccion = oConexion.Reader.GetString(3);
                    FechaNacimiento = oConexion.Reader.GetDateTime(4);

                    oConexion.CerrarConexion();
                    return true;
                }
                else
                {
                    Error = "No existen datos para el cliente de documento: " + Documento;
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
            SQL = "SELECT			dbo.tblCLIEnte.strDocumento_CLIE AS DOCUMENTO, dbo.tblCLIEnte.strNombre_CLIE + ' ' + " +
                                    "dbo.tblCLIEnte.strPrimerApellido_CLIE + ' ' + dbo.tblCLIEnte.strSegundoApellido_CLIE AS CLIENTE, " +
                                    "dbo.tblCLIEnte.strDireccion_CLIE AS DIRECCIÓN, dbo.tblCLIEnte.FechaNacimiento AS[FECHA NACIMIENTO], " +
                                    "COUNT(dbo.tblTELEfono.strNumero_TELE) AS [NRO TELEFONOS] " +
                  "FROM            dbo.tblTIpoTElefono INNER JOIN dbo.tblTELEfono " +
                                    "ON dbo.tblTIpoTElefono.intCodigo_TITE = dbo.tblTELEfono.intCodigo_TITE " +
                                    "RIGHT OUTER JOIN dbo.tblCLIEnte " +
                                    "ON dbo.tblTELEfono.strDocumento_CLIE = dbo.tblCLIEnte.strDocumento_CLIE " +
                  "GROUP BY        dbo.tblCLIEnte.strDocumento_CLIE, dbo.tblCLIEnte.strNombre_CLIE + ' ' + dbo.tblCLIEnte.strPrimerApellido_CLIE " +
                                    "+ ' ' + dbo.tblCLIEnte.strSegundoApellido_CLIE, dbo.tblCLIEnte.strDireccion_CLIE, " +
                                    "dbo.tblCLIEnte.FechaNacimiento " +
                  "ORDER BY         CLIENTE";

            //Se crea la clase grid
            clsGrid oGrid = new clsGrid();
            //Se pasa el grid vacío
            oGrid.grdGenerico = grdClientes;
            //Se pasa el sql
            oGrid.SQL = SQL;
            //Se invoca el método para llenar el grid
            if (oGrid.LlenarGridWeb())
            {
                //Se pasa el grid lleno
                grdClientes = oGrid.grdGenerico;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                return false;
            }
        }
        public bool LlenarGridTelefonos()
        {
            SQL = "SELECT		dbo.tblTIpoTElefono.intCodigo_TITE AS [COD TIPO TELÉFONO], " +
                               " dbo.tblTIpoTElefono.strNombre_TITE AS[TIPO TELÉFONO], " +
                               " dbo.tblTELEfono.intCodigo_TELE AS CÓDIGO, " +
                               " dbo.tblTELEfono.strNumero_TELE AS TELÉFONO " +
                    "FROM        dbo.tblTELEfono INNER JOIN dbo.tblTIpoTElefono " +
                               " ON dbo.tblTELEfono.intCodigo_TITE = dbo.tblTIpoTElefono.intCodigo_TITE " +
                    "WHERE dbo.tblTELEfono.strDocumento_CLIE = @prDocumento " +
                    " ORDER BY[TIPO TELÉFONO], TELÉFONO;";

            //Se crea la clase grid
            clsGrid oGrid = new clsGrid();
            //Se pasa el grid vacío
            oGrid.grdGenerico = grdTelefonos;
            //Se pasa el sql
            oGrid.SQL = SQL;
            oGrid.AgregarParametro("@prDocumento", Documento);
            //Se invoca el método para llenar el grid
            if (oGrid.LlenarGridWeb())
            {
                //Se pasa el grid lleno
                grdTelefonos = oGrid.grdGenerico;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                return false;
            }
        }
        public bool InsertarTelefono()
        {
            SQL = "INSERT INTO tblTelefono (strNumero_TELE, strDocumento_CLIE, intCodigo_TITE) " +
                  "VALUES (@NumeroTelefono, @prDocumento, @prTipoTelefono)";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@NumeroTelefono", NumeroTelefono);
            oConexion.AgregarParametro("@prDocumento", Documento);
            oConexion.AgregarParametro("@prTipoTelefono", TipoTelefono);

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
        public bool ActualizarTelefono()
        {
            SQL = "UPDATE       tblTelefono " +
                  "SET          strNumero_TELE = @NumeroTelefono, " +
                               "strDocumento_CLIE = @prDocumento, " +
                               "intCodigo_TITE = @prTipoTelefono " +
                  "WHERE        intCodigo_TELE = @prCodigoTelefono";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigoTelefono", CodigoTelefono);
            oConexion.AgregarParametro("@NumeroTelefono", NumeroTelefono);
            oConexion.AgregarParametro("@prDocumento", Documento);
            oConexion.AgregarParametro("@prTipoTelefono", TipoTelefono);

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
        public bool EliminarTelefono()
        {
            SQL = "DELETE FROM  tblTelefono " +
                  "WHERE        intCodigo_TELE = @prCodigoTelefono";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigoTelefono", CodigoTelefono);

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
        #endregion
    }
}
