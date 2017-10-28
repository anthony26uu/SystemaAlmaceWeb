using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb.Ui.Consultas
{
    public partial class CArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
            myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
            myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
            myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
            myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);

            Lista = BLL.ArticuloBLL.GetListodo();
            Entidades.Articulos artoculo = new Entidades.Articulos();
            ArticuloGrid.DataSource = Lista;
            ArticuloGrid.DataBind();

            buscaText.Focus();

            if (!Page.IsPostBack)
            {
                LlenarDrop();
            }
        }
        public static List<Entidades.Articulos> Lista { get; set; }

        private void LlenarDrop()
        {
            List<Entidades.Categorias> ListaDrop = BLL.CategoriaBLL.GetListodo();

            DropCategoria.DataSource = ListaDrop;
            DropCategoria.DataValueField = "CategoriaId";
            DropCategoria.DataTextField = "NombreCategoria";
            DropCategoria.DataBind();                            
        }

        public void Selecionar(int id)
        {

            if (DropFiltro.SelectedIndex == 0)
            {
                buscaText.Text = "";
                if (Lista.Count == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No se han registrado Articulos');</script>");
                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    Lista = BLL.ArticuloBLL.GetListodo();
                    ArticuloGrid.DataSource = Lista;


                }
            }
            else if (DropFiltro.SelectedIndex == 1)
            {

                Lista = BLL.ArticuloBLL.GetList(p => p.IdArticulo == id);

                if (Lista.Count == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No se han registrado Elementos con este Id');</script>");
                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    ArticuloGrid.DataSource = Lista;
                    ArticuloGrid.DataBind();
                }



            }
            else if (DropFiltro.SelectedIndex == 2)
            {


                if (desdeFecha.Text == "" && desdeFecha.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Fecha invalida ');</script>");

                    hastaFecha.Text = "";
                    desdeFecha.Text = "";
                    desdeFecha.Focus();
                }
                else
                {

                    DateTime desde = DateTime.Now;
                    DateTime hasta = DateTime.Now;
                    if (desdeFecha.Text == "")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Fecha invalida ');</script>");
                        hastaFecha.Text = "";
                        desdeFecha.Text = "";
                        desdeFecha.Focus();
                    }
                    else
                    {
                        desde = Convert.ToDateTime(desdeFecha.Text);
                        hasta = Convert.ToDateTime(hastaFecha.Text);
                    }


                    if (desdeFecha.Text != "" && hastaFecha.Text != "")
                    {
                        if (desde <= hasta)
                        {


                            Lista = BLL.ArticuloBLL.GetList(p => p.FechaIngreso >= desde.Date && p.FechaIngreso <= hasta.Date);
                            ArticuloGrid.DataSource = Lista;
                            ArticuloGrid.DataBind();


                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Fecha invalida debe ser menor');</script>");
                            desdeFecha.Text = "";
                            hastaFecha.Text = "";
                            desdeFecha.Focus();
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Ingrese Fecha');</script>");
                        desdeFecha.Focus();
                    }

                }
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
                    Lista = BLL.ArticuloBLL.GetList(p => p.NombreArticulo == buscaText.Text);
                    if (Lista.Count == 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No se han registrado elementos con esa descripcion');</script>");
                        buscaText.Text = "";
                        buscaText.Focus();
                    }
                    else
                    {
                        ArticuloGrid.DataSource = Lista;
                        ArticuloGrid.DataBind();
                    }


                }

            }

            else if (DropFiltro.SelectedIndex == 4)
            {

                Lista = BLL.ArticuloBLL.GetList(p => p.Categoria == Convert.ToString(DropCategoria.TabIndex));

                DropCategoria.DataSource = Lista;
                DropCategoria.DataBind();
            }
        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            Selecionar(Utilidades.TOINT(buscaText.Text));
        }
    }
}