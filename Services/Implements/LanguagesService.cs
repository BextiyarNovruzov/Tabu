﻿using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Languages;
using Tabu.Services.Implements;

namespace Tabu.Services.Abstracts
{
    public class LanguagesService(TabuDbContext context) : ILanguagesServise
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            await context.Languages.AddAsync(new Entites.Language
            {
                Code = dto.Code,
                Name = dto.Name,
                Icon = dto.Icon,
            });
            await context.SaveChangesAsync();
        }

       

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            return await context.Languages.Select(L => new LanguageGetDto
            {
                Code = L.Code,
                Name = L.Name,
                Icon = L.Icon,
            }).ToListAsync();
        }

        public async Task UpdateAsync(LanguageUpdateDto dto)
        {
           var  excistingLanguage = await context.Languages.FindAsync(dto.Code);
            if (excistingLanguage == null)
            {
                throw new Exception("Language Not Found brat!");
            }
            else
            {
                excistingLanguage.Code = dto.Code;
                excistingLanguage.Name = dto.Name;
                excistingLanguage.Icon = dto.Icon;
            }
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(LanguageDeleteDto dto)
        {
            var excistingLanguage = await context.Languages.FindAsync(dto.Code);
            if(excistingLanguage == null)
            {
                throw new Exception("Brat onsuz yoxdu bu dil nece sileceksenki");
            }
            else
            {
                context.Languages.Remove(excistingLanguage);
            }
            await context.SaveChangesAsync();
        }
    }
}
