// This program demonstrates suppressing compiler warnings in C#.
// Warnings are disabled while using a non-generic collection and restored afterward.

using System;
using System.Collections;

namespace AttributesAssignment
{
    class Program
    {
        static void Main()
        {
#pragma warning disable 0618   // Suppress warning for using obsolete non-generic collections

            ArrayList list = new ArrayList();
            list.Add(10);
            list.Add("Hello");
            list.Add(3.14);

#pragma warning restore 0618    // Restore warning

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
