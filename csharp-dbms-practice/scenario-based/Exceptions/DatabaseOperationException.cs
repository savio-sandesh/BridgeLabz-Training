using System;

namespace Exceptions
{
    public class DatabaseOperationException : System.Exception
    {
        public DatabaseOperationException()
            : base("Database operation failed.")
        {
        }

        public DatabaseOperationException(string message)
            : base(message)
        {
        }

        public DatabaseOperationException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
