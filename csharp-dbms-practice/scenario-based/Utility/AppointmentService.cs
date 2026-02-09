using System;
using System.Data;
using Microsoft.Data.SqlClient;

using Interface;
using Connection;
using Exceptions;

namespace Utility
{
    public class AppointmentService : IAppointmentService
    {
        // Book appointment
        public void BookAppointment()
        {
            int pid = InputHelper.ReadInt("Patient ID: ");
            int did = InputHelper.ReadInt("Doctor ID: ");

            DateTime date = InputHelper.ReadDate("Appointment Date (yyyy-mm-dd): ");
            TimeSpan time = TimeSpan.Parse(InputHelper.ReadString("Time (HH:mm): "));

            using (SqlConnection con = DBConnection.GetConnection())
            {
                // Check availability
                SqlCommand check =
                    new SqlCommand("sp_CheckDoctorAvailability", con);

                check.CommandType = CommandType.StoredProcedure;

                check.Parameters.AddWithValue("@DoctorID", did);
                check.Parameters.AddWithValue("@Date", date);

                con.Open();

                object result = check.ExecuteScalar();

                if (result != null && Convert.ToInt32(result) >= 10)
                {
                    Console.WriteLine("Doctor fully booked.");
                    return;
                }

                con.Close();


                // Book appointment
                SqlCommand cmd =
                    new SqlCommand("sp_BookAppointment", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PatientID", pid);
                cmd.Parameters.AddWithValue("@DoctorID", did);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Time", time);

                con.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("Appointment Booked Successfully.");
            }
        }


        // Cancel appointment
        public void CancelAppointment()
        {
            int id = InputHelper.ReadInt("Appointment ID: ");

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                "UPDATE Appointments SET AppointmentStatus='CANCELLED' WHERE AppointmentID=@id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                    throw new AppointmentNotFoundException();

                Console.WriteLine("Appointment Cancelled.");
            }
        }


        // Reschedule appointment
        public void RescheduleAppointment()
        {
            int id = InputHelper.ReadInt("Appointment ID: ");

            DateTime date = InputHelper.ReadDate("New Date (yyyy-mm-dd): ");
            TimeSpan time = TimeSpan.Parse(InputHelper.ReadString("New Time (HH:mm): "));

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                @"UPDATE Appointments
                  SET AppointmentDate=@Date,
                      AppointmentTime=@Time,
                      AppointmentStatus='RESCHEDULED'
                  WHERE AppointmentID=@id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Time", time);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                    throw new AppointmentNotFoundException();

                Console.WriteLine("Appointment Rescheduled.");
            }
        }


        // View all appointments
        public void ViewAppointments()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                @"SELECT a.AppointmentID,
                         p.FirstName + ' ' + p.LastName AS Patient,
                         d.FirstName + ' ' + d.LastName AS Doctor,
                         a.AppointmentDate,
                         a.AppointmentTime,
                         a.AppointmentStatus
                  FROM Appointments a
                  JOIN Patients p ON a.PatientID = p.PatientID
                  JOIN Doctors d ON a.DoctorID = d.DoctorID";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(
                        $"ID:{dr["AppointmentID"]} | " +
                        $"Patient:{dr["Patient"]} | " +
                        $"Doctor:{dr["Doctor"]} | " +
                        $"Date:{dr["AppointmentDate"]} | " +
                        $"Status:{dr["AppointmentStatus"]}");
                }
            }
        }


        // Check doctor availability
        public void CheckAvailability()
        {
            int did = InputHelper.ReadInt("Doctor ID: ");
            DateTime date = InputHelper.ReadDate("Date (yyyy-mm-dd): ");

            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd =
                    new SqlCommand("sp_CheckDoctorAvailability", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DoctorID", did);
                cmd.Parameters.AddWithValue("@Date", date);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Console.WriteLine($"Booked Slots: {dr["BookedSlots"]}");
                }
                else
                {
                    Console.WriteLine("No bookings found.");
                }
            }
        }

        public void CompleteAppointment()
{
    int id = InputHelper.ReadInt("Appointment ID: ");

    string diagnosis =
        InputHelper.ReadString("Diagnosis: ");

    string notes =
        InputHelper.ReadString("Notes (optional): ");


    using (SqlConnection con = DBConnection.GetConnection())
    {
        con.Open();

        // Check appointment exists and is scheduled
        string checkQuery =
        "SELECT AppointmentStatus FROM Appointments WHERE AppointmentID=@id";

        SqlCommand checkCmd =
            new SqlCommand(checkQuery, con);

        checkCmd.Parameters.AddWithValue("@id", id);

        object status = checkCmd.ExecuteScalar();

        if (status == null)
        {
            Console.WriteLine("Appointment not found.");
            return;
        }

        if (status.ToString() != "SCHEDULED")
        {
            Console.WriteLine("Only scheduled appointments can be completed.");
            return;
        }


        // Start transaction
        SqlTransaction tx = con.BeginTransaction();


        try
        {
            // Update status
            string updateQuery =
            "UPDATE Appointments SET AppointmentStatus='COMPLETED' WHERE AppointmentID=@id";

            SqlCommand updateCmd =
                new SqlCommand(updateQuery, con, tx);

            updateCmd.Parameters.AddWithValue("@id", id);

            updateCmd.ExecuteNonQuery();


            // Insert visit
            string insertQuery =
            @"INSERT INTO Visits
              (AppointmentID, Diagnosis, Notes)
              VALUES
              (@id, @diag, @notes)";

            SqlCommand insertCmd =
                new SqlCommand(insertQuery, con, tx);

            insertCmd.Parameters.AddWithValue("@id", id);
            insertCmd.Parameters.AddWithValue("@diag", diagnosis);

            insertCmd.Parameters.AddWithValue("@notes",
                string.IsNullOrWhiteSpace(notes)
                ? (object)DBNull.Value
                : notes);

            insertCmd.ExecuteNonQuery();


            // Commit
            tx.Commit();

            Console.WriteLine("Appointment completed and visit created.");
        }
        catch
        {
            tx.Rollback();
            Console.WriteLine("Failed to complete appointment.");
        }
    }
}

    }
}
