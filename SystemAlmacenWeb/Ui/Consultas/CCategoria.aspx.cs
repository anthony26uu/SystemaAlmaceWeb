using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb.Ui.Consultas
{
    public partial class CCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
            myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
            myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
            myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
            myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);

            Lista = BLL.CategoriaBLL.GetListodo();
            Entidades.Categorias categoria = new Entidades.Categorias();
            CategoriasGrid.DataSource = Lista;
            CategoriasGrid.DataBind();

            buscaText.Focus();
        }
        public static List<Entidades.Categorias> Lista { get; set; }

        public void Selecionar(int id)
        {

            if (DropFiltro.SelectedIndex == 0)
            {
                buscaText.Text = "";
                if (Lista.Count == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No se han registrado Categoria');</script>");
                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    Lista = BLL.CategoriaBLL.GetListodo();
                    CategoriasGrid.DataSource = Lista;


                }
            }
            else if (DropFiltro.SelectedIndex == 1)
            {

                Lista = BLL.CategoriaBLL.GetList(p => p.CategoriaId == id);

                if (Lista.Count == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No se han registrado Elementos con este Id');</script>");
                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    CategoriasGrid.DataSource = Lista;
                    CategoriasGrid.DataBind();
                }



            }
            else if (DropFiltro.SelectedIndex == 2)
            {
            
            }

            else if (DropFiltro.SelectedIndex == 3)
            {
                if (buscaText.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Debe escribir la descripcion a buscar');</script>");

                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    Lista = BLL.CategoriaBLL.GetList(p => p.NombreCategoria == buscaText.Text);
                    if (Lista.Count == 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No se han registrado elementos con esa descripcion');</script>");
                        buscaText.Text = "";
                        buscaText.Focus();
                    }
                    else
                    {
                        CategoriasGrid.DataSource = Lista;
                        CategoriasGrid.DataBind();
                    }
                    

                }

            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Selecionar(Utilidades.TOINT(buscaText.Text));
        }
    }
}