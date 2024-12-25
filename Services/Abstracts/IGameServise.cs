using Tabu.DTOs.Games;
using Tabu.Entites;

namespace Tabu.Services.Abstracts
{
    public interface IGameServise
    {
        Task<Guid> CreateAsync(GameCreateDto Dto);
        Task Start(Guid Id);
        Task Fail(Guid Id);
        Task Success(Guid Id);
        Task Skip(Guid Id);
        Task End(Guid Id);
    }
}
