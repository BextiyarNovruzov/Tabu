namespace Tabu.Exceptions.Words
{
    public class WordNotFoundException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public WordNotFoundException()
        {
            ErrorMessage = "Word Tapilmadi!";
        }

        public string ErrorMessage { get; }

        public WordNotFoundException(string? message) : base(message)
        {
            ErrorMessage = message;
        }


    }
}
