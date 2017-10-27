using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{

    public class ArticuloBLL
    {

        public static bool Guardar(Articulos nuevo)
        {
            bool retorno = false;

            using (var db = new Repositorio<Articulos>())
            {
                retorno = db.Guardar(nuevo) != null;
            }
            return retorno;

        }
        public static bool Mofidicar(Articulos existente)
        {
            bool eliminado = false;
            using (var repositorio = new Repositorio<Articulos>())
            {
                eliminado = repositorio.Modificar(existente);
            }

            return eliminado;

        }


        public static bool Eliminar(Articulos id)
        {
            bool resultado = false;
            using (var db = new Repositorio<Articulos>())
            {
                resultado = db.Eliminar(id);

            }
            return resultado;
        }

        public static List<Entidades.Articulos> GetList(Expression<Func<Entidades.Articulos, bool>> criterioBusqueda)
        {
            using (var repositorio = new DAL.Repositorio<Entidades.Articulos>())
            {
                return repositorio.GetList(criterioBusqueda);
            }
        }

        public static Articulos Buscar(Expression<Func<Articulos, bool>> tipo)
        {
            Articulos Result = null;
            using (var repoitorio = new Repositorio<Articulos>())

            {
                Result = repoitorio.Buscar(tipo);
            }

            return Result;
        }




        public static Entidades.Articulos BuscarB(int id)
        {

            Entidades.Articulos nuevo;
            using (var db = new RegistroDb())
            {
                try
                {
                    nuevo = db.articuloDb.Find(id);


                }
                catch (Exception)
                {

                    throw;
                }
                return nuevo;
            }
        }

        public static List<Entidades.Articulos> GetListodo()
        {

            using (var db = new DAL.Repositorio<Articulos>())
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

        public static Articulos BuscarRelacion(int id)
        {
            Articulos estudiante = null;
            using (var conexion = new RegistroDb())
            {
                try
                {
                    estudiante = conexion.articuloDb.Find(id);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return estudiante;
        }

    }



}