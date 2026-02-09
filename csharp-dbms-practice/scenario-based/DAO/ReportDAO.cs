using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthCare.Model;
using Connection;

namespace DAO
{
    public class ReportDAO
    {
        // INSERT
        public void Insert(AuditLog auditLog)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"INSERT INTO AuditLogs (UserName, ActionType, TableName, RecordID, ActionDateTime)
                                 VALUES (@UserName, @ActionType, @TableName, @RecordID, @ActionDateTime)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", auditLog.UserName);
                cmd.Parameters.AddWithValue("@ActionType", auditLog.ActionType);
                cmd.Parameters.AddWithValue("@TableName", auditLog.TableName);
                cmd.Parameters.AddWithValue("@RecordID", auditLog.RecordID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ActionDateTime", auditLog.ActionDateTime);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // SELECT by ID
        public AuditLog SelectById(int auditId)
        {
            AuditLog auditLog = null;
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM AuditLogs WHERE Audit_ID = @Audit_ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Audit_ID", auditId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    auditLog = new AuditLog
                    {
                        AuditID = (int)reader["Audit_ID"],
                        UserName = reader["UserName"].ToString(),
                        ActionType = reader["ActionType"].ToString(),
                        TableName = reader["TableName"].ToString(),
                        RecordID = reader["RecordID"] as int?,
                        ActionDateTime = (DateTime)reader["ActionDateTime"]
                    };
                }
            }
            return auditLog;
        }

        // SELECT ALL
        public List<AuditLog> SelectAll()
        {
            List<AuditLog> auditLogs = new List<AuditLog>();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM AuditLogs";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AuditLog auditLog = new AuditLog
                    {
                        AuditID = (int)reader["Audit_ID"],
                        UserName = reader["UserName"].ToString(),
                        ActionType = reader["ActionType"].ToString(),
                        TableName = reader["TableName"].ToString(),
                        RecordID = reader["RecordID"] as int?,
                        ActionDateTime = (DateTime)reader["ActionDateTime"]
                    };
                    auditLogs.Add(auditLog);
                }
            }
            return auditLogs;
        }

        // UPDATE
        public void Update(AuditLog auditLog)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"UPDATE AuditLogs SET UserName = @UserName, ActionType = @ActionType, TableName = @TableName,
                                 RecordID = @RecordID, ActionDateTime = @ActionDateTime WHERE Audit_ID = @Audit_ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Audit_ID", auditLog.AuditID);
                cmd.Parameters.AddWithValue("@UserName", auditLog.UserName);
                cmd.Parameters.AddWithValue("@ActionType", auditLog.ActionType);
                cmd.Parameters.AddWithValue("@TableName", auditLog.TableName);
                cmd.Parameters.AddWithValue("@RecordID", auditLog.RecordID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ActionDateTime", auditLog.ActionDateTime);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void Delete(int auditId)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "DELETE FROM AuditLogs WHERE Audit_ID = @Audit_ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Audit_ID", auditId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
