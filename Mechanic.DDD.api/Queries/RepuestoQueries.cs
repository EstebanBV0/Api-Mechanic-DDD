using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Mechanic.DDD.api.Queries
{
    public class RepuestoQueries
    {
        private readonly IRepuestoRepository repuestosRepository;
        public RepuestoQueries(IRepuestoRepository repuestosRepository)
        {
            this.repuestosRepository = repuestosRepository;
        }

        public async Task<IEnumerable<Repuesto>> GetAllForRevision(string placa)
        {
            var repuestos = await repuestosRepository.GetAllForRevision(placa);
            return repuestos;
        }






        //normal queriess
        public async Task<Repuesto> GetRepuestoIdAsync(int id)
        {
            var response = await repuestosRepository.GetRepuestoById(id);
            return response;
        }
        public async Task<List<Repuesto>> GetRepuestos()
        {
            return await repuestosRepository.GetAll();

        }
        public async Task<ActionResult> UpdateRepuesto(int id, Repuesto repuesto)
        {
            return await repuestosRepository.UpdateRepuesto(id, repuesto);
        }
        public async Task<ActionResult<Repuesto>> DeleteRepuesto(int id)
        {
            return await repuestosRepository.DeleteRepuestoById(id);
    }
}
}
