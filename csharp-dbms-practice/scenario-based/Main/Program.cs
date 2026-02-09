// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


using System;
using Menu;


namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "Healthcare Management System";

                MainMenu menu = new MainMenu();
                menu.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Application crashed!");
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Thank you for using the system.");
            }
        }
    }
}

