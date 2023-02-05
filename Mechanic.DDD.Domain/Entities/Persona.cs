using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Domain.Entities
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NumeroTelefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int Cedula { get; set; }


    }
}