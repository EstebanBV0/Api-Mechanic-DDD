
using AutoMapper;
using Mechanic.DDD.api.AplicationServices;
using Mechanic.DDD.api.Queries;
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
    public class RepuestoController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly RepuestoServices repuestoServices;
        public RepuestoController(IMapper mapper, RepuestoServices repuestoServices)
        {
            this.mapper = mapper;
            this.repuestoServices = repuestoServices;
        }


        [HttpGet("{placa}")]

        public async Task<IEnumerable<Repuesto>> GetAllForRevision(string placa)
        {
            var response = await repuestoServices.GetAllForRevision(placa);
           
                return response;
           
        }

        [HttpPost]
        public async Task<IActionResult> AddRepuesto([FromBody] RepuestoDTO repuestoDTO)
        {
            //await mechanicServices.HandleCommand(mecanico);
            //return Ok("resuelto");
            var repuesto = mapper.Map<Repuesto>(repuestoDTO);
            await repuestoServices.HandleCommand(repuesto);
            return NoContent();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRepuesto(int id)
        {
            var response = await repuestoServices.GetRepuesto(id);
            return Ok(response);

        }
        [HttpGet]
        public async Task<List<RepuestoDTO>> GetRepuestos()
        {

            var repuesto = await repuestoServices.GetRepuestos();
            return mapper.Map<List<RepuestoDTO>>(repuesto);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutRepuesto(int id, [FromBody] RepuestoDTOput repuestoDTOput)
        {
            var repuesto = await repuestoServices.GetRepuesto(id);
            if (repuesto == null)
            {
                return NotFound();

            }
            repuesto = mapper.Map(repuestoDTOput, repuesto);
            var rep = await repuestoServices.UpdateRepuesto(id, repuesto);


            return Ok(rep);




        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Repuesto>> DeleteRepuesto(int id)
        {
            var response = await repuestoServices.DeleteRepuesto(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
