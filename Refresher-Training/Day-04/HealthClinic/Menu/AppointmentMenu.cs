using System;
using System.Collections.Generic;
using HealthClinic.Entity;
using HealthClinic.Interface;

namespace HealthClinic.Menu
{
    // AppointmentMenu represents the Presentation Layer.
    // It interacts with the user and delegates operations to the Service layer.
    public class AppointmentMenu
    {
        // Reference to the Appointment Service through the interface.
        private readonly IAppointmentService appointmentService;

        // Constructor Injection
        public AppointmentMenu(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        // Displays all appointment related options.
        public void ShowMenu()
        {
            int choice;

            do
            {
                Console.Clear();

                Console.WriteLine("===================================");
                Console.WriteLine("      APPOINTMENT MANAGEMENT");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Book Appointment");
                Console.WriteLine("2. View All Appointments");
                Console.WriteLine("3. Search Appointment By ID");
                Console.WriteLine("4. View Patient Appointments");
                Console.WriteLine("5. Update Appointment Status");
                Console.WriteLine("6. Cancel Appointment");
                Console.WriteLine("0. Back");
                Console.WriteLine("===================================");

                Console.Write("Enter your choice : ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        // Create Appointment object from user input.
                        Appointment appointment = new Appointment();

                        Console.Write("Enter Patient ID : ");
                        appointment.PatientId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Doctor ID : ");
                        appointment.DoctorId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Appointment Date (yyyy-mm-dd) : ");
                        appointment.AppointmentDate = Convert.ToDateTime(Console.ReadLine());

                        Console.Write("Enter Appointment Time (HH:mm) : ");
                        appointment.AppointmentTime = TimeSpan.Parse(Console.ReadLine());

                        Console.Write("Enter Reason : ");
                        appointment.Reason = Console.ReadLine();

                        // Default status while booking.
                        appointment.Status = "Scheduled";

                        appointmentService.BookAppointment(appointment);

                        break;

                    case 2:

                        List<Appointment> appointments=
                            appointmentService.ViewAllAppointments();

                        foreach (Appointment item in appointments)
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine($"Appointment ID : {item.AppointmentId}");
                            Console.WriteLine($"Patient ID     : {item.PatientId}");
                            Console.WriteLine($"Doctor ID      : {item.DoctorId}");
                            Console.WriteLine($"Date           : {item.AppointmentDate:d}");
                            Console.WriteLine($"Time           : {item.AppointmentTime}");
                            Console.WriteLine($"Reason         : {item.Reason}");
                            Console.WriteLine($"Status         : {item.Status}");
                        }

                        break;

                    case 3:

                        Console.Write("Enter Appointment ID : ");
                        int appointmentId = Convert.ToInt32(Console.ReadLine());

                        Appointment result =
                            appointmentService.GetAppointmentById(appointmentId);

                        if (result != null)
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine($"Appointment ID : {result.AppointmentId}");
                            Console.WriteLine($"Patient ID     : {result.PatientId}");
                            Console.WriteLine($"Doctor ID      : {result.DoctorId}");
                            Console.WriteLine($"Date           : {result.AppointmentDate:d}");
                            Console.WriteLine($"Time           : {result.AppointmentTime}");
                            Console.WriteLine($"Reason         : {result.Reason}");
                            Console.WriteLine($"Status         : {result.Status}");
                        }
                        else
                        {
                            Console.WriteLine("Appointment not found.");
                        }

                        break;

                    case 4:

                        Console.Write("Enter Patient ID : ");
                        int patientId = Convert.ToInt32(Console.ReadLine());

                        List<Appointment> patientAppointments =
                            appointmentService.GetPatientAppointments(patientId);

                        foreach (Appointment item in patientAppointments)
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine($"Appointment ID : {item.AppointmentId}");
                            Console.WriteLine($"Date           : {item.AppointmentDate:d}");
                            Console.WriteLine($"Time           : {item.AppointmentTime}");
                            Console.WriteLine($"Status         : {item.Status}");
                        }

                        break;

                    case 5:

                        Console.Write("Enter Appointment ID : ");
                        int updateAppointmentId =
                            Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter New Status : ");
                        string status = Console.ReadLine();

                        appointmentService.UpdateAppointmentStatus(
                            updateAppointmentId,
                            status);

                        break;

                    case 6:

                        Console.Write("Enter Appointment ID : ");
                        int cancelAppointmentId =
                            Convert.ToInt32(Console.ReadLine());

                        appointmentService.CancelAppointment(cancelAppointmentId);

                        break;

                    case 0:

                        Console.WriteLine("Returning to Main Menu...");
                        break;

                    default:

                        Console.WriteLine("Invalid Choice.");
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