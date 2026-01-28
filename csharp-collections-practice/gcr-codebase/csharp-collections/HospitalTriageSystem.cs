using System;
using System.Collections.Generic;

class HospitalTriageSystem
{
    static void Main()
    {
        // PriorityQueue stores patient name with severity as priority
        PriorityQueue<string, int> patients = new PriorityQueue<string, int>();

        // Step 1: Input patient details
        Console.Write("Enter number of patients: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter patient name: ");
            string name = Console.ReadLine();

            Console.Write("Enter severity (higher number = more severe): ");
            int severity = Convert.ToInt32(Console.ReadLine());

            // Negative severity is used to treat higher values as higher priority
            patients.Enqueue(name, -severity);
        }

        int choice;

        // Step 2: Menu
        do
        {
            Console.WriteLine("\n1. Treat next patient");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                if (patients.Count > 0)
                {
                    string nextPatient = patients.Dequeue();
                    Console.WriteLine("Treating patient: " + nextPatient);
                }
                else
                {
                    Console.WriteLine("No patients left to treat.");
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine("Exiting program...");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

        } while (choice != 2);
    }
}
