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

 
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LlenarDropCliente();
                LlenarDrop();

                dt.Columns.AddRange(new DataColumn[7] { new DataColumn("ID Articulo"), new DataColumn("ID Detalle"), new DataColumn("ID Factura"), new DataColumn(" Precio"), new DataColumn("Cantidad"),
                new DataColumn("Nombre"), new DataColumn("ITBS")});
                ViewState["Detalle"] = dt;
                artig = new Entidades.Articulos();

                listadoArticulos = new List<Entidades.Articulos>();
                listaRelaciones = new List<Entidades.FacturaDetalles>();
                            
                facturaG = new Entidades.Facturas();
                DropDownTipoVenta.Text = "";
            }


        }


        private void limpiar()
        {
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("ID Articulo"), new DataColumn("ID Detalle"),
                new DataColumn("ID Factura"), new DataColumn(" Precio"),
                new DataColumn("Cantidad"),
                new DataColumn("Nombre"), new DataColumn("ITBS")});

            TextBoxBuscar.Text = "";
            ViewState["Detalle"] = dt;
            this.BindGrid();
            DropDownTipoVenta.Text = "";
            DropDownTipoVenta.SelectedValue = null;
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
        }

        public void LlenarRegistro(List<Entidades.FacturaDetalles> llenar)
        {

            foreach (var li in llenar)
            {
                DataTable dt = (DataTable)ViewState["Detalle"];
                dt.Rows.Add(li.IdArticulo, li.IdDetalle, li.IdFactura, li.Precio, li.Cantidad, li.Nombre, li.ITBIS);
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
             Convert.ToDecimal(dr.Cells[3].Text), Convert.ToInt32(dr.Cells[4].Text), Convert.ToString(dr.Cells[5].Text), Convert.ToDecimal(dr.Cells[6].Text)
                    );
                cantidad++;
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

            int id2 = 0;
            if (facturaG != null)
            {
                id2 = facturaG.IdFactura;

            }



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
                       

                        break;

                    }
                }
                if (agregado)
                {
                  
                    Utilidades.ShowToastr(this, " Articulo ya esta en factura -Selecione otro","Error" , "info");

                }
                else
                {
                    DataTable dt = (DataTable)ViewState["Detalle"];
                    dt.Rows.Add(DropArticulo.SelectedValue, 0, Convert.ToString(id2), artig.Precio, TextBoxCantidad.Text.Trim(), artig.NombreArticulo.Trim(), artig.ITBIS);
                    ViewState["Detalle"] = dt;
                    this.BindGrid();
                    CalcularMonto();
                    TextBoxCantidad.Text = "";


                }


            }
                        
        }



        protected void Button2_Click(object sender, EventArgs e)
        {




            Entidades.FacturaDetalles detallef = new Entidades.FacturaDetalles();
            LlenarDatos(detallef);

            if (BLL.FacturaBLL.Guardar(facturaG, detallef.Detalle))
            {
                EliminarExitencia();

                Utilidades.ShowToastr(this, "Guardo", "Correcto", "success");
                limpiar();
            }
            else
            {
                Utilidades.ShowToastr(this, "Error", "Error", "error");

            }

        }


        private void EliminarExitencia()
        {

            decimal descuento = 0;
            Entidades.Articulos Descontar = new Entidades.Articulos();
            foreach (GridViewRow producto in FacturaGrid.Rows)
            {

                int productoId = Convert.ToInt32(producto.Cells[0].Text); ///Celda 2 es el idArticulo antes esta detalleid y facturaid
                descuento = Convert.ToDecimal(producto.Cells[4].Text); //Celda 4 es la cantiddad

                Descontar = BLL.ArticuloBLL.BuscarB(productoId);
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

        private void RefreshListaRelciones()
        {
            FacturaGrid.DataSource = null;
            FacturaGrid.DataSource = listaRelaciones;
            FacturaGrid.DataBind();
        }


        public void CalcularMonto()
        {
            decimal subTotal = 0m;
            decimal descuento = 0;
            decimal total = 0;
            decimal itbs = 0;
            int porciento = 100;
            int devuelta = 0;

            if (FacturaGrid.Rows.Count > 0)
            {
                foreach (GridViewRow precio in FacturaGrid.Rows)
                {
                    Math.Round(subTotal += Convert.ToDecimal(precio.Cells[3].Text));
                    Math.Round(subTotal += (subTotal * 0.18m));
                    TextBoxSubTotal.Text = subTotal.ToString();

                    itbs += Convert.ToDecimal(precio.Cells[6].Text);
                    TextBoxTotalITBS.Text = itbs.ToString();
                }
            }
            if (DescuentoTextBox.Text == "")
            {
                DescuentoTextBox.Text = Convert.ToString(0);
            }

            descuento = (Convert.ToDecimal(DescuentoTextBox.Text) / porciento) * Convert.ToDecimal(TextBoxSubTotal.Text);
            Math.Round(total = (subTotal + itbs) - descuento);
            TextBoxTotal.Text = total.ToString();

            devuelta = Utilidades.TOINT(TextMontoRecibido.Text) - Convert.ToInt16(total);
            TexboxDevuelta.Text = devuelta.ToString();




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

                            foreach (var relacion in listaRelaciones)
                            {
                                listadoArticulos.Add(BLL.ArticuloBLL.Buscar(A => A.IdArticulo == relacion.IdArticulo));
                            }

                            foreach (var articulo in listadoArticulos)
                            {
                                articulo.IdArticulo = BLL.ArticuloBLL.Buscar(A => A.IdArticulo == articulo.IdArticulo).IdArticulo;
                            }

                            LlenarRegistro(listaRelaciones);


                            Utilidades.ShowToastr(this, "Sus Resultados", "Resultados", "success");

                        }



                    }





                }
                else
                {
                    Utilidades.ShowToastr(this, "No existe factura", "Error", "error");
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

        protected void TextMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            CalcularMonto();

        }
    }
}
