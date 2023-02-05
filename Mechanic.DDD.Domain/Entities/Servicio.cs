using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Domain.Entities
{
    public class Servicio
    {
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public List<Repuesto> Repuestos { get; set; }
        public int Nivelaceite { get; set; }

        public int MecanicoId { get; set; }
        public  Mecanico  Dueno { get; set; }

        public int Nivelfrenos { get; set; }
        public  DateTime FechaRev { get; set; }




    }
}
