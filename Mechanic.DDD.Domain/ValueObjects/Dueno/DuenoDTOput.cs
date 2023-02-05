using Mechanic.DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Domain.ValueObjects
{
    public class DuenoDTOput
    {
        public List<Vehiculo> Vehiculos { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NumeroTelefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int Cedula { get; set; }
    }
}
