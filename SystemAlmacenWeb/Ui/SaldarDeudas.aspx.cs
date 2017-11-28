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
            TextBoxDinero.Text = "";
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
        private void calcular()
        {
            decimal total = 0;
            
            total =( Convert.ToDecimal(TextMonto.Text) - Convert.ToDecimal(TextBoxDinero.Text));
            TextBoxDinero.Text = total.ToString();
        }

        public Entidades.Deudasclientes LlenarCampos()
        {

            //deuda.Cliente = TextBoxNombre.Text;
          
            deuda.Deuda = Convert.ToDecimal(TextBoxDinero.Text);




            return deuda;
        }


        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            int id = 0;

            if (IsValid)
            {

                deuda = LlenarCampos();


                if (id != deuda.IdDeudas)
                {

                    if (BLL.DeudasclientesBLL.Mofidicar(deuda))
                    {
                        Utilidades.ShowToastr(this, "Se modifico la deuda Satisfactoriamente", "Correcto", "success");
                    }
                    else
                    {
                        Utilidades.ShowToastr(this, "No se pudo modificar la deuda", "Error", "Error");
                    }


                }
                else
                {
                    Utilidades.ShowToastr(this, "Deuda a modificar no existe", "Error", "error");
                    //if (BLL.ClientesBLL.Guardar(clienteg))
                    //{
                    //    Utilidades.ShowToastr(this, " Cliente Agregado", "Correcto", "success");
                    //}
                    //else
                    //{
                    //    Utilidades.ShowToastr(this, "No se agrego", "Error", "error");

                    //}


                }

            }
            Limpiar();

        }

        protected void ButtonCalcular_Click(object sender, EventArgs e)
        {
            calcular();
        }
    }
}