using System;
using Microsoft.Data.SqlClient;

using Interface;
using Connection;

namespace Utility
{
    public class ReportService : IReportService
    {
        // Total revenue
        public void ShowTotalRevenue()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                "SELECT ISNULL(SUM(TotalAmount),0) FROM Bills WHERE PaymentStatus='PAID'";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                object result = cmd.ExecuteScalar();

                Console.WriteLine($"Total Revenue: ₹{result}");
            }
        }


        // Revenue per doctor
        public void ShowDoctorRevenue()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                @"SELECT 
                    d.FirstName + ' ' + d.LastName AS DoctorName,
                    SUM(b.TotalAmount) AS Revenue
                  FROM Bills b
                  JOIN Visits v ON b.VisitID = v.VisitID
                  JOIN Appointments a ON v.AppointmentID = a.AppointmentID
                  JOIN Doctors d ON a.DoctorID = d.DoctorID
                  WHERE b.PaymentStatus='PAID'
                  GROUP BY d.FirstName, d.LastName";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("\nDoctor Revenue:");

                while (dr.Read())
                {
                    Console.WriteLine(
                        $"{dr["DoctorName"]} → ₹{dr["Revenue"]}");
                }
            }
        }


        // Pending bills
        public void ShowPendingBills()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                @"SELECT 
                    b.BillID,
                    p.FirstName + ' ' + p.LastName AS Patient,
                    b.TotalAmount
                  FROM Bills b
                  JOIN Visits v ON b.VisitID = v.VisitID
                  JOIN Appointments a ON v.AppointmentID = a.AppointmentID
                  JOIN Patients p ON a.PatientID = p.PatientID
                  WHERE b.PaymentStatus='UNPAID'";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("\nPending Bills:");

                while (dr.Read())
                {
                    Console.WriteLine(
                        $"Bill:{dr["BillID"]} | " +
                        $"Patient:{dr["Patient"]} | " +
                        $"Amount:₹{dr["TotalAmount"]}");
                }
            }
        }


        // Daily appointments
        public void ShowDailyAppointments()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                @"SELECT 
                    AppointmentDate,
                    COUNT(*) AS Total
                  FROM Appointments
                  GROUP BY AppointmentDate
                  ORDER BY AppointmentDate";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("\nDaily Appointments:");

                while (dr.Read())
                {
                    Console.WriteLine(
                        $"{dr["AppointmentDate"]} → {dr["Total"]}");
                }
            }
        }


        // Audit logs
        public void ShowAuditLogs()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query =
                "SELECT * FROM AuditLogs ORDER BY ActionDateTime DESC";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("\nAudit Logs:");

                while (dr.Read())
                {
                    Console.WriteLine(
                        $"User:{dr["UserName"]} | " +
                        $"Action:{dr["ActionType"]} | " +
                        $"Table:{dr["TableName"]} | " +
                        $"Time:{dr["ActionDateTime"]}");
                }
            }
        }
    }
}
