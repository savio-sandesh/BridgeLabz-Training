using System;

namespace Exceptions
{
    public class DoctorNotFoundException : System.Exception
    {
        public DoctorNotFoundException()
            : base("Doctor not found in the system.")
        {
        }

        public DoctorNotFoundException(string message)
            : base(message)
        {
        }
    }
}
