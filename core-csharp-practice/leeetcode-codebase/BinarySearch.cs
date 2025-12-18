using System;

class BinarySearch
{
    static void Main()
    {
        // Sorted array (binary search works only on sorted arrays)
        int[] nums = { 24, 29, 64, 67, 78, 98 };
        int target = 29;

        int s = 0;
        int e = nums.Length - 1;
        int result = -1;

        // Binary Search logic
        while (s <= e)
        {
            int m = s + (e - s) / 2;

            if (nums[m] == target)
            {
                result = m;
                break;
            }
            else if (target > nums[m])
            {
                s = m + 1;
            }
            else
            {
                e = m - 1;
            }
        }

        // Print result (INSIDE Main)
        if (result != -1)
        {
            Console.WriteLine("Element found at index: " + result);
        }
        else
        {
            Console.WriteLine("Element not found");
        }
    }
}
