using System;

// MSTest namespace
using Microsoft.VisualStudio.TestTools.UnitTesting;

// NUnit namespace
using NUnit.Framework;

namespace UnitTestingAssignment
{
    
    // BUSINESS LOGIC CLASS (Class Under Test)
   
    public class Calculator
    {
        // Adds two integers and returns the result
        public int Add(int a, int b)
        {
            return a + b;
        }

        // Subtracts second integer from first
        public int Subtract(int a, int b)
        {
            return a - b;
        }

        // Multiplies two integers
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        // Divides first integer by second
        // Throws exception when divisor is zero
        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new ArithmeticException("Division by zero is not allowed.");
            }
            return a / b;
        }
    }

    
    // MSTEST TEST CLASS
    
    [TestClass]
    public class CalculatorMSTest
    {
        private Calculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void Add_ReturnsCorrectSum()
        {
            int result = calculator.Add(10, 5);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void Subtract_ReturnsCorrectDifference()
        {
            int result = calculator.Subtract(10, 5);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Multiply_ReturnsCorrectProduct()
        {
            int result = calculator.Multiply(4, 5);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(20, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Divide_ByZero_ThrowsException()
        {
            calculator.Divide(10, 0);
        }
    }

   
    // NUNIT TEST CLASS
    
    [TestFixture]
    public class CalculatorNUnitTest
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_ReturnsCorrectSum()
        {
            int result = calculator.Add(20, 10);
            NUnit.Framework.Assert.AreEqual(30, result);
        }

        [Test]
        public void Subtract_ReturnsCorrectDifference()
        {
            int result = calculator.Subtract(20, 5);
            NUnit.Framework.Assert.AreEqual(15, result);
        }

        [Test]
        public void Multiply_ReturnsCorrectProduct()
        {
            int result = calculator.Multiply(3, 6);
            NUnit.Framework.Assert.AreEqual(18, result);
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            NUnit.Framework.Assert.Throws<ArithmeticException>(
                () => calculator.Divide(10, 0)
            );
        }
    }
}
