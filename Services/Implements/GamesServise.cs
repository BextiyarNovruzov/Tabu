using AutoMapper;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Tabu.DAL;
using Tabu.DTOs.Games;
using Tabu.DTOs.Words;
using Tabu.Entites;
using Tabu.Exceptions.Languages;
using Tabu.Extention;
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
            await context.SaveChangesAsync();
            return game.Id;
        }
		public async Task Start(Guid Id)
		{
			var game = await context.Games.FindAsync(Id);
			if(await context.Games.AnyAsync(x=>x.Id ==Id && x.Score ==null))
			{
				throw new Exception();
			}
			IQueryable<Word> qurey = context.Word.Where(x=>x.LanguageCode == game.LanguageCode);
			var words = await context.Word
				.Where(x => x.LanguageCode == game.LanguageCode)
				.Select(x => new WordForGameDto
				{
					Id = x.Id,
					Word = x.Text,
					BannedWords = x.BannedWords.Select(y => y.Text),
				}).Random(await qurey.CountAsync())
				.Take(20)
				.ToListAsync();
			GameStatusDto status = new GameStatusDto()
			{
				Fail = 0,
				Skip = 0,
				Success = 0,
				Words = new Stack<WordForGameDto>(words),
				UsedWordIds = words.Select(x=>x.Id)
			}; 
		}


		public Task End(Guid Id)
		{
			throw new NotImplementedException();
		}

		public Task Fail(Guid Id)
		{
			throw new NotImplementedException();
		}

		public Task Skip(Guid Id)
		{
			throw new NotImplementedException();
		}

		
		public Task Success(Guid Id)
		{
			throw new NotImplementedException();
		}
	}
}
