using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }

        public Clientes()
        {

        }

        public Clientes(int clienteId, string nombres, string direccion, string email, string sexo, DateTime fechaNacimiento, string cedula)
        {
            this.Cedula = cedula;
            this.ClienteId = clienteId;
            this.Nombres = nombres;
            this.Direccion = direccion;
            this.Email = email;
            this.Sexo = sexo;
            this.FechaNacimiento = fechaNacimiento;
        }




    }
}
