using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.scenario_based
{
    // Scenario:
    // A freelancer enters multiple work items and their prices in a single string
    // (e.g., "Logo Design - 3000 INR, Web Page - 4500 INR").
    // The program processes this string and calculates the total invoice amount.

    /*
    Flow:
    Input String
        ↓
    Split by ',' → Individual Tasks
        ↓
    For each Task:
        Split by '-' → Extract Amount
        Remove 'INR' → Convert to Integer
        Add to Total
        ↓
    Display Total Invoice Amount
    */


    internal class InvoiceGenerator
    {
        internal static string[] ParseInvoice(string invoice)
        {
            // handle empty or null invoice string
            if (string.IsNullOrWhiteSpace(invoice))
            {
                return new string[0];
            }

            // split the invoice string by commas
            string[] rawTasks= invoice.Split(',');

            // trim each task and return the array
            for(int p=0; p<rawTasks.Length; p++)
            {
                rawTasks[p] = rawTasks[p].Trim();
            }

            return rawTasks;
        }

        internal static int GetTotalAmount(string[] tasks)
        {
            if(tasks==null || tasks.Length==0)  
            {
                return 0;
            }

            int totalAmount = 0;

            foreach (string task in tasks)
            {
                if(string.IsNullOrWhiteSpace(task))
                {
                    continue;
                }

                // splitting task into description and amount
                string[] parts = task.Split(':');

                if(parts.Length != 2)
                {
                    continue; // skip invalid format
                }

                // extract amount part and parse to integer

                string amountPart = parts[1].Replace("INR", "").Trim();

                if(int.TryParse(amountPart, out int amount))
                {
                    totalAmount += amount;
                }
            }

            return totalAmount;
        }
        
        static void Main(string[] args)
        {
            // sample invoice input 
            string invoiceInput = "Design: INR 5000, Development: INR 15000, Testing: INR 7000";

            Console.WriteLine("Invoice Input: " + invoiceInput);

            // parsing invoice to get individual tasks
            string[] tasks = ParseInvoice(invoiceInput);

            Console.WriteLine("Parsed Tasks:");
            foreach (string task in tasks)
            {
                Console.WriteLine(task);
            }

            // calculating total amount from tasks
            int totalAmount = GetTotalAmount(tasks);


            Console.WriteLine("Total Invoice Amount:");
            Console.WriteLine("Amount: INR " + totalAmount);
           
        }
    }
}
