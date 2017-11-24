using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb
{
    public partial class Base : System.Web.UI.MasterPage
    {
       
        public static string Usuario { get; set; }

    
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                TextBoxVendedor.Text = Usuario;
            }


        }

        protected void ButtonCerrarSesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            System.Web.Security.FormsAuthentication.RedirectToLoginPage();
        }
    }
}