using Mechanic.DDD.api.Queries;
using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Mechanic.DDD.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Mechanic.DDD.api.AplicationServices
{
    public class MechanicServices
    {
        private readonly IMecanicoRepository repository;
        private readonly MecanicoQueries mecanicoQueries;

        public MechanicServices(IMecanicoRepository repository,  MecanicoQueries mecanicoQueries)
        {
            this.repository = repository;
            this.mecanicoQueries = mecanicoQueries;
        }











        // Normal queries and services
        public async Task HandleCommand(Mecanico mecanico)
        {
            await repository.AddMecanico(mecanico);

        }
        public async Task<Mecanico> GetMecanico (int id)

        {  
            return await mecanicoQueries.GetMecanicoIdAsync(id);    

        }
        public async Task<List<Mecanico>> GetMecanicosAsyc()
        {
            return await  mecanicoQueries.GetMecanicos();
        }
        public async Task <ActionResult> UpdateMechanic (int Id, Mecanico mecanico)
        {
            return await mecanicoQueries.UpdateMechan(Id, mecanico);
        }
        public async Task<ActionResult> DeleteMecanico(int Id)
        {
            return await mecanicoQueries.DeleteMecnaic(Id);
        }
    }
}
