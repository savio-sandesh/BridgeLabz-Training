using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTestingAssignment
{
    // BUSINESS LOGIC CLASS (Class Under Test)
    public class NumberUtils
    {
        // Returns true if the given number is even
        public bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }

    // MSTEST TEST CLASS (Parameterized using DataRow)
    [TestClass]
    public class NumberUtilsMSTest
    {
        private NumberUtils numberUtils;

        [TestInitialize]
        public void Setup()
        {
            numberUtils = new NumberUtils();
        }

        [TestMethod]
        [DataRow(2, true)]
        [DataRow(4, true)]
        [DataRow(6, true)]
        [DataRow(7, false)]
        [DataRow(9, false)]
        public void IsEven_ReturnsExpectedResult(int input, bool expected)
        {
            bool result = numberUtils.IsEven(input);
            Assert.AreEqual(expected, result);
        }
    }

    // NUNIT TEST CLASS (Parameterized using TestCase)
    [TestFixture]
    public class NumberUtilsNUnitTest
    {
        private NumberUtils numberUtils;

        [SetUp]
        public void Setup()
        {
            numberUtils = new NumberUtils();
        }

        [TestCase(2, true)]
        [TestCase(4, true)]
        [TestCase(6, true)]
        [TestCase(7, false)]
        [TestCase(9, false)]
        public void IsEven_ReturnsExpectedResult(int input, bool expected)
        {
            bool result = numberUtils.IsEven(input);
            NUnit.Framework.Assert.AreEqual(expected, result);
        }
    }
}
