
using AutoMapper;
using Mechanic.DDD.api.AplicationServices;
using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Mechanic.DDD.Domain.ValueObjects;
using Mechanic.DDD.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using static System.Net.WebRequestMethods;

namespace Mechanic.DDD.api.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class DuenoController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly DuenoServices duenoServices;
        private readonly DuenoRepository duenoRepository;
        private readonly ServicioExterno servicioExterno;
        public DuenoController(IMapper mapper, DuenoServices duenoServices, ServicioExterno servicioExterno)
        {
            this.mapper = mapper;
            this.duenoServices = duenoServices;
            this.servicioExterno = servicioExterno;
        }

        [HttpPost]
        public async Task<IActionResult> AddDueno([FromBody] DuenoDTO duenoDTO)
        {
            //await mechanicServices.HandleCommand(mecanico);
            //return Ok("resuelto");
            var dueno = mapper.Map<Dueno>(duenoDTO);
            await duenoServices.HandleCommands(dueno);
            return NoContent();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDueno(int id)
        {
            var response = await duenoServices.GetDueno(id);
            return Ok(response);

        }
        [HttpGet]
        public async Task<List<DuenoDTO>> GetDuenos()
        {



            var dueno = await duenoServices.GetDuenosAsyc();
            return mapper.Map<List<DuenoDTO>>(dueno);



        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutDueno(int id, [FromBody] DuenoDTOput duenoDTO)
        {
            var dueno = await duenoServices.GetDueno(id);
            if (dueno == null)
            {
                return NotFound();

            }
            dueno = mapper.Map(duenoDTO, dueno);
            var duen = await duenoServices.UpdateDueno(id,dueno);


            return Ok(duen);




        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dueno>> DeleteDueno(int id)
        {
            var dueno = await duenoServices.GetDueno(id);
            if (dueno == null)
            {
                return NotFound();
            }
            var response = await duenoServices.DeleteDueno(id);

            return Ok(response);
        }
        [HttpPatch("{CartUniqueId}")]
        public async Task<string> Proofpach(string CartUniqueId, [FromBody]  StatusCarrito status)
        {
            
            return await servicioExterno.UpdateStatusShoppingCart(CartUniqueId, status);
        }       


    }
}
