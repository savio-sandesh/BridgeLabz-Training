// Ternary Operator

// The ternary operator is a shorthand for an if-else statement.
// Syntax: condition ? expression1 : expression2

using System;

class TernaryOperator {
static void Main(string[] args) {
int a = 30;
int b = 90;
int max = (a > b) ? a : b;

Console.WriteLine("Max: " + max); // 90

}
}