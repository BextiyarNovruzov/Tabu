﻿namespace Tabu.Exceptions.Language
{
    public class LanguageExistException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }
        public LanguageExistException()
        {
            ErrorMessage = "Bu dil Movcuddur!";
        }

        public LanguageExistException(string? message) : base(message)
        {
            ErrorMessage = message;
        }


    }
}