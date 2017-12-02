using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb.Ui.Consultas
{
    public partial class CClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Utilidades.SCritpValidacion();

            Lista = BLL.ClientesBLL.GetListodo();
            Entidades.Categorias categoria = new Entidades.Categorias();
            ClienteGrid.DataSource = Lista;
            ClienteGrid.DataBind();

            buscaText.Focus();

        }

        public static List<Entidades.Clientes> Lista { get; set; }


        protected void DropFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public void Selecionar(int id)
        {

            if (DropFiltro.SelectedIndex == 0)
            {
                buscaText.Text = "";
                if (Lista.Count == 0)
                {
                    Utilidades.ShowToastr(this, "No se ha registrado Clientes", "Resultados", "error");

                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    Lista = BLL.ClientesBLL.GetListodo();
                    ClienteGrid.DataSource = Lista;
                    Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");



                }
            }
            else if (DropFiltro.SelectedIndex == 1)
            {

                Lista = BLL.ClientesBLL.GetList(p => p.ClienteId == id);

                if (Lista.Count == 0)
                {
                    Utilidades.ShowToastr(this, "No se ha registrado Clientes con este ID", "Resultados", "error");

                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {

                    ClienteGrid.DataSource = Lista;
                    ClienteGrid.DataBind();

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


                            Lista = BLL.ClientesBLL.GetList(p => p.FechaNacimiento >= desde.Date && p.FechaNacimiento <= hasta.Date);
                            ClienteGrid.DataSource = Lista;
                            ClienteGrid.DataBind();
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
                    Lista = BLL.ClientesBLL.GetList(p => p.Nombres == buscaText.Text);
                    if (Lista.Count == 0)
                    {
                        Utilidades.ShowToastr(this, "No se ha Registrado clientes con este nombre", "Resultados", "error");

                        buscaText.Text = "";
                        buscaText.Focus();
                    }
                    else
                    {
                        ClienteGrid.DataSource = Lista;
                        ClienteGrid.DataBind();
                        Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");

                    }


                }

            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Selecionar(Utilidades.TOINT(buscaText.Text));
        }

        protected void DropFiltro_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (DropFiltro.SelectedIndex == 1)
            {
                buscaText.Enabled = true;
                RegularExpressionValidator1.Enabled = true;
               
                desdeFecha.Enabled = false;
                hastaFecha.Enabled = false;
            }
            else if (DropFiltro.SelectedIndex == 0)
            {
                RegularExpressionValidator1.Enabled = false;
                buscaText.Enabled = false;
               
                desdeFecha.Enabled = false;
                hastaFecha.Enabled = false;
            }
            else if (DropFiltro.SelectedIndex == 2)
            {
                buscaText.Enabled = false;
                RegularExpressionValidator1.Enabled = false;
               
                desdeFecha.Enabled = true;
                hastaFecha.Enabled = true;
            }
            else if (DropFiltro.SelectedIndex == 3)
            {
                buscaText.Enabled = true;
                RegularExpressionValidator1.Enabled = false;
               
                desdeFecha.Enabled = false;
                hastaFecha.Enabled = false;
            }

        }
    }
}