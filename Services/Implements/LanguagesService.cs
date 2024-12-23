using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Languages;
using Tabu.Entites;
using Tabu.Exceptions.Language;
using Tabu.Exceptions.Languages;
using Tabu.Services.Implements;

namespace Tabu.Services.Abstracts
{
    public class LanguagesService(TabuDbContext context,IMapper mapper) : ILanguagesServise
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            if(await context.Languages.AnyAsync(x=>x.Code == dto.Code))
            {
                throw new LanguageExistException();
            }
            await context.Languages.AddAsync(mapper.Map<Language>(dto));
            await context.SaveChangesAsync();
        }

       

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            var datas = await context.Languages.ToListAsync();
            if(datas==null|| !datas.Any())
            {
                throw new LanguageNotFoundException();
            }
            return mapper.Map<IEnumerable<LanguageGetDto>>(datas);
        }

       
        public async Task DeleteAsync(string Code)
        {
            if( !context.Languages.Any(x=>x.Code==Code))
            {
                throw new LanguageNotFoundException();
            }
            var excistingLanguage = await context.Languages.FindAsync(Code);
                context.Languages.Remove(excistingLanguage);
            
            await context.SaveChangesAsync();
        }

		public async Task UpdateAsync(LanguageUpdateDto dto, string Code)
		{
            if (!context.Languages.Any(x => x.Code == Code))
            {
                throw new LanguageNotFoundException();
            }
			var excistingLanguage = await context.Languages.FindAsync(Code);
			
                //excistingLanguage.Name = dto.Name;
                //excistingLanguage.Icon = dto.Icon;
                mapper.Map(dto,excistingLanguage);
			
			await context.SaveChangesAsync();
		}
	}
}
