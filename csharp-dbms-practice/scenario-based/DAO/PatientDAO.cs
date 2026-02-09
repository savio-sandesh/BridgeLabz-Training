using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthCare.Model;
using Connection;

namespace DAO
{
    public class PatientDAO
    {
        // INSERT
        public void Insert(Patient patient)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"INSERT INTO Patients (FirstName, LastName, DOB, Gender, Address, BloodGroup, ContactNumber, Email)
                                 VALUES (@FirstName, @LastName, @DOB, @Gender, @Address, @BloodGroup, @ContactNumber, @Email)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                cmd.Parameters.AddWithValue("@DOB", patient.DOB);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", patient.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ContactNumber", patient.ContactNumber);
                cmd.Parameters.AddWithValue("@Email", patient.Email ?? (object)DBNull.Value);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // SELECT by ID
        public Patient SelectById(int patientId)
        {
            Patient patient = null;
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM Patients WHERE PatientID = @PatientID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PatientID", patientId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    patient = new Patient
                    {
                        PatientID = (int)reader["PatientID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        DOB = (DateTime)reader["DOB"],
                        Gender = reader["Gender"].ToString(),
                        Address = reader["Address"].ToString(),
                        BloodGroup = reader["BloodGroup"].ToString(),
                        ContactNumber = reader["ContactNumber"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }
            }
            return patient;
        }

        // SELECT ALL
        public List<Patient> SelectAll()
        {
            List<Patient> patients = new List<Patient>();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM Patients";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Patient patient = new Patient
                    {
                        PatientID = (int)reader["PatientID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        DOB = (DateTime)reader["DOB"],
                        Gender = reader["Gender"].ToString(),
                        Address = reader["Address"].ToString(),
                        BloodGroup = reader["BloodGroup"].ToString(),
                        ContactNumber = reader["ContactNumber"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                    patients.Add(patient);
                }
            }
            return patients;
        }

        // UPDATE
        public void Update(Patient patient)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"UPDATE Patients SET FirstName = @FirstName, LastName = @LastName, DOB = @DOB, Gender = @Gender,
                                 Address = @Address, BloodGroup = @BloodGroup, ContactNumber = @ContactNumber, Email = @Email
                                 WHERE PatientID = @PatientID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PatientID", patient.PatientID);
                cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                cmd.Parameters.AddWithValue("@DOB", patient.DOB);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", patient.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ContactNumber", patient.ContactNumber);
                cmd.Parameters.AddWithValue("@Email", patient.Email ?? (object)DBNull.Value);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void Delete(int patientId)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "DELETE FROM Patients WHERE PatientID = @PatientID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PatientID", patientId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
