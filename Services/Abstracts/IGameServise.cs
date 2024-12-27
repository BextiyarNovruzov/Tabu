using Tabu.DTOs.Games;
using Tabu.DTOs.Words;
using Tabu.Entites;

namespace Tabu.Services.Abstracts
{
    public interface IGameServise
    {
        Task<Guid> CreateAsync(GameCreateDto Dto);
        Task<WordForGameDto> Start(Guid Id);
        Task<WordForGameDto> Fail(Guid Id);
        Task<WordForGameDto> Success(Guid Id);
        Task<WordForGameDto> Skip(Guid Id);
        Task End(Guid Id);
    }
}
