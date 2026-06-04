using AutoMapper;
using MusicStore.Dto.Response;
using MusicStore.Dto.Resquest;
using MusicStore.Entities;

namespace MusicStore.Services.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreResponseDto>();
            CreateMap<GenreRequestDto, Genre>();
        }
    }
}
