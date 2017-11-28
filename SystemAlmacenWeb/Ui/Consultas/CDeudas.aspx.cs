using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb.Ui.Consultas
{
    public partial class CDeudas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Utilidades.SCritpValidacion();
            Lista = BLL.DeudasclientesBLL.GetListodo();
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
        public static List<Entidades.Deudasclientes> Lista { get; set; }

        private void LlenarDrop()
        {
            List<Entidades.Clientes> ListaDrop = BLL.ClientesBLL.GetListodo();

            DropUsuario.DataSource = ListaDrop;
            DropUsuario.DataValueField = "ClienteId";
            DropUsuario.DataTextField = "Nombres";
            DropUsuario.DataBind();
        }
        private void calcular()
        {
            decimal total = 0;

            if (FacturaGrid.Rows.Count > 0)
            {
                foreach (GridViewRow precio in FacturaGrid.Rows)
                {
                    Math.Round (total += Convert.ToDecimal(precio.Cells[2].Text));
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
                    Utilidades.ShowToastr(this, "No se ha registrado deuduas", "Resultados", "error");

                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    Lista = BLL.DeudasclientesBLL.GetListodo();
                    FacturaGrid.DataSource = Lista;
                    Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");
                    calcular();
                    buscaText.Text = "";


                }
            }
            else if (DropFiltro.SelectedIndex == 1)
            {

                Lista = BLL.DeudasclientesBLL.GetList(p => p.IdDeudas == id);

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
                    buscaText.Text = "";

                }



            }



            else if (DropFiltro.SelectedIndex == 2)
            {


                Lista = BLL.DeudasclientesBLL.GetList(p => p.Cliente == DropUsuario.Text);


                if (Lista.Count == 0)
                {
                    Utilidades.ShowToastr(this, "No existe deudas para este clente", "Resultados", "error");

                    buscaText.Text = "";
                    buscaText.Focus();
                }
                else
                {
                    FacturaGrid.DataSource = Lista;
                    FacturaGrid.DataBind();
                    Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");
                    calcular();
                    buscaText.Text = "";

                }




            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Selecionar(Utilidades.TOINT(buscaText.Text));
        }
    }
}