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
    public  class CategoriaTest
    {

        Entidades.Categorias categoria = new Entidades.Categorias();


        [TestMethod()]
        public void GuardarTest()
        {

            categoria.NombreCategoria = "Calzado";
           

            Assert.IsTrue(CategoriaBLL.Guardar(categoria));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 5;
            bool bandera = false;
            categoria = CategoriaBLL.Buscar(p => p.CategoriaId == id);
            if (categoria != null)
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
            int id = 5;
            categoria = CategoriaBLL.Buscar(p => p.CategoriaId == id);
            categoria.NombreCategoria = "Calzad";


          

            Assert.IsTrue(CategoriaBLL.Mofidicar(categoria));
        }
        [TestMethod()]
        public void EliminaTest()
        {
            int id = 4;
            categoria = BLL.CategoriaBLL.Buscar(c => c.CategoriaId == id);

            Assert.IsTrue(CategoriaBLL.Eliminar(categoria));
        }

    }
}

