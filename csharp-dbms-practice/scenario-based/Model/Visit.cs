using System;

namespace HealthCare.Model
{
    public class Visit
    {
        public int VisitID { get; set; }
        public int AppointmentID { get; set; }
        public string Diagnosis { get; set; }
        public string Notes { get; set; }
        public DateTime VisitDate { get; set; }
        public Appointment Appointment { get; set; }
    }
}
