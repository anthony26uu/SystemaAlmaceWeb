using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb.Ui.Registros
{
    public partial class RCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         //   TextFecha.Text = (DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);

            ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
            myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
            myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
            myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
            myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);
        }

        Entidades.Clientes clienteg = new Entidades.Clientes();



        public Entidades.Clientes LlenarCampos()
        {
            clienteg.ClienteId = Utilidades.TOINT(TextBoxID.Text);
            clienteg.Nombres = TextBoxNombre.Text;
            clienteg.Email = TexboEmail.Text;
            clienteg.Cedula = TexboCedula.Text;
            clienteg.Direccion = TextBoxDireccion.Text;
            clienteg.FechaNacimiento = Convert.ToDateTime(TextFecha.Text);
            clienteg.Sexo = DropSexo.Text;


            

            return clienteg;
        }

        public void Limpiar()
        {
         
            TextBoxNombre.Text = "";
            TextFecha.Text = (DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);
            TextBoxDireccion.Text = "";
            TexboTelefono.Text = "";
            TextBoxID.Text = "";
            TexboCedula.Text = "";
            TexboEmail.Text = "";
            
            DropSexo.Text = "";

        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            int id = 0;

            if (IsValid)
            {

                clienteg = LlenarCampos();


                if (id != clienteg.ClienteId)
                {

                    if (BLL.ClientesBLL.Mofidicar(clienteg))
                    {
                        Utilidades.ShowToastr(this, "Se modifico elcliente Satisfactoriamente", "Correcto", "success");
                    }
                    else
                    {
                        Utilidades.ShowToastr(this, "No se pudo modificar el cliente", "Error", "Error");
                    }


                }
                else
                {

                    if (BLL.ClientesBLL.Guardar(clienteg))
                    {
                        Utilidades.ShowToastr(this, " Cliente Agregado", "Correcto", "success");
                    }
                    else
                    {
                        Utilidades.ShowToastr(this, "No se agrego", "Error", "error");

                    }


                }

            }
            Limpiar();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxID.Text))
            {

                Utilidades.ShowToastr(this, "Llene campo Id ", "Consejo", "info");


                Limpiar();


            }
            else
            {
                int id = int.Parse(TextBoxID.Text);
                var bll = new BLL.ClientesBLL();
                var cliente = BLL.ClientesBLL.Buscar(p => p.ClienteId == id);
                if (BLL.ClientesBLL.Eliminar(cliente))
                {

                    Utilidades.ShowToastr(this, "Cliente Eliminado con exito", "CORRECTO", "success");

                    Limpiar();
                }
                else
                {

                    Utilidades.ShowToastr(this, "No se puedo eliminar elcliente", "ERROR", "error");

                }
            }
        }

        protected void BotonBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxID.Text))
            {


                Utilidades.ShowToastr(this, "llene Campo   id", "CONSEJO", "info");

                Limpiar();
            }
            else

            {

                int id = int.Parse(TextBoxID.Text);
                var cliente = BLL.ClientesBLL.Buscar(p => p.ClienteId == id);
                if (cliente != null)
                {

                    TextFecha.Text = Convert.ToString(cliente.FechaNacimiento);
                    TextBoxNombre.Text = cliente.Nombres;
                  
                    TextBoxDireccion.Text = cliente.Direccion ;
                    DropSexo.Text = cliente.Sexo;
                    TexboEmail.Text = cliente.Email;
                  
                    TexboCedula.Text = cliente.Cedula;
                    TexboTelefono.Text = cliente.Telefono;

                    Utilidades.ShowToastr(this, "Resultados", "RESULTADOS", "success");

                }
                else
                {
                    Utilidades.ShowToastr(this, "No existe Cliente con ese ID", "ERROR", "error");

                    Limpiar();

                }
            }
        }
    }
}