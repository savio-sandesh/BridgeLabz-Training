using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.csharp_string
{
    internal class StringComparison
    {
        static void Main(string[] args)
        {
            // asking user to enter the first string
            Console.WriteLine("Enter the first string: ");
            string strOne = Console.ReadLine()!;

            Console.WriteLine("Enter the second string: ");
            string strTwo = Console.ReadLine()!;

            int minLength = Math.Min(strOne.Length, strTwo.Length);
            bool areEqual = false;

            // loop through each character in both strings up to the length of the shorter string
            for (int i = 0; i < minLength; i++)
            {
                if (strOne[i] < strTwo[i])
                {
                    Console.WriteLine($"\"{strOne}\" comes before \"{strTwo}\" in lexicographical order");
                    areEqual = true;
                    break;
                }
                else if (strOne[i] > strTwo[i])
                {
                    Console.WriteLine($"\"{strTwo}\" comes before \"{strOne}\" in lexicographical order");
                    areEqual = true;
                    break;
                }
            }

            // if all characters compared same, check lengths
            if (!areEqual)
            {
                if (strOne.Length < strTwo.Length)
                {
                    Console.WriteLine($"\"{strOne}\" comes before \"{strTwo}\" in lexicographical order");
                }
                else if (strOne.Length > strTwo.Length)
                {
                    Console.WriteLine($"\"{strTwo}\" comes before \"{strOne}\" in lexicographical order");
                }
                else
                {
                    Console.WriteLine("Both strings are equal.");
                }
            }
            // 'A' to 'Z'  → ASCII 65–90
            // 'a' to 'z'  → ASCII 97–122
            // Sandesh vs sandesh → Sandesh comes before sandesh
        }
    }
}
