using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb.Ui.Consultas
{
    public partial class CUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Utilidades.SCritpValidacion();

            Lista = BLL.UserBLL.GetListodo();
            Entidades.Usuarios Usuario = new Entidades.Usuarios();
            UsuarioGrid.DataSource = Lista;
            UsuarioGrid.DataBind();

            buscaText.Focus();
        }
        public static List<Entidades.Usuarios> Lista { get; set; }

        public void Selecionar(int id)
        {

            if (DropFiltro.SelectedIndex == 0)
            {
                buscaText.Text = "";
                if (Lista.Count == 0)
                {
                    Utilidades.ShowToastr(this, "No se ha Registrado Usuario", "Correcto", "warning");
                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    Lista = BLL.UserBLL.GetListodo();
                    UsuarioGrid.DataSource = Lista;
                    Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");


                }
            }
            else if (DropFiltro.SelectedIndex == 1)
            {

                Lista = BLL.UserBLL.GetList(p => p.Id == id);

                if (Lista.Count == 0)
                {
                    Utilidades.ShowToastr(this, "No se ha Registrado Usuario con este ID", "Error", "warning");
                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    UsuarioGrid.DataSource = Lista;
                    UsuarioGrid.DataBind();
                    Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");

                }



            }
            else if (DropFiltro.SelectedIndex == 4)
            {
                Lista = BLL.UserBLL.GetList(p => p.Tipo == DropTipo.Text);
                UsuarioGrid.DataSource = Lista;
                UsuarioGrid.DataBind();
                Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");

            }

            else if (DropFiltro.SelectedIndex == 2)
            {


                if (desdeFecha.Text == "" && desdeFecha.Text == "")
                {
                    Utilidades.ShowToastr(this, "Fecha Invalidad", "Error", "warning");

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
                        Utilidades.ShowToastr(this, "Fecha Invalidad", "Error", "warning");
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


                            Lista = BLL.UserBLL.GetList(p => p.FechaIngreso >= desde.Date && p.FechaIngreso <= hasta.Date);
                            UsuarioGrid.DataSource = Lista;
                            UsuarioGrid.DataBind();
                            Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");



                        }
                        else
                        {
                            Utilidades.ShowToastr(this, "Fecha Deve ser menor", "Consejo", "info");
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
                    Utilidades.ShowToastr(this, "Escriba Descripcion a buscar", "Consejo", "info");

                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    Lista = BLL.UserBLL.GetList(p => p.NombreUsuario == buscaText.Text);
                    if (Lista.Count == 0)
                    {
                        Utilidades.ShowToastr(this, "No se ha registrado Elementos con este descripcion", "Consejo", "warning");
                        buscaText.Text = "";
                        buscaText.Focus();
                    }
                    else
                    {
                        UsuarioGrid.DataSource = Lista;
                        UsuarioGrid.DataBind();
                        Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");

                    }


                }

            }


        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Selecionar(Utilidades.TOINT(buscaText.Text));
        }

        protected void DropTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void buscaText_TextChanged(object sender, EventArgs e)
        {
          
        }

        protected void DropFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropFiltro.SelectedIndex == 1)
            {
                buscaText.Enabled = true;
                RegularExpressionValidator1.Enabled = true;
                DropTipo.Enabled = false;
                desdeFecha.Enabled = false;
                hastaFecha.Enabled = false;
            }
            else if(DropFiltro.SelectedIndex==0)
            {
                RegularExpressionValidator1.Enabled = false;
                buscaText.Enabled = false;
                DropTipo.Enabled = false;
                desdeFecha.Enabled = false;
                hastaFecha.Enabled = false;
            }
            else if(DropFiltro.SelectedIndex==2)
            {
                buscaText.Enabled = false;
                RegularExpressionValidator1.Enabled = false;
                DropTipo.Enabled = false;
                desdeFecha.Enabled = true;
                hastaFecha.Enabled = true;
            }
            else if(DropFiltro.SelectedIndex==3)
            {
                buscaText.Enabled = true;
                RegularExpressionValidator1.Enabled = false;
                DropTipo.Enabled = false;
                desdeFecha.Enabled = false;
                hastaFecha.Enabled = false;
            }
            else if(DropFiltro.SelectedIndex==4)
            {
                buscaText.Enabled = false;
                RegularExpressionValidator1.Enabled = false;
                DropTipo.Enabled = true;
                desdeFecha.Enabled = false;
                hastaFecha.Enabled = false;
            }
        }
    }
}