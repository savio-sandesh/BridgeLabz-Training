using System;
using Utility;

namespace Menu
{
    public class BillingMenu
    {
        private readonly BillingService service =
            new BillingService();

        public void Show()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("---- Billing Menu ----");

                Console.WriteLine("1. Generate Bill");
                Console.WriteLine("2. Make Payment");
                Console.WriteLine("3. View Bill");
                Console.WriteLine("4. View Payments");
                Console.WriteLine("5. Back");

                int ch = InputHelper.ReadInt("Choice: ");

                switch (ch)
                {
                    case 1: service.GenerateBill(); break;
                    case 2: service.MakePayment(); break;
                    case 3: service.ViewBill(); break;
                    case 4: service.ViewPayments(); break;
                    case 5: return;
                }

                Console.ReadKey();
            }
        }
    }
}
