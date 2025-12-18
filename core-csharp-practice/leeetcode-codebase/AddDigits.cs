public class Solution
{
    public int AddDigits(int num)
    {
        // Repeat until number becomes a single digit
        while (num >= 10)
        {
            int sum = 0;

            // Calculate sum of digits
            while (num > 0)
            {
                int last = num % 10;
                sum += last;
                num = num / 10;
            }

            // Assign sum back to num
            num = sum;
        }

        return num;
    }
}
