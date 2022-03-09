using System;
using libComunes.CapaDatos; //Para hacer el CRUD
using libComunes.CapaObjetos; //Para utilizar la clase clsGrid 
using System.Web.UI.WebControls; //Para utilizar el gridview

namespace libExamen4.Examen_4
{
    public class clsUrgencia
    {
        #region Constructor
        public clsUrgencia()
        {

        }
        #endregion
        #region Propiedades/Atributos
        public Int32 Codigo { get; set; }
        public string DocumentoPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public string NombreAcompañante { get; set; }
        public DateTime FechaHora { get; set; }
        public GridView grdUrgencia { get; set; }
        public string EPS { get; set; }
        public Int32 TipoUrgencia { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public bool LlenarGrid()
        {
            //Se crea la instrucción sql
            SQL = "SELECT		dbo.tblTipoUrgencia.Codigo AS [COD TIPO URGENCIA], dbo.tblTipoUrgencia.Nombre AS [TIPO URGENCIA], " +
                                "dbo.tblUrgencia.Codigo AS CÓDIGO, dbo.tblUrgencia.DocumentoPaciente AS DOCUMENTO, " +
			                    "dbo.tblUrgencia.NombrePaciente AS PACIENTE, dbo.tblUrgencia.NombreAcompañante AS ACOMPAÑANTE, " +
			                    "dbo.tblUrgencia.FechaHora AS FECHA, dbo.tblUrgencia.EPS " +
                    "FROM        dbo.tblTipoUrgencia INNER JOIN dbo.tblUrgencia " +
                                "ON dbo.tblTipoUrgencia.Codigo = dbo.tblUrgencia.CodigoTipoUrgencia; ";

            //Se crea el objeto grid
            clsGrid oGrid = new clsGrid();
            //Paso el sql y el grid vacío
            oGrid.SQL = SQL;
            oGrid.grdGenerico = grdUrgencia;
            //Invocar el llenado del grid
            if (oGrid.LlenarGridWeb())
            {
                //lee el grid lleno
                grdUrgencia = oGrid.grdGenerico;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                return false;
            }
        }
        public bool Insertar()
        {
            SQL = "INSERT INTO tblUrgencia (DocumentoPaciente, NombrePaciente, NombreAcompañante, FechaHora, EPS, CodigoTipoUrgencia) " +
                  "VALUES (@prDocumento, @prNombrePaciente, @prNombreAcompañante, @prFechaHora, @prEPS, @prTipoUrgencia)";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", DocumentoPaciente);
            oConexion.AgregarParametro("@prNombrePaciente", NombrePaciente);
            oConexion.AgregarParametro("@prNombreAcompañante", NombreAcompañante);
            oConexion.AgregarParametro("@prFechaHora", FechaHora);
            oConexion.AgregarParametro("@prEPS", EPS);
            oConexion.AgregarParametro("@prTipoUrgencia", TipoUrgencia);

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
            SQL = "UPDATE       tblUrgencia " +
                  "SET          DocumentoPaciente = @prDocumento, " +
                               "NombrePaciente = @prNombrePaciente, " +
                               "NombreAcompañante = @prNombreAcompañante, " +
                               "FechaHora = @prFechaHora, " +
                               "EPS = @prEPS, " +
                               "CodigoTipoUrgencia = @prTipoUrgencia " +
                  "WHERE        Codigo = @prCodigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", Codigo);
            oConexion.AgregarParametro("@prDocumento", DocumentoPaciente);
            oConexion.AgregarParametro("@prNombrePaciente", NombrePaciente);
            oConexion.AgregarParametro("@prNombreAcompañante", NombreAcompañante);
            oConexion.AgregarParametro("@prFechaHora", FechaHora);
            oConexion.AgregarParametro("@prEPS", EPS);
            oConexion.AgregarParametro("@prTipoUrgencia", TipoUrgencia);

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
            SQL = "DELETE FROM  tblUrgencia " +
                  "WHERE        Codigo = @prCodigo";

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
        #endregion
    }
}

