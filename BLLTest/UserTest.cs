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
    public class UserTest
    {

        Entidades.Usuarios user = new Entidades.Usuarios();


        [TestMethod()]
        public void GuardarTest()
        {
           
            user.NombreUsuario = "Anthony";
            user.Tipo = "Administrador";
            user.PassUsuario = "000";
            user.FechaIngreso = Convert.ToDateTime("0:00:00.079507");


            Assert.IsTrue(UserBLL.Guardar(user));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 4;
            bool bandera = false;
            user = UserBLL.Buscar(p => p.Id == id);
            if (user != null)
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
            user = BLL.UserBLL.Buscar(c => c.Id == id);


            user.NombreUsuario = "Anthony";
            user.Tipo = "Administrador";
            user.PassUsuario = "000";
            user.FechaIngreso = Convert.ToDateTime("0:00:00.079507");


            Assert.IsTrue(UserBLL.Mofidicar(user));
        }
        [TestMethod()]
        public void EliminaTest()
        {
            int id = 4;
            user = BLL.UserBLL.Buscar(c => c.Id == id);

            Assert.IsTrue(UserBLL.Eliminar(user));
        }

    }
}

