using Azure;
using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Mechanic.DDD.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Mechanic.DDD.api.Queries
{
    public class ServicioQueries
    {
        private readonly IServicioRepository servicioRepository;
        public ServicioQueries(IServicioRepository servicioRepository)
        {
                this.servicioRepository = servicioRepository;
        }

        public async Task<Servicio> GetServicioIdAsync(int id)
        {
            var response = await servicioRepository.GetServicioById(id);
            return response;
        }

        public async Task<List<Servicio>> GetServicios()
        {
            return await servicioRepository.GetAll();

        }

        public async Task<ActionResult> UpdateServicio(int Id, Servicio servicio)
        {
            return await servicioRepository.UpdateServicio(Id, servicio);
        }

        public async Task<ActionResult<Servicio>> DeleteServicio(int Id)
        {
            return await servicioRepository.DeleteServicioById(Id);
        }
    }
}
