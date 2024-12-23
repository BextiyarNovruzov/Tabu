namespace Tabu.Exceptions.BannedWords
{
    public class BannedWordExistException : Exception, IBaseException
    {
        public string ErrorMessage { get;}

        public BannedWordExistException()
        {
            ErrorMessage = "Daxil etdiyiniz BannedWord movcuddur!";
        }

        public BannedWordExistException(string? message) : base(message)
        {
            ErrorMessage = message;
        }

        public int StatusCode => StatusCodes.Status409Conflict;

    }
}
