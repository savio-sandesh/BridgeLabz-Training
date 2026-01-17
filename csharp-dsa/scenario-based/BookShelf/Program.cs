// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// 

using System;

namespace BookShelf
{
    // Entry point of the BookShelf application
    class Program
    {
        static void Main(string[] args)
        {
            BookShelfMain bookShelfMain = new BookShelfMain();
            bookShelfMain.Start();
        }
    }
}
