using Mechanic.DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Domain.ValueObjects
{
    public class RepuestoDTOput
    {
        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
