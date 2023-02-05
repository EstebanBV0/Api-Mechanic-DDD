using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Domain.Entities
{
    public class Dueno : Persona
    {
        public int Id { get; set; }
        public List<Vehiculo> Vehiculos { get; set; }
    }
}
