namespace Tabu.Exceptions.Languages
{
    public class LanguageNotFoundException:Exception,IBaseException
    {
        public string ErrorMessage { get; }

       
        public LanguageNotFoundException()
        {
            ErrorMessage = "Dil Tapilmadi!";
        }

        public LanguageNotFoundException(string? message) : base(message)
        {
            ErrorMessage = message;
        }

        int IBaseException.StatusCode =>StatusCodes.Status404NotFound;





    }
}
