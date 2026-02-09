using System;

namespace Exceptions
{
    public class DeleteNotAllowedException : System.Exception
    {
        public DeleteNotAllowedException()
            : base("Delete operation cannot be performed due to dependent records.")
        {
        }

        public DeleteNotAllowedException(string message)
            : base(message)
        {
        }
    }
}
