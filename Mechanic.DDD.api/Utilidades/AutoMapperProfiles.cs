using AutoMapper;
using Mechanic.DDD.Domain.Entities;
using Mechanic.DDD.Domain.ValueObjects;


namespace Mechanic.DDD.api.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<Mecanico, MecanicoDTO>();
            CreateMap<MecanicoDTO, Mecanico>().ReverseMap();
            CreateMap<MecanicoDTOPut, Mecanico>().ReverseMap();

            CreateMap<RepuestoDTO, Repuesto>().ReverseMap();
            CreateMap<RepuestoDTOput, Repuesto>().ReverseMap();

            CreateMap<DuenoDTO,Dueno>().ReverseMap();
            CreateMap<DuenoDTOput, Dueno>().ReverseMap();

            CreateMap<ServicioDTO,Servicio>().ReverseMap();
            CreateMap<ServicioDTOput, Servicio>().ReverseMap();

            CreateMap<VehiculoDTO,Vehiculo>().ReverseMap();
            CreateMap<VehiculoDTOput, Vehiculo>().ReverseMap();






        }

    }
}
