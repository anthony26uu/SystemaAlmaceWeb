using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 1; i++)
            {
                Utilidades.ShowToastr(this, "Bienvenido", "Hola", "success");
            }

           
            
        }
    }
}