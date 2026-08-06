using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using HealthClinic.Connection;
using HealthClinic.Entity;
using HealthClinic.Interface;

namespace HealthClinic.Service
{
    // DoctorService contains business logic for doctor operations.
    public class DoctorService : IDoctorService
    {
        // Adds a new doctor.
        public void AddDoctor(Doctor doctor)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"INSERT INTO Doctor
                                (FirstName, LastName, Specialization, Phone, Email, RoomId)
                                VALUES
                                (@FirstName, @LastName, @Specialization, @Phone, @Email, @RoomId)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@FirstName", doctor.FirstName);
                cmd.Parameters.AddWithValue("@LastName", doctor.LastName);
                cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
                cmd.Parameters.AddWithValue("@Phone", doctor.Phone);
                cmd.Parameters.AddWithValue("@Email", doctor.Email);

                if (doctor.RoomId.HasValue)
                    cmd.Parameters.AddWithValue("@RoomId", doctor.RoomId.Value);
                else
                    cmd.Parameters.AddWithValue("@RoomId", DBNull.Value);

                con.Open();

                cmd.ExecuteNonQuery();

                Console.WriteLine("Doctor added successfully.");
            }
        }

        // Returns all doctors.
        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM Doctor";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Doctor doctor = new Doctor
                    {
                        DoctorId = Convert.ToInt32(reader["DoctorId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Specialization = reader["Specialization"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                        RoomId = reader["RoomId"] == DBNull.Value
                                    ? null
                                    : Convert.ToInt32(reader["RoomId"])
                    };

                    doctors.Add(doctor);
                }
            }

            return doctors;
        }

        // Returns doctor by id.
        public Doctor GetDoctorById(int doctorId)
        {
            Doctor doctor = null;

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM Doctor WHERE DoctorId=@DoctorId";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@DoctorId", doctorId);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    doctor = new Doctor
                    {
                        DoctorId = Convert.ToInt32(reader["DoctorId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Specialization = reader["Specialization"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                        RoomId = reader["RoomId"] == DBNull.Value
                                    ? null
                                    : Convert.ToInt32(reader["RoomId"])
                    };
                }
            }

            return doctor;
        }

        // Updates doctor details.
        public void UpdateDoctor(Doctor doctor)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"UPDATE Doctor SET
                                FirstName=@FirstName,
                                LastName=@LastName,
                                Specialization=@Specialization,
                                Phone=@Phone,
                                Email=@Email,
                                RoomId=@RoomId
                                WHERE DoctorId=@DoctorId";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@DoctorId", doctor.DoctorId);
                cmd.Parameters.AddWithValue("@FirstName", doctor.FirstName);
                cmd.Parameters.AddWithValue("@LastName", doctor.LastName);
                cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
                cmd.Parameters.AddWithValue("@Phone", doctor.Phone);
                cmd.Parameters.AddWithValue("@Email", doctor.Email);

                if (doctor.RoomId.HasValue)
                    cmd.Parameters.AddWithValue("@RoomId", doctor.RoomId.Value);
                else
                    cmd.Parameters.AddWithValue("@RoomId", DBNull.Value);

                con.Open();

                cmd.ExecuteNonQuery();

                Console.WriteLine("Doctor updated successfully.");
            }
        }

        // Deletes doctor.
        public void DeleteDoctor(int doctorId)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "DELETE FROM Doctor WHERE DoctorId=@DoctorId";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@DoctorId", doctorId);

                con.Open();

                cmd.ExecuteNonQuery();

                Console.WriteLine("Doctor deleted successfully.");
            }
        }
    }
}