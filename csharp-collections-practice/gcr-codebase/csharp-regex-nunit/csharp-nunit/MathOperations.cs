using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTestingAssignment
{
    // BUSINESS LOGIC CLASS (Class Under Test)
    
    public class MathOperations
    {
        // Divides two integers
        // Throws ArithmeticException when divisor is zero
        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new ArithmeticException("Division by zero is not allowed.");

            return a / b;
        }
    }

   
    // MSTEST TEST CLASS
  
    [TestClass]
    public class MathOperationsMSTest
    {
        private MathOperations mathOperations;

        [TestInitialize]
        public void Setup()
        {
            mathOperations = new MathOperations();
        }

        [TestMethod]
        public void Divide_ReturnsCorrectResult()
        {
            int result = mathOperations.Divide(10, 2);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(5, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Divide_ByZero_ThrowsArithmeticException()
        {
            mathOperations.Divide(10, 0);
        }
    }

    // NUNIT TEST CLASS
    
    [TestFixture]
    public class MathOperationsNUnitTest
    {
        private MathOperations mathOperations;

        [SetUp]
        public void Setup()
        {
            mathOperations = new MathOperations();
        }

        [Test]
        public void Divide_ReturnsCorrectResult()
        {
            int result = mathOperations.Divide(20, 4);
            NUnit.Framework.Assert.AreEqual(5, result);
        }

        [Test]
        public void Divide_ByZero_ThrowsArithmeticException()
        {
            NUnit.Framework.Assert.Throws<ArithmeticException>(
                () => mathOperations.Divide(10, 0)
            );
        }
    }
}
