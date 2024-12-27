using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<WordForGameDto> Start(Guid Id)
        {
            var game = await context.Game.FindAsync(Id);

            if (game == null || game.Score != null)
            {
                throw new Exception();
            }
            IQueryable<Word> query = context.Word
                .Where(x => x.LanguageCode == game.LanguageCode);
            int totalWords = await query.CountAsync();
            if (totalWords == 0)
            {
                throw new Exception("Bazadaki Word sayi sifirdir.");  
            }
            var words = await query
                .Select(x => new WordForGameDto
                {
                    Id = x.Id,
                    Word = x.Text,
                    BannedWords = x.BannedWords.Select(x => x.Text)
                }).Random(totalWords)
                .Take(5)
                .ToListAsync();
            var wordStack = new Stack<WordForGameDto>(words);
            WordForGameDto currentWord = wordStack.Pop();
            GameStatusDto gameStatus = new GameStatusDto
            {
                Fail = 0,
                Success = 0,
                Skip = 0,
                MasskipCount = game.SkipCount,
                Words = wordStack,
                UsedWordIds = words.Select(x => x.Id).ToList(),
            };
            chache.Set(Id, gameStatus, TimeSpanExtention.GetChacheDuration());
            return currentWord;
        }

 

        public async Task<WordForGameDto> Skip(Guid Id)
        {
            var status = getCurrentGame(Id);
            if (status.Skip <= status.MasskipCount)
            {
                var currentword = status.Words.Pop();
                status.Skip++;
                chache.Set(Id, status, TimeSpanExtention.GetChacheDuration());
                return currentword;
            }
            return null;
        }


        public async Task<WordForGameDto> Success(Guid Id)
        {
            var status = getCurrentGame(Id);
            status.Success++;
            await AddNewWords(status);
            var currentword = status.Words.Pop();
            chache.Set(Id, status, TimeSpanExtention.GetChacheDuration());
            return currentword;
        }


        public async Task<WordForGameDto> Fail(Guid Id)
        {
            var status = getCurrentGame(Id);
            var currentword = status.Words.Pop();
            status.Fail++;
            await AddNewWords(status);
            chache.Set(Id, status, TimeSpanExtention.GetChacheDuration());
            return currentword;

        }
        public async Task End(Guid Id)
        {
            var status = getCurrentGame(Id);
            var game = await context.Game.FindAsync(Id);
            if (game == null)
            {
                throw new Exception("Game not found.");
            }
            game.Score = status.Success;
            game.FailCount = status.Fail;
            game.SkipCount = status.Skip;
            context.Game.Update(game);
            await context.SaveChangesAsync();
            chache.Remove(Id);
        }
        GameStatusDto getCurrentGame(Guid Id)
        {
            var resut = chache.Get<GameStatusDto>(Id);
            if (resut == null) throw new Exception();
            return resut;
        }
        async Task AddNewWords(GameStatusDto status)
        {
            if (status.Words.Count < 6)
            {
                var newWords = await context.Word
                    .Where(w => w.LanguageCode == status.LanguageCode && !status.UsedWordIds.Contains(w.Id))
                    .Take(5)
                    .Select(x => new WordForGameDto
                    {
                        Id = x.Id,
                        Word = x.Text,
                        BannedWords = x.BannedWords.Select(y => y.Text).ToList()
                    })
                    .ToListAsync();

                status.UsedWordIds.AddRange(newWords.Select(x => x.Id));
                newWords.ForEach(x => status.Words.Push(x));
            }
        }

    }
}
