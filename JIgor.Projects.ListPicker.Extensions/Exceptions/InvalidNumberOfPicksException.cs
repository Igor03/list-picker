using System;

namespace JIgor.Projects.ListPicker.Extensions.Exceptions
{
    public class InvalidNumberOfPicksException : Exception
    {
        public InvalidNumberOfPicksException()
        {
        }

        public InvalidNumberOfPicksException(string message)
            : base(message)
        {
        }

        public InvalidNumberOfPicksException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
