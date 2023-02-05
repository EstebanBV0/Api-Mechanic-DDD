using Mechanic.DDD.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Domain.Repositories
{
    public interface IRepuestoRepository
    {
        Task<IEnumerable<Repuesto>> GetAllForRevision(string placa);
        Task<Repuesto> GetRepuestoById(int id);
        Task AddRepuesto(Repuesto repuesto);
        Task<List<Repuesto>> GetAll();
        Task<ActionResult> UpdateRepuesto(int id, Repuesto repuestoActualizado);

        Task<ActionResult<Repuesto>> DeleteRepuestoById(int id);
    }
}
