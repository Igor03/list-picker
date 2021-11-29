using System;
using System.Diagnostics.CodeAnalysis;

namespace JIgor.Projects.ListPicker.Exceptions
{
    public class InvalidNumberOfPicksException : Exception
    {
        public InvalidNumberOfPicksException()
        {
        }

        public InvalidNumberOfPicksException([NotNull] string message)
            : base(message)
        {
        }

        public InvalidNumberOfPicksException([NotNull] string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
