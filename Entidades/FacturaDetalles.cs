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

        public   List<FacturaDetalles> Detalle;
        public static List<FacturaDetalles> impresion;
        public Entidades.Articulos Articulo { get; set; }
        public FacturaDetalles()
        {
            Detalle = new List<FacturaDetalles>();
            impresion = new List<FacturaDetalles>();
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
            Detalle = new List<FacturaDetalles>();
            impresion = new List<FacturaDetalles>();
        }


        public void AgregarDetalle(int idarticulo, int iddetalle, int idFactura, decimal precio, int cantidad, string nombre, decimal itbs)
        {
            this.Detalle.Add(new FacturaDetalles(idarticulo, iddetalle, idFactura, precio, cantidad, nombre, itbs));

            impresion = Detalle;
        }
    }
}
