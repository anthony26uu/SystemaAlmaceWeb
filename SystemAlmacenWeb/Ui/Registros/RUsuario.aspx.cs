using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb.Ui.Registros
{
    public partial class RUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
            myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
            myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
            myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
            myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);

            TextFecha.Text = (DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);
           
        }
        Usuarios usuariog = new Usuarios();

      

        private void Limpiar()
        {


            TextBoxID.Text = "";
            TextBoxConfirm.Text = "";
            TextBoxNombre.Text = "";
            TextBoxPass.Text = "";
            TextFecha.Text = (DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);
            RequiredFieldValidator1.Text = "";
            RequiredFieldValidator2.Text = "";
            RequiredFieldValidator3.Text = "";
            RequiredFieldValidator3.Text = "";
            RequiredFieldValidator5.Text = "";
            RegularExpressionValidator7.Text = "";
            DropTipo.Text = null;

        }

        public Usuarios LlenarCampos()
        {
            usuariog.Id = Utilidades.TOINT(TextBoxID.Text);
            usuariog.NombreUsuario = TextBoxNombre.Text;
            usuariog.PassUsuario = TextBoxPass.Text;
            usuariog.Tipo = DropTipo.Text;
            usuariog.FechaIngreso = Convert.ToDateTime(TextFecha.Text);
            return usuariog;
        }


        private bool validarUser()
        {
            bool retorno = true;
            Entidades.Usuarios us = new Usuarios();
            us = BLL.UserBLL.Buscar(p => p.NombreUsuario == TextBoxNombre.Text);
            if (us != null)
            {
                if (us.NombreUsuario == TextBoxNombre.Text)
                {

                    retorno = false;
                }
            }

            return retorno;
        }





        protected void BotonBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxID.Text))
            {


                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No existen elementos con este id');</script>");
                Limpiar();
            }
            else

            {

                int id = int.Parse(TextBoxID.Text);
                var usuar = BLL.UserBLL.Buscar(p => p.Id == id);
                if (usuar != null)
                {


                    TextBoxNombre.Text = usuar.NombreUsuario;
                    TextBoxPass.Text = usuar.PassUsuario;
                    TextFecha.Text = Convert.ToString(usuar.FechaIngreso);
                    TextBoxConfirm.Text = usuar.PassUsuario;
                                       
                }
                else
                {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No Existe Elementos con este id');</script>");
                    Limpiar();

                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            int id = 0;
           
                if (IsValid)
                {

                    if (!validarUser())
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Nombre de usuario ya existe');</script>");


                    }
                    else
                    {
                        usuariog= LlenarCampos();


                        if (TextBoxPass.Text == TextBoxConfirm.Text)
                        {
                            if (id != usuariog.Id)
                            {
                               if (BLL.UserBLL.Mofidicar(usuariog))
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Usuario modificado con exito');</script>");

                            }
                               else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Error al modificar');</script>");

                            }



                            }
                            else
                            {
                              if (BLL.UserBLL.Guardar(usuariog))
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Nuevo usuario agregado!');</script>");

                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No pudo ser agregado!');</script>");

                            }


                           }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Campos Contraseña no coninciden');</script>");



                        }


                    }
                }
              

                Limpiar();
         
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(TextBoxID.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No Existe Usuario con este id');</script>");



                Limpiar();


            }
            else
            {
                int id = int.Parse(TextBoxID.Text);
                var bll = new BLL.UserBLL();
                var user = BLL.UserBLL.Buscar(p => p.Id == id);
                if (BLL.UserBLL.Eliminar(user))
                {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('El Usuario se ha Eliminado  con exito');</script>");

                    Limpiar();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No se pudo eliminar El usuario');</script>");


                }
            }
        }
    }
}