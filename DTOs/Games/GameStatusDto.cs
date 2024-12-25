using Tabu.Entites;

namespace Tabu.DTOs.Games
{
    public class GameStatusDto
    {
        public byte Fail { get; set; }
        public byte Skip { get; set; }
        public byte Success { get; set; }
        public Stack<Word> Words { get; set; }
    }
}
