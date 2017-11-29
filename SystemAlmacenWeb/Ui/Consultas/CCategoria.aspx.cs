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
            Utilidades.SCritpValidacion();

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
                    Utilidades.ShowToastr(this, "No se ha registrado Categoria", "Resultados", "error");

                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    Lista = BLL.CategoriaBLL.GetListodo();
                    CategoriasGrid.DataSource = Lista;
                    Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");



                }
            }
            else if (DropFiltro.SelectedIndex == 1)
            {

                Lista = BLL.CategoriaBLL.GetList(p => p.CategoriaId == id);

                if (Lista.Count == 0)
                {
                    Utilidades.ShowToastr(this, "No existe categoria con este ID", "Resultados", "error");

                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    CategoriasGrid.DataSource = Lista;
                    CategoriasGrid.DataBind();
                    Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");

                }



            }

            else if (DropFiltro.SelectedIndex == 2)
            {
                if (buscaText.Text == "")
                {
                    Utilidades.ShowToastr(this, "Escriba Descripcion", "Resultados", "error");

                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    Lista = BLL.CategoriaBLL.GetList(p => p.NombreCategoria == buscaText.Text);
                    if (Lista.Count == 0)
                    {
                        Utilidades.ShowToastr(this, "No existe categoria con esa descripcion", "Resultados", "error");

                        buscaText.Text = "";
                        buscaText.Focus();
                    }
                    else
                    {
                        CategoriasGrid.DataSource = Lista;
                        CategoriasGrid.DataBind();
                        buscaText.Text = "";
                        Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");

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