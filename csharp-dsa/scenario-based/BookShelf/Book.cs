using System;

namespace BookShelf
{
    // Represents a book in the library
    public class Book
    {
        // Private fields for encapsulation
        private string title;
        private string author;
        private string genre;

        // Gets or sets the book title
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        // Gets or sets the author name
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        // Gets or sets the book genre
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
    }
}
