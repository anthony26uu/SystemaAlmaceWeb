﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Articulos
    {

        [Key]
        public int IdArticulo { get; set; }
        public String NombreArticulo { get; set; }
        public int Existencia { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public string Categoria { get; set; }
        public string CodigoArticulo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int CategoriaId { get; set; }
        public decimal ITBIS { get; set; }


        public Articulos()
        {


        }


        public Articulos(int idArticulo, string nombreArticulo, int existencia, decimal precio, decimal costo, string codigoArticulo, DateTime fechaIngreso, decimal itbs, string categoria)
        {
            this.IdArticulo = idArticulo;
            this.NombreArticulo = nombreArticulo;
            this.Existencia = existencia;
            this.Precio = precio;
            this.Costo = costo;
            this.Categoria = categoria;
            this.CodigoArticulo = codigoArticulo;
            this.FechaIngreso = fechaIngreso;
            this.ITBIS = itbs;
        }

    }
}
