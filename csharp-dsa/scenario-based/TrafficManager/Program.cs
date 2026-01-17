// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;

namespace TrafficManager
{
    // Entry point of the Traffic Manager application
    class Program
    {
        static void Main(string[] args)
        {
            TrafficMain trafficMain = new TrafficMain();
            trafficMain.Start();
        }
    }
}
