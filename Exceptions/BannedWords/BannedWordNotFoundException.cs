namespace Tabu.Exceptions.BannedWords
{
    public class BannedWordNotFoundException : Exception, IBaseException
    {
        public BannedWordNotFoundException()
        {
            ErrorMessage = "BannedWord Tapulmadi!";
        }

        public BannedWordNotFoundException(string? message) : base(message)
        {
            ErrorMessage = message;
        }

        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }
    }
}
