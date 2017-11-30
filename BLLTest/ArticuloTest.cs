using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLTest
{
    [TestClass()]
  public  class ArticuloTest
    {

        Entidades.Articulos articulo = new Entidades.Articulos();


        [TestMethod()]
        public void GuardarTest()
        {

            articulo.NombreArticulo = "Tenni";
            articulo.Precio = 100;
            articulo.Costo = 150;
            articulo.Categoria = "Calzado";
            articulo.CodigoArticulo = "000";
            articulo.ITBIS = 10m;
            articulo.FechaIngreso = Convert.ToDateTime("0:00:00.079507");
            articulo.Existencia = 20;
            Assert.IsTrue(ArticuloBLL.Guardar(articulo));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 19;
            bool bandera = false;
            articulo = ArticuloBLL.Buscar(p => p.IdArticulo == id);
            if (articulo != null)
            {
                bandera = true;
            }
            else
            {
                bandera = false;
            }
            Assert.IsTrue(bandera);
        }
        [TestMethod()]
        public void ModificarTest()
        {
            int id = 14;

            articulo = ArticuloBLL.Buscar(p => p.IdArticulo == id);
            articulo.NombreArticulo = "Tenis";
            articulo.Precio = 100;
            articulo.Costo = 150;
            articulo.Categoria = "Calzado";
            articulo.CodigoArticulo = "000";
            articulo.ITBIS = 10m;
            articulo.FechaIngreso = Convert.ToDateTime("0:00:00.079507");
            articulo.Existencia = 20;



            Assert.IsTrue(ArticuloBLL.Mofidicar(articulo));
        }
        [TestMethod()]
        public void EliminaTest()
        {
            int id = 19;
            articulo = BLL.ArticuloBLL.Buscar(c => c.IdArticulo == id);

            Assert.IsTrue(ArticuloBLL.Eliminar(articulo));
        }

    }
}
