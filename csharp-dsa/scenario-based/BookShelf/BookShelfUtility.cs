using System;
using System.Collections.Generic;

namespace BookShelf
{
    // Handles library catalog operations
    public class BookShelfUtility : IBookShelfManager
    {
        // Genre-wise catalog (Genre -> List of Books)
        private Dictionary<string, LinkedList<Book>> catalog;

        // Tracks unique books to avoid duplication (optional)
        private HashSet<string> uniqueBooks;

        // Constructor initializes data structures
        public BookShelfUtility()
        {
            catalog = new Dictionary<string, LinkedList<Book>>();
            uniqueBooks = new HashSet<string>();
        }

        // Adds a book to the catalog
        public void AddBook()
        {
            Book book = new Book();

            Console.Write("Enter Book Title: ");
            book.Title = Console.ReadLine();

            Console.Write("Enter Author Name: ");
            book.Author = Console.ReadLine();

            Console.Write("Enter Genre: ");
            book.Genre = Console.ReadLine();

            string uniqueKey = book.Title + "-" + book.Author;

            if (uniqueBooks.Contains(uniqueKey))
            {
                Console.WriteLine("Duplicate book entry not allowed.\n");
                return;
            }

            if (!catalog.ContainsKey(book.Genre))
            {
                catalog[book.Genre] = new LinkedList<Book>();
            }

            catalog[book.Genre].AddLast(book);
            uniqueBooks.Add(uniqueKey);

            Console.WriteLine("Book added successfully.\n");
        }

        // Removes a book from the catalog
        public void RemoveBook()
        {
            Console.Write("Enter Genre: ");
            string genre = Console.ReadLine();

            if (!catalog.ContainsKey(genre))
            {
                Console.WriteLine("Genre not found.\n");
                return;
            }

            Console.Write("Enter Book Title to Remove: ");
            string title = Console.ReadLine();

            LinkedList<Book> books = catalog[genre];
            LinkedListNode<Book> current = books.First;

            while (current != null)
            {
                if (current.Value.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    string key = current.Value.Title + "-" + current.Value.Author;
                    uniqueBooks.Remove(key);
                    books.Remove(current);

                    Console.WriteLine("Book removed successfully.\n");
                    return;
                }
                current = current.Next;
            }

            Console.WriteLine("Book not found in this genre.\n");
        }

        // Displays books for a specific genre
        public void DisplayBooksByGenre()
        {
            Console.Write("Enter Genre: ");
            string genre = Console.ReadLine();

            if (!catalog.ContainsKey(genre) || catalog[genre].Count == 0)
            {
                Console.WriteLine("No books available for this genre.\n");
                return;
            }

            Console.WriteLine("Books in Genre: " + genre);
            foreach (Book book in catalog[genre])
            {
                Console.WriteLine("Title: " + book.Title + ", Author: " + book.Author);
            }
            Console.WriteLine();
        }

        // Displays all books grouped by genre
        public void DisplayAllBooks()
        {
            if (catalog.Count == 0)
            {
                Console.WriteLine("Library catalog is empty.\n");
                return;
            }

            foreach (var entry in catalog)
            {
                Console.WriteLine("Genre: " + entry.Key);
                foreach (Book book in entry.Value)
                {
                    Console.WriteLine("  Title: " + book.Title + ", Author: " + book.Author);
                }
                Console.WriteLine();
            }
        }
    }
}
