using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{
    public class FacturaDetallesBLL
    {


        public static FacturaDetalles Guardard(FacturaDetalles detalle)
        {
            using (var repositorio = new Repositorio<FacturaDetalles>())
            {

                return repositorio.Guardar(detalle);

            }
        }

        public static bool Mofidicar(FacturaDetalles existente)
        {
            bool eliminado = false;
            using (var repositorio = new Repositorio<FacturaDetalles>())
            {
                eliminado = repositorio.Modificar(existente);
            }

            return eliminado;

        }


        public static List<Entidades.FacturaDetalles> GetListado(Expression<Func<Entidades.FacturaDetalles, bool>> criterioBusqueda)
        {
            List<Entidades.FacturaDetalles> lista = new List<Entidades.FacturaDetalles>();
            using (var db = new RegistroDb())
            {
                try
                {
                    lista = db.RelacionDb.Where(criterioBusqueda).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return lista;
            }
        }

        public static List<FacturaDetalles> GetList(Expression<Func<FacturaDetalles, bool>> criterioBusqueda)
        {
            using (var repositorio = new Repositorio<FacturaDetalles>())
            {
                return repositorio.GetList(criterioBusqueda);
            }
        }

        public static Entidades.FacturaDetalles Buscar(Expression<Func<FacturaDetalles, bool>> criterioBusqueda)
        {
            using (var repositorio = new DAL.Repositorio<FacturaDetalles>())
            {
                return repositorio.Buscar(criterioBusqueda);
            }
        }


        public static bool Guardar(FacturaDetalles relacion)
        {

            bool resultado = false;
            using (var conexion = new RegistroDb())
            {
                try
                {
                    conexion.RelacionDb.Add(relacion);
                    conexion.SaveChanges();
                    resultado = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }

        public static bool Eliminar(Entidades.FacturaDetalles detalle)
        {
            using (var repositorio = new Repositorio<Entidades.FacturaDetalles>())
            {
                return repositorio.Eliminar(detalle);
            }
        }


        public static bool Guardar(List<FacturaDetalles> listado)
        {
            bool resultado = false;
            try
            {
                foreach (var relacion in listado)
                {
                    resultado = Guardar(relacion);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }
        public static List<FacturaDetalles> GetLista(Expression<Func<FacturaDetalles, bool>> criterioBusqueda)
        {
            using (var repositorio = new Repositorio<FacturaDetalles>())
            {
                return repositorio.GetList(criterioBusqueda);
            }
        }

        public static List<Entidades.FacturaDetalles> GetListodo()
        {
            List<Entidades.FacturaDetalles> lista = new List<Entidades.FacturaDetalles>();
            using (var db = new RegistroDb())
            {
                try
                {
                    lista = db.RelacionDb.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return lista;
            }
        }


        public static List<Articulos> Listar(Expression<Func<FacturaDetalles, bool>> criterioBusqueda)
        {
            List<Articulos> listado = new List<Articulos>();
            List<FacturaDetalles> relaciones = null;
            using (var conexion = new RegistroDb())
            {
                try
                {
                    relaciones = conexion.RelacionDb.Where(criterioBusqueda).ToList();
                    foreach (var item in relaciones)
                    {
                        listado.Add(ArticuloBLL.BuscarRelacion(item.IdArticulo));
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }

    }

}
