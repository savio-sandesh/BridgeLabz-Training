using System;

namespace HealthClinic.Entity
{
    // Represents Doctor table.
    public class Doctor
    {
        public int DoctorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Specialization { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int? RoomId { get; set; }


        // Default Constructor
        public Doctor()
        {

        }


        // Parameterized Constructor
        public Doctor(int doctorId, string firstName, string lastName,
            string specialization, string phone, string email, int? roomId)
        {
            DoctorId = doctorId;
            FirstName = firstName;
            LastName = lastName;
            Specialization = specialization;
            Phone = phone;
            Email = email;
            RoomId = roomId;
        }


        public override string ToString()
        {
            return $"Doctor ID : {DoctorId}\n" +
                   $"Name : {FirstName} {LastName}\n" +
                   $"Specialization : {Specialization}\n" +
                   $"Phone : {Phone}\n" +
                   $"Email : {Email}\n" +
                   $"Room ID : {(RoomId.HasValue ? RoomId.ToString() : "Not Assigned")}";
        }
    }
}