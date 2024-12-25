using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Words;
using Tabu.Entites;
using Tabu.Exceptions.Words;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{

    public class WordsServise(TabuDbContext context, IMapper mapper) : IWordsServise
    {
        //public async Task CreateAsync(WordCreateDto dto)
        //{
        //    //await context.Word.AddAsync(new Entites.Word
        //    //{
        //    //    Text = dto.Text,
        //    //    LanguageCode = dto.LanguageCode,

        //    //});
        //    if (await context.Languages.FindAsync(dto.LanguageCode) == null)
        //    {
        //        throw new LanguageNotFoundException();
        //    }
        //    if (await context.Word.AnyAsync(x => x.Text == dto.Text))
        //    {
        //        throw new WordExistException();
        //    }
        //    await context.Word.AddAsync(mapper.Map<Word>(dto));

        //    await context.SaveChangesAsync();

        //}

        public async Task DeleteAsync(int id)
        {
            var existWord = await context.Word.FindAsync(id);
            if (existWord == null)
            {
                throw new WordNotFoundException();
            }
            context.Word.Remove(existWord);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WordGetDto>> GetAllAsync()
        {
            //return (await context.Word.Select(x => new WordGetDto
            //{
            //    Id = x.Id,
            //    Text = x.Text,
            //    LanguageCode = x.LanguageCode,
            //}).ToListAsync());

            var words = await context.Word.ToListAsync();
            if (words == null || !words.Any())
            {
                throw new WordNotFoundException();
            }
            return mapper.Map<IEnumerable<WordGetDto>>(words);

        }



        public async Task UpdateAsync(WordUpdateDto dto, int id)
        {

                var existWord = await context.Word.FindAsync(id);

                //if (existWord != null)
                //{
                //    existWord.Text = dto.Text;
                //    existWord.LanguageCode = dto.LanguageCode;
                //}
                if (existWord == null)

                {
                    throw new WordNotFoundException();
                }
                mapper.Map(dto, existWord);
                await context.SaveChangesAsync();

        }

        public async Task<int> CreateAsync(WordCreateDto dto)
        {
            Word word = new Word
            {
                Text = dto.Text,
                LanguageCode = dto.LanguageCode,
                BannedWords = dto.BanedWords.Select(x => new BannedWord
                {
                    Text = x,
                }).ToList()
            };
            await context.Word.AddAsync(word);
            await context.SaveChangesAsync();
            return word.Id;
        }
    }
}
    