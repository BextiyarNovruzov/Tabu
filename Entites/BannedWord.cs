namespace Tabu.Entites
{
    public class BannedWord
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int WordId { get; set; }
        public Word Words { get; set; }
            
    }
}
