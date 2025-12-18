using System;

class TwoSum
{
    static void Main()
    {
		// Declare and initialize an integer array
        int[] nums = { 2, 7, 11, 15 };
		
		// Target value to be found as sum of two numbers
        int target = 9;
		
		// Create object of TwoSum class to call non-static method
        TwoSum ts = new TwoSum();
		
		 // Call TwoSumMethod and store returned indices
        int[] result = ts.TwoSumMethod(nums, target);

        // Display the indices of the two numbers whose sum equals target
        Console.WriteLine(result[0] + ", " + result[1]);
    }

    public int[] TwoSumMethod(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
					// Return indices if condition is satisfied
                    return new int[] { i, j };
                }
            }
        }
		// Return empty array if no valid pair is found
        return new int[] { };
    }
}
