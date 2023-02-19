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

    public class MecanicoController : ControllerBase
    {
        private readonly MechanicServices mechanicServices;
        private readonly IMecanicoRepository mecanicoRepository;
        private readonly IMapper mapper;

        public MecanicoController(MechanicServices mechanicServices,IMapper mapper, IMecanicoRepository mecanicoRepository)
        {
            this.mechanicServices = mechanicServices;
            this.mapper = mapper;
            this.mecanicoRepository = mecanicoRepository;   
        }
        [HttpPost]
        public async Task<IActionResult> AddMecanico([FromBody] MecanicoDTO mecanicoDTO)
        {
            //await mechanicServices.HandleCommand(mecanico);
            //return Ok("resuelto");
            var mecanico = mapper.Map<Mecanico>(mecanicoDTO);
            await mechanicServices.HandleCommand(mecanico);
            return NoContent(); 

        }
        [HttpGet("{id}")]
        public  async Task<IActionResult> GetMecanico(int id)
        {
            var response = await mecanicoRepository.GetMecanicoById(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);    

        }
        [HttpGet]
        public async Task<List<MecanicoDTO>> GetMecanicos()
        {

           

                var mecanico = await mechanicServices.GetMecanicosAsyc();
                return mapper.Map<List<MecanicoDTO>>(mecanico);

            

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutMecanico (int id, [FromBody] MecanicoDTOPut mecanicoDTO)
        {
            var mecanico = await mechanicServices.GetMecanico(id);
            if (mecanico == null)
            {
                return NotFound();

            }
             mecanico = mapper.Map(mecanicoDTO, mecanico);
             var mec = await mechanicServices.UpdateMechanic(id, mecanico);

            
            return Ok(mec);




        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mecanico>> DeleteMecanico(int id)
        {

            var mecanico = await mechanicServices.GetMecanico(id);
            if (mecanico == null)
            {
                return NotFound();

            }

            var response = await mechanicServices.DeleteMecanico(id);
       
            return Ok(response);
        }

    }
}
