using System;

namespace HealthCare.Model
{
    public class AppointmentAudit
    {
        public int AuditID { get; set; }
        public int AppointmentID { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public string ChangedBy { get; set; }
        public DateTime ChangeDateTime { get; set; }
        public Appointment Appointment { get; set; }
    }
}
