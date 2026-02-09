using System;
using Utility;

namespace Menu
{
    public class MainMenu
    {
        public void Show()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("=================================");
                Console.WriteLine("   HEALTHCARE MANAGEMENT SYSTEM");
                Console.WriteLine("=================================");

                Console.WriteLine("Select Role:");
                Console.WriteLine("1. Receptionist");
                Console.WriteLine("2. Doctor");
                Console.WriteLine("3. Administrator");
                Console.WriteLine("4. Exit");

                int role = InputHelper.ReadInt("Choice: ");

                switch (role)
                {
                    case 1:
                        ShowUserMenu();      // Receptionist
                        break;

                    case 2:
                        ShowDoctorMenu();    // Doctor
                        break;


                    case 3:
                        ShowAdminMenu();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowUserMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("----- Main Menu -----");

                Console.WriteLine("1. Patient");
                Console.WriteLine("2. Doctor");
                Console.WriteLine("3. Appointment");
                Console.WriteLine("4. Billing");
                Console.WriteLine("5. Back");

                int ch = InputHelper.ReadInt("Choice: ");

                switch (ch)
                {
                    case 1: new PatientMenu().Show(); break;
                    case 2: new DoctorMenu().Show(); break;
                    case 3: new AppointmentMenu().Show(); break;
                    case 4: new BillingMenu().Show(); break;
                    case 5: return;
                }
            }
        }

        private void ShowDoctorMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("----- Doctor Menu -----");

                Console.WriteLine("1. View Appointments");
                Console.WriteLine("2. Complete Appointment");
                Console.WriteLine("3. Back");

                int ch = InputHelper.ReadInt("Choice: ");

                switch (ch)
                {
                    case 1:
                        new AppointmentMenu().ViewOnly();
                        break;

                    case 2:
                        new AppointmentMenu().CompleteOnly();
                        break;

                    case 3:
                        return;
                }
            }
        }


        private void ShowAdminMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("----- Admin Menu -----");

                Console.WriteLine("1. Reports");
                Console.WriteLine("2. Back");

                int ch = InputHelper.ReadInt("Choice: ");

                switch (ch)
                {
                    case 1: new ReportMenu().Show(); break;
                    case 2: return;
                }
            }
        }
    }
}
