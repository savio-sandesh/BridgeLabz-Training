using System;
using Utility;

namespace Menu
{
    public class AppointmentMenu
    {
        private readonly AppointmentService service =
            new AppointmentService();

        public void ViewOnly()
        {
            service.ViewAppointments();
            Console.ReadKey();
        }

        public void CompleteOnly()
        {
            service.CompleteAppointment();
            Console.ReadKey();
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("---- Appointment Menu ----");

                Console.WriteLine("1. Book Appointment");
                Console.WriteLine("2. Cancel Appointment");
                Console.WriteLine("3. Reschedule Appointment");
                Console.WriteLine("4. View Appointments");
                Console.WriteLine("5. Check Availability");
                Console.WriteLine("6. Complete Appointment");
                Console.WriteLine("7. Back");

                int ch = InputHelper.ReadInt("Choice: ");

                switch (ch)
                {
                    case 1:
                        service.BookAppointment();
                        break;

                    case 2:
                        service.CancelAppointment();
                        break;

                    case 3:
                        service.RescheduleAppointment();
                        break;

                    case 4:
                        service.ViewAppointments();
                        break;

                    case 5:
                        service.CheckAvailability();
                        break;

                    case 6:
                        service.CompleteAppointment();
                        break;

                    case 7:
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                Console.ReadKey();
            }
        }

    }
}
