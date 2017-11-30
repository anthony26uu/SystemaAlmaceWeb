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
    public  class DeudasTest
    {


        Entidades.Deudasclientes debe = new Entidades.Deudasclientes();


        [TestMethod()]
        public void GuardarTest()
        {
            debe.Deuda = 100;
            debe.Cliente = "Anthony";
            
            Assert.IsTrue(DeudasclientesBLL.Guardar(debe));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1; //ID Varia dependiendo lo registrado en la base de datos
            bool bandera = false;
            debe = DeudasclientesBLL.Buscar(p => p.IdDeudas == id);
            if (debe != null)
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
            int id = 1;
            debe = BLL.DeudasclientesBLL.Buscar(c => c.IdDeudas == id);

            debe.Deuda = 100;
            debe.Cliente = "Juan";



            Assert.IsTrue(DeudasclientesBLL.Mofidicar(debe));
        }
        [TestMethod()]
        public void EliminaTest()
        {
            int id = 1;
            debe = BLL.DeudasclientesBLL.Buscar(c => c.IdDeudas == id);

            Assert.IsTrue(DeudasclientesBLL.Eliminar(debe));
        }

    }
}

