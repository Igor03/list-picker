using System;

namespace JIgor.Projects.ListPicker.Extensions.Exceptions
{
    public class EmptyListException : Exception
    {
        public EmptyListException()
        {
        }

        public EmptyListException(string message)
            : base(message)
        {
        }

        public EmptyListException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
