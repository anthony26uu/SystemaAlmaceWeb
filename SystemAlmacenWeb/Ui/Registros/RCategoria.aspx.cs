using BLL;
using Entidades;
using ProyectoTech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb.Ui.Registros
{
    public partial class RCategoria : System.Web.UI.Page
    {
        Categorias categoriag = new Categorias();
        protected void Page_Load(object sender, EventArgs e)
        {

            ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
            myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
            myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
            myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
            myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);
        }

        private void Limpiar()
        {
            RequiredFieldValidator1.Text = "";
            RequiredFieldValidator2.Text = "";
            Textnombre.Text = "";
            Textid.Text = "";
        }

        public Categorias LlenarCampos()
        {
            categoriag.CategoriaId = Utilidades.TOINT(Textid.Text);
            categoriag.NombreCategoria = Textnombre.Text;
            return categoriag;
        }


        protected void Button3_Click(object sender, EventArgs e)
        {

            int id = 0;

            if (IsValid)
            {

                categoriag = LlenarCampos();


                if (id != categoriag.CategoriaId)
                {

                    if (CategoriaBLL.Mofidicar(categoriag))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Categoria modificado con exito');</script>");

                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Categoria No pudo ser modificado');</script>");

                    }


                }
                else
                {

                    if (CategoriaBLL.Guardar(categoriag))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Nueva Categoria agregada!');</script>");

                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No se pudo  agregar Categoria');</script>");

                    }


                }

            }
            Limpiar();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}