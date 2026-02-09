namespace Interface
{
    public interface IAppointmentService
    {
        // Book new appointment
        void BookAppointment();

        // Cancel appointment
        void CancelAppointment();

        // Reschedule appointment
        void RescheduleAppointment();

        // View appointments
        void ViewAppointments();

        // Check doctor availability
        void CheckAvailability();

        void CompleteAppointment();

    }
}
