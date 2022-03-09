using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace libProgramacionSoftware.ReglasNegocio
{
    public class clsRN_PromocionAgencia
    {
        #region Constructor
        public clsRN_PromocionAgencia()
        {

        }
        #endregion
        #region Propiedades/Atributos
        public string TipoDestino { private get; set; }
        public Int16 NumeroPaquetes { private get; set; }
        public double PorcentajeDescuento { get; private set; }
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public bool CalcularPorcentajeDescuento()
        {
            if (Validar())
            {
                //calcula el porcentaje de descuento
                //Para trabajar con xml, se requiere la librería de XML: System.Xml, se debe validar que esté en
                //las referencias, si no está, se debe agregar: De la carpeta Ensamblados
                //Apenas se confirme la referencia, se agrega en el using
                //Para manipular el archivo xml, se utiliza la clase XmlDocument, y se debe crear un objeto de esta
                try
                {
                    XmlDocument oDocumento = new XmlDocument();
                    //Se carga el archivo xml, con el método .Load(), con la ruta del archivo absoluta y completa
                    //Incluye el nombre del archivo y la extensión del mismo
                    oDocumento.Load(@"D:\Trabajos\ITM\2021-2\Programacion_Software\Clases\libProgramacionSoftware\XML\xmlRN_AgenciaViajes.xml");
                    //Se genera la consulta en XPath
                    string ConsultaXML = "/RN_AGENCIA_VIAJES/DESCUENTO_TIPO_DESTINO/DESCUENTO[@TIPO_DESTINO='" + TipoDestino.ToUpper() + "' and " +
                                         "@MIN<=" + NumeroPaquetes + " and @MAX>=" + NumeroPaquetes + "]";
                    //string Consulta1 = "//DESCUENTO[@TIPO_DESTINO='" + TipoDestino.ToUpper() + "' and @MIN<=" + NumeroPaquetes + " and MAX>=" + NumeroPaquetes + "]";
                    //Para aplicar la consulta, se ejecuta el método SelectNodes para múltiples respuestas, o SelectSingleNode para una única respuesta
                    //y se asignan a unas clases estáticas, que no requieren ser instanciadas, de tipo XmlNodeList, o XmlNode
                    XmlNodeList oNodos = oDocumento.SelectNodes(ConsultaXML);
                    //XmlNode oNodo = oDocumento.SelectSingleNode(ConsultaXML);
                    if (oNodos.Count == 0)
                    {
                        Error = "No se obtuvo respuesta, comuníquese con el administrador";
                        return false;
                    }
                    else
                    {
                        if (oNodos.Count > 1)
                        {
                            Error = "Se generaron más respuestas de las esperadas, comuníquese con el administrador";
                            return false;
                        }
                        else
                        {
                            //Hubo una respuesta, que es la esperada, y se calcula el porcentaje de descuento
                            PorcentajeDescuento = Convert.ToDouble(oNodos[0].InnerText) / 100;
                            return true;
                        }
                    }
                }
                catch (Exception ex)
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
            if (string.IsNullOrEmpty(TipoDestino))
            {
                Error = "No definió el tipo de destino";
                return false;
            }
            if (NumeroPaquetes < 1 || NumeroPaquetes > 20)
            {
                Error = "El número de paquetes debe estar entre 1 y 20";
                return false;
            }
            return true;
        }
        #endregion
    }
}
