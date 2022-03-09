using System;

namespace libProgramacionSoftware.Taller
{
    public class clsServicios
    {
        #region Constructor
        public clsServicios()
        {
            ValorAgua = 1500;
            ValorEnergia = 950;
            ValorGas = 1200;
        }
        #endregion
        #region Propiedades/Atributos
        public Int16 ConsumoAgua { private get; set; }
        public Int16 ConsumoGas { private get; set; }
        public Int16 ConsumoEnergia { private get; set; }
        public double PorcentajeCargoAgua { get; private set; }
        public double PorcentajeCargoGas { get; private set; }
        public double PorcentajeCargoEnergia { get; private set; }
        public Int32 ValorConsumoAgua { get; private set; }
        public Int32 ValorRecargoAgua { get; private set; }
        public Int32 ValorTotalAgua { get; private set; }
        public Int32 ValorConsumoGas { get; private set; }
        public Int32 ValorRecargoGas { get; private set; }
        public Int32 ValorTotalGas { get; private set; }
        public Int32 ValorConsumoEnergia { get; private set; }
        public Int32 ValorRecargoEnergia { get; private set; }
        public Int32 ValorTotalEnergia { get; private set; }
        public string TipoCobroAgua { get; private set; }
        public string TipoCobroEnergia { get; private set; }
        public string TipoCobroGas { get; private set; }
        private Int16 ValorAgua;
        private Int16 ValorEnergia;
        private Int16 ValorGas;
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public bool CalcularPagoServicios()
        {
            CalcularCargo();
            if (CalcularRecargos())
            {
                ValorTotalAgua = ValorConsumoAgua + ValorRecargoAgua;
                ValorTotalEnergia = ValorConsumoEnergia + ValorRecargoEnergia;
                ValorTotalGas = ValorConsumoGas + ValorRecargoGas;
                return true;
             }
            else
            {
                return false;
            }
        }
        private bool CalcularRecargos()
        {
            clsRN_Servicios oRNServicios = new clsRN_Servicios();
            oRNServicios.ConsumoAgua = ConsumoAgua;
            oRNServicios.ConsumoEnergia = ConsumoEnergia;
            oRNServicios.ConsumoGas = ConsumoGas;

            if (oRNServicios.CalcularRecargoServicios())
            {
                TipoCobroAgua = oRNServicios.TipoCobroAgua;
                PorcentajeCargoAgua = oRNServicios.PorcentajeCargoAgua;
                ValorRecargoAgua = Convert.ToInt32(ValorConsumoAgua * PorcentajeCargoAgua);

                TipoCobroEnergia = oRNServicios.TipoCobroEnergia;
                PorcentajeCargoEnergia = oRNServicios.PorcentajeCargoEnergia;
                ValorRecargoEnergia = Convert.ToInt32(ValorConsumoEnergia * PorcentajeCargoEnergia);

                TipoCobroGas = oRNServicios.TipoCobroGas;
                PorcentajeCargoGas = oRNServicios.PorcentajeCargoGas;
                ValorRecargoGas = Convert.ToInt32(ValorConsumoGas * PorcentajeCargoGas);
                return true;
            }
            else
            {
                Error = oRNServicios.Error;
                return false;
            }
        }
        private void CalcularCargo()
        {
            ValorConsumoAgua = ConsumoAgua * ValorAgua;
            ValorConsumoGas = ConsumoGas * ValorGas;
            ValorConsumoEnergia = ConsumoEnergia * ValorEnergia;
        }
        #endregion
    }
}
