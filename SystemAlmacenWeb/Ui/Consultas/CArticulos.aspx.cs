﻿using System;
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

            Utilidades.SCritpValidacion();

            Lista = BLL.ArticuloBLL.GetListodo();
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
                    Utilidades.ShowToastr(this, "No se ha registrado Articulos", "Resultados", "error");

                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    Lista = BLL.ArticuloBLL.GetListodo();
                    ArticuloGrid.DataSource = Lista;
                    ArticuloGrid.DataBind();
                    buscaText.Text = "";
                    Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");



                }
            }
            else if (DropFiltro.SelectedIndex == 1)
            {

                Lista = BLL.ArticuloBLL.GetList(p => p.IdArticulo == id);

                if (Lista.Count == 0)
                {
                    Utilidades.ShowToastr(this, "No se ha registrado Articulos con este ID", "Resultados", "error");

                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {

                    ArticuloGrid.DataSource = Lista;
                    ArticuloGrid.DataBind();
                    buscaText.Text = "";
                    Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");

                }



            }
            else if (DropFiltro.SelectedIndex == 2)
            {


                if (desdeFecha.Text == "" && desdeFecha.Text == "")
                {
                    Utilidades.ShowToastr(this, "Fecha invalida", "Resultados", "error");
                    buscaText.Text = "";
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
                        buscaText.Text = "";
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
                            buscaText.Text = "";
                            Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");


                        }
                        else
                        {
                            Utilidades.ShowToastr(this, "Fecha debe ser menor", "Consejo", "info");
                            buscaText.Text = "";
                            desdeFecha.Text = "";
                            hastaFecha.Text = "";
                            desdeFecha.Focus();
                        }
                    }
                    else
                    {
                        Utilidades.ShowToastr(this, "Ingrese Fecha", "Consejo", "info");
                        buscaText.Text = "";
                        desdeFecha.Focus();
                    }

                }
            }
            else if (DropFiltro.SelectedIndex == 4)
            {
                if (DropCategoria.Text == "")
                {
                    Utilidades.ShowToastr(this, "Selecion o Registre Categoria Antes de buscar", "Resultados", "info");


                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    Lista = BLL.ArticuloBLL.GetList(p => p.Categoria == DropCategoria.Text);
                    if (Lista.Count == 0)
                    {
                        Utilidades.ShowToastr(this, "No se ha Registrado Elementos con esta categoria", "Resultados", "error");

                        buscaText.Text = "";
                        buscaText.Focus();
                    }
                    else
                    {
                        ArticuloGrid.DataSource = Lista;
                        ArticuloGrid.DataBind();
                        Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");
                        buscaText.Text = "";
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
                        buscaText.Text = "";
                    }


                }

            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Selecionar(Utilidades.TOINT(buscaText.Text));
        }

        protected void DropFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropFiltro.SelectedIndex == 1)
            {
                buscaText.Enabled = true;
                RegularExpressionValidator1.Enabled = true;
                DropCategoria.Enabled = false;
                desdeFecha.Enabled = false;
                hastaFecha.Enabled = false;
            }
            else if (DropFiltro.SelectedIndex == 0)
            {
                RegularExpressionValidator1.Enabled = false;
                buscaText.Enabled = false;
                DropCategoria.Enabled = false;
                desdeFecha.Enabled = false;
                hastaFecha.Enabled = false;
            }
            else if (DropFiltro.SelectedIndex == 2)
            {
                buscaText.Enabled = false;
                RegularExpressionValidator1.Enabled = false;
                DropCategoria.Enabled = false;
                desdeFecha.Enabled = true;
                hastaFecha.Enabled = true;
            }
            else if (DropFiltro.SelectedIndex == 3)
            {
                buscaText.Enabled = true;
                RegularExpressionValidator1.Enabled = false;
                DropCategoria.Enabled = false;
                desdeFecha.Enabled = false;
                hastaFecha.Enabled = false;
            }
            else if (DropFiltro.SelectedIndex == 4)
            {
                buscaText.Enabled = false;
                RegularExpressionValidator1.Enabled = false;
                DropCategoria.Enabled = true;
                desdeFecha.Enabled = false;
                hastaFecha.Enabled = false;
            }

        }
    }
}