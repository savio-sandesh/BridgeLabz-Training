using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_array.level_2
{
    internal class ZaraEmployeeBonus
    {
        static void Main(string[] args)
        {
            int employeeCount = 10;

            double[] salary = new double[employeeCount];
            double[] bonus = new double[employeeCount];
            double[] workingYears = new double[employeeCount];
            double[] newSalary = new double[employeeCount];

            double totalOldSalary = 0;
            double totalNewSalary = 0;
            double totalBonus = 0;

            // Input salaries and working years
            for (int i = 0; i < employeeCount; i++)
            {
                Console.WriteLine($"Enter salary for employee {i + 1}: ");
                salary[i] = double.Parse(Console.ReadLine());
                Console.WriteLine($"Enter working years for employee {i + 1}: ");
                workingYears[i] = double.Parse(Console.ReadLine());
            }

            // bonus calculation
            for (int j = 0; j < employeeCount; j++)
                {
                if (workingYears[j] > 5)
                {
                    bonus[j] = salary[j] * 0.05;
                }
                else
                {
                    bonus[j] = salary[j] * 0.02;
                }

                newSalary[j] = salary[j] + bonus[j];

                totalOldSalary += salary[j];
                totalNewSalary += newSalary[j];
                totalBonus += bonus[j];
            }

            // Display results
            Console.WriteLine("Total Bonus: "+totalBonus);
            Console.WriteLine("Total Old Salary: "+totalOldSalary);
            Console.WriteLine("Total New Salary: "+totalNewSalary);
        }
    }
}
