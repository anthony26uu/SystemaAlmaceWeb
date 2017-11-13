﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Inicio_Click(object sender, EventArgs e)
        {
            if (BLL.UserBLL.Authenticate(Textid.Text, TextPass.Text))
            {
                Home.Usuario = Textid.Text;
                FormsAuthentication.RedirectFromLoginPage(Textid.Text, true);
               // Utilidades.ShowToastr(this, "Bienvenido", "Hola", "success");

            }
            else
            {

                Utilidades.ShowToastr(this, "Usuario y/o Contraseña Incorrectas", "ERROR", "info");

            }
        }
    }
}