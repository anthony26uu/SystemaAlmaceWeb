using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Inicio_Click(object sender, EventArgs e)
        {

           if( BLL.UserBLL.Authenticate(Textid.Text, TextPass.Text))
            {
               
                FormsAuthentication.RedirectFromLoginPage(Textid.Text, true);
              
            }
            else
            {
               
                Utilidades.ShowToastr(this, "Usuario y/o Contraseña Incorrectas", "ERROR", "info");

            }
            
        }
    }
}