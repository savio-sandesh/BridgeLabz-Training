// This program demonstrates the use of the Obsolete attribute in C#.
// An old method is marked obsolete to warn developers to use a new method instead.

using System;

namespace AttributesAssignment
{
    public class LegacyAPI
    {
        [Obsolete("OldFeature is obsolete. Use NewFeature instead.")]
        public void OldFeature()
        {
            Console.WriteLine("Executing old feature");
        }

        public void NewFeature()
        {
            Console.WriteLine("Executing new feature");
        }
    }

    class Program
    {
        static void Main()
        {
            LegacyAPI api = new LegacyAPI();

            api.OldFeature();   // Generates a compiler warning
            api.NewFeature();   // Recommended method
        }
    }
}
