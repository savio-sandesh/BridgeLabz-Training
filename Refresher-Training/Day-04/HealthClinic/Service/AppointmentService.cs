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




















// SQL Server returns rows, not Appointment objects.
// Your C# program doesn't understand database rows directly. It understands objects.
// So we convert:

// Database Row
//         ↓
// Appointment Object
// This process is called Object Mapping (or Data Mapping).
// Read() moves the cursor one row forward



// SQL Server returns data in the form of rows and columns, whereas C# applications work with objects. Therefore, we map each database row to an entity object, such as Appointment, so that the data can be easily accessed, passed between layers, and used according to object-oriented programming principles. This also keeps the service layer independent of the database representation



// This code is used to retrieve multiple appointment records from the database and convert them into C# objects.

// reader is a SqlDataReader object that contains the result set returned by the SQL query.

// The Read() method moves the reader to the next row in the result set and returns true as long as there are rows available. That's why we use a while loop—to process every record one by one.

// Inside the loop, I create a new Appointment object and map each database column to its corresponding property in the object. Since database values are returned as object, I convert them to the appropriate C# data types using methods like Convert.ToInt32(), Convert.ToDateTime(), and ToString().

// After creating and populating the object, I add it to a List<Appointment>. When the loop finishes, the list contains all appointment records from the database, which can then be returned to the caller