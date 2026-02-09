using System;

namespace Exceptions
{
    public class AppointmentNotFoundException : System.Exception
    {
        public AppointmentNotFoundException()
            : base("Appointment not found.")
        {
        }

        public AppointmentNotFoundException(string message)
            : base(message)
        {
        }
    }
}
