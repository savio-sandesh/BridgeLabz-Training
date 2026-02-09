using System;

namespace Exceptions
{
    public class PatientNotFoundException : System.Exception
    {
        public PatientNotFoundException()
            : base("Patient not found in the system.")
        {
        }

        public PatientNotFoundException(string message)
            : base(message)
        {
        }
    }
}
