using Mechanic.DDD.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.DDD.Domain.Repositories
{
    public interface IVehiculoRepository
    {
        Task<Vehiculo> GetVehiculoByPlaca(string placa);

        Task<Vehiculo> GetVehiculoById(int id);
        Task AddVehiculo(Vehiculo Vehiculo);
        Task<List<Vehiculo>> GetAll();
        Task<ActionResult> UpdateVehiculo(int id, Vehiculo vehiculoActualizado);

        Task<ActionResult<Vehiculo>> DeleteVehiculoById(int id);
    }
}
