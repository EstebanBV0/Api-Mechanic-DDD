using Mechanic.DDD.api.Queries;
using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;

namespace Mechanic.DDD.api.AplicationServices
{
    public class ServicioServices
    {
        private readonly ServicioQueries  servicioQueries;
        private readonly IServicioRepository servicioRepository;
        public ServicioServices(ServicioQueries servicioQueries, IServicioRepository servicioRepository)
        {
            this.servicioQueries = servicioQueries;
            this.servicioRepository = servicioRepository;
        }








        //Normal queries and services
        public async Task HandleCommand(Servicio servicio)
        {
            await servicioRepository.AddServicio(servicio);

        }
        public async Task<Servicio> GetServiciobyID(int id)

        {
            return await servicioRepository.GetServicioById(id);

        }
        public async Task<List<Servicio>> GetServicioAsyc()
        {
            return await servicioRepository.GetAll();
        }
        public async Task<ActionResult> UpdateServicio(int id, Servicio servicio)
        {
            return await servicioRepository.UpdateServicio(id, servicio);
        }
        public async Task<ActionResult<Servicio>> DeleteServicio(int id)
        {
            return await servicioRepository.DeleteServicioById(id);
        }
    }
}
