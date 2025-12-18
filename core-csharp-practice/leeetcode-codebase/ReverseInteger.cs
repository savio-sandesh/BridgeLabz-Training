// Leetcode Problem Number 7

class ReverseInteger {
public:
    int reverse(int x) {
        int res = 0;

        while (x != 0) {
            int digit = x % 10;   // get last digit
            x /= 10;              // remove last digit

            // Check for overflow before multiplying by 10
            if (res > INT_MAX / 10 || res < INT_MIN / 10) {
                return 0;
            }

            // recreate reversed number
            res = res * 10 + digit;
        }

        return res;
    }
};
