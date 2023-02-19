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

    public class MecanicoControllerTest : ControllerBase
    {
        private readonly IMecanicoRepository mecanicoRepository;

        public MecanicoControllerTest(IMecanicoRepository mecanicoRepository)
        {
            this.mecanicoRepository = mecanicoRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMecanico(int id)
        {
            var response = await mecanicoRepository.GetMecanicoById(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);

        }

    }
}

