using BLL;
using Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemAlmacenWeb.Ui.Registros
{
    public partial class RCategoria : System.Web.UI.Page
    {
        Categorias categoriag = new Categorias();
        protected void Page_Load(object sender, EventArgs e)
        {

            ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
            myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
            myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
            myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
            myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);
        }

        private void Limpiar()
        {
            RequiredFieldValidator1.Text = "";
            RequiredFieldValidator2.Text = "";
            Textnombre.Text = "";
            Textid.Text = "";
        }

        public Categorias LlenarCampos()
        {
            categoriag.CategoriaId = Utilidades.TOINT(Textid.Text);
            categoriag.NombreCategoria = Textnombre.Text;
            return categoriag;
        }


        protected void Button3_Click(object sender, EventArgs e)
        {

            int id = 0;

            if (IsValid)
            {

                categoriag = LlenarCampos();


                if (id != categoriag.CategoriaId)
                {

                    if (CategoriaBLL.Mofidicar(categoriag))
                    {
                          Utilidades.ShowToastr(this, "Modificado con exito", "CORRECTO", "success");

                    }
                    else
                    {
                        Utilidades.ShowToastr(this, "Error Al modificar Categoria", "ERROR", "error");

                    }


                }
                else
                {

                    if (CategoriaBLL.Guardar(categoriag))
                    {

                        Utilidades.ShowToastr(this, "Agregada correctamente", "CORRECTO", "success");

                    }
                    else
                    {
                        Utilidades.ShowToastr(this, "Error al guardar", "ERROR", "error");

                    }


                }

            }
            Limpiar();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Textid.Text))
            {

                Utilidades.ShowToastr(this, "Campo Vacio", "ERROR", "error");

                Limpiar();
            }
            else

            {

                int id = int.Parse(Textid.Text);
                var cate = CategoriaBLL.Buscar(p => p.CategoriaId == id);
                if (cate != null)
                {

                  
                    Textnombre.Text = cate.NombreCategoria;
                    Utilidades.ShowToastr(this, "Sus Resultados", "CORRECTO", "success");




                }
                else
                {
                    Utilidades.ShowToastr(this, "No existe categoria con este ID", "ERROR", "error");
                    Limpiar();

                }
            }
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Textid.Text))
            {
                Utilidades.ShowToastr(this, "Capo Vacio", "ERROR", "error");

                Limpiar();


            }
            else
            {
                int id = int.Parse(Textid.Text);

                var cate = CategoriaBLL.Buscar(p => p.CategoriaId == id);
                if (cate != null)
                {
                    CategoriaBLL.Eliminar(cate);
                    Utilidades.ShowToastr(this, "Se ha modificado con exito", "CORRECTO", "success");

                    Limpiar();
                }

                else
                {
                    Utilidades.ShowToastr(this, "No se puedo eliminar Categoria", "ERROR", "error");

                    Limpiar();
                }
            }
        }
    }
    }
