using MusicStore.Dto.Response;
using MusicStore.Entities;
using MusicStore.Entities.Info;

namespace MusicStore.Repositories.Abstractions;

public interface IConcertRepository : IRepositoryBase<Concert>
{
    Task<ICollection<ConcertInfo>> GetAsync(string? title);
    Task<Concert?> GetAsyncById(int id);
    Task FinalizeAsync(int id);
}