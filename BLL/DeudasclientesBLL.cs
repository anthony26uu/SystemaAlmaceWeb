using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{
    public class DeudasclientesBLL
    {
        public static bool Guardar(Deudasclientes nuevo)
        {
            bool retorno = false;

            using (var db = new Repositorio<Deudasclientes>())
            {
                retorno = db.Guardar(nuevo) != null;
            }
            return retorno;

        }

        public static bool Mofidicar(Deudasclientes existente)
        {
            bool eliminado = false;
            using (var repositorio = new Repositorio<Deudasclientes>())
            {
                eliminado = repositorio.Modificar(existente);
            }

            return eliminado;

        }

        public static bool Eliminar(Deudasclientes id)
        {
            bool resultado = false;
            using (var db = new Repositorio<Deudasclientes>())
            {
                resultado = db.Eliminar(id);

            }
            return resultado;
        }

        public static Deudasclientes Buscar(Expression<Func<Deudasclientes, bool>> tipo)
        {
            Deudasclientes Result = null;
            using (var repoitorio = new Repositorio<Deudasclientes>())

            {
                Result = repoitorio.Buscar(tipo);
            }

            return Result;
        }

        public static List<Entidades.Deudasclientes> GetListodo()
        {
            List<Entidades.Deudasclientes> lista = new List<Entidades.Deudasclientes>();
            using (var db = new DAL.Repositorio<Deudasclientes>())
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
        public static List<Entidades.Deudasclientes> GetList(Expression<Func<Entidades.Deudasclientes, bool>> criterioBusqueda)
        {
            using (var repositorio = new DAL.Repositorio<Entidades.Deudasclientes>())
            {
                return repositorio.GetList(criterioBusqueda);
            }
        }

    }
}
