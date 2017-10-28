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
            ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
            myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
            myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
            myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
            myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);


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
            articulog.PrecioCompra = Convert.ToDecimal(TexboCosto.Text);
            articulog.PrecioVenta = Convert.ToDecimal(TexboPrecio.Text);
            articulog.ITBIS = Convert.ToDecimal(TexboItbis.Text);
            articulog.Existencia = Utilidades.TOINT(TextBoxExistencia.Text);
            articulog.Categoria = DropCategoria.Text;
            articulog.CodigoArticulo = DropCategoria.Text;
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
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Articulo modificado con exito');</script>");

                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Articulo No pudo ser modificado');</script>");

                    }


                }
                else
                {

                    if (BLL.ArticuloBLL.Guardar(articulog))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Nuevo Articulo agregada!');</script>");

                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No se pudo  agregar el Articulo');</script>");

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
                    BLL.ArticuloBLL.Eliminar(cate);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('El Elemento se ha Eliminado  con exito');</script>");

                    Limpiar();
                }

                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No se pudo eliminar El elemento compruebe existencia');</script>");
                    Limpiar();
                }
            }
        }

        protected void BotonBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxID.Text))
            {


                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No existen elementos con este id');</script>");
                Limpiar();
            }
            else

            {

                int id = int.Parse(TextBoxID.Text);
                var artic = BLL.ArticuloBLL.Buscar(p => p.CategoriaId == id);
                if (artic != null)
                {


                    TextBoxNombre.Text = artic.NombreArticulo;

                    TexboCodigo.Text = artic.CodigoArticulo;
                    TexboCosto.Text = Convert.ToString(artic.PrecioCompra);
                    TexboItbis.Text = Convert.ToString(artic.ITBIS);
                    TexboPrecio.Text = Convert.ToString(artic.PrecioVenta);
                    DropCategoria.Text = artic.Categoria;
                    TextFecha.Text = Convert.ToString(artic.FechaIngreso);



                }
                else
                {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No Existe Elementos con este id');</script>");
                    Limpiar();

                }
            }
        }
    }
}