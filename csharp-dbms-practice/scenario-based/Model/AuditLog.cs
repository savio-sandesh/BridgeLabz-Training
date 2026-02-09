using System;

namespace HealthCare.Model
{
    public class AuditLog
    {
        public int AuditID { get; set; }
        public string UserName { get; set; }
        public string ActionType { get; set; }
        public string TableName { get; set; }
        public int? RecordID { get; set; }
        public DateTime ActionDateTime { get; set; }
    }
}
