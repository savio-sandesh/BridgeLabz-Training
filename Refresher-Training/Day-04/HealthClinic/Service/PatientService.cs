using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using HealthClinic.Connection;
using HealthClinic.Entity;
using HealthClinic.Interface;

namespace HealthClinic.Service
{
    // PatientService contains business logic for patient operations.
    // It implements IPatientService interface.
    public class PatientService : IPatientService
    {

        // Adds a new patient into Patient table.
        public void AddPatient(Patient patient)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                @"INSERT INTO Patient
                  (FirstName, LastName, DateOfBirth, Gender, Phone, Email, Address)
                  VALUES
                  (@FirstName, @LastName, @DateOfBirth, @Gender, @Phone, @Email, @Address)";


                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Phone", patient.Phone);
                cmd.Parameters.AddWithValue("@Email", patient.Email);
                cmd.Parameters.AddWithValue("@Address", patient.Address);


                con.Open();

                cmd.ExecuteNonQuery();

                Console.WriteLine("Patient added successfully.");
            }
        }



        // Retrieves all patients from Patient table.
        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM Patient";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Patient patient = new Patient
                    {
                        PatientId = Convert.ToInt32(reader["PatientId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                        Gender = reader["Gender"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString()
                    };


                    patients.Add(patient);
                }
            }

            return patients;
        }



        // Retrieves patient using PatientId.
        public Patient GetPatientById(int patientId)
        {
            Patient patient = null;


            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                "SELECT * FROM Patient WHERE PatientId = @PatientId";


                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@PatientId", patientId);


                con.Open();


                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    patient = new Patient
                    {
                        PatientId = Convert.ToInt32(reader["PatientId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                        Gender = reader["Gender"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString()
                    };
                }
            }


            return patient;
        }



        // Updates existing patient information.
        public void UpdatePatient(Patient patient)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                @"UPDATE Patient SET
                    FirstName = @FirstName,
                    LastName = @LastName,
                    DateOfBirth = @DateOfBirth,
                    Gender = @Gender,
                    Phone = @Phone,
                    Email = @Email,
                    Address = @Address
                  WHERE PatientId = @PatientId";


                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@PatientId", patient.PatientId);
                cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Phone", patient.Phone);
                cmd.Parameters.AddWithValue("@Email", patient.Email);
                cmd.Parameters.AddWithValue("@Address", patient.Address);


                con.Open();


                int rows = cmd.ExecuteNonQuery();


                if(rows > 0)
                    Console.WriteLine("Patient updated successfully.");
                else
                    Console.WriteLine("Patient not found.");
            }
        }



        // Deletes patient using PatientId.
        public void DeletePatient(int patientId)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                "DELETE FROM Patient WHERE PatientId = @PatientId";


                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@PatientId", patientId);


                con.Open();


                int rows = cmd.ExecuteNonQuery();


                if(rows > 0)
                    Console.WriteLine("Patient deleted successfully.");
                else
                    Console.WriteLine("Patient not found.");
            }
        }

    }
}