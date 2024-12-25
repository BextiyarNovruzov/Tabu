using Tabu.Entites;

namespace Tabu.DTOs.Games
{
    public class GameCreateDto
    {
        public int BannedWordCount { get; set; }
        public int FailCount { get; set; }
        public int SkipCount { get; set; }
        public int Time { get; set; }
        public string LanguageCode { get; set; }
        public HashSet<Word> Words { get; set; }
    }
}
