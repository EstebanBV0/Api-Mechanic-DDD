
using AutoMapper;
using Azure;
using Mechanic.DDD.api.AplicationServices;
using Mechanic.DDD.api.Controllers;
using Mechanic.DDD.api.Queries;
using Mechanic.DDD.api.Utilidades;
using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.Repositories;
using Mechanic.DDD.Domain.ValueObjects;
using Mechanic.DDD.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using Xunit;
using System.Threading.Tasks;
using Moq;

namespace TestMechanic
{
    public class UnitTestMecanico
    {
        DatabaseContext db;

        private readonly MecanicoController _mecanicoController;
        private readonly MechanicServices _mechanicServices;
        private readonly IMapper _mapper;
        private readonly MecanicoQueries _mecanicoQueries;
        private readonly MecanicoRepository mecanicoRepository;
        private readonly ICacheService _cache;

        public UnitTestMecanico()
        {
         

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperProfiles());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            mecanicoRepository = new MecanicoRepository(db, _cache);
            _mecanicoQueries = new MecanicoQueries(mecanicoRepository);
            _mechanicServices = new MechanicServices(mecanicoRepository, _mecanicoQueries);
            _mecanicoController = new MecanicoController(_mechanicServices, _mapper, mecanicoRepository);
        }



        [Fact]
        public void Get_Ok()
        {
            //var Mechcontroller = new MecanicoController(_mechanicServices, _mapper);
            var rest = _mecanicoController.GetMecanicos();
            var result = mecanicoRepository.GetAll();
    
            //Assert.IsType<List<Mecanico>>(result);
            var expected = typeof(Task<List<Mecanico>>);
            //var exprect2 = typeof(Task<List<MecanicoDTO>>);


            //Assert.IsType(expected, result);
            Assert.IsType<Task<List<Mecanico>>>(result);
            Assert.IsType<Task<List<MecanicoDTO>>>(rest);
        }
        [Fact]
        public async Task Get_By_Id_Async()
        {
           
            var controller = new MecanicoControllerTest(mecanicoRepository);
            var result = (OkObjectResult)await controller.GetMecanico(5);

            //var mechrepository = new MecanicoRepository(db);

            //var Mechcontroller = new MecanicoController(_mechanicServices, _mapper);
            //IActionResult response =   await Mechcontroller.GetMecanico(5);

            //OkObjectResult okResult = response as OkObjectResult;


            Assert.IsType<OkObjectResult>(result);





        }
    }
}