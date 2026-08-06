using System;
using HealthClinic.Entity;

namespace HealthClinic.Interface
{
    // Defines the operations that an Appointment Service should provide.
    // This interface provides abstraction between Menu layer and Service layer.
    public interface IAppointmentService
    {
        void BookAppointment(Appointment appointment);

        List<Appointment> ViewAllAppointments();

        Appointment GetAppointmentById(int appointmentId);

        List<Appointment> GetPatientAppointments(int patientId);

        void UpdateAppointmentStatus(int appointmentId, string status);

        void CancelAppointment(int appointmentId);
}
}