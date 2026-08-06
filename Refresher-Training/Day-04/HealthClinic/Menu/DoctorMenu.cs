using System;
using System.Collections.Generic;
using HealthClinic.Entity;
using HealthClinic.Interface;

namespace HealthClinic.Menu
{
    // DoctorMenu represents the user interface for doctor management.
    public class DoctorMenu
    {
        // Reference to doctor service.
        private readonly IDoctorService doctorService;

        // Constructor Injection.
        public DoctorMenu(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        // Displays doctor management menu.
        public void ShowMenu()
        {
            int choice;

            do
            {
                Console.Clear();

                Console.WriteLine("===================================");
                Console.WriteLine("        DOCTOR MANAGEMENT");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. View All Doctors");
                Console.WriteLine("3. Search Doctor By ID");
                Console.WriteLine("4. Update Doctor");
                Console.WriteLine("5. Delete Doctor");
                Console.WriteLine("0. Back");
                Console.WriteLine("===================================");

                Console.Write("Enter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Doctor doctor = new Doctor();

                        Console.Write("Enter First Name : ");
                        doctor.FirstName = Console.ReadLine();

                        Console.Write("Enter Last Name : ");
                        doctor.LastName = Console.ReadLine();

                        Console.Write("Enter Specialization : ");
                        doctor.Specialization = Console.ReadLine();

                        Console.Write("Enter Phone : ");
                        doctor.Phone = Console.ReadLine();

                        Console.Write("Enter Email : ");
                        doctor.Email = Console.ReadLine();

                        Console.Write("Enter Room ID (Leave blank if none) : ");
                        string room = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(room))
                            doctor.RoomId = Convert.ToInt32(room);

                        doctorService.AddDoctor(doctor);

                        break;


                    case 2:

                        List<Doctor> doctors = doctorService.GetAllDoctors();

                        foreach (Doctor item in doctors)
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine(item);
                        }

                        break;


                    case 3:

                        Console.Write("Enter Doctor ID : ");
                        int doctorId = Convert.ToInt32(Console.ReadLine());

                        Doctor result = doctorService.GetDoctorById(doctorId);

                        if (result != null)
                            Console.WriteLine(result);
                        else
                            Console.WriteLine("Doctor not found.");

                        break;


                    case 4:

                        Doctor updateDoctor = new Doctor();

                        Console.Write("Enter Doctor ID : ");
                        updateDoctor.DoctorId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter First Name : ");
                        updateDoctor.FirstName = Console.ReadLine();

                        Console.Write("Enter Last Name : ");
                        updateDoctor.LastName = Console.ReadLine();

                        Console.Write("Enter Specialization : ");
                        updateDoctor.Specialization = Console.ReadLine();

                        Console.Write("Enter Phone : ");
                        updateDoctor.Phone = Console.ReadLine();

                        Console.Write("Enter Email : ");
                        updateDoctor.Email = Console.ReadLine();

                        Console.Write("Enter Room ID (Leave blank if none) : ");
                        room = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(room))
                            updateDoctor.RoomId = Convert.ToInt32(room);

                        doctorService.UpdateDoctor(updateDoctor);

                        break;


                    case 5:

                        Console.Write("Enter Doctor ID : ");
                        doctorId = Convert.ToInt32(Console.ReadLine());

                        doctorService.DeleteDoctor(doctorId);

                        break;


                    case 0:

                        Console.WriteLine("Returning to Main Menu...");
                        break;


                    default:

                        Console.WriteLine("Invalid choice.");
                        break;
                }

                if (choice != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

            } while (choice != 0);
        }
    }
}