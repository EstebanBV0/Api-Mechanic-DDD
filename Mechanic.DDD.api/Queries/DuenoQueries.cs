using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Mechanic.DDD.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Mechanic.DDD.api.Queries
{
    public class DuenoQueries
    {
        private readonly IDuenoRepository duenoRepository;
        public DuenoQueries(IDuenoRepository duenoRepository)
        {
            this.duenoRepository = duenoRepository; 
        }
        public async Task<Dueno> GetDuenoIdAsync(int id)
        {
            var response = await duenoRepository.GetDuenoById(id);
            return response;
        }
        public async Task<List<Dueno>> GetDuenos()
        {
            return await duenoRepository.GetAll();

        }
        public async Task<ActionResult> UpdateDueno(int Id, Dueno dueno)
        {
            return await duenoRepository.UpdateDueno(Id, dueno);
        }
        public async Task<ActionResult<Dueno>> DeleteDueno(int id)
        {
            return await duenoRepository.DeleteDuenoById(id);
        }

    }
}
