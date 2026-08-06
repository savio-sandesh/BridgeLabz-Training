using System;

namespace HealthClinic.Menu
{
    // MainMenu acts as the navigation menu of the application.
    // It allows the user to choose different modules.
    public class MainMenu
    {
        // Reference to Patient menu.
        private readonly PatientMenu patientMenu;

        // Reference to Appointment menu.
        private readonly AppointmentMenu appointmentMenu;

        private readonly DoctorMenu doctorMenu;

        // Constructor injection.
        // MainMenu receives required module menus.
        public MainMenu(
            PatientMenu patientMenu,
            AppointmentMenu appointmentMenu, DoctorMenu doctorMenu)
        {
            this.patientMenu = patientMenu;
            this.appointmentMenu = appointmentMenu;
            this.doctorMenu = doctorMenu;
        }


        // Displays application main menu.
        public void ShowMenu()
        {
            int choice;

            do
            {
                Console.Clear();

                Console.WriteLine("===================================");
                Console.WriteLine("        HEALTH CLINIC SYSTEM");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Patient Management");
                Console.WriteLine("2. Appointment Management");
                Console.WriteLine("3. Doctor Management");
                Console.WriteLine("0. Exit");
                Console.WriteLine("===================================");

                Console.Write("Enter your choice : ");

                choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:

                        patientMenu.ShowMenu();

                        break;


                    case 2:

                        appointmentMenu.ShowMenu();

                        break;

                    case 3:
                        doctorMenu.ShowMenu();
                        break;

                    case 0:

                        Console.WriteLine("Exiting application...");
                        break;


                    default:

                        Console.WriteLine("Invalid choice.");

                        break;
                }


            } while (choice != 0);
        }
    }
}