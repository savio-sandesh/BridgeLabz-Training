using System;
using Utility;
using Exceptions;

namespace Menu
{
    public class PatientMenu
    {
        private readonly PatientService service = new PatientService();

        public void Show()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("---- Patient Menu ----");

                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Update Patient");
                Console.WriteLine("3. Delete Patient");
                Console.WriteLine("4. Search Patient");
                Console.WriteLine("5. View All");
                Console.WriteLine("6. Back");

                int ch = InputHelper.ReadInt("Choice: ");

                try
                {
                    switch (ch)
                    {
                        case 1: service.AddPatient(); break;
                        case 2: service.UpdatePatient(); break;
                        case 3: service.DeletePatient(); break;
                        case 4: service.SearchPatient(); break;
                        case 5: service.ViewAllPatients(); break;
                        case 6: return;
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadKey();
            }
        }
    }
}
