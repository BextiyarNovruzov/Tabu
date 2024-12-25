using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Tabu.DAL;
using Tabu.DTOs.Games;
using Tabu.Entites;
using Tabu.Exceptions.Languages;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class GamesServise(TabuDbContext context, IMapper mapper, IMemoryCache chache) : IGameServise
    {
        public async Task<Guid> CreateAsync(GameCreateDto dto)
        {
            if (await context.Languages.FindAsync(dto.LanguageCode) == null)
            {
                throw new LanguageNotFoundException();
            }
            var game = mapper.Map<Game>(dto);
            await context.AddAsync(game);
            var gamestatus = new GameStatusDto
            {
                Fail = 0,
                Skip = 0,
                Success = 0,
            };
            await context.SaveChangesAsync();
            return game.Id;
        }

        public Task Start(Guid Id, GameStartDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
