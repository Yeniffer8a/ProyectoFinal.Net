using System;
using System.Globalization;
using System.Xml;

namespace libProgramacionSoftware.ReglasNegocio
{
    public class clsRN_PromocionMinutos
    {
        #region Constructor
        public clsRN_PromocionMinutos()
        {
            ValorRecarga = 0;
        }
        #endregion
        #region Propiedades/Atributos
        public Int32 ValorRecarga { private get; set; }
        public string NumeroCelular { private get; set; }
        public double PorcentajeExtra { get; private set; }
        public string Error { get; private set; }
        private string DiaSemana;
        private string UltimoDigito;
        #endregion
        #region Metodos
        public bool CalcularPromocion()
        {
            if (Validar())
            {
                CalcularDiaSemana();
                CalcularUltimoDigito();
                try
                {
                    XmlDocument oDocumento = new XmlDocument();
                    oDocumento.Load(@"D:\Trabajos\ITM\2021-2\Programacion_Software\Clases\libProgramacionSoftware\XML\xmlRN_VentaMinutos.xml");
                    string ConsultaXML = "//PROMOCION[@DIA='" + DiaSemana.ToUpper() + "' and @DIGITO=" + UltimoDigito + " and @MIN<=" + 
                                          ValorRecarga + " and @MAX>=" + ValorRecarga + "]";
                    /*XmlNode oNodo = oDocumento.SelectSingleNode(ConsultaXML);
                    PorcentajeExtra = Convert.ToDouble(oNodo.InnerText) / 100;
                    return true;
                    */
                    XmlNodeList oNodos = oDocumento.SelectNodes(ConsultaXML);
                    if (oNodos.Count == 0)
                    {
                        Error = "No se encontró una respuesta válida, por favor consulte con el admin del sistema";
                        return false;
                    }
                    else
                    {
                        if (oNodos.Count > 1)
                        {
                            Error = "Se encontraron varias respuestas, por favor consulte con el admin del sistema";
                            return false;
                        }
                        else
                        {
                            PorcentajeExtra = Convert.ToDouble(oNodos[0].InnerText) / 100;
                            return true;
                        }
                    }
                }
                catch(Exception ex)
                {
                    Error = ex.Message;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private bool Validar()
        {
            if (ValorRecarga < 1000 || ValorRecarga > 60000)
            {
                Error = "El valor de la recarga no es válido, por favor ingrese un número entre $1.000 y $60.000";
                return false;
            }
            if (string.IsNullOrEmpty(NumeroCelular))
            {
                Error = "No definió el número de celular";
                return false;
            }
            return true;
        }
        private void CalcularUltimoDigito()
        {
            //La función substring captura una parte de la cadena, iniciando en una posición, y va hasta el final o 
            //el número de caracteres seleccionados
            //La función .Length del substring, permite capturar el tamaño de caracteres de la cadena
            UltimoDigito = NumeroCelular.Substring(NumeroCelular.Length - 1);
        }
        private void CalcularDiaSemana()
        {
            //Para encontrar el día de la semana en español, o en otro idioma que no sea en inglés, se debe utilizar
            //la librería CultureInfo
            CultureInfo oCultura = new CultureInfo("Es-Es");
            DiaSemana = oCultura.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
        }
        #endregion
    }
}
