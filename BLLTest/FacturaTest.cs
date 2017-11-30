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
    public  class FacturaTest
    {



        Entidades.Facturas factura = new Entidades.Facturas();
        List<Entidades.FacturaDetalles> listaRelaciones = new List<Entidades.FacturaDetalles>();


        [TestMethod()]
        public void GuardarTest()
        {
           
            factura.CantidadProd = 10;
            factura.Cliente = "Randy";
            factura.FechaVenta = Convert.ToDateTime("0:00:00.079507");
            factura.NombreUsuario = "Juan";
            factura.TipoVenta = "Contado";
            factura.Total = 100;
           
            Assert.IsTrue(FacturaBLL.Guardar(factura,listaRelaciones));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 55; //ID Varia dependiendo lo registrado en la base de datos
            bool bandera = false;
            factura = FacturaBLL.Buscar(p => p.IdFactura == id);
            if (factura != null)
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
            int id = 55;
            factura = BLL.FacturaBLL.Buscar(c => c.IdFactura == id);
            factura.Total = 200;
          


            Assert.IsTrue(FacturaBLL.Mofidicar(factura));
        }
        [TestMethod()]
        public void EliminaTest()
        {
            int id = 55;
            factura = BLL.FacturaBLL.Buscar(c => c.IdFactura == id);

            Assert.IsTrue(FacturaBLL.Eliminar(factura));
        }
    }
}
