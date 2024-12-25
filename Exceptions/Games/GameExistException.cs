namespace Tabu.Exceptions.Games
{
    public class GameExistException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;
        public GameExistException() 
        {
            ErrorMessage = "Hazirda Bu Game movcuddur!";
        }
        public GameExistException(string? message) :base(message)
        {
            ErrorMessage = message;
        }

        public string ErrorMessage { get; }
    }
}
