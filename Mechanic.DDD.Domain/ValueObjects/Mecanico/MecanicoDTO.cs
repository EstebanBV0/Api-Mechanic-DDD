using Mechanic.DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Domain.ValueObjects
{
    public class MecanicoDTO
    {

        public int Id { get; set; }
        public string NivelEstudio { get; set; }
        public string FechaNacimiento { get; set; }

        public List<Servicio> Servicio { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NumeroTelefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int Cedula { get; set; }
    }
}
