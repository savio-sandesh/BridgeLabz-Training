namespace Interface
{
    public interface IDoctorService
    {
        // Add new doctor
        void AddDoctor();

        // Update doctor information
        void UpdateDoctor();

        // Deactivate / Delete doctor
        void DeleteDoctor();

        // Search doctor
        void SearchDoctor();

        // View all doctors
        void ViewAllDoctors();
    }
}
