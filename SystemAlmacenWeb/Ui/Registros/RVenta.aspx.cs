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
        private static List<Entidades.FacturaDetalles> listaRelaciones;
        private static List<Entidades.Articulos> listadoArticulos = null;

        public static List<Entidades.FacturaDetalles> detalle { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LlenarDrop();
              
                dt.Columns.AddRange(new DataColumn[7] { new DataColumn("ID Articulo"), new DataColumn("ID Detalle"), new DataColumn("ID Factura"), new DataColumn(" Precio"), new DataColumn("Cantidad"),
                new DataColumn("Nombre"), new DataColumn("ITBS")});
                ViewState["Detalle"] = dt;
                artig = new Entidades.Articulos();
              
                listadoArticulos = new List<Entidades.Articulos>();
                listaRelaciones = new List<Entidades.FacturaDetalles>();
                detalle = new List<Entidades.FacturaDetalles>();

                facturaG = new Entidades.Facturas();
                DropDownTipoVenta.Text = "";
            }

            
        }

      
        private void limpiar()
        {
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("ID Articulo"), new DataColumn("ID Detalle"), new DataColumn("ID Factura"), new DataColumn(" Precio"), new DataColumn("Cantidad"),
                new DataColumn("Nombre"), new DataColumn("ITBS")});

            TextBoxBuscar.Text = "";
            ViewState["Detalle"] = dt;
            this.BindGrid();
            DropDownTipoVenta.Text = "";
            DropDownTipoVenta.SelectedValue = null;
        //    DropDownTipoVenta.SelectedItem.Text=":"
        }

        public void LlenarRegistro( List<Entidades.FacturaDetalles> llenar )
        {
          //  limpiar();

            foreach (var li in llenar)
            {
                DataTable dt = (DataTable)ViewState["Detalle"];
                dt.Rows.Add(li.IdArticulo, li.IdDetalle, li.IdFactura,li.Precio, li.Cantidad, li.Nombre, li.ITBIS);
                ViewState["Detalle"] = dt;
                this.BindGrid();
            }


        }

       

        public void LlenarDatos(Entidades.FacturaDetalles detalle)
        {


           
            int id = 0;
            
            if (facturaG != null)
            {
                id = facturaG.IdFactura;
                
            }

            int cantidad= 0;
         
           
           foreach (GridViewRow dr in FacturaGrid.Rows)
            {
                detalle.AgregarDetalle(Convert.ToInt32(dr.Cells[0].Text), 0,0,
                    Convert.ToDecimal(dr.Cells[3].Text), Convert.ToInt32(dr.Cells[4].Text), Convert.ToString(dr.Cells[5].Text), Convert.ToDecimal(dr.Cells[6].Text)
                    );
                cantidad  =+ 1;               
            }
                                  
            facturaG = new Entidades.Facturas(0, "Anthony", DateTime.Now, "Clente", "Prueba", cantidad, 100);


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

            int id2=0;
            if (facturaG != null)
            {
                id2 = facturaG.IdFactura;
            }

            DataTable dt = (DataTable)ViewState["Detalle"];
            dt.Rows.Add(DropArticulo.SelectedValue,0, Convert.ToString(id2), artig.Precio, TextBoxCantidad.Text.Trim(),artig.NombreArticulo.Trim(),artig.ITBIS);
            ViewState["Detalle"] = dt;
            this.BindGrid();
            TextBoxCantidad.Text = "";
        }
                 


            protected void Button2_Click(object sender, EventArgs e)
            {

            


            Entidades.FacturaDetalles detallef = new Entidades.FacturaDetalles();
            LlenarDatos(detallef);

                if (BLL.FacturaBLL.Guardar(facturaG, detallef.Detalle))
                {


                Utilidades.ShowToastr(this, "Guardo", "Correcto", "success");
                limpiar();
                 }
                else
                {
                Utilidades.ShowToastr(this, "Error", "Error", "error");
                  
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

        private void RefreshListaRelciones()
        {
            FacturaGrid.DataSource = null;
            FacturaGrid.DataSource = listaRelaciones;
            FacturaGrid.DataBind();
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
                  

                   listaRelaciones = BLL.FacturaDetallesBLL.GetList(A => A.IdFactura == facturaG.IdFactura);
                    if (facturaG != null)
                    {


                        if (listaRelaciones.Count == 0)
                        {
                            Utilidades.ShowToastr(this, "No se ha registrado Articulos con este ID", "Resultados", "error");


                        }
                        else
                        {

                            TextBoxVendedor.Text=   facturaG.NombreUsuario;
                            DropDownCliente.Text = facturaG.Cliente;
                            TexboxCantidad.Text = Convert.ToString(facturaG.CantidadProd);
                            TextFecha.Text = Convert.ToString(facturaG.FechaVenta);
                            TextBoxTotal.Text = Convert.ToString(facturaG.Total);


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
    }
}