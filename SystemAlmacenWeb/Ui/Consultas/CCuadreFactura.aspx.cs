using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb.Ui.Consultas
{
    public partial class CCuadreFactura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utilidades.SCritpValidacion();
            Lista = BLL.FacturaBLL.GetListodo();
            FacturaGrid.DataSource = Lista;
            FacturaGrid.DataBind();

            buscaText.Focus();

            buscaText.Focus();
            calcular();
            if (!Page.IsPostBack)
            {
                LlenarDrop();
                
            }
        }
        public static List<Entidades.Facturas> Lista { get; set; }


        private void calcular()
        {
            decimal total = 0;

            if (FacturaGrid.Rows.Count > 0)
            {
                foreach (GridViewRow precio in FacturaGrid.Rows)
                {
                  total +=   Convert.ToDecimal(precio.Cells[6].Text);
                }
            }
            TextBoxTotal.Text = total.ToString();
        }
            
        public void Selecionar(int id)
        {

            if (DropFiltro.SelectedIndex == 0)
            {
                buscaText.Text = "";
                if (Lista.Count == 0)
                {
                    Utilidades.ShowToastr(this, "No se ha registrado Factura", "Resultados", "error");

                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    Lista = BLL.FacturaBLL.GetListodo();
                    FacturaGrid.DataSource = Lista;
                    Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");
                    calcular();


                }
            }
            else if (DropFiltro.SelectedIndex == 1)
            {

                Lista = BLL.FacturaBLL.GetList(p => p.IdFactura == id);

                if (Lista.Count == 0)
                {
                    Utilidades.ShowToastr(this, "No existe categoria con este ID", "Resultados", "error");

                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    FacturaGrid.DataSource = Lista;
                    FacturaGrid.DataBind();
                    Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");
                    calcular();

                }



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


                            Lista = BLL.FacturaBLL.GetList(p => p.FechaVenta >= desde.Date && p.FechaVenta <= hasta.Date);
                            FacturaGrid.DataSource = Lista;
                            FacturaGrid.DataBind();
                            Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");
                            calcular();


                        }
                        else
                        {
                            Utilidades.ShowToastr(this, "Fecha Debe ser menor", "Consejo", "info");
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


                Lista = BLL.FacturaBLL.GetList(p => p.Cliente == DropUsuario.Text);


                if (Lista.Count == 0)
                {
                    Utilidades.ShowToastr(this, "No existe factura realizada por ese usuario", "Resultados", "error");

                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    FacturaGrid.DataSource = Lista;
                    FacturaGrid.DataBind();
                    Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");
                    calcular();

                }




            }


        }

        private void LlenarDrop()
        {
            List<Entidades.Usuarios> ListaDrop = BLL.UserBLL.GetListodo();

            DropUsuario.DataSource = ListaDrop;
            DropUsuario.DataValueField = "Id";
            DropUsuario.DataTextField = "NombreUsuario";
            DropUsuario.DataBind();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Selecionar(Utilidades.TOINT(buscaText.Text));
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }

        protected void DropFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropFiltro.SelectedIndex==1)
            {
                RegularExpressionValidator1.Enabled = true;
            }
            else
            {
                RegularExpressionValidator1.Enabled = false;

            }
        }
    }
}