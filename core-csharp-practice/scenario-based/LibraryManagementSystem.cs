using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BridgeLabzTraining.scenario_based
{
    // This program implements a simple Library Management System using arrays.
    // It stores book details such as title, author, and availability status in parallel arrays.
    // Each book is identified using a common array index.

    // The system allows:
    // Displaying all books with their current status
    // Searching for books using partial title matching
    // Updating the book status when a book is checked out or returned
    internal class LibraryManagementSystem
    {
        static void Main(string[] args)
        {
            // Book titles
            string[] bookTitles =
                { "The Alchemist",
                  "To Kill a Mockingbird",
                  "Truth Without Apology",
                  "Pride and Prejudice",
                  "The Catcher in the Rye",
                  "Dopamine Detox",
                  "The Brain",
                  "Sophies World",
                  "Thinking, Fast and Slow",
                  "Thinker Dies Doer Did"};

            // Corresponding Authors
            string[] bookAuthors =
            {   "Paulo Coelho",                 // The Alchemist
                "Harper Lee",                   // To Kill a Mockingbird
                "Acharya Prashant",             // Truth Without Apology
                "Jane Austen",                  // Pride and Prejudice
                "J. D. Salinger",               // The Catcher in the Rye
                "Thibaut Meurisse",             // Dopamine Detox
                "David Eagleman",               // The Brain
                "Jostein Gaarder",              // Sophie's World
                "Daniel Kahneman",              // Thinking, Fast and Slow
                "Sandesh Yadav"                 // Thinker Dies Doer Did

            };

            // Availability status: true = Available, false = Checked Out
            bool[] bookAvailability =
                { true, true, true, true, true, true, true, true, true, true };


            LibraryManagementSystem library = new LibraryManagementSystem();

            // Display all books
            library.DisplayBooks(bookTitles, bookAuthors, bookAvailability);

            // Search books by title
            Console.WriteLine("Enter book title to search:");
            string searchTerm = Console.ReadLine()!;
            bool bookFound = library.BookSearchByTitle(
                             bookTitles, bookAuthors, bookAvailability, searchTerm);


            // Checkout ONLY if a book was found
            if (bookFound)
            {
                Console.WriteLine("Enter book number to checkout:");
                int bookNumber = int.Parse(Console.ReadLine()!);
                library.CheckOutBook(bookAvailability, bookNumber);

                Console.WriteLine("\nUpdated Book List:");
                library.DisplayBooks(bookTitles, bookAuthors, bookAvailability);
            }
            else
            {
                Console.WriteLine("Checkout skipped because no matching book was found.");
            }
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

            // Display updated book list
            Console.WriteLine("\nUpdated Book List:");
            library.DisplayBooks(bookTitles, bookAuthors, bookAvailability);
      

        }

        // Displays all books with their details and availability status
        void DisplayBooks(string[] titles, string[] authors, bool[] availability)
        {
            for (int s = 0; s < titles.Length; s++)
            {
                Console.WriteLine("Book Number: " + (s + 1));
                Console.WriteLine("Title: " + titles[s]);
                Console.WriteLine("Author: " + authors[s]);
                Console.WriteLine("Availability: " + (availability[s] ? "Available" : "Checked Out"));
                Console.WriteLine("----------------------------");
            }

        }

        // Searches for books using partial title match (case-insensitive)
        bool BookSearchByTitle(string[] titles, string[] authors, bool[] availability, string searchTerm)
        {
            bool found = false;

            for (int y = 0; y < titles.Length; y++)
            {
                if (titles[y].ToLower().Contains(searchTerm.ToLower()))
                {
                    Console.WriteLine("Book Found:");
                    Console.WriteLine("Book Number: " + (y + 1));
                    Console.WriteLine("Title: " + titles[y]);
                    Console.WriteLine("Author: " + authors[y]);
                    Console.WriteLine("Status: " + (availability[y] ? "Available" : "Checked Out"));
                    Console.WriteLine("----------------------------");

                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No book found with the given title.");
            }

            return found;

        }

        // Checks out a book by updating its availability status
        void CheckOutBook(bool[] availability, int bookNumber)
        {

            // Validate book number
            if (bookNumber<=0 || bookNumber > availability.Length)
            {
                Console.WriteLine("Invalid Book Number");
                return;
            }

            int index = bookNumber - 1;

            if (availability[index])
            {
                availability[index] = false;
                Console.WriteLine("Book checked out successfully.");
            }
            else
            {
                Console.WriteLine("Book is already checked out.");
            }
        }
    }
}
