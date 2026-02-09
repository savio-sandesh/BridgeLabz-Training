using System;
using System.Data;
using Microsoft.Data.SqlClient;

using Interface;
using Connection;
using Exceptions;

namespace Utility
{
    public class DoctorService : IDoctorService
    {
        // Add doctor
        public void AddDoctor()
        {
            string first = InputHelper.ReadString("First Name: ");
            string last = InputHelper.ReadString("Last Name: ");
            string contact = InputHelper.ReadString("Contact: ");
            string email = InputHelper.ReadString("Email: ");
            decimal fee = InputHelper.ReadDecimal("Consultation Fee: ");
            int specId = InputHelper.ReadInt("Specialization ID: ");

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                @"INSERT INTO Doctors
                  (FirstName, LastName, ContactNumber, Email, ConsultationFee, Is_Active, SpecializationID)
                  VALUES
                  (@First, @Last, @Contact, @Email, @Fee, 1, @SpecId)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@First", first);
                cmd.Parameters.AddWithValue("@Last", last);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Email",
                    string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                cmd.Parameters.AddWithValue("@Fee", fee);
                cmd.Parameters.AddWithValue("@SpecId", specId);

                con.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("Doctor Added Successfully.");
            }
        }


        // Delete doctor (soft delete)
        public void DeleteDoctor()
        {
            int id = InputHelper.ReadInt("Doctor ID: ");

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                "UPDATE Doctors SET Is_Active=0 WHERE DoctorID=@id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                    throw new DoctorNotFoundException();

                Console.WriteLine("Doctor Deactivated.");
            }
        }


        // Search doctor
        public void SearchDoctor()
        {
            int id = InputHelper.ReadInt("Doctor ID: ");

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                "SELECT * FROM Doctors WHERE DoctorID=@id AND Is_Active=1";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.Read())
                    throw new DoctorNotFoundException();

                Console.WriteLine($"Name: {dr["FirstName"]} {dr["LastName"]}");
                Console.WriteLine($"Contact: {dr["ContactNumber"]}");
                Console.WriteLine($"Fee: {dr["ConsultationFee"]}");
            }
        }

        public void UpdateDoctor()
        {
            throw new NotImplementedException();
        }


        // View all doctors
        public void ViewAllDoctors()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                "SELECT * FROM Doctors WHERE Is_Active=1";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(
                        $"{dr["DoctorID"]} - {dr["FirstName"]} {dr["LastName"]} | Fee: {dr["ConsultationFee"]}");
                }
            }
        }
    }
}
