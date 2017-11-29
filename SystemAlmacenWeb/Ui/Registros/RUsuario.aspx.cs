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
            Utilidades.SCritpValidacion();
            TextFecha.Text = string.Format("{0:G}", DateTime.Now);

        }
        Usuarios usuariog = new Usuarios();



        private void Limpiar()
        {


            TextBoxID.Text = "";
            TextBoxConfirm.Text = "";
            TextBoxNombre.Text = "";
            TextBoxPass.Text = "";

            TextFecha.Text = string.Format("{0:G}", DateTime.Now);
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
            int id = int.Parse(TextBoxID.Text);
            var usuar = BLL.UserBLL.Buscar(p => p.Id == id);
            var user = BLL.UserBLL.Buscar(p => p.NombreUsuario == Base.Usuario);
            if (user.Tipo != "Administrador")
            {

                Utilidades.ShowToastr(this, "No es Administrador", "Error", "error");



            }
            else
            {
                if (string.IsNullOrWhiteSpace(TextBoxID.Text))
                {


                    Utilidades.ShowToastr(this, "Llene Campo  id", "CONSEJO", "info");

                    Limpiar();
                }
                else

                {


                    if (usuar != null)
                    {


                        TextBoxNombre.Text = usuar.NombreUsuario;
                        TextBoxPass.Text = usuar.PassUsuario;
                        TextFecha.Text = Convert.ToString(usuar.FechaIngreso);
                        TextBoxConfirm.Text = usuar.PassUsuario;


                        Utilidades.ShowToastr(this, "Contraseña omitida por seguridad", "RESULTADOS", "info");

                    }
                    else
                    {
                        Utilidades.ShowToastr(this, "NO existe elementos con ID", "ERROR", "info");

                        Limpiar();

                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int id = 0;
            var user = BLL.UserBLL.Buscar(p => p.NombreUsuario == Base.Usuario);
            if (user.Tipo != "Administrador")
            {

                Utilidades.ShowToastr(this, "No es Administrador", "Error", "error");



            }
            else
            {

                if (IsValid)
                {

                    if (!validarUser())
                    {

                        Utilidades.ShowToastr(this, "Nombre de Usuario ya existe", "ERROR", "info");
                    }
                    else
                    {

                        usuariog = LlenarCampos();

                        if (TextBoxPass.Text == TextBoxConfirm.Text)
                        {

                            var usuar = BLL.UserBLL.Buscar(p => p.Id == id);
                            if (id != usuariog.Id)

                            {


                                if (BLL.UserBLL.Mofidicar(usuariog))
                                {
                                    Utilidades.ShowToastr(this, "Modificado con exito", "CORRECTO", "success");

                                }
                                else
                                {
                                    Utilidades.ShowToastr(this, "No puede Modificado ", "Error", "error");

                                }
                            }
                            else
                            {
                                if (BLL.UserBLL.Guardar(usuariog))
                                {
                                    Utilidades.ShowToastr(this, "Nuevo usuario agregado con exito", "CORRECTO", "success");

                                }
                                else
                                {
                                    Utilidades.ShowToastr(this, "Error al guardar", "ERROR", "error");

                                }


                            }
                        }



                        else
                        {
                            Utilidades.ShowToastr(this, "Campos contraseña no coniciden", "CORRECTO", "info");


                        }


                    }
                }


                Limpiar();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            var user = BLL.UserBLL.Buscar(p => p.NombreUsuario == Base.Usuario);



            if (user.Tipo != "Administrador")
            {

                Utilidades.ShowToastr(this, "No es Administrador", "Error", "error");
            }
            else
            {


                if (string.IsNullOrWhiteSpace(TextBoxID.Text))
                {

                    Utilidades.ShowToastr(this, "Campo Id vacio", "ERROR", "info");


                    Limpiar();


                }
                else
                {

                    if (user.Id == 1)
                    {
                        Utilidades.ShowToastr(this, "Usuario por defecto no se puede borrar", "Informacion", "info");

                    }
                    else

                    {
                        if (BLL.UserBLL.Eliminar(user))
                        {

                            Utilidades.ShowToastr(this, "Eliminado con exito", "CORRECTO", "success");

                            Limpiar();
                        }
                        else
                        {

                            Utilidades.ShowToastr(this, "No se puedo eliminar", "ERROR", "error");

                        }
                    }

                }
            }

        }

        protected void TextBoxConfirm_TextChanged(object sender, EventArgs e)
        {

        }
    }
}