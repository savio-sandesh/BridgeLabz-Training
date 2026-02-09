using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthCare.Model;
using Connection;

namespace DAO
{
    public class AppointmentDAO
    {
        // INSERT
        public void Insert(Appointment appointment)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"INSERT INTO Appointments (PatientID, DoctorID, AppointmentDate, AppointmentTime, AppointmentStatus)
                                 VALUES (@PatientID, @DoctorID, @AppointmentDate, @AppointmentTime, @AppointmentStatus)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PatientID", appointment.PatientID);
                cmd.Parameters.AddWithValue("@DoctorID", appointment.DoctorID);
                cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate.Date);
                cmd.Parameters.AddWithValue("@AppointmentTime", appointment.AppointmentTime);
                cmd.Parameters.AddWithValue("@AppointmentStatus", appointment.AppointmentStatus);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // SELECT by ID
        public Appointment SelectById(int appointmentId)
        {
            Appointment appointment = null;
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM Appointments WHERE AppointmentID = @AppointmentID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    appointment = new Appointment
                    {
                        AppointmentID = (int)reader["AppointmentID"],
                        PatientID = (int)reader["PatientID"],
                        DoctorID = (int)reader["DoctorID"],
                        AppointmentDate = (DateTime)reader["AppointmentDate"],
                        AppointmentTime = (TimeSpan)reader["AppointmentTime"],
                        AppointmentStatus = reader["AppointmentStatus"].ToString()
                    };
                }
            }
            return appointment;
        }

        // SELECT ALL
        public List<Appointment> SelectAll()
        {
            List<Appointment> appointments = new List<Appointment>();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM Appointments";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Appointment appointment = new Appointment
                    {
                        AppointmentID = (int)reader["AppointmentID"],
                        PatientID = (int)reader["PatientID"],
                        DoctorID = (int)reader["DoctorID"],
                        AppointmentDate = (DateTime)reader["AppointmentDate"],
                        AppointmentTime = (TimeSpan)reader["AppointmentTime"],
                        AppointmentStatus = reader["AppointmentStatus"].ToString()
                    };
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }

        // UPDATE
        public void Update(Appointment appointment)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"UPDATE Appointments SET PatientID = @PatientID, DoctorID = @DoctorID, AppointmentDate = @AppointmentDate,
                                 AppointmentTime = @AppointmentTime, AppointmentStatus = @AppointmentStatus
                                 WHERE AppointmentID = @AppointmentID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AppointmentID", appointment.AppointmentID);
                cmd.Parameters.AddWithValue("@PatientID", appointment.PatientID);
                cmd.Parameters.AddWithValue("@DoctorID", appointment.DoctorID);
                cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate.Date);
                cmd.Parameters.AddWithValue("@AppointmentTime", appointment.AppointmentTime);
                cmd.Parameters.AddWithValue("@AppointmentStatus", appointment.AppointmentStatus);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void Delete(int appointmentId)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "DELETE FROM Appointments WHERE AppointmentID = @AppointmentID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
