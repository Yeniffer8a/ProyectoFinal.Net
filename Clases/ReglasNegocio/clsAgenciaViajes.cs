using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace libProgramacionSoftware.ReglasNegocio
{
    public class clsAgenciaViajes
    {
        #region Constructor
        public clsAgenciaViajes()
        {
            NumeroPaquetes = 0;
            PorcentajeIVA = 0.19;
            ValorDolar = 3850;
        }
        #endregion
        #region Propiedades/Atributos
        public string CiudadDestino { private get; set; }
        public Int16 NumeroPaquetes { private get; set; }
        public double TotalPagar { get; private set; }
        public double ValorDescuento { get; private set; }
        public double ValorIVA { get; private set; }
        public double ValorAntesDescuento { get; private set; }
        public double ValorAntesIVA { get; private set; }
        public string Error { get; private set; }
        private double ValorDolar;
        private double ValorPaquete;
        private double PorcentajeDescuento;
        private double PorcentajeIVA;
        private string MonedaPaquete;
        private string TipoDestino;
        #endregion
        #region Metodos
        public bool CalcularTotal()
        {
            if (Validar())
            {
                if (CalcularValorPaquete())
                {
                    ConvertirMoneda();
                    ValorAntesDescuento = NumeroPaquetes * ValorPaquete;
                    if (CalcularDescuento())
                    {
                        TotalPagar = ValorAntesDescuento - ValorDescuento;
                        CalcularSubtotal();
                        CalcularIVA();
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
            else
            {
                return false;
            }
        }
        private bool Validar()
        {
            if (NumeroPaquetes < 1 || NumeroPaquetes > 20)
            {
                Error = "El número de paquetes debe estar entre 1 y 20";
                return false;
            }
            if (string.IsNullOrEmpty(CiudadDestino))
            {
                Error = "No definió la ciudad de destino";
                return false;
            }
            return true;
        }
        private void ConvertirMoneda()
        {
            if (MonedaPaquete.ToUpper() == "DOLAR")
            {
                ValorPaquete = ValorPaquete * ValorDolar;
            }
        }
        private void CalcularIVA()
        {
            ValorIVA = TotalPagar - ValorAntesIVA;
        }
        private void CalcularSubtotal()
        {
            ValorAntesIVA = TotalPagar / (1 + PorcentajeIVA);
        }
        private bool CalcularDescuento()
        {
            //Este método invoca la regla de negocio. Se crea un objeto de la clase de la regla de negocio, se le pasan
            //las propiedades, se invoca el método(s) y se lee la(s) respuesta(s)
            clsRN_PromocionAgencia oPromocion = new clsRN_PromocionAgencia();
            oPromocion.TipoDestino = TipoDestino;
            oPromocion.NumeroPaquetes = NumeroPaquetes;
            if (oPromocion.CalcularPorcentajeDescuento())
            {
                //Si ejecuta bien, leo la respuesta. Porcentaje de descuento
                PorcentajeDescuento = oPromocion.PorcentajeDescuento;
                //Con el porcentaje se calcula el descuento
                ValorDescuento = ValorAntesDescuento * PorcentajeDescuento;
                return true;
            }
            else
            {
                //Si no ejecuta bien, se debe leer el error del objeto y retornar false
                Error = oPromocion.Error;
                return false;
            }
        }
        private bool CalcularValorPaquete()
        {
            switch (CiudadDestino.ToUpper())
            {
                case "MIAMI":
                    MonedaPaquete = "Dolar";
                    TipoDestino = "Internacional";
                    ValorPaquete = 1000;
                    return true;
                case "ORLANDO":
                    MonedaPaquete = "Dolar";
                    TipoDestino = "Internacional";
                    ValorPaquete = 2500;
                    return true;
                case "CANCUN":
                    MonedaPaquete = "Dolar";
                    TipoDestino = "Internacional";
                    ValorPaquete = 1500;
                    return true;
                case "CANCÚN":
                    MonedaPaquete = "Dolar";
                    TipoDestino = "Internacional";
                    ValorPaquete = 1500;
                    return true;
                case "CUBA":
                    MonedaPaquete = "Dolar";
                    TipoDestino = "Internacional";
                    ValorPaquete = 1200;
                    return true;
                case "CARTAGENA":
                    MonedaPaquete = "Peso Colombiano";
                    TipoDestino = "Nacional";
                    ValorPaquete = 1800000;
                    return true;
                case "SAN ANDRÉS":
                    MonedaPaquete = "Peso Colombiano";
                    TipoDestino = "Nacional";
                    ValorPaquete = 2350000;
                    return true;
                case "BOGOTÁ":
                    MonedaPaquete = "Peso Colombiano";
                    TipoDestino = "Nacional";
                    ValorPaquete = 1120000;
                    return true;
                case "ARMENIA":
                    MonedaPaquete = "Peso Colombiano";
                    TipoDestino = "Nacional";
                    ValorPaquete = 1450000;
                    return true;
                default:
                    Error = "No definió una ciudad que se tenga disponible en la agencia";
                    return false;
            }
        }
        #endregion
    }
}
