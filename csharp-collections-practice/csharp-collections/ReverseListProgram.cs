using System;
using System.Collections.Generic;

class ReverseListProgram
{
    static void Main()
    {
        int choice;

        // do-while loop is used to keep showing the menu
        // until the user chooses to exit
        do
        {
            Console.WriteLine("\n--- Reverse List Menu ---");
            Console.WriteLine("1. Reverse using List");
            Console.WriteLine("2. Reverse using LinkedList");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            // Read user choice
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ReverseUsingList();
                    break;

                case 2:
                    ReverseUsingLinkedList();
                    break;

                case 3:
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        } while (choice != 3);
    }

    // Method to reverse elements using List
    static void ReverseUsingList()
    {
        List<int> list = new List<int>();

        Console.Write("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        // Taking input from the user
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            list.Add(Convert.ToInt32(Console.ReadLine()));
        }

        // Two-pointer approach to reverse the list
        int start = 0;
        int end = list.Count - 1;

        // Swap elements until pointers meet
        while (start < end)
        {
            int temp = list[start];
            list[start] = list[end];
            list[end] = temp;

            start++;
            end--;
        }

        Console.WriteLine("Reversed List:");
        foreach (int item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    // Method to reverse elements using LinkedList
    static void ReverseUsingLinkedList()
    {
        LinkedList<int> list = new LinkedList<int>();

        Console.Write("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        // Taking input from the user
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            list.AddLast(Convert.ToInt32(Console.ReadLine()));
        }

        // New LinkedList to store reversed elements
        LinkedList<int> reversedList = new LinkedList<int>();

        // Traversing original list and adding elements at the beginning
        // This automatically reverses the order
        foreach (int item in list)
        {
            reversedList.AddFirst(item);
        }

        Console.WriteLine("Reversed LinkedList:");
        foreach (int item in reversedList)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
