using System;
using System.Collections.Generic;

class NthFromEndProgram
{
    static void Main()
    {
        LinkedList<string> list = new LinkedList<string>();

        // Step 1: Read elements into LinkedList
        Console.Write("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            list.AddLast(Console.ReadLine());
        }

        int choice;

        // Step 2: Menu after input
        do
        {
            Console.WriteLine("\n1. Find Nth element from end");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter value of N: ");
                int N = Convert.ToInt32(Console.ReadLine());

                if (N <= 0)
                {
                    Console.WriteLine("N must be greater than zero.");
                    continue;
                }

                LinkedListNode<string> first = list.First;
                LinkedListNode<string> second = list.First;

                // Move first pointer N steps ahead
                for (int i = 0; i < N; i++)
                {
                    if (first == null)
                    {
                        Console.WriteLine("N is greater than the number of elements.");
                        goto EndOperation;
                    }
                    first = first.Next;
                }

                // Move both pointers until first reaches the end
                while (first != null)
                {
                    first = first.Next;
                    second = second.Next;
                }

                // second now points to the Nth element from the end
                Console.WriteLine("Nth element from the end is: " + second.Value);
            }
            else if (choice == 2)
            {
                Console.WriteLine("Exiting program...");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

        EndOperation:
            ;
        } while (choice != 2);
    }
}
