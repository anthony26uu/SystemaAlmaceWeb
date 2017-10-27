using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Facturas
    {
        [Key]
        public int IdFactura { get; set; }


        public string NombreUsuario { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Cliente { get; set; }
        public string TipoVenta { get; set; }
        public int CantidadProd { get; set; }
        public decimal Total { get; set; }



        public Facturas()
        {

        }
        public Facturas(int idFactura, string nombreUsuario, DateTime fechaVenta, string cliente, string tipoventa, int cantidadProd, decimal total)
        {
            this.IdFactura = idFactura;
            this.NombreUsuario = nombreUsuario;
            this.FechaVenta = fechaVenta;
            this.Cliente = cliente;
            this.TipoVenta = tipoventa;
            this.CantidadProd = cantidadProd;
            this.Total = total;

        }
    }
}
