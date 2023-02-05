using Mechanic.DDD.api.Queries;
using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Mechanic.DDD.Infrastructure;

using Microsoft.AspNetCore.Mvc;

namespace Mechanic.DDD.api.AplicationServices
{
    public class DuenoServices
    {
        private readonly DuenoQueries duenoQueries;
        private readonly IDuenoRepository duenoRepository;

        public DuenoServices(DuenoQueries duenoQueries, IDuenoRepository duenoRepository)
        {
            this.duenoQueries = duenoQueries;
            this.duenoRepository = duenoRepository;
        }












        // normal queries and services
        public async Task HandleCommands(Dueno dueno)
        {
            await duenoRepository.AddDueno(dueno);

        }
        public async Task<Dueno> GetDueno(int id)

        {
            return await duenoQueries.GetDuenoIdAsync(id);


        }
        public async Task<List<Dueno>> GetDuenosAsyc()
        {
            return await duenoQueries.GetDuenos();
        }
        public async Task<ActionResult> UpdateDueno(int id, Dueno dueno)
        {
            return await duenoQueries.UpdateDueno(id, dueno);
        }
        public async Task<ActionResult<Dueno>> DeleteDueno(int id)
        {
            return await duenoQueries.DeleteDueno(id);
        }
    }
}
