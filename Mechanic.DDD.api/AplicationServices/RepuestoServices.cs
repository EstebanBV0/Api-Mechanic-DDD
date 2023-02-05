using Mechanic.DDD.api.Queries;
using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Mechanic.DDD.api.AplicationServices
{
    public class RepuestoServices
    {
        private readonly IRepuestoRepository repuestoRepository;
        private readonly RepuestoQueries repuestoQueries;

        public RepuestoServices(IRepuestoRepository repuestoRepository, RepuestoQueries repuestoQueries)
        {
            this.repuestoRepository = repuestoRepository;
            this.repuestoQueries = repuestoQueries; 
        }

        public async Task<IEnumerable<Repuesto>> GetAllForRevision(string placa)
        {
            return await repuestoQueries.GetAllForRevision(placa);
        }







        //Normal queries and services 
        public async Task HandleCommand(Repuesto repuesto)
        {
            await repuestoRepository.AddRepuesto(repuesto);

        }
        public async Task<Repuesto> GetRepuesto(int id)

        {
            return await repuestoQueries.GetRepuestoIdAsync(id);

        }
        public async Task<List<Repuesto>> GetRepuestos()
        {
            return await repuestoQueries.GetRepuestos();  
        }
        public async Task<ActionResult> UpdateRepuesto (int id, Repuesto repuesto)
        {
            return await repuestoQueries.UpdateRepuesto(id, repuesto);
        }
        public async Task<ActionResult<Repuesto>> DeleteRepuesto(int id)
        {
            return await repuestoQueries.DeleteRepuesto(id);    
        }


    }
}
