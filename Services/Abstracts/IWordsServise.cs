﻿using Tabu.DTOs.Words;

namespace Tabu.Services.Abstracts
{
    public interface IWordsServise
    {
        Task CreateAsync(WordCreateDto dto);
        Task <IEnumerable<WordGetDto>> GetAllAsync();
        Task UpdateAsync(WordUpdateDto dto, int id);
        Task DeleteAsync(int id);

    }
}