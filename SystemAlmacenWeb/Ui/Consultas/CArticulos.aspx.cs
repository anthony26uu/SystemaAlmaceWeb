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

            detalle = BLL.FacturaDetallesBLL.GetListodo();
        //    Entidades.Articulos artoculo = new Entidades.Articulos();
           
         //   ArticuloGrid.DataSource = Lista;
           // ArticuloGrid.DataBind();

            buscaText.Focus();

            if (!Page.IsPostBack)
            {
                LlenarDrop();
            }
        }
        public static List<Entidades.Articulos> Lista { get; set; }
        public static List<Entidades.FacturaDetalles> detalle { get; set; }

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
                if (detalle.Count == 0)
                {
                    Utilidades.ShowToastr(this, "No se ha registrado Articulos", "Resultados", "error");

                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    detalle = BLL.FacturaDetallesBLL.GetListodo();
                    ArticuloGrid.DataSource = detalle;
                    Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");



                }
            }
            else if (DropFiltro.SelectedIndex == 1)
            {

                detalle = BLL.FacturaDetallesBLL.GetList(p => p.IdDetalle == id);

                if (detalle.Count == 0)
                {u78
                    Utilidades.ShowToastr(this, "No se ha registrado Articulos con este ID", "Resultados", "error");

                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    ArticuloGrid.DataSource = detalle;
                    ArticuloGrid.DataBind();
                    Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");

                }



            }
            else if (DropFiltro.SelectedIndex == 2)
            {


                if (desdeFecha.Text == "" && desdeFecha.Text == "")
                {
                    Utilidades.ShowToastr(this, "Fecha invalida", "Resultados", "error");

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
                        Utilidades.ShowToastr(this, "Fecha invalida", "Resultados", "error");

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
                            Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");


                        }
                        else
                        {
                             Utilidades.ShowToastr(this, "Fecha debe ser menor", "Consejo", "info");

                            desdeFecha.Text = "";
                            hastaFecha.Text = "";
                            desdeFecha.Focus();
                        }
                    }
                    else
                    {
                        Utilidades.ShowToastr(this, "Ingrese Fecha", "Consejo", "info");

                        desdeFecha.Focus();
                    }

                }
            }

            else if (DropFiltro.SelectedIndex == 3)
            {
                if (buscaText.Text == "")
                {
                    Utilidades.ShowToastr(this, "Escriba descripcion", "Resultados", "info");


                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    Lista = BLL.ArticuloBLL.GetList(p => p.NombreArticulo == buscaText.Text);
                    if (Lista.Count == 0)
                    {
                        Utilidades.ShowToastr(this, "No se ha Registrado Elementos con descripcion", "Resultados", "error");

                        buscaText.Text = "";
                        buscaText.Focus();
                    }
                    else
                    {
                        ArticuloGrid.DataSource = Lista;
                        ArticuloGrid.DataBind();
                        Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");

                    }


                }

            }

           
            else if (DropFiltro.SelectedIndex == 4)
            {

                Lista = BLL.ArticuloBLL.GetList(p => p.Categoria == DropCategoria.Text);

                ArticuloGrid.DataSource = Lista;
                ArticuloGrid.DataBind();
                Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");

            }
        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            Selecionar(Utilidades.TOINT(buscaText.Text));
        }
    }
}