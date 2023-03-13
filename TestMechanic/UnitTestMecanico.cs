
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
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

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
         IMecanicoRepository _mecanicoRepository;

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
            var  mockdbcontext = new Mock<DatabaseContext>();
            int id = 5;
            _mecanicoRepository = new MecanicoRepository(mockdbcontext.Object, _cache);
                int _mecanicoid = 5;
            Mock<IMecanicoRepository> mecanicrepo = new Mock<IMecanicoRepository>();
            mecanicrepo.Setup(p => p.GetMecanicoById(_mecanicoid)).ReturnsAsync(new Mecanico()
            {
                Id = 5,
                NivelEstudio = "string",
                Nombre = "string",
                Apellido = "string",
                NumeroTelefono = 0,
                FechaNacimiento = "string",
                Correo = "string",
                Direccion = "string",
                Cedula = 10,
                Servicio = null
            }); ;
            Mecanico andres = new Mecanico()
            { 
                Id = 5,
                NivelEstudio = "string",
                Nombre= "string",
                Apellido= "string",
                NumeroTelefono = 0,
                FechaNacimiento = "string",
                Correo = "string",
                Direccion = "string",
                Cedula = 10,
                 Servicio = null
            };
                    var result =   mecanicoRepository.GetMecanicoById(5);
            var serviciomecanico = new MecanicoQueries(mecanicrepo.Object);
            Assert.Equal(andres, serviciomecanico.GetMecanicoIdAsync(5).Result);    


        //    //    var result = await _mecanicoController.GetMecanico(5);

            //    //    Assert.IsType<IActionResult>(result);
            //    var rest = _mecanicoController.GetMecanico(5);
            //    Assert.IsType<Task<List<MecanicoDTO>>>(rest);





        }
    }
}