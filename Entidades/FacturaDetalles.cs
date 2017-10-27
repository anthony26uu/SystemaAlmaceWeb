using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class FacturaDetalles
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdFactura { get; set; }
        public int IdArticulo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Nombre { get; set; }
        public decimal ITBIS { get; set; }

        public Entidades.Articulos Articulo { get; set; }
        public FacturaDetalles()
        {

        }

        public FacturaDetalles(int idArticulo, int idDetalle, int idFactura, decimal precio, int Cantidad, string nombre, decimal itbis)
        {
            this.IdDetalle = idDetalle;
            this.IdFactura = idFactura;
            this.IdArticulo = idArticulo;
            this.Precio = precio;
            this.Cantidad = Cantidad;
            this.Nombre = nombre;
            this.ITBIS = itbis;


        }
    }
}
