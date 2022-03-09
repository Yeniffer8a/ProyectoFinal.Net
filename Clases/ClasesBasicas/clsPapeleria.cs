using System;


namespace libProgramacionSoftware.ClasesBasicas
{
    public class clsPapeleria
    {
        #region Constructor
        // El constructor se define: public [Nombre Clase](){}
        public clsPapeleria()
        {
            // Se inicializan las variables de entrada que se quieren validar y los atributos que trabajan
            // como constantes en la clase
            CantidadFotocopiasByN = 0;
            CantidadFotocopiasColor = 0;
            CantidadImpresionesByN = 0;
            CantidadImpresionesColor = 0;
            PrecioFotocopiaByN = 300;
            PrecioFotocopiaColor = 500;
            PrecioImpresionByN = 380;
            PrecioImpresionColor = 800;
            PorcentajeIVA = 0.19;
        }
        #endregion
        #region Propiedades/Atributos
        public Int16 CantidadFotocopiasColor { private get; set; }
        public Int16 CantidadFotocopiasByN { private get; set; }
        public Int16 CantidadImpresionesColor { private get; set; }
        public Int16 CantidadImpresionesByN { private get; set; }
        public double Total { get; private set; }
        public double Subtotal { get; private set; }
        public double ValorIVA { get; private set; }
        public string Error { get; private set; }
        private double PorcentajeIVA;
        private Int16 PrecioFotocopiaColor;
        private Int16 PrecioFotocopiaByN;
        private Int16 PrecioImpresionColor;
        private Int16 PrecioImpresionByN;
        #endregion
        #region Metodos
        public bool CalcularTotal()
        {
            //El primer paso es validar
            if (Validar())
            {
                //Se ejecuta el proceso, la validación es correcta y están todos los valores
                Total = CalcularCostoFotocopias() + CalcularCostoImpresiones();
                CalcularSubtotal();
                CalcularValorIVA();
                return true;
            }
            else
            {
                //Hubo un error, no se debe ejecutar más
                return false;
            }
        }
        private bool Validar()
        {
            //El método validar verifica los datos de entrada, y si están correctos, se debe continuar con la ejecución
            //de los demás métodos
            //El or lógico de C# es ||
            //El and lógico de C# es &&
            if (CantidadFotocopiasByN < 0 || CantidadFotocopiasByN > 50)
            {
                Error = "No definió una cantidad válida para las fotocopias a blanco y negro.\nDebe ingresar " +
                        "un número entre 0 y 50";
                return false;
            }
            if (CantidadFotocopiasColor < 0 || CantidadFotocopiasColor > 50)
            {
                Error = "No definió una cantidad válida para las fotocopias a color.\nDebe ingresar " +
                        "un número entre 0 y 50";
                return false;
            }
            if (CantidadImpresionesByN < 0 || CantidadImpresionesByN > 50)
            {
                Error = "No definió una cantidad válida para las impresiones a blanco y negro.\nDebe ingresar " +
                        "un número entre 0 y 50";
                return false;
            }
            if (CantidadImpresionesColor < 0 || CantidadImpresionesColor > 50)
            {
                Error = "No definió una cantidad válida para las impresiones a color.\nDebe ingresar " +
                        "un número entre 0 y 50";
                return false;
            }
            if (CantidadFotocopiasByN == 0 && CantidadFotocopiasColor == 0 && CantidadImpresionesByN == 0 && CantidadImpresionesColor == 0)
            {
                Error = "Al menos un valor de las fotocopias o las impresiones debe ser mayor que cero.";
                return false;
            }
            return true;
        }
        private double CalcularCostoFotocopias()
        {
            return CantidadFotocopiasByN * PrecioFotocopiaByN + CantidadFotocopiasColor * PrecioFotocopiaColor;
        }
        private double CalcularCostoImpresiones()
        {
            return CantidadImpresionesByN * PrecioImpresionByN + CantidadImpresionesColor * PrecioImpresionColor;
        }
        private void CalcularSubtotal()
        {
            Subtotal = Total / (1 + PorcentajeIVA);
        }
        private void CalcularValorIVA()
        {
            ValorIVA = Total - Subtotal;
        }
        #endregion
    }
}
