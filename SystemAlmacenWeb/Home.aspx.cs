﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb
{
    public partial class Home : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

            
             
            if (!IsPostBack)
            {
              
                Utilidades.ShowToastr(this, "Bienvenido", "Hola", "success");
                LlenarUsuario();
            }

           


        }

        public  void LlenarUsuario()
        {
            
            UsuarioLabel.Text = Base.Usuario.ToString();

        }

    }
}