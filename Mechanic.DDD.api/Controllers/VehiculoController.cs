
using AutoMapper;
using Mechanic.DDD.api.AplicationServices;
using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Mechanic.DDD.Domain.ValueObjects;
using Mechanic.DDD.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mechanic.DDD.api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class VehiculoController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly VehiculoServices vehiculoServices;

        public VehiculoController(IMapper mapper, VehiculoServices vehiculoServices)
        {
            this.mapper = mapper;
            this.vehiculoServices = vehiculoServices;
        }

        [HttpGet("{placa}")]
        public async Task<IActionResult> GetVehiculoByPlaca(string placa)
        {
            var response = await vehiculoServices.GetVehiculoByPlaca(placa);
            return Ok(response);

        }





        [HttpPost]
        public async Task<IActionResult> AddVehiculo([FromBody] VehiculoDTO vehiculoDTO)
        {
            //await mechanicServices.HandleCommand(mecanico);
            //return Ok("resuelto");
            var vehiculo = mapper.Map<Vehiculo>(vehiculoDTO);
            await vehiculoServices.HandleCommand(vehiculo);
            return NoContent();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehiculo(int id)
        {
            var response = await vehiculoServices.GetVehiculo(id);
            return Ok(response);

        }
        [HttpGet]
        public async Task<List<VehiculoDTO>> GetVehiculos()
        {
            var vehiculo = await vehiculoServices.GetVehiculoAsyc();
            return mapper.Map<List<VehiculoDTO>>(vehiculo);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutVehiculo(int id, [FromBody] VehiculoDTOput vehiculoDTOput)
        {
            var vehiculo = await vehiculoServices.GetVehiculo(id);
            if (vehiculo == null)
            {
                return NotFound();

            }
            vehiculo = mapper.Map(vehiculoDTOput, vehiculo);
            var rep = await vehiculoServices.UpdateVehiculo(id, vehiculo);


            return Ok(vehiculo);




        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vehiculo>> DeleteVehiculo(int id)
        {


            var Vehiculo = await vehiculoServices.GetVehiculo(id);
            if (Vehiculo == null)
            {
                return NotFound();
            }

            var response = await vehiculoServices.DeleteVehiculo(id);

            return Ok(response);
        }


    }
}
