using Mechanic.DDD.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Domain.Repositories
{
    public interface IDuenoRepository
    {
        Task<Dueno> GetDuenoById(int Id);
        Task AddDueno(Dueno Dueno);
        Task<List<Dueno>> GetAll();
        Task<ActionResult> UpdateDueno(int id, Dueno duenoactualizado);

        Task<ActionResult<Dueno>> DeleteDuenoById(int id);

    }
}
