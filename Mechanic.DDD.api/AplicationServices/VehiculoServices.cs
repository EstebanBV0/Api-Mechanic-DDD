using Mechanic.DDD.api.Queries;
using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Mechanic.DDD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;

namespace Mechanic.DDD.api.AplicationServices
{
    public class VehiculoServices
    {
        private readonly IVehiculoRepository vehiculoRepository;
        private readonly VehiculoQueries vehiculoQueries;
        public VehiculoServices(IVehiculoRepository vehiculoRepository, VehiculoQueries vehiculoQueries)
        {
            this.vehiculoRepository = vehiculoRepository;
            this.vehiculoQueries = vehiculoQueries;
        }

          public async Task<Vehiculo> GetVehiculoByPlaca(string placa)
        {
            return await vehiculoQueries.GetVehiculoPlaca(placa); 
        }









        //Normal queries and services
        public async Task HandleCommand(Vehiculo vehiculo)
        {
            await vehiculoRepository.AddVehiculo(vehiculo);

        }
        public async Task<Vehiculo> GetVehiculo(int id)

        {
            return await vehiculoQueries.GetVehiculoIdAsync(id);
        }
        public async Task<List<Vehiculo>> GetVehiculoAsyc()
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
