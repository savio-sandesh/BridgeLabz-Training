using System;

namespace BookShelf
{
    // Defines library bookshelf operations
    public interface IBookShelfManager
    {
        void AddBook();
        void RemoveBook();
        void DisplayBooksByGenre();
        void DisplayAllBooks();
    }
}
