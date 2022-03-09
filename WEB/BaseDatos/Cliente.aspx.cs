using System;
using libProgramacionSoftware.BaseDatos;

namespace pSitioWEB_Prog.BaseDatos
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarGridClientes();
            }
        }
        private void LlenarGridClientes()
        {
            clsCliente oCliente = new clsCliente();
            oCliente.grdClientes = grdClientes;
            if (!oCliente.LlenarGrid())
            {
                lblError.Text = oCliente.Error;
            }
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string Documento, Nombre, PrimerApellido, SegundoApellido, Direccion;
            DateTime FechaNacimiento;

            Documento = txtDocumento.Text;
            Nombre = txtNombre.Text;
            PrimerApellido = txtPrimerApellido.Text;
            SegundoApellido = txtSegundoApellido.Text;
            Direccion = txtDireccion.Text;
            FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);

            clsCliente oCliente = new clsCliente();

            oCliente.Documento = Documento;
            oCliente.Nombre = Nombre;
            oCliente.PrimerApellido = PrimerApellido;
            oCliente.SegundoApellido = SegundoApellido;
            oCliente.Direccion = Direccion;
            oCliente.FechaNacimiento = FechaNacimiento;

            if (oCliente.Insertar())
            {
                lblError.Text = "Se ingresó el cliente de documento: " + Documento + " a la base de datos";
                LlenarGridClientes();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string Documento, Nombre, PrimerApellido, SegundoApellido, Direccion;
            DateTime FechaNacimiento;

            Documento = txtDocumento.Text;
            Nombre = txtNombre.Text;
            PrimerApellido = txtPrimerApellido.Text;
            SegundoApellido = txtSegundoApellido.Text;
            Direccion = txtDireccion.Text;
            FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);

            clsCliente oCliente = new clsCliente();

            oCliente.Documento = Documento;
            oCliente.Nombre = Nombre;
            oCliente.PrimerApellido = PrimerApellido;
            oCliente.SegundoApellido = SegundoApellido;
            oCliente.Direccion = Direccion;
            oCliente.FechaNacimiento = FechaNacimiento;

            if (oCliente.Actualizar())
            {
                lblError.Text = "Se actualizaron los datos del cliente de documento: " + Documento + " a la base de datos";
                LlenarGridClientes();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            string Documento;

            Documento = txtDocumento.Text;
            
            clsCliente oCliente = new clsCliente();

            oCliente.Documento = Documento;
            
            if (oCliente.Eliminar())
            {
                lblError.Text = "Se eliminó el cliente de documento: " + Documento + " de la base de datos";
                LlenarGridClientes();
            }
            else
            {
                lblError.Text = oCliente.Error;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            string Documento;

            Documento = txtDocumento.Text;

            clsCliente oCliente = new clsCliente();

            oCliente.Documento = Documento;

            if (oCliente.Consultar())
            {
                txtNombre.Text = oCliente.Nombre;
                txtPrimerApellido.Text = oCliente.PrimerApellido;
                txtSegundoApellido.Text = oCliente.SegundoApellido;
                txtDireccion.Text = oCliente.Direccion;
                txtFechaNacimiento.Text = oCliente.FechaNacimiento.ToString("yyyy-MM-dd");

                lblError.Text = "Se consultó la información";
            }
            else
            {
                lblError.Text = oCliente.Error;

                txtNombre.Text = "";
                txtPrimerApellido.Text = "";
                txtSegundoApellido.Text = "";
                txtDireccion.Text = "";
                txtFechaNacimiento.Text = "";
            }
        }

        protected void grdClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Variables de sesión en WEB permiten la persistencia de valores a lo largo de la sesión
            //Las variables de sesión son de tipo "Objeto", es decir, no tienen un tipo de dato simple, sino complejo para que reciba
            //cualquier cosa. Son muy pesadas, y se deben manejar con cuidado
            //Se definen con el objeto Session["Nombre Variable"] = Valor;
            //Se leen: Variable = Session["Nombre variable"];
            //Se obtienen los datos del cliente al que se le van a gestionar los teléfonos
            //Dimensionar las variables que se quieren capturar
            string Documento, Nombre, Direccion, FechaNacimiento;

            //Se capturan los datos del grid
            Documento = grdClientes.SelectedRow.Cells[1].Text;
            //Se graba como una variable de sesión
            Session["Documento"] = Documento;
            Nombre = grdClientes.SelectedRow.Cells[2].Text;
            Direccion = grdClientes.SelectedRow.Cells[3].Text;
            FechaNacimiento = grdClientes.SelectedRow.Cells[4].Text;

            //Para navegar entre páginas (Desde el servidor), se utiliza el objeto Response, con el método .Redirect();
            //Se pone la ruta de la página donde se quiere navegar, ruta puede ser absoluta o relativa.
            //Para pasar parámetros a otra página, se termina la página que se llama con el símbolo "?" y se agrega el primer
            //parámetro con su valor, los siguientes parámetros se agregan con el símbolo "&"
            //Ejemplo: Navegar a la página Empleado, con el documento y nombre del empleado:
            //         Empleado.aspx?Documento=101010&Nombre=Juan Fernando Castro
            string PaginaNavegar;
            //Ejemplo con el documento como parámetro
            //PaginaNavegar = "TelefonoCliente.aspx?Documento=" + Documento + "&Nombre=" + Nombre + "&Direccion=" + 
            //                 Direccion + "&Fecha=" + FechaNacimiento;
            //Ejemplo con el documento como variable de sesión
            PaginaNavegar = "TelefonoCliente.aspx?Nombre=" + Nombre + "&Direccion=" + Direccion + "&Fecha=" + FechaNacimiento;
            Response.Redirect(PaginaNavegar);
        }
    }
}