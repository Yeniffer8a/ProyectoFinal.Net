using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;using System.Text;
using System.Threading.Tasks;
using libProgramacionSoftware.ClasesBasicas;

namespace pSitioWEB_Prog.ClasesBasicas
{
    public partial class VentaProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            //1. Crear la referencia del archivo .dll en el proyecto WEB
            //   En la carpeta References (Referencias), hago click derecho y selecciono agregar referencias.
            //   En el botón Browse (Explorar) se hace click, se busca la ruta donde se generó el .dll y se 
            //   selecciona
            //2. Utilizar la palabra clave using, para que se pueda utilizar la librería en la página que se
            //   se está desarrollando. Se escribe en la parte superior de la página, junto a los demás using
            //3. Definir las variables del código y capturar la información de la interfaz
            Int16 Cantidad;
            double ValorUnitario;
            //   Para capturar la información se escribe la variable en el lado izquierdo de la igualdad, y en
            //   el derecho, el objeto que tiene la información (Textbox). Como el textbox es un texto, si la 
            //   variable donde voy a guardar la información no lo es, se debe realizar una conversión con el 
            //   objeto Convert.[Tipo dato]
            Cantidad = Convert.ToInt16(txtCantidad.Text);
            ValorUnitario = Convert.ToDouble(txtValorUnitario.Text);
            //4. Crear el objeto de la clase, crear la instancia, en C#, el objeto se crea con la siguiente
            //   sintaxis: [Nombre clase] [Nombre objeto] = new [Nombre clase]();
            clsVentaProducto oVentaProducto = new clsVentaProducto();
            //5. Definir las propiedades de entrada del objeto: 
            //   [Nombre Objeto].[Nombre Propiedad] = Variable o valor;
            oVentaProducto.Cantidad = Cantidad;
            oVentaProducto.ValorUnitario = ValorUnitario;
            //6. Invocar el método (s) público(s)
            //   Cuando es tipo void: [Nombre Objeto].[Método](); 
            //   Si retorna algo, se debe asignar a una variable, y si la variable es tipo bool, se ejecuta
            //   con una instrucción if
            oVentaProducto.CalcularTotal();
            //7. Leer las respuestas de las propiedades de salida y asignarlas a los objetos de la interfaz
            //   [Objeto gráfico].[Text] = [Nombre objeto].[Propiedad salida];
            //   Si la propiedad de salida es numérica o tipo fecha (etc), se debe convertir a tipo texto
            //   con el método .ToString(), que tienen todos los tipos de datos numéricos
            lblSubtotal.Text = "$ " + oVentaProducto.Subtotal.ToString("#,###");
            lblValorIVA.Text = "$ " + oVentaProducto.ValorIVA.ToString("#,###");
            lblTotal.Text = "$ " + oVentaProducto.Total.ToString("#,###");
        }
    }
}