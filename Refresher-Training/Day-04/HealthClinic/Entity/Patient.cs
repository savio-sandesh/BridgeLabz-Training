using System;

namespace HealthClinic.Entity
{
    // Patient entity represents the Patient table.
    // It contains only data and object behavior related to Patient.
    public class Patient
    {
        // Primary key
        public int PatientId { get; set; }

        // Patient first name
        public string FirstName { get; set; }

        // Patient last name
        public string LastName { get; set; }

        // Patient date of birth
        public DateTime DateOfBirth { get; set; }

        // Patient gender
        public string Gender { get; set; }

        // Patient phone number
        public string Phone { get; set; }

        // Patient email address
        public string Email { get; set; }

        // Patient residential address
        public string Address { get; set; }


        // Default constructor
        // Required when creating an empty object and assigning values later.
        public Patient()
        {

        }


        // Parameterized constructor
        // Used when creating a Patient object with existing data.
        public Patient(
            int patientId,
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            string gender,
            string phone,
            string email,
            string address)
        {
            PatientId = patientId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Phone = phone;
            Email = email;
            Address = address;
        }


        // Overrides default object representation.
        // Helps display Patient details directly using Console.WriteLine().
        public override string ToString()
        {
            return $"Patient ID: {PatientId}\n" +
                   $"Name: {FirstName} {LastName}\n" +
                   $"Date Of Birth: {DateOfBirth:yyyy-MM-dd}\n" +
                   $"Gender: {Gender}\n" +
                   $"Phone: {Phone}\n" +
                   $"Email: {Email}\n" +
                   $"Address: {Address}";
        }
    }
}