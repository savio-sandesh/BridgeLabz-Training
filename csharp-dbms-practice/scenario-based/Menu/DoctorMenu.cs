using System;
using Utility;

namespace Menu
{
    public class DoctorMenu
    {
        private readonly DoctorService service = new DoctorService();

        public void Show()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("---- Doctor Menu ----");

                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Update Doctor");
                Console.WriteLine("3. Delete Doctor");
                Console.WriteLine("4. Search Doctor");
                Console.WriteLine("5. View All");
                Console.WriteLine("6. Back");

                Console.Write("Enter your choice: ");
                int ch = int.Parse(Console.ReadLine());

                try
                {
                    switch (ch)
                    {
                        case 1: service.AddDoctor(); break;
                        case 2: service.UpdateDoctor(); break;
                        case 3: service.DeleteDoctor(); break;
                        case 4: service.SearchDoctor(); break;
                        case 5: service.ViewAllDoctors(); break;
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
