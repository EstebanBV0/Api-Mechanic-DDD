using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mechanic.DDD.Domain.Entities
{
    public  class Mecanico : Persona
    {
        public int Id { get; set; }
        public string NivelEstudio { get; set; }
        public string FechaNacimiento { get; set; }
        
        public  List<Servicio> Servicio { get; set; }


    }
}
