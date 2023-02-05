
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
    public class ServicioController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ServicioServices servicioServices;

        public ServicioController(IMapper mapper, ServicioServices servicioServices)
        {
            this.mapper = mapper;
            this.servicioServices = servicioServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddServicio([FromBody] ServicioDTO servicioDTO)
        {
            //await mechanicServices.HandleCommand(mecanico);
            //return Ok("resuelto");
            var servicio = mapper.Map<Servicio>(servicioDTO);
            await servicioServices.HandleCommand(servicio);
            return NoContent();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicio(int id)
        {
            var response = await servicioServices.GetServiciobyID(id);
            return Ok(response);

        }
        [HttpGet]
        public async Task<List<ServicioDTO>> GetServicios()
        {

            var servicio = await servicioServices.GetServicioAsyc();
            return mapper.Map<List<ServicioDTO>>(servicio);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutServicio(int id, [FromBody] ServicioDTOput servicioDTOput)
        {
            var servicio = await servicioServices.GetServiciobyID(id);
            if (servicio == null)
            {
                return NotFound();

            }
            servicio = mapper.Map(servicioDTOput, servicio);
            var rep = await servicioServices.UpdateServicio(id, servicio);


            return Ok(rep);




        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Servicio>> DeleteServicio(int id)
        {
            var servicio = await servicioServices.GetServiciobyID(id);
            if (servicio == null)
            {
                return NotFound();
            }
            var response = await servicioServices.DeleteServicio(id);

            return Ok(response);
        }
    }
}
