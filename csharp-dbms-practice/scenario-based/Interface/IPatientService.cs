namespace Interface
{
    public interface IPatientService
    {
        // Register a new patient
        void AddPatient();

        // Update existing patient details
        void UpdatePatient();

        // Delete patient record
        void DeletePatient();

        // Search patient by ID / Name / Contact
        void SearchPatient();

        // Display all patients
        void ViewAllPatients();
    }
}
