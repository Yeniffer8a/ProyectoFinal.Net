using System;
using System.Xml;

namespace libProgramacionSoftware.Taller
{
    public class clsRN_Servicios
    {
        #region Constructor
        public clsRN_Servicios()
        {

        }
        #endregion
        #region Propiedades/Atributos
        public Int16 ConsumoAgua { private get; set; }
        public Int16 ConsumoGas { private get; set; }
        public Int16 ConsumoEnergia { private get; set; }
        public double PorcentajeCargoAgua { get; private set; }
        public double PorcentajeCargoGas { get; private set; }
        public double PorcentajeCargoEnergia { get; private set; }
        public string TipoCobroAgua { get; private set; }
        public string TipoCobroEnergia { get; private set; }
        public string TipoCobroGas { get; private set; }
        private double PorcentajeCargo;
        private string TipoCobro;
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public bool CalcularRecargoServicios()
        {
            if (CalcularRecargo("Agua", ConsumoAgua)) 
            {
                PorcentajeCargoAgua = PorcentajeCargo;
                TipoCobroAgua = TipoCobro;
            } 
            else { return false; }
            if (CalcularRecargo("Gas", ConsumoGas)) 
            {
                PorcentajeCargoGas = PorcentajeCargo;
                TipoCobroGas = TipoCobro;
            } 
            else { return false; }
            if (CalcularRecargo("Energia", ConsumoEnergia)) 
            { 
                PorcentajeCargoEnergia = PorcentajeCargo;
                TipoCobroEnergia = TipoCobro;
            } 
            else { return false; }
            return true;
        }
        private bool CalcularRecargo(string TipoServicio, Int16 Consumo)
        {
            try
            {
                XmlDocument oDocumento = new XmlDocument();
                oDocumento.Load(@"D:\Trabajos\ITM\2021-2\Programacion_Software\Clases\libProgramacionSoftware\XML\xmlRN_Servicios.xml");
                string ConsultaXML = "//COBRO[@SERVICIO='" + TipoServicio.ToUpper() + "' and @MIN<" + Consumo + " and @MAX>=" + Consumo + "]";
                
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
                        PorcentajeCargo = Convert.ToDouble(oNodos[0].InnerText) / 100;
                        TipoCobro = oNodos[0].Attributes["TIPO_COBRO"].Value;
                        /*
                        if (PorcentajeCargo < 0)
                        {
                            TipoCobro = "DESCUENTO";
                        }
                        else
                        {
                            if (PorcentajeCargo == 0)
                            {
                                TipoCobro = "SIN DESCUENTO NI RECARGO";
                            }
                            else
                            {
                                TipoCobro = "CON RECARGO";
                            }
                        }
                        */
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
        #endregion
    }
}
