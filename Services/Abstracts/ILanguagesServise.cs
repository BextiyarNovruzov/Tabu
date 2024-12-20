using Tabu.DTOs.Languages;

namespace Tabu.Services.Implements
{
    public interface ILanguagesServise
    {
        Task CreateAsync(LanguageCreateDto dto);
        Task<IEnumerable<LanguageGetDto>> GetAllAsync();
        Task UpdateAsync(LanguageUpdateDto dto,string Code);
        Task DeleteAsync(string Code);

    }
}
