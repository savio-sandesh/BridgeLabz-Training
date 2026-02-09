using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthCare.Model;
using Connection;

namespace DAO
{
    public class BillingDAO
    {
        // INSERT
        public void Insert(Bill bill)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"INSERT INTO Bills (VisitID, TotalAmount, PaymentStatus, BillingDate)
                                 VALUES (@VisitID, @TotalAmount, @PaymentStatus, @BillingDate)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@VisitID", bill.VisitID);
                cmd.Parameters.AddWithValue("@TotalAmount", bill.TotalAmount);
                cmd.Parameters.AddWithValue("@PaymentStatus", bill.PaymentStatus);
                cmd.Parameters.AddWithValue("@BillingDate", bill.BillingDate);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // SELECT by ID
        public Bill SelectById(int billId)
        {
            Bill bill = null;
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM Bills WHERE BillID = @BillID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BillID", billId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    bill = new Bill
                    {
                        BillID = (int)reader["BillID"],
                        VisitID = (int)reader["VisitID"],
                        TotalAmount = (decimal)reader["TotalAmount"],
                        PaymentStatus = reader["PaymentStatus"].ToString(),
                        BillingDate = (DateTime)reader["BillingDate"]
                    };
                }
            }
            return bill;
        }

        // SELECT ALL
        public List<Bill> SelectAll()
        {
            List<Bill> bills = new List<Bill>();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM Bills";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bill bill = new Bill
                    {
                        BillID = (int)reader["BillID"],
                        VisitID = (int)reader["VisitID"],
                        TotalAmount = (decimal)reader["TotalAmount"],
                        PaymentStatus = reader["PaymentStatus"].ToString(),
                        BillingDate = (DateTime)reader["BillingDate"]
                    };
                    bills.Add(bill);
                }
            }
            return bills;
        }

        // UPDATE
        public void Update(Bill bill)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"UPDATE Bills SET VisitID = @VisitID, TotalAmount = @TotalAmount, PaymentStatus = @PaymentStatus,
                                 BillingDate = @BillingDate WHERE BillID = @BillID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BillID", bill.BillID);
                cmd.Parameters.AddWithValue("@VisitID", bill.VisitID);
                cmd.Parameters.AddWithValue("@TotalAmount", bill.TotalAmount);
                cmd.Parameters.AddWithValue("@PaymentStatus", bill.PaymentStatus);
                cmd.Parameters.AddWithValue("@BillingDate", bill.BillingDate);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void Delete(int billId)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "DELETE FROM Bills WHERE BillID = @BillID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BillID", billId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
