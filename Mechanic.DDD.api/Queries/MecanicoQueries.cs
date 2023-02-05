using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Mechanic.DDD.api.Queries
{
    public class MecanicoQueries
    {
        private readonly IMecanicoRepository mecanicoRepository;
        public MecanicoQueries( IMecanicoRepository mecanicoRepository)
        {
            this.mecanicoRepository = mecanicoRepository;
        }
        public async Task<Mecanico> GetMecanicoIdAsync (int id)
        {
            var response = await mecanicoRepository.GetMecanicoById(id);
            return response;
        }
        public async Task <List<Mecanico>> GetMecanicos()
        {
            return await mecanicoRepository.GetAll();
             
        }
        public async Task <ActionResult > UpdateMechan(int Id, Mecanico mecanico)
        {
            return await mecanicoRepository.UpdateMecanico(Id, mecanico);
        }
        public async Task<ActionResult> DeleteMecnaic (int Id)
        {
            return await mecanicoRepository.DeleteMecanicoById (Id);
        }
    }
}
