using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{
    public class CategoriaBLL
    {
        public static bool Guardar(Categorias nuevo)
        {
            bool retorno = false;

            using (var db = new Repositorio<Categorias>())
            {
                retorno = db.Guardar(nuevo) != null;
            }
            return retorno;

        }

        public static bool Mofidicar(Categorias existente)
        {
            bool eliminado = false;
            using (var repositorio = new Repositorio<Categorias>())
            {
                eliminado = repositorio.Modificar(existente);
            }

            return eliminado;

        }

        public static bool Eliminar(Categorias id)
        {
            bool resultado = false;
            using (var db = new Repositorio<Categorias>())
            {
                resultado = db.Eliminar(id);

            }
            return resultado;
        }

        public static Categorias Buscar(Expression<Func<Categorias, bool>> tipo)
        {
            Categorias Result = null;
            using (var repoitorio = new Repositorio<Categorias>())

            {
                Result = repoitorio.Buscar(tipo);
            }

            return Result;
        }

        public static List<Entidades.Categorias> GetListodo()
        {
            List<Entidades.Categorias> lista = new List<Entidades.Categorias>();
            using (var db = new DAL.Repositorio<Categorias>())
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
        public static List<Entidades.Categorias> GetList(Expression<Func<Entidades.Categorias, bool>> criterioBusqueda)
        {
            using (var repositorio = new DAL.Repositorio<Entidades.Categorias>())
            {
                return repositorio.GetList(criterioBusqueda);
            }
        }

    }
}
