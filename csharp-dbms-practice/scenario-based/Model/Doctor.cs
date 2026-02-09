using System;

namespace HealthCare.Model
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public decimal ConsultationFee { get; set; }
        public bool IsActive { get; set; }
        public int SpecializationID { get; set; }
        public Specialization Specialization { get; set; }
    }
}
