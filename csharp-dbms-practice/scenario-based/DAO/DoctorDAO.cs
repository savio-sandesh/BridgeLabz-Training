using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

using Connection;
using HealthCare.Model;
using Exceptions;

namespace DAO
{
    public class DoctorDAO
    {
        // Add doctor
        public void AddDoctor(Doctor doctor)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                @"INSERT INTO Doctors
                  (FirstName, LastName, ContactNumber, Email, ConsultationFee, Is_Active, SpecializationID)
                  VALUES
                  (@FirstName, @LastName, @Contact, @Email, @Fee, 1, @SpecId)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@FirstName", doctor.FirstName);
                cmd.Parameters.AddWithValue("@LastName", doctor.LastName);
                cmd.Parameters.AddWithValue("@Contact", doctor.ContactNumber);
                cmd.Parameters.AddWithValue("@Email", doctor.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Fee", doctor.ConsultationFee);
                cmd.Parameters.AddWithValue("@SpecId", doctor.SpecializationID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        // Get doctor by ID
        public Doctor GetDoctorById(int id)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                "SELECT * FROM Doctors WHERE DoctorID=@Id AND Is_Active=1";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Doctor
                    {
                        DoctorID = (int)reader["DoctorID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        ContactNumber = reader["ContactNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        ConsultationFee = (decimal)reader["ConsultationFee"],
                        IsActive = (bool)reader["Is_Active"],
                        SpecializationID = (int)reader["SpecializationID"]
                    };
                }
                else
                {
                    throw new DoctorNotFoundException("Doctor not found");
                }
            }
        }


        // Get all active doctors
        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> list = new List<Doctor>();

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                "SELECT * FROM Doctors WHERE Is_Active=1";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Doctor doctor = new Doctor
                    {
                        DoctorID = (int)reader["DoctorID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        ContactNumber = reader["ContactNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        ConsultationFee = (decimal)reader["ConsultationFee"],
                        IsActive = (bool)reader["Is_Active"],
                        SpecializationID = (int)reader["SpecializationID"]
                    };

                    list.Add(doctor);
                }
            }

            return list;
        }


        // Update doctor
        public void UpdateDoctor(Doctor doctor)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                @"UPDATE Doctors
                  SET FirstName=@First,
                      LastName=@Last,
                      ContactNumber=@Contact,
                      Email=@Email,
                      ConsultationFee=@Fee,
                      SpecializationID=@SpecId
                  WHERE DoctorID=@Id AND Is_Active=1";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", doctor.DoctorID);
                cmd.Parameters.AddWithValue("@First", doctor.FirstName);
                cmd.Parameters.AddWithValue("@Last", doctor.LastName);
                cmd.Parameters.AddWithValue("@Contact", doctor.ContactNumber);
                cmd.Parameters.AddWithValue("@Email", doctor.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Fee", doctor.ConsultationFee);
                cmd.Parameters.AddWithValue("@SpecId", doctor.SpecializationID);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                    throw new DoctorNotFoundException("Doctor not found");
            }
        }


        // Soft delete doctor
        public void DeactivateDoctor(int id)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                "UPDATE Doctors SET Is_Active=0 WHERE DoctorID=@Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                    throw new DoctorNotFoundException("Doctor not found");
            }
        }
    }
}
