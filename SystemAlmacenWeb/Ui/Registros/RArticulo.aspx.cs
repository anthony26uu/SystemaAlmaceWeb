using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb.Ui.Registros
{
    public partial class RArticulo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            TextFecha.Text = (DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);
            TextBoxID.Focus();
            Utilidades.SCritpValidacion();

            if (!Page.IsPostBack)
            {
                LlenarDrop();
            }

        }

        Articulos articulog = new Articulos();


        public Articulos LlenarCampos()
        {
            articulog.IdArticulo = Utilidades.TOINT(TextBoxID.Text);
            articulog.NombreArticulo = TextBoxNombre.Text;
            articulog.Costo = Convert.ToDecimal(TexboCosto.Text);
            articulog.Precio = Convert.ToDecimal(TexboPrecio.Text);
            articulog.ITBIS = Convert.ToDecimal(TexboItbis.Text);
            articulog.Existencia = Utilidades.TOINT(TextBoxExistencia.Text);
            articulog.Categoria = DropCategoria.Text;
            articulog.CodigoArticulo = TexboCodigo.Text;
            articulog.FechaIngreso = Convert.ToDateTime(TextFecha.Text);

           
            return articulog;
        }


        private void LlenarDrop()
        {
            List<Entidades.Categorias> ListaDrop = BLL.CategoriaBLL.GetListodo();

            DropCategoria.DataSource = ListaDrop;
            DropCategoria.DataValueField = "CategoriaId";
            DropCategoria.DataTextField = "NombreCategoria";
            DropCategoria.DataBind();




        }

        private void Limpiar()
        {
            TexboCodigo.Text = "";
            TexboCosto.Text = "";
            TexboItbis.Text = "";
            TexboPrecio.Text = "";
            TextBoxID.Text = "";
            TextBoxNombre.Text = "";
            TextBoxExistencia.Text = "";

            RequiredFieldValidator1.Text = "";
            RequiredFieldValidator2.Text = "";
            RequiredFieldValidator3.Text = "";
            RequiredFieldValidator6.Text = "";
            RequiredFieldValidator7.Text = "";
            RequiredFieldValidator8.Text = "";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int id = 0;

            if (IsValid)
            {

                articulog = LlenarCampos();


                if (id != articulog.IdArticulo)
                {

                    if (BLL.ArticuloBLL.Mofidicar(articulog))
                    {
                        Utilidades.ShowToastr(this, "Se modifico Articulo Satisfactoriamente", "Correcto", "success");
                    }
                    else
                    {
                        Utilidades.ShowToastr(this, "No se pudo modificar Articulo", "Error", "Error");
                    }


                }
                else
                {

                    if (BLL.ArticuloBLL.Guardar(articulog))
                    {
                       Utilidades.ShowToastr(this, "Agredado Articulo", "Correcto", "success");
                    }
                    else
                    {
                        Utilidades.ShowToastr(this, "No se agrego", "Error", "error");
                      
                    }


                }

            }
            Limpiar();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxID.Text))
            {
                  Limpiar();


            }
            else
            {
                int id = int.Parse(TextBoxID.Text);

                var cate = BLL.ArticuloBLL.Buscar(p => p.IdArticulo == id);
                if (cate != null)
                {
                   if( BLL.ArticuloBLL.Eliminar(cate))
                    {
                        Utilidades.ShowToastr(this, "Se a Eliminado", "Correcto", "success");
                        Limpiar();
               

                    }
                    else
                    {
                        Utilidades.ShowToastr(this, "No se puedo Eliminar", "Fallido", "error");
                    }
               
                }

                else
                {
                    Utilidades.ShowToastr(this, "No se puedo Eliminar", "Fallido", "error");
            

                    Limpiar();
                }
            }
        }

        protected void BotonBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxID.Text))
            {

                Utilidades.ShowToastr(this, "Capo Vacio ", "Fallido", "error");
               Limpiar();
            }
            else

            {

                int id = int.Parse(TextBoxID.Text);
                var artic = BLL.ArticuloBLL.Buscar(p => p.IdArticulo == id);
                if (artic != null)
                {


                    TextBoxNombre.Text = artic.NombreArticulo;

                    TexboCodigo.Text = artic.CodigoArticulo;
                    TexboCosto.Text = Convert.ToString(artic.Costo);
                    TexboItbis.Text = Convert.ToString(artic.ITBIS);
                    TexboPrecio.Text = Convert.ToString(artic.Precio);
                    DropCategoria.Text = artic.Categoria;
                    TextFecha.Text = Convert.ToString(artic.FechaIngreso);
                    TextBoxExistencia.Text = Convert.ToString(artic.Existencia);
                    Utilidades.ShowToastr(this, "Resultados", "Correcto", "success");

                }
                else
                {
                    Utilidades.ShowToastr(this, "NO existen elementos", "Resultados", "error");
                    Limpiar();

                }
            }
        }
    }
}