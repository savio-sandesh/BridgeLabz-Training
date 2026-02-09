using System;
using Utility;

namespace Menu
{
    public class ReportMenu
    {
        private readonly ReportService service =
            new ReportService();

        public void Show()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("---- Reports ----");

                Console.WriteLine("1. Total Revenue");
                Console.WriteLine("2. Doctor Revenue");
                Console.WriteLine("3. Pending Bills");
                Console.WriteLine("4. Daily Appointments");
                Console.WriteLine("5. Audit Logs");
                Console.WriteLine("6. Back");

                int ch = InputHelper.ReadInt("Choice: ");

                switch (ch)
                {
                    case 1: service.ShowTotalRevenue(); break;
                    case 2: service.ShowDoctorRevenue(); break;
                    case 3: service.ShowPendingBills(); break;
                    case 4: service.ShowDailyAppointments(); break;
                    case 5: service.ShowAuditLogs(); break;
                    case 6: return;
                }

                Console.ReadKey();
            }
        }
    }
}
