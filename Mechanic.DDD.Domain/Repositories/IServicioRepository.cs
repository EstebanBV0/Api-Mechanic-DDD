using Mechanic.DDD.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Domain.Repositories
{
    public  interface IServicioRepository
    {
        Task<Servicio> GetServicioById(int Id);
        Task AddServicio(Servicio servicio);
        Task<List<Servicio>> GetAll();
        Task<ActionResult> UpdateServicio(int id, Servicio servicioactualiz);

        Task<ActionResult<Servicio>> DeleteServicioById(int id);

    }
}
