using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb.Ui
{
    public partial class SaldarDeudas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Utilidades.SCritpValidacion();
        }
        Entidades.Deudasclientes deuda = new Entidades.Deudasclientes();

        private void Limpiar()
        {
            TextBoxID.Text = "";
            TextBoxNombre.Text = "";
            TextBoxAbono.Text = "";
            TextBoxDevuelta.Text = "";
            TextMonto.Text = "";

        }


        protected void ButtoNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxID.Text))
            {

                Utilidades.ShowToastr(this, "Llene campo Id ", "Consejo", "info");


                Limpiar();


            }
            else
            {
                int id = int.Parse(TextBoxID.Text);
                var bll = new BLL.DeudasclientesBLL();
                var cliente = BLL.DeudasclientesBLL.Buscar(p => p.IdDeudas == id);
                if (BLL.DeudasclientesBLL.Eliminar(cliente))
                {

                    Utilidades.ShowToastr(this, "Deuda Eliminada con exito", "CORRECTO", "success");

                    Limpiar();
                }
                else
                {

                    Utilidades.ShowToastr(this, "No se puedo eliminar la deuda", "ERROR", "error");

                }
            }
        }

        protected void BotonBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxID.Text))
            {


                Utilidades.ShowToastr(this, "llene Campo   id", "CONSEJO", "info");

                Limpiar();
            }
            else

            {

                int id = int.Parse(TextBoxID.Text);
                var cliente = BLL.DeudasclientesBLL.Buscar(p => p.IdDeudas == id);


                if (cliente != null)
                {
                    TextBoxNombre.Text = cliente.Cliente;
                    TextMonto.Text = Convert.ToString(cliente.Deuda);



                    Utilidades.ShowToastr(this, "Resultados", "RESULTADOS", "success");

                }
                else
                {
                    Utilidades.ShowToastr(this, "No existe deuda con ese ID", "ERROR", "error");

                    Limpiar();

                }
            }
        }


        private void CalcularDevuelta()
        {
            if (string.IsNullOrWhiteSpace(TextMonto.Text))
            {
                Utilidades.ShowToastr(this, " Opciones \n - Realice busqueda \n - Registre una deuda", "ATENCION", "info");
            }
            else
            {
                if (TextBoxAbono.Text != "")
                {
                    decimal efevtivo = Convert.ToDecimal(TextBoxAbono.Text);
                    decimal deuda = Convert.ToDecimal(TextMonto.Text);
                    decimal total =  deuda - efevtivo;
                    if(total <= 0)
                    {
                        TextBoxDevuelta.Text = "0";
                    }
                    else
                    {

                        TextBoxDevuelta.Text = total.ToString();
                    }
                }
                else
                {
                    Utilidades.ShowToastr(this, "Ingrese Dinero Abonar", "ATENCION", "info");
                }
            }

        }



        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            int id = 0;

            decimal deudatotal = 0;
            var guardar = new Entidades.Deudasclientes();



            deudatotal = Convert.ToDecimal(TextMonto.Text);
            guardar.Cliente = TextBoxNombre.Text;
          //  guardar.Deuda = deudatotal;
            guardar.IdDeudas = (Utilidades.TOINT(TextBoxID.Text));
            if (deudatotal < Convert.ToDecimal(TextBoxDevuelta.Text) || deudatotal == 0)
            {
                int idd = int.Parse(TextBoxID.Text);
                var bll = new BLL.DeudasclientesBLL();
                var cliente = BLL.DeudasclientesBLL.Buscar(p => p.IdDeudas == idd);
                BLL.DeudasclientesBLL.Eliminar(cliente);
                Utilidades.ShowToastr(this, "Abono es mayor que deuda se elimina automaticamente", "ATENCION", "info");
            }
            else
            {


                if (id != guardar.IdDeudas)
                {
                    BLL.DeudasclientesBLL.Mofidicar(guardar);
                    Utilidades.ShowToastr(this, "Modifico la deuda", "ATENCION", "info");
                }
            }


        }

        protected void ButtonCalcular_Click(object sender, EventArgs e)
        {
            CalcularDevuelta();
        }
    }
}