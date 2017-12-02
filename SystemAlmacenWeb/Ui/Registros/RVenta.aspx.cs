using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SystemAlmacenWeb.Ui.Registros
{
    public partial class RVenta : System.Web.UI.Page
    {

        DataTable dt = new DataTable();

        Entidades.Articulos artig = new Entidades.Articulos();
        private static List<Entidades.Articulos> listadoArticulos = null;



        private static List<Entidades.FacturaDetalles> listaRelaciones;
        Entidades.Facturas facturaG;
        decimal devuelta = 0;


        protected void Page_Load(object sender, EventArgs e)
        {

            Utilidades.SCritpValidacion();
            if (!Page.IsPostBack)
            {

                LlenarDropCliente();
                LlenarDrop();

                dt.Columns.AddRange(new DataColumn[5] { new DataColumn("ID Articulo"),
                new DataColumn(" Precio"),
                new DataColumn("Cantidad"),
                new DataColumn("Nombre"), new DataColumn("ITBS")});

                ViewState["Detalle"] = dt;

                artig = new Entidades.Articulos();

                listadoArticulos = new List<Entidades.Articulos>();
                listaRelaciones = new List<Entidades.FacturaDetalles>();

                facturaG = new Entidades.Facturas();
                DropDownTipoVenta.Text = "";
            }


        }

        private void limpiarFac()
        {
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("ID Articulo"),
               new DataColumn(" Precio"),
                new DataColumn("Cantidad"),
                new DataColumn("Nombre"), new DataColumn("ITBS")});

            TextBoxBuscar.Text = "";
            ViewState["Detalle"] = dt;
            this.BindGrid();
        }

        private void limpiar()
        {
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("ID Articulo"),
               new DataColumn(" Precio"),
                new DataColumn("Cantidad"),
                new DataColumn("Nombre"), new DataColumn("ITBS")});

            TextBoxBuscar.Text = "";
            ViewState["Detalle"] = dt;
            this.BindGrid();

            DropDownTipoVenta.SelectedIndex = 0;
            DropDownCliente.SelectedValue = null;
            TextBoxVendedor.Text = "";
            TexboxClienteCompro.Text = "";
            DescuentoTextBox.Text = "";
            TexboxCantidad.Text = "";
            TextBoxSubTotal.Text = "";
            TextBoxTotal.Text = "";
            TextMontoRecibido.Text = "";
            TexboxDevuelta.Text = "";
            TextBoxTotalITBS.Text = "";

            DescuentoTextBox.Enabled = true;
            DropDownTipoVenta.Enabled = true;
            DropDownCliente.Enabled = true;
            Agregar.Enabled = true;
            DropArticulo.Enabled = true;
            TextBoxCantidad.Enabled = true;
            BotonCalcularDevuelta.Enabled = true;
            TextMontoRecibido.Enabled = true;
            ButtonGurdar.Enabled = true;
        }

        public void LlenarRegistro(List<Entidades.FacturaDetalles> llenar)
        {

            foreach (var li in llenar)
            {
                DataTable dt = (DataTable)ViewState["Detalle"];
                dt.Rows.Add(li.IdArticulo, li.Precio, li.Cantidad, li.Nombre, li.ITBIS);
                ViewState["Detalle"] = dt;
                this.BindGrid();
            }


        }




        public void LlenarDatos(Entidades.FacturaDetalles detalle)
        {

            int id = 0;
            int idCliente = 0;
            int cantidad = 0;

            idCliente = Utilidades.TOINT(DropDownCliente.Text);
            var clientec = BLL.ClientesBLL.Buscar(p => p.ClienteId == idCliente);

            if (facturaG != null)
            {
                id = facturaG.IdFactura;

            }

            foreach (GridViewRow dr in FacturaGrid.Rows)
            {
                detalle.AgregarDetalle(Convert.ToInt32(dr.Cells[0].Text), 0, 0,
                Convert.ToDecimal(dr.Cells[1].Text), Convert.ToInt32(dr.Cells[2].Text), Convert.ToString(dr.Cells[3].Text), Convert.ToDecimal(dr.Cells[4].Text)
                       );
                cantidad++;
                BotonCalcularDevuelta.Focus();
                CalcularMonto();
            }

            if (TextBoxTotal.Text == "" && TextBoxSubTotal.Text == "")
            {
                CalcularMonto();

            }
            else
            {
                if (clientec != null)
                {

                    facturaG = new Entidades.Facturas(0, Base.Usuario, DateTime.Now, clientec.Nombres, DropDownTipoVenta.Text, cantidad, Convert.ToDecimal(TextBoxTotal.Text));
                }
                else
                {
                    Utilidades.ShowToastr(this, "Error cliente vacio", "error");
                }
            }


        }

        protected void BindGrid()
        {
            FacturaGrid.DataSource = (DataTable)ViewState["Detalle"];
            FacturaGrid.DataBind();
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            int id = Utilidades.TOINT(DropArticulo.SelectedValue);

            artig = BLL.ArticuloBLL.Buscar(p => p.IdArticulo == id);
                       
            if (Utilidades.TOINT(TextBoxCantidad.Text) > artig.Existencia)
            {

                Utilidades.ShowToastr(this, "Cantidad exece existencia", "info");
                TextBoxCantidad.Text = "";
            }
            else
            {
                bool agregado = false;

                foreach (GridViewRow producto in FacturaGrid.Rows)
                {


                    int prueba = Utilidades.TOINT(producto.Cells[0].Text);
                    if (artig.IdArticulo == Utilidades.TOINT(producto.Cells[0].Text))
                    {
                        agregado = true;


                        Utilidades.ShowToastr(this, " Articulo ya esta en factura -Selecione otro", "Error", "info");
                        break;

                    }
                }
                if (agregado == true)
                {

                    Utilidades.ShowToastr(this, " Articulo ya esta en factura -Selecione otro", "Error", "info");

                }
                else
                {
                    DataTable dt = (DataTable)ViewState["Detalle"];
                    dt.Rows.Add(DropArticulo.SelectedValue, artig.Precio, TextBoxCantidad.Text.Trim(), artig.NombreArticulo, artig.ITBIS);
                    ViewState["Detalle"] = dt;
                    this.BindGrid();
                    CalcularMonto();
                    TextBoxCantidad.Text = "";
                    TexboxCantidad.Focus();

                }


            }

        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            Entidades.FacturaDetalles detallef = new Entidades.FacturaDetalles();
            LlenarDatos(detallef);
            var guardar = new Entidades.Deudasclientes();

            int idcliente = int.Parse(DropDownCliente.Text);
            var ClienteNombre = BLL.ClientesBLL.Buscar(p => p.ClienteId == idcliente);



            if (detallef.Detalle.Count == 0)
            {
                Utilidades.ShowToastr(this, "Primero agregue Articulos", "Consejo", "info");

            }
            else

            {
                if (TextBoxTotal.Text == "" && DropDownTipoVenta.Text == "Contado")
                {
                    Utilidades.ShowToastr(this, "Calcule total", "ATENCION", "info");
                }

                else
                {

                    if (BLL.FacturaBLL.Guardar(facturaG, detallef.Detalle))
                    {
                        EliminarExitencia();

                        if (DropDownTipoVenta.Text == "Credito")
                        {
                            if (TextBoxTotal.Text == "")
                            {
                                Utilidades.ShowToastr(this, "Calcule total, presionando el boton ", "ATENCION", "info");

                            }
                            else
                            {

                                guardar.Cliente = ClienteNombre.Nombres;
                                guardar.Deuda = Convert.ToDecimal(TextBoxTotal.Text);
                                if (BLL.DeudasclientesBLL.Guardar(guardar))
                                {
                                    Utilidades.ShowToastr(this, "Nueva deuda agregada", "ATENCION", "info");
                                }

                            }

                        }

                        Utilidades.ShowToastr(this, "Guardo", "Correcto", "success");

                        limpiar();
                    }
                    else
                    {
                        Utilidades.ShowToastr(this, "Error", "Error", "error");

                    }
                }

            }
        }

        private void EliminarExitencia()
        {

            decimal descuento = 0;
            Entidades.Articulos Descontar = new Entidades.Articulos();
            foreach (GridViewRow producto in FacturaGrid.Rows)
            {

                int productoId = Convert.ToInt32(producto.Cells[0].Text); ///Celda 2 es el idArticulo antes esta detalleid y facturaid
                descuento = Convert.ToDecimal(producto.Cells[2].Text); //Celda 4 es la cantiddad

                Descontar = BLL.ArticuloBLL.BuscarB(productoId);
              //  if(Descontar.Existencia <)
                Descontar.Existencia -= Convert.ToInt32(descuento);
                BLL.ArticuloBLL.Mofidicar(Descontar);
            }

        }

        private void LlenarDropCliente()
        {
            List<Entidades.Clientes> ListaDrocl = BLL.ClientesBLL.GetListodo();

            DropDownCliente.DataSource = ListaDrocl;
            DropDownCliente.DataValueField = "ClienteId";
            DropDownCliente.DataTextField = "Nombres";
            DropDownCliente.DataBind();

        }

        private void LlenarDrop()
        {
            List<Entidades.Articulos> ListaDrop = BLL.ArticuloBLL.GetListodo();

            DropArticulo.DataSource = ListaDrop;
            DropArticulo.DataValueField = "IdArticulo";
            DropArticulo.DataTextField = "NombreArticulo";
            DropArticulo.DataBind();
        }

        public void calcularDevuelta()
        {

            if (DropDownTipoVenta.Text == "Credito")
            {
                CalcularMonto();
            }
            else
            {
                if (TextBoxTotal.Text == "")
                {
                    CalcularMonto();
                }
                else
                {
                    if (TextMontoRecibido.Text == "")
                    {
                        Utilidades.ShowToastr(this, "Ingres Monto para calcular devuelta", "Atencion", "info");
                    }
                    else
                    {

                        if (Convert.ToDecimal(TextMontoRecibido.Text) < Convert.ToDecimal(TextBoxTotal.Text))
                        {
                            Utilidades.ShowToastr(this, "Dinero Ingresado es menor que monto a pagar", "ATENCION", "info");

                        }
                        else
                        {
                            devuelta = Convert.ToDecimal(TextMontoRecibido.Text) - Convert.ToDecimal(TextBoxTotal.Text);
                            TexboxDevuelta.Text = devuelta.ToString();
                        }
                    }
                }
            }


        }

        private void SumarExistencia()
        {
            decimal suma = 0;
            foreach (GridViewRow producto in FacturaGrid.Rows)
            {
                Entidades.FacturaDetalles detallef = new Entidades.FacturaDetalles();
                int productoId = Convert.ToInt32(producto.Cells[0].Text); ///Celda 0 es el idArticulo antes esta detalleid y facturaid
                suma = Convert.ToDecimal(producto.Cells[2].Text); //Celda 2 es la cantiddad

                detallef.Articulo = BLL.ArticuloBLL.BuscarB(productoId);
                detallef.Articulo.Existencia += Convert.ToInt32(suma);
                BLL.ArticuloBLL.Mofidicar(detallef.Articulo);
            }
        }

        public void CalcularMonto()
        {
            decimal total = 0;
            decimal subTotal = 0m;
            decimal descuento = 0;

            decimal itbs = 0;
            decimal porciento = 100;


            if (FacturaGrid.Rows.Count > 0)
            {
                foreach (GridViewRow precio in FacturaGrid.Rows)
                {
                    subTotal += ((Convert.ToDecimal(precio.Cells[2].Text) * Convert.ToDecimal(precio.Cells[1].Text))); ;
                    subTotal += (Convert.ToDecimal(precio.Cells[1].Text) * (Convert.ToDecimal(precio.Cells[4].Text) / 100));
                    TextBoxSubTotal.Text = subTotal.ToString();

                    itbs += Convert.ToDecimal(precio.Cells[4].Text);
                    TextBoxTotalITBS.Text = itbs.ToString();
                    TextBoxSubTotal.Text = subTotal.ToString();

                }

            }
            if (DescuentoTextBox.Text == "")
            {
                DescuentoTextBox.Text = Convert.ToString(0);
            }
            else
            {
                if (TextBoxSubTotal.Text == "")
                {
                    Utilidades.ShowToastr(this, "Primero Agregue articulos", "ANTENCION ", "info");
                }
                else
                {
                    descuento = ((Convert.ToDecimal(DescuentoTextBox.Text) / porciento) * Convert.ToDecimal(TextBoxSubTotal.Text));
                    Math.Round(total = (subTotal + itbs) - descuento);
                    TextBoxTotal.Text = total.ToString();
                    if (DropDownTipoVenta.Text != "Credito")
                    {
                        TexboxDevuelta.Text = devuelta.ToString();
                    }
                }



            }

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TextBoxBuscar.Text))
            {
                Utilidades.ShowToastr(this, "ID Vacio", "Resultados", "error");

            }
            else
            {
                int id = Utilidades.TOINT(TextBoxBuscar.Text);

                facturaG = BLL.FacturaBLL.Buscarb(f => f.IdFactura == id);
                if (facturaG != null)
                {

                    limpiar();
                    listaRelaciones = BLL.FacturaDetallesBLL.GetList(A => A.IdFactura == facturaG.IdFactura);
                    TextBoxBuscar.Text = facturaG.IdFactura.ToString();
                    if (facturaG != null)
                    {

                        if (listaRelaciones.Count == 0)
                        {
                            Utilidades.ShowToastr(this, "No se ha registrado Articulos con este ID", "Resultados", "error");


                        }
                        else
                        {

                            TextBoxVendedor.Text = facturaG.NombreUsuario;
                            TexboxClienteCompro.Text = facturaG.Cliente;
                            TexboxCantidad.Text = Convert.ToString(facturaG.CantidadProd);
                            TextFecha.Text = Convert.ToString(facturaG.FechaVenta);
                            TextBoxTotal.Text = Convert.ToString(facturaG.Total);
                            DropDownTipoVenta.Text = Convert.ToString(facturaG.TipoVenta);

                            DropDownTipoVenta.Enabled = false;
                            DropDownCliente.Enabled = false;
                            Agregar.Enabled = false;
                            DropArticulo.Enabled = false;
                            TextBoxCantidad.Enabled = false;
                            BotonCalcularDevuelta.Enabled = false;
                            TextMontoRecibido.Enabled = false;
                            ButtonGurdar.Enabled = false;
                            DescuentoTextBox.Enabled = false;
                            foreach (var relacion in listaRelaciones)
                            {
                                listadoArticulos.Add(BLL.ArticuloBLL.Buscar(A => A.IdArticulo == relacion.IdArticulo));
                            }


                            LlenarRegistro(listaRelaciones);


                            Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");

                        }

                    }
                }
                else
                {
                    Utilidades.ShowToastr(this, "No existe factura", "Error", "error");
                    limpiarFac();
                }
            }



        }

        protected void Asignar(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            var user = BLL.UserBLL.Buscar(p => p.NombreUsuario == Base.Usuario);
            if (user.Tipo != "Administrador")
            {

                Utilidades.ShowToastr(this, "No es Administrador", "Error", "error");
            }
            else
            {

                if (string.IsNullOrWhiteSpace(TextBoxBuscar.Text))
                {

                    Utilidades.ShowToastr(this, "Campo Id Vacio", "Error", "info");
                }
                else
                {
                    int id = Utilidades.TOINT(TextBoxBuscar.Text);

                    facturaG = BLL.FacturaBLL.Buscarb(f => f.IdFactura == id);



                    if (facturaG != null)
                    {


                        if (BLL.FacturaBLL.EliminarRelacion(facturaG))
                        {
                            SumarExistencia();
                            limpiar();

                            facturaG = new Entidades.Facturas();
                            Utilidades.ShowToastr(this, "Elimino Correctamente", "ELIMINADO", "success");

                        }
                        else
                        {
                            Utilidades.ShowToastr(this, "Problemas Al Eliminar", "Error", "error");
                        }

                    }
                    else
                    {
                        Utilidades.ShowToastr(this, "No hay Factura", "Informacion", "info");
                    }
                }

            }

        }

        protected void TextMontoRecibido_TextChanged(object sender, EventArgs e)
        {

            calcularDevuelta();
        }

        protected void BotonCalcularDevuelta_Click(object sender, ImageClickEventArgs e)
        {

            if (DropDownTipoVenta.Text == "Credito")
            {
                CalcularMonto();
            }
            else
            {

                CalcularMonto();
                calcularDevuelta();
                ButtonGurdar.Focus();
            }
        }

        protected void DropDownTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownTipoVenta.Text=="Credito")
            {
                BotonCalcularDevuelta.Enabled = false;
                TextMontoRecibido.Enabled = false;
            }
            else
            {
                BotonCalcularDevuelta.Enabled = true;
                TextMontoRecibido.Enabled = true;
            }
        }

        protected void DropArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TexboxCantidad.Focus();
        }

        protected void DropDownCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDropCliente();
        }

        protected void ButtonNuevoCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Ui/Registros/RCliente.aspx");
        }

        protected void TextBoxTotal_TextChanged(object sender, EventArgs e)
        {
            calcularDevuelta();
        }

        protected void ButtonNuevoCliente_Click1(object sender, EventArgs e)
        {
            Response.Redirect("/Ui/Registros/RCliente.aspx");
        }
    }
}
