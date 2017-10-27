using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
    public class Repositorio<TEntity> : IRepository<TEntity> where TEntity : class
    {
        RegistroDb Contex = null;

        public Repositorio()
        {
            Contex = new RegistroDb();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> criterioBusqueda)
        {
            try
            {
                return EntitySet.Where(criterioBusqueda).ToList();
            }
            catch (Exception)
            {
                throw;
                return new List<TEntity>();
            }
        }


        private DbSet<TEntity> EntitySet
        {
            get
            {

                return Contex.Set<TEntity>();
            }
        }

        public bool GuardarBool(TEntity entidad)
        {
            try
            {
                EntitySet.Add(entidad);
                return Contex.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
        }

        public TEntity Guardar(TEntity laEntidad)
        {
            TEntity Result = null;

            try
            {
                EntitySet.Add(laEntidad);
                Contex.SaveChanges();
                Result = laEntidad;
            }
            catch (Exception)
            {
                throw;
            }

            return Result;
        }

        public bool Modificar(TEntity laEntidad)
        {
            bool Result = false;

            try
            {

                EntitySet.Attach(laEntidad);


                Contex.Entry<TEntity>(laEntidad).State = EntityState.Modified;

                Result = Contex.SaveChanges() > 0;
            }
            catch { }

            return Result;
        }

        public TEntity Buscar(Expression<Func<TEntity, bool>> criterioBusqueda)
        {
            TEntity Result = null;

            try
            {
                Result = EntitySet.FirstOrDefault(criterioBusqueda);
            }
            catch { }

            return Result;
        }

        public bool Eliminar(TEntity entidad)
        {
            try
            {
                EntitySet.Attach(entidad);
                EntitySet.Remove(entidad);
                return Contex.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<TEntity> Lista(Expression<Func<TEntity, bool>> criterioBusqueda)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criterioBusqueda).ToList();
            }
            catch { }

            return Result;
        }


        public List<TEntity> ListaTodo()
        {
            using (var Conec = new DAL.RegistroDb())
            {
                try
                {
                    return EntitySet.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return null;
        }

        public void Dispose()
        {
            if (Contex != null)
                Contex.Dispose();
        }
    }
}
