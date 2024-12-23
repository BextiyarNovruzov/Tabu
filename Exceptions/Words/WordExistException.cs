namespace Tabu.Exceptions.Words
{
    public class WordExistException : Exception,IBaseException
    {


        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }
        public WordExistException()
        {
            ErrorMessage = "Bu word movcuddur!";
        }

        public WordExistException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
