using System;

namespace BookShelf
{
    // Controls application flow and coordination
    public class BookShelfMain
    {
        private IBookShelfManager bookShelfManager;
        private BookShelfMenu bookShelfMenu;

        // Constructor initializes required components
        public BookShelfMain()
        {
            bookShelfManager = new BookShelfUtility();
            bookShelfMenu = new BookShelfMenu();
        }

        // Starts the bookshelf application
        public void Start()
        {
            int choice;

            do
            {
                choice = bookShelfMenu.ShowMenu();

                switch (choice)
                {
                    case 1:
                        bookShelfManager.AddBook();
                        break;

                    case 2:
                        bookShelfManager.RemoveBook();
                        break;

                    case 3:
                        bookShelfManager.DisplayBooksByGenre();
                        break;

                    case 4:
                        bookShelfManager.DisplayAllBooks();
                        break;

                    case 5:
                        Console.WriteLine("Exiting BookShelf...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        break;
                }

            } while (choice != 5);
        }
    }
}
