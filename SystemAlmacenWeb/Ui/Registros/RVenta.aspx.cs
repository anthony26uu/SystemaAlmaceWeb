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
        Entidades.Facturas facturaG;
        DataTable dt = new DataTable();
        Entidades.Articulos artig = new Entidades.Articulos();
        private static List<Entidades.FacturaDetalles> listaRelaciones = null;
        private static List<Entidades.Articulos> listadoArticulos = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LlenarDrop();
                dt.Columns.AddRange(new DataColumn[7] { new DataColumn("ID Articulo"), new DataColumn("ID Detalle"), new DataColumn("ID Factura"), new DataColumn(" Precio"), new DataColumn("Cantidad"),
                new DataColumn("Nombre"), new DataColumn("ITBS")});
                ViewState["Detalle"] = dt;
                artig = new Entidades.Articulos();
                facturaG = new Entidades.Facturas();
                listadoArticulos = new List<Entidades.Articulos>();
                listaRelaciones = new List<Entidades.FacturaDetalles>();
            }

            
        }

        private void LlenarDrop()
        {
            List<Entidades.Articulos> ListaDrop = BLL.ArticuloBLL.GetListodo();

            DropArticulo.DataSource = ListaDrop;
            DropArticulo.DataValueField = "IdArticulo";
            DropArticulo.DataTextField = "NombreArticulo";
            DropArticulo.DataBind();

          


        }

        public void LlenarRegistro(Entidades.FacturaDetalles factura)
        {
           
          //  TextBoxfactura.Text = factura.IdFactura.ToString();
        //    DropArticulo.SelectedValue = factura.IdArticulo.ToString();
        //    TextBoxCantidad.Text = factura.Cantidad.ToString();
            foreach (var li in factura.Detalle)
            {
                DataTable dt = (DataTable)ViewState["Detalle"];
                dt.Rows.Add(li.IdArticulo, li.IdDetalle, li.IdFactura,li.Precio, li.Cantidad, li.Nombre, li.ITBIS);
                ViewState["Detalle"] = dt;
                this.BindGrid();
            }


        }

       

        public void LlenarDatos(Entidades.FacturaDetalles detalle)
        {

            int Idarti = 0;
            Entidades.Articulos art = new Entidades.Articulos();
            art = BLL.ArticuloBLL.Buscar(p => p.IdArticulo == Idarti);

            detalle.IdArticulo = Convert.ToInt32(DropArticulo.SelectedValue);
            detalle.Nombre = DropArticulo.Text;
           // detalle.Cantidad = Utilidades.TOINT(TextBoxCantidad.Text);
           // detalle.Precio = art.Precio;
           //detalle.ITBIS = art.ITBIS;
       
            foreach (GridViewRow dr in FacturaGrid.Rows)
            {
                detalle.AgregarDetalle(Convert.ToInt32(dr.Cells[0].Text), Convert.ToInt32(dr.Cells[1].Text), Convert.ToInt32(dr.Cells[2].Text),
                    Convert.ToDecimal(dr.Cells[3].Text), Convert.ToInt32(dr.Cells[4].Text), Convert.ToString(dr.Cells[5].Text), Convert.ToDecimal(dr.Cells[6].Text)
                    );
               
            }

            int id = 0;
            if (facturaG != null)
            {
                id = facturaG.IdFactura;
            }

            int cantidad = 5;
           
            facturaG = new Entidades.Facturas(id, "Anthony", DateTime.Now, "Clente", "Prueba", cantidad, 100);


        }

        protected void BindGrid()
        {
            FacturaGrid.DataSource = (DataTable)ViewState["Detalle"];
            FacturaGrid.DataBind();
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            int id = Utilidades.TOINT(DropArticulo.SelectedValue);
            artig= BLL.ArticuloBLL.Buscar(p => p.IdArticulo == id);

            int id2;
            if (facturaG != null)
            {
                id2 = facturaG.IdFactura;
            }

            DataTable dt = (DataTable)ViewState["Detalle"];
            dt.Rows.Add(DropArticulo.SelectedValue,0,0, artig.Precio, TextBoxCantidad.Text.Trim(),artig.NombreArticulo.Trim(),artig.ITBIS);
            ViewState["Detalle"] = dt;
            this.BindGrid();
            TextBoxCantidad.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {


            var guardar = new Entidades.Deudasclientes();



            Entidades.FacturaDetalles detallef = new Entidades.FacturaDetalles();
            LlenarDatos(detallef);

                if (BLL.FacturaBLL.Guardar(facturaG, detallef.Detalle))
                {


                Utilidades.ShowToastr(this, "Guardo", "Correcto", "success");
                 }
                else
                {
                Utilidades.ShowToastr(this, "Error", "Error", "error");
                  
                }
                
            }

        protected void Buscar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TextBoxBuscar.Text))
            {
                Utilidades.ShowToastr(this, "Llenar Campo buscaro", "Consejo", "info");

            }
            else
            {
                Entidades.FacturaDetalles detalleb = new Entidades.FacturaDetalles();
   


                //    TextBoxTotal.Text = facturaG.Total.ToString();
                // int id = Utilidades.TOINT(TextBoxBuscar.Text);
                
                if (BLL.FacturaDetallesBLL.Buscar(p => p.IdDetalle == 1)!=null)
                {
                    LlenarRegistro(detalleb);
                    Utilidades.ShowToastr(this, "Busqueda exitosa", "Exito");
                   
                }
                else
                {

                    Utilidades.ShowToastr(this, "Fallo", "error");
                }

            }

        }
    }
}