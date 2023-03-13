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
        public Mecanico (int id, string nivelEstudio, string nombre , string apellido, int numeroTelefono, string fechaNacimiento, string correo,
            string direccion, int cedula)
        {
            Id = id; 
            NivelEstudio = nivelEstudio;
            Nombre = nombre;
            Apellido = apellido;
            NumeroTelefono = numeroTelefono;
            FechaNacimiento = fechaNacimiento;
            Correo = correo;
           Direccion = direccion;
            Cedula = cedula;
     


        }
        public Mecanico()
        {

        }




    }
}
