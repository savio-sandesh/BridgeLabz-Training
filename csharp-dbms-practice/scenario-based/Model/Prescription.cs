namespace HealthCare.Model
{
    public class Prescription
    {
        public int PrescriptionID { get; set; }
        public int VisitID { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
        public Visit Visit { get; set; }
    }
}
