using Api.Models.Domain;
using Api.Vms;
using AutoMapper;


namespace Firebase.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
       CreateMap<Producto, ProductoVm>();
    }
}