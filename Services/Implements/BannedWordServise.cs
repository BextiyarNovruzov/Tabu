using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using Tabu.DAL;
using Tabu.DTOs.BannedWords;
using Tabu.Entites;
using Tabu.Exceptions.BannedWords;
using Tabu.Exceptions.Words;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class BannedWordServise(TabuDbContext context, IMapper mapper) : IBannedWordServise
    {

        public async Task DeleteAsync(int id)
        {
                var existBannedWord = await context.BannedWord.FindAsync(id);
                if (existBannedWord == null)
                {
                    throw new BannedWordNotFoundException();

                };
                context.BannedWord.Remove(existBannedWord);
                await context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<BannedWordGetDto>> GetAllAsync()
        {
            //return (await context.BannedWord.Select(x => new BannedWordGetDto
            //{
            //    Id = x.Id,
            //    WordId = x.WordId,
            //    Text = x.Text,
            //}).ToListAsync());
            var bannedwords = await context.BannedWord.ToListAsync();
            if (bannedwords == null || !bannedwords.Any())
            {
                throw new BannedWordNotFoundException();
            }
            return mapper.Map<IEnumerable<BannedWordGetDto>>(bannedwords);


        }

        public async Task UpdateAsync(BannedWordUpdateDto dto, int id)
        {

            var existBannedWord = await context.BannedWord.FindAsync(id);
            if (existBannedWord == null)
            {
                //existBannedWord.Text = dto.Text;
                //existBannedWord.WordId = dto.WordId;
                //await context.SaveChangesAsync();
                throw new BannedWordNotFoundException();
            }
            mapper.Map(dto, existBannedWord);
            await context.SaveChangesAsync();

        }
    }
}
