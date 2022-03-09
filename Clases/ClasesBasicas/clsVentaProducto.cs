using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Xml.Schema;

namespace libProgramacionSoftware.ClasesBasicas
{
    public class clsVentaProducto
    {
        #region Propiedades
        //Comentarios de una línea
        /*
         * Comentarios
         * de
         * múltiples
         * líneas 
         */
        public Int16 Cantidad { private get; set; }
        public double ValorUnitario { private get; set; }
        public double Total { get; private set; }
        public double ValorIVA { get; private set; }
        public double Subtotal { get; private set; }
        public string Error { get; private set; }
        #endregion
        #region Metodos
        public void CalcularTotal()
        {
            Total = ValorUnitario * Cantidad;
            //Para invocar un método que retorna un valor, se pone a la izquierda de la igualdad la propiedad
            //y a la derecha el método
            Subtotal = CalcularSubtotal();
            //Los métodos de tipo void, se invocan directamente, sin hacer asignaciones
            CalcularIVA();
        }
        private void CalcularIVA()
        {
            //El método tipo void, no retorna nada, pero modifica las propiedades/atributos de la clase
            ValorIVA = Total - Subtotal;
        }
        private double CalcularSubtotal()
        {
            double PorcentajeIVA = 0.19;
            return (Total / (1 + PorcentajeIVA));
        }
        #endregion
    }
}
