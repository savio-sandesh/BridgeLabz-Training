using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using HealthClinic.Entity;
using HealthClinic.Interface;
using HealthClinic.Connection;

namespace HealthClinic.Service
{
    // AppointmentService contains the business logic for appointment management.
    // It implements IAppointmentService and communicates with the database.
    public class AppointmentService : IAppointmentService
    {
        // Books a new appointment for a patient with a doctor.
        public void BookAppointment(Appointment appointment)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                // SQL query to insert appointment details.
                                string query =
                                @"INSERT INTO Appointment
                  (PatientID, DoctorID, AppointmentDate, AppointmentTime, Reason, Status)
                  VALUES
                  (@PatientID, @DoctorID, @AppointmentDate, @AppointmentTime, @Reason, @Status)";


                SqlCommand cmd = new SqlCommand(query, con);

                // Passing values using parameters prevents SQL injection.
                cmd.Parameters.AddWithValue("@PatientID", appointment.PatientId);
                cmd.Parameters.AddWithValue("@DoctorID", appointment.DoctorId);
                cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                cmd.Parameters.AddWithValue("@AppointmentTime", appointment.AppointmentTime);
                cmd.Parameters.AddWithValue("@Reason", appointment.Reason);
                cmd.Parameters.AddWithValue("@Status", appointment.Status);


                con.Open();

                cmd.ExecuteNonQuery();

                Console.WriteLine("Appointment booked successfully.");
            }
        }

        // Retrieves all appointments from the database.
        public List<Appointment> ViewAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM Appointment";


                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();


                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    // Converting database row into Appointment object.
                    Appointment appointment = new Appointment
                    {
                        AppointmentId = Convert.ToInt32(reader["AppointmentID"]),
                        PatientId = Convert.ToInt32(reader["PatientID"]),
                        DoctorId = Convert.ToInt32(reader["DoctorID"]),
                        AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                        AppointmentTime = (TimeSpan)reader["AppointmentTime"],
                        Reason = reader["Reason"].ToString(),
                        Status = reader["Status"].ToString()
                    };


                    appointments.Add(appointment);
                }
            }

            return appointments;
        }

        // Searches appointment details using Appointment ID.
        public Appointment GetAppointmentById(int appointmentId)
        {
            Appointment appointment = null;


            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                "SELECT * FROM Appointment WHERE AppointmentID=@AppointmentID";


                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);


                con.Open();


                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    appointment = new Appointment
                    {
                        AppointmentId = Convert.ToInt32(reader["AppointmentID"]),
                        PatientId = Convert.ToInt32(reader["PatientID"]),
                        DoctorId = Convert.ToInt32(reader["DoctorID"]),
                        AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                        AppointmentTime = (TimeSpan)reader["AppointmentTime"],
                        Reason = reader["Reason"].ToString(),
                        Status = reader["Status"].ToString()
                    };
                }
            }


            return appointment;
        }



        // Gets all appointments of a specific patient.
        public List<Appointment> GetPatientAppointments(int patientId)
        {
            List<Appointment> appointments = new List<Appointment>();


            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd =
                new SqlCommand("sp_GetPatientAppointments", con);


                // Calling stored procedure.
                cmd.CommandType =
                    System.Data.CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@PatientID", patientId);


                con.Open();


                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Appointment appointment = new Appointment
                    {
                        AppointmentId = Convert.ToInt32(reader["AppointmentID"]),
                        AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                        Status = reader["Status"].ToString()
                    };


                    appointments.Add(appointment);
                }
            }


            return appointments;
        }



        // Updates appointment status.
        // Example:
        // Scheduled → Completed
        // Scheduled → Cancelled
        public void UpdateAppointmentStatus(int appointmentId, string status)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd =
                new SqlCommand("sp_UpdateAppointmentStatus", con);


                cmd.CommandType =
                    System.Data.CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
                cmd.Parameters.AddWithValue("@Status", status);


                con.Open();

                cmd.ExecuteNonQuery();

                Console.WriteLine("Appointment status updated.");
            }
        }



        // Cancels an appointment.
        // Instead of deleting the record, status is updated.
        // This preserves appointment history.
        public void CancelAppointment(int appointmentId)
        {
            UpdateAppointmentStatus(appointmentId, "Cancelled");

            Console.WriteLine("Appointment cancelled successfully.");
        }
    }
}