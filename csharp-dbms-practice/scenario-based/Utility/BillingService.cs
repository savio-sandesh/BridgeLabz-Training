using System;
using System.Data;
using Microsoft.Data.SqlClient;

using Interface;
using Connection;
using Exceptions;

namespace Utility
{
    public class BillingService : IBillingService
    {
        // Generate bill after visit
        public void GenerateBill()
        {
            int vid = InputHelper.ReadInt("Visit ID: ");

            if (!VisitExists(vid))
            {
                Console.WriteLine("Visit not found.");
                return;
            }

            decimal amt = InputHelper.ReadDecimal("Amount: ");

            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd =
                    new SqlCommand("sp_GenerateBill", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VisitID", vid);
                cmd.Parameters.AddWithValue("@Amount", amt);

                con.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("Bill Generated Successfully.");
            }
        }


        // Make payment
        public void MakePayment()
        {
            int bid = InputHelper.ReadInt("Bill ID: ");

            if (!BillExists(bid))
            {
                Console.WriteLine("Bill not found.");
                return;
            }

            decimal amt = InputHelper.ReadDecimal("Amount: ");

            string mode =
                InputHelper.ReadString("Mode (CASH/CARD/UPI/NETBANKING): ");

            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd =
                    new SqlCommand("sp_MakePayment_Transaction", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BillID", bid);
                cmd.Parameters.AddWithValue("@Amount", amt);
                cmd.Parameters.AddWithValue("@Mode", mode.ToUpper());
                cmd.Parameters.AddWithValue("@UserName", "SYSTEM");

                con.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("Payment Completed.");
            }
        }


        // View all bills
        public void ViewBill()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                @"SELECT b.BillID,
                         b.TotalAmount,
                         b.PaymentStatus,
                         b.BillingDate,
                         p.FirstName + ' ' + p.LastName AS Patient
                  FROM Bills b
                  JOIN Visits v ON b.VisitID = v.VisitID
                  JOIN Appointments a ON v.AppointmentID = a.AppointmentID
                  JOIN Patients p ON a.PatientID = p.PatientID";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(
                        $"Bill:{dr["BillID"]} | " +
                        $"Patient:{dr["Patient"]} | " +
                        $"Amount:{dr["TotalAmount"]} | " +
                        $"Status:{dr["PaymentStatus"]}");
                }
            }
        }


        // View payment history
        public void ViewPayments()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                @"SELECT TransactionID,
                         BillID,
                         AmountPaid,
                         PaymentMode,
                         TransactionDate,
                         PerformedBy
                  FROM Payment_Transactions";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(
                        $"Txn:{dr["TransactionID"]} | " +
                        $"Bill:{dr["BillID"]} | " +
                        $"Paid:{dr["AmountPaid"]} | " +
                        $"Mode:{dr["PaymentMode"]}");
                }
            }
        }


        // Helpers

        private bool VisitExists(int id)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd =
                    new SqlCommand("SELECT COUNT(*) FROM Visits WHERE VisitID=@id", con);

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();

                return (int)cmd.ExecuteScalar() > 0;
            }
        }


        private bool BillExists(int id)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd =
                    new SqlCommand("SELECT COUNT(*) FROM Bills WHERE BillID=@id", con);

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();

                return (int)cmd.ExecuteScalar() > 0;
            }
        }
    }
}
