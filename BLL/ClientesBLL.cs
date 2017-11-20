using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{
    public class ClientesBLL
    {

       

        public static bool Guardar(Clientes nuevo)
        {
            bool retorno = false;

            using (var db = new Repositorio<Clientes>())
            {
                retorno = db.Guardar(nuevo) != null;
            }
            return retorno;

        }

        public static Clientes Buscar(Expression<Func<Clientes, bool>> criterioBusqueda)
        {
            using (var repositorio = new DAL.Repositorio<Clientes>())
            {
                return repositorio.Buscar(criterioBusqueda);
            }
        }

        public static List<Entidades.Clientes> GetList(Expression<Func<Entidades.Clientes, bool>> criterioBusqueda)
        {
            using (var repositorio = new DAL.Repositorio<Entidades.Clientes>())
            {
                return repositorio.GetList(criterioBusqueda);
            }
        }
        public static bool Eliminar(Clientes cliente)
        {
            using (var repositorio = new DAL.Repositorio<Clientes>())
            {
                return repositorio.Eliminar(cliente);
            }
        }


        public static List<Entidades.Clientes> GetListodo()
        {
            List<Entidades.Clientes> lista = new List<Entidades.Clientes>();
            using (var db = new DAL.Repositorio<Clientes>())
            {
                try
                {
                    return db.ListaTodo();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public static bool Mofidicar(Clientes existente)
        {
            bool eliminado = false;
            using (var repositorio = new Repositorio<Clientes>())
            {
                eliminado = repositorio.Modificar(existente);
            }

            return eliminado;

        }



    }
}
