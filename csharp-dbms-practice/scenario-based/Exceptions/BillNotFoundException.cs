using System;

namespace Exceptions
{
    public class BillNotFoundException : System.Exception
    {
        public BillNotFoundException()
            : base("Bill not found.")
        {
        }

        public BillNotFoundException(string message)
            : base(message)
        {
        }
    }
}
