using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLTest
{
    [TestClass()]
    class FacturasDetallesTest
    {

        Entidades.FacturaDetalles Factura = new Entidades.FacturaDetalles();


        [TestMethod()]
        public void GuardarTest()
        {
            Factura.AgregarDetalle(4, 0, 0, 200m, 2, "Tennis", 0.18m);


            Assert.IsTrue(BLL.FacturaDetallesBLL.Guardar(Factura));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 3; //ID Varia dependiendo lo registrado en la base de datos
            bool bandera = false;
            Factura = BLL.FacturaDetallesBLL.Buscar(p => p.IdDetalle == id);
            if (Factura != null)
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
            int id = 10;
            Factura = BLL.FacturaDetallesBLL.Buscar(c => c.IdDetalle == id);

            Factura.Cantidad = 100;
            Factura.Nombre = "Juan";



            Assert.IsTrue(BLL.FacturaDetallesBLL.Mofidicar(Factura));
        }
        [TestMethod()]
        public void EliminaTest()
        {
            int id = 10;
            Factura = BLL.FacturaDetallesBLL.Buscar(c => c.IdDetalle == id);

            Assert.IsTrue(BLL.FacturaDetallesBLL.Eliminar(Factura));
        }
    }
}
