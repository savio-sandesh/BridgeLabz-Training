using System;

namespace HealthClinic.Entity
{
    // Appointment entity represents the Appointment table.
    // It stores appointment related information.
    public class Appointment
    {
        // Primary key of Appointment table
        public int AppointmentId { get; set; }


        // Foreign key referencing Patient table
        public int PatientId { get; set; }


        // Foreign key referencing Doctor table
        public int DoctorId { get; set; }


        // Date of appointment
        public DateTime AppointmentDate { get; set; }


        // Time of appointment
        public TimeSpan AppointmentTime { get; set; }


        // Reason for appointment
        public string Reason { get; set; }


        // Current status of appointment
        // Example: Scheduled, Completed, Cancelled
        public string Status { get; set; }


        // Default constructor
        // Used when creating an empty Appointment object
        // and assigning values later.
        public Appointment()
        {

        }


        // Parameterized constructor
        // Used for creating Appointment object with values.
        public Appointment(
            int appointmentId,
            int patientId,
            int doctorId,
            DateTime appointmentDate,
            TimeSpan appointmentTime,
            string reason,
            string appointmentStatus)
        {
            AppointmentId = appointmentId;
            PatientId = patientId;
            DoctorId = doctorId;
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
            Reason = reason;
            Status = appointmentStatus;
        }


        // Overrides default ToString() method.
        // Allows direct display of Appointment details.
        public override string ToString()
        {
            return $"Appointment ID: {AppointmentId}\n" +
                   $"Patient ID: {PatientId}\n" +
                   $"Doctor ID: {DoctorId}\n" +
                   $"Date: {AppointmentDate:yyyy-MM-dd}\n" +
                   $"Time: {AppointmentTime}\n" +
                   $"Reason: {Reason}\n" +
                   $"Status: {Status}";
        }
    }
}