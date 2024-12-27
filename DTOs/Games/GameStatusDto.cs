using Microsoft.Identity.Client;
using Tabu.DTOs.Words;
using Tabu.Entites;

namespace Tabu.DTOs.Games
{
    public class GameStatusDto
    {
        public byte Fail { get; set; }
        public byte Skip { get; set; }
        public byte Success { get; set; }
        public string LanguageCode { get; set; }
        public Stack<WordForGameDto> Words { get; set; }
        public List<int> UsedWordIds { get; set; }
        public int MasskipCount { get; set; }
        public int MaxFailFount { get; set; }
        
    }
}
