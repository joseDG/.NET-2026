using AutoMapper;
using Microsoft.Extensions.Logging;
using MusicStore.Dto.Response;
using MusicStore.Dto.Resquest;
using MusicStore.Entities;
using MusicStore.Repositories.Abstractions;
using MusicStore.Services.Abstractions;

namespace MusicStore.Services.implementations
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository repository;
        private readonly ILogger<GenreService> logger;
        private readonly IMapper mapper;


        public GenreService(IGenreRepository repository, ILogger<GenreService> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<BaseResponseGeneric<ICollection<GenreResponseDto>>> GetAsync()
        {
            var response = new BaseResponseGeneric<ICollection<GenreResponseDto>>();
            try
            {
                response.Data = mapper.Map<ICollection<GenreResponseDto>>(await repository.GetAsync());
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al obtener la informacion";
                logger.LogError(ex, "{ErrorMessage} {Message}" , response.ErrorMessage , ex.Message);
            }

            return response;
        }

        public async Task<BaseResponseGeneric<GenreResponseDto>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<GenreResponseDto>();
            try
            {
                response.Data = mapper.Map<GenreResponseDto>(await repository.GetAsync(id));
                response.Success = response.Data != null;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al obtener la informacion";
                logger.LogError(ex, "{ErrorMessage} {Message}" , response.ErrorMessage , ex.Message);
            }

            return response;
        }

        public async Task<BaseResponseGeneric<int>> AddAsync(GenreRequestDto request)
        {
            var response = new BaseResponseGeneric<int>();
            try
            {
                response.Data = await repository.AddAsync(mapper.Map<Genre>(request));
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al obtener la informacion";
                logger.LogError(ex, "{ErrorMessage} {Message}" , response.ErrorMessage , ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, GenreRequestDto request)
        {
            var response = new BaseResponse();
            try
            {
                var entity = await repository.GetAsync(id);
                if (entity is null)
                {
                    response.ErrorMessage = "No se encontro el resgistro";
                    return response;
                }

                mapper.Map(request, entity);
                await repository.UpdateAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al actualizar la informacion";
                logger.LogError(ex, "{ErrorMessage} {mesage}", response.ErrorMessage , ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();
            try
            {
                await repository.DeleteAsync(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al eliminar la informacion";
                logger.LogError(ex , "{ErrorMessage} {message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }
    }
}
