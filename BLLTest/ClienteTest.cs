using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLTest
{
    [TestClass()]
    public  class ClienteTest
    {
         Entidades.Clientes cliente = new Clientes();
       

        [TestMethod()]
        public void GuardarTest()
        {
           
            cliente.Nombres = "Anthony";
            cliente.Email = "Anthony@gmail.com";
            cliente.Cedula = "000";
            cliente.Telefono = "00";
            cliente.Sexo = "Masculino";
            cliente.FechaNacimiento = Convert.ToDateTime("0:00:00.079507");
          
            Assert.IsTrue(ClientesBLL.Guardar(cliente));
        }

        [TestMethod()]
        public void BuscarTest()
        {
           int id = 4;
            bool bandera=false;
            cliente = ClientesBLL.Buscar(p => p.ClienteId == id);
            if(cliente !=null)
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
            int id = 4;
            cliente = BLL.ClientesBLL.Buscar(c => c.ClienteId == id);

           
            cliente.Nombres = "juan";
            cliente.Email = "Anthony@gmail.com";
            cliente.Cedula = "000";
            cliente.Telefono = "00";
            cliente.Sexo = "Masculino";
            cliente.FechaNacimiento = Convert.ToDateTime("0:00:00.079507");

            Assert.IsTrue(ClientesBLL.Mofidicar(cliente));
        }
        [TestMethod()]
        public void EliminaTest()
        {
            int id = 4;
            cliente = BLL.ClientesBLL.Buscar(c => c.ClienteId == id);

            Assert.IsTrue(ClientesBLL.Eliminar(cliente));
        }

    }
}
