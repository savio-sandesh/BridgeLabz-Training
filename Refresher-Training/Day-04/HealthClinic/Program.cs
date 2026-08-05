using HealthClinic.Interface;
using HealthClinic.Menu;
using HealthClinic.Service;

namespace HealthClinic
{
    // Program class is the entry point of the console application.
    // It initializes services and starts the main navigation menu.
    public class Program
    {
        // Main method where application execution starts.
        static void Main(string[] args)
        {
            // Creating Appointment service object.
            // Contains appointment business logic.
            IAppointmentService appointmentService =
                new AppointmentService();


            // Passing Appointment service dependency to AppointmentMenu.
            AppointmentMenu appointmentMenu =
                new AppointmentMenu(appointmentService);



            // Creating Patient service object.
            // Contains patient business logic.
            IPatientService patientService =
                new PatientService();


            // Passing Patient service dependency to PatientMenu.
            PatientMenu patientMenu =
                new PatientMenu(patientService);



            // Creating MainMenu object.
            // MainMenu controls navigation between modules.
            MainMenu mainMenu =
                new MainMenu(
                    patientMenu,
                    appointmentMenu
                );


            // Starting application.
            mainMenu.ShowMenu();
        }
    }
}