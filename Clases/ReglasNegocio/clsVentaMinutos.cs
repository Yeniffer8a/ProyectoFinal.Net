using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProgramacionSoftware.ReglasNegocio
{
    public class clsVentaMinutos
    {
        #region Constructor
        public clsVentaMinutos()
        {
            ValorMinuto = 30;
            ValorDatos = 130;
            ValorRecarga = 0;
            ValorReferenciaDatos = 1000;
        }
        #endregion
        #region Propiedades/Atributos
        public Int32 ValorRecarga { private get; set; }
        public string NumeroCelular { private get; set; }
        public double PorcentajeExtra { get; private set; }
        public Int32 MinutosExtra { get; private set; }
        public Int32 MinutosComprados { get; private set; }
        public Int32 MinutosTotales { get; private set; }
        public Int16 DatosExtra { get; private set; }
        public Int16 DatosComprados { get; private set; }
        public Int16 DatosTotales { get; private set; }
        private Int16 ValorMinuto;
        private Int16 ValorDatos;
        private Int16 ValorReferenciaDatos;
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public bool CalcularTotal()
        {
            if (Validar())
            {
                MinutosComprados = ValorRecarga / ValorMinuto;
                DatosComprados = Convert.ToInt16 (ValorRecarga / ValorReferenciaDatos * ValorDatos);
                if (CalcularExtra())
                {
                    MinutosTotales = MinutosComprados + MinutosExtra;
                    DatosTotales = Convert.ToInt16(DatosComprados + DatosExtra);
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
        private bool CalcularExtra()
        {
            //Se debe calcular el porcentaje extra
            if (CalcularPorcentajeExtra())
            {
                MinutosExtra = Convert.ToInt32(MinutosComprados * PorcentajeExtra);
                DatosExtra = Convert.ToInt16(DatosComprados * PorcentajeExtra);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CalcularPorcentajeExtra()
        {
            //Invoca la regla de negocio
            clsRN_PromocionMinutos oPromocion = new clsRN_PromocionMinutos();
            oPromocion.ValorRecarga = ValorRecarga;
            oPromocion.NumeroCelular = NumeroCelular;

            if (oPromocion.CalcularPromocion())
            {
                PorcentajeExtra = oPromocion.PorcentajeExtra;
                return true;
            }
            else
            {
                Error = oPromocion.Error;
                return false;
            }
        }
        #endregion
    }
}
