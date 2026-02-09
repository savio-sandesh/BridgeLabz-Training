using System;
using System.Data;
using Microsoft.Data.SqlClient;

using Interface;
using Connection;
using Exceptions;

namespace Utility
{
    public class PatientService : IPatientService
    {
        public void AddPatient()
        {
            string first = InputHelper.ReadString("First Name: ");
            string last = InputHelper.ReadString("Last Name: ");

            DateTime dob = InputHelper.ReadDate("DOB (yyyy-mm-dd): ");

            string gender = InputHelper.ReadString("Gender: ");
            string address = InputHelper.ReadString("Address: ");
            string blood = InputHelper.ReadString("Blood Group: ");

            string contact = InputHelper.ReadString("Contact: ");
            string email = InputHelper.ReadString("Email: ");

            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_RegisterPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", first);
                cmd.Parameters.AddWithValue("@LastName", last);
                cmd.Parameters.AddWithValue("@DOB", dob);

                cmd.Parameters.AddWithValue("@Gender",
                    string.IsNullOrWhiteSpace(gender) ? (object)DBNull.Value : gender);

                cmd.Parameters.AddWithValue("@Address",
                    string.IsNullOrWhiteSpace(address) ? (object)DBNull.Value : address);

                cmd.Parameters.AddWithValue("@BloodGroup",
                    string.IsNullOrWhiteSpace(blood) ? (object)DBNull.Value : blood);

                cmd.Parameters.AddWithValue("@ContactNumber", contact);

                cmd.Parameters.AddWithValue("@Email",
                    string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);

                con.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("Patient Added Successfully.");
            }
        }
        public void UpdatePatient()
        {
            Console.WriteLine("Update Patient - To be implemented");
        }

        public void DeletePatient()
        {
            int id = InputHelper.ReadInt("Enter Patient ID: ");

            if (!PatientExists(id))
                throw new PatientNotFoundException();

            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd =
                    new SqlCommand("DELETE FROM Patients WHERE PatientID=@id", con);

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("Patient Deleted.");
            }
        }

        public void SearchPatient()
        {
            int id = InputHelper.ReadInt("Enter Patient ID: ");

            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd =
                    new SqlCommand("SELECT * FROM Patients WHERE PatientID=@id", con);

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.Read())
                    throw new PatientNotFoundException();

                Console.WriteLine($"Name: {dr["FirstName"]} {dr["LastName"]}");
                Console.WriteLine($"Contact: {dr["ContactNumber"]}");
            }
        }

        public void ViewAllPatients()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Patients", con);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine($"{dr["PatientID"]} - {dr["FirstName"]}");
                }
            }
        }

        private bool PatientExists(int id)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd =
                    new SqlCommand("SELECT COUNT(*) FROM Patients WHERE PatientID=@id", con);

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();

                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }
    }
}
