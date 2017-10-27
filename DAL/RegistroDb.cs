using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;

namespace DAL
{
    public class RegistroDb : DbContext
    {
        public RegistroDb() : base("ConStr")
        {

        }

        public DbSet<Articulos> articuloDb { get; set; }
        public DbSet<Deudasclientes> deudasDb { get; set; }
        public DbSet<Usuarios> usuarioDb { get; set; }
        public DbSet<Clientes> clientesDb { get; set; }
        public DbSet<Categorias> categoriaDb { get; set; }
        public DbSet<FacturaDetalles> RelacionDb { get; set; }
        public DbSet<Facturas> FacturasDb { get; set; }


    }



   

}
