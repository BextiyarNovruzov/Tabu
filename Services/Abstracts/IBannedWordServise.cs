using Tabu.DTOs.BannedWords;

namespace Tabu.Services.Abstracts
{
    public interface IBannedWordServise
    {
        Task CreateAsync(BannedWordCreateDto dto);
        Task<IEnumerable<BannedWordGetDto>> GetAllAsync();
        Task UpdateAsync(BannedWordUpdateDto dto,int id);
        Task DeleteAsync(int id);


    }
}
