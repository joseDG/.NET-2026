using AutoMapper;
using Azure.Core;
using Microsoft.Extensions.Logging;
using MusicStore.Dto.Response;
using MusicStore.Dto.Resquest;
using MusicStore.Entities;
using MusicStore.Repositories.Abstractions;
using MusicStore.Repositories.Implementations;
using MusicStore.Services.Abstractions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MusicStore.Services.implementations
{
    public class ConcertService : IConcertService
    {
        protected readonly IConcertRepository repository;
        protected readonly ILogger<ConcertService> logger;
        protected readonly IMapper mapper;

        public ConcertService(IConcertRepository repository, ILogger<ConcertService> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }
        
        public async Task<BaseResponseGeneric<ICollection<ConcertResponseDto>>> GetAsync(string? title)
        {

            var response = new BaseResponseGeneric<ICollection<ConcertResponseDto>>();

            try
            {
                var data = await repository.GetAsync(title);
                response.Data = mapper.Map<ICollection<ConcertResponseDto>>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error obtener la informacion";
                logger.LogError(ex, $"{response.ErrorMessage} {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponseGeneric<ConcertResponseDto>> GetAsync(int id)
        {
            
            var response = new BaseResponseGeneric<ConcertResponseDto>();

            try
            {
                //var data = await repository.GetAsync(id);
                var data = await repository.GetAsyncById(id);
                if (data is null)
                {
                    response.ErrorMessage = $"No existe el concierto con id {id}";
                    logger.LogWarning($"No existe el concierto con id {id}");
                    return response;
                }
                response.Data = mapper.Map<ConcertResponseDto>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error obtener la informacion";
                logger.LogError(ex, $"{response.ErrorMessage} {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponseGeneric<int>> AddAsync(ConcertRequestDto request)
        {
            var response = new BaseResponseGeneric<int>();

            try
            {
                response.Data = await repository.AddAsync(mapper.Map<Concert>(request));
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error obtener la informacion";
                logger.LogError(ex, $"{response.ErrorMessage} {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, ConcertRequestDto request)
        {
            var response = new BaseResponse();

            try
            {
                var data = await repository.GetAsync(id);
                if (data is null)
                {
                    response.ErrorMessage = $"El registro no fue encontrado";
                    return response;
                }
                mapper.Map(request, data);
                await repository.UpdateAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error obtener la informacion";
                logger.LogError(ex, $"{response.ErrorMessage} {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();

            try
            {
                var data = await repository.GetAsync(id);
                if (data is null)
                {
                    response.ErrorMessage = $"No existe el concierto con id {id}";
                    logger.LogWarning($"No existe el concierto con id {id}");
                    return response;
                }

                await repository.DeleteAsync(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrio un error al eliminar el registro";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse> FinalizeAsync(int id)
        {
            var response = new BaseResponse();

            try
            {
                await repository.FinalizeAsync(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error al finalizar un concierto";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }

            return response;
        }
    }
}
