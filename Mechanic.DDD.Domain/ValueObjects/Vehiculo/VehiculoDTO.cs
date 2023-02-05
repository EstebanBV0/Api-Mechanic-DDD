using Mechanic.DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Domain.ValueObjects
{
    public class VehiculoDTO
    {
        public int DuenoId { get; set; }
        public Dueno Dueno { get; set; }
        public List<Servicio> Servicios { get; set; }
        public string Estado { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Referencia { get; set; }
        public int Cilindraje { get; set; }
        public string Observaciones { get; set; }

    }
}
