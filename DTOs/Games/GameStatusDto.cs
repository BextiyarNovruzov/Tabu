using Tabu.DTOs.Words;
using Tabu.Entites;

namespace Tabu.DTOs.Games
{
    public class GameStatusDto
    {
        public byte Fail { get; set; }
        public byte Skip { get; set; }
        public byte Success { get; set; }
        public Stack<WordForGameDto> Words { get; set; }
        public IEnumerable<int> UsedWordIds { get; set; }
    }
}
