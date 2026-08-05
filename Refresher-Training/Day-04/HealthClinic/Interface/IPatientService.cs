using System.Collections.Generic;
using HealthClinic.Entity;

namespace HealthClinic.Interface
{
    // Interface defines the contract for Patient related operations.
    // PatientService class will implement these methods.
    public interface IPatientService
    {
        // Add a new patient into the database.
        void AddPatient(Patient patient);


        // Retrieve all patients from the database.
        List<Patient> GetAllPatients();


        // Retrieve a patient using PatientId.
        Patient GetPatientById(int patientId);


        // Update existing patient details.
        void UpdatePatient(Patient patient);


        // Delete patient using PatientId.
        void DeletePatient(int patientId);
    }
}