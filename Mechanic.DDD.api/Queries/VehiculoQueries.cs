using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Mechanic.DDD.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Mechanic.DDD.api.Queries
{
    public class VehiculoQueries
    {
       private readonly IVehiculoRepository vehiculoRepository;
        public VehiculoQueries(IVehiculoRepository vehiculoRepository)
        {
            this.vehiculoRepository = vehiculoRepository;
        }

        public async Task<Vehiculo> GetVehiculoPlaca(string placa)
        {
            return await vehiculoRepository.GetVehiculoByPlaca(placa);
        }



        public async Task<Vehiculo> GetVehiculoIdAsync(int id)
        {
            var response = await vehiculoRepository.GetVehiculoById(id);
            return response;
        }
        public async Task<List<Vehiculo>> GetVehiculos()
        {
            return await vehiculoRepository.GetAll();

        }
        public async Task<ActionResult> UpdateVehiculo(int id, Vehiculo vehiculo)
        {
            return await vehiculoRepository.UpdateVehiculo(id, vehiculo);
        }
        public async Task<ActionResult<Vehiculo>> DeleteVehiculo(int id)
        {
            return await vehiculoRepository.DeleteVehiculoById(id);
        }
    }
}
