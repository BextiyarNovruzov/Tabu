using Tabu.DTOs.Games;
using Tabu.Entites;

namespace Tabu.Services.Abstracts
{
    public interface IGameServise
    {
        Task<Guid> CreateAsync(GameCreateDto Dto);
        Task Start(Guid Id,GameStartDto dto);
    }
}
