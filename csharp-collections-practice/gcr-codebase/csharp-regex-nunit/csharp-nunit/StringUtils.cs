using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTestingAssignment
{
   
    // BUSINESS LOGIC CLASS (Class Under Test)
    
    public class StringUtils
    {
        // Returns the reverse of the given string
        public string Reverse(string input)
        {
            if (input == null)
                return null;

            char[] characters = input.ToCharArray();
            Array.Reverse(characters);
            return new string(characters);
        }

        // Checks whether the given string is a palindrome
        public bool IsPalindrome(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            string reversed = Reverse(input);
            return string.Equals(input, reversed, StringComparison.OrdinalIgnoreCase);
        }

        // Converts the string to uppercase
        public string ToUpperCase(string input)
        {
            if (input == null)
                return null;

            return input.ToUpper();
        }
    }

    
    // MSTEST TEST CLASS

    [TestClass]
    public class StringUtilsMSTest
    {
        private StringUtils stringUtils;

        [TestInitialize]
        public void Setup()
        {
            stringUtils = new StringUtils();
        }

        [TestMethod]
        public void Reverse_ReturnsReversedString()
        {
            string result = stringUtils.Reverse("hello");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("olleh", result);
        }

        [TestMethod]
        public void IsPalindrome_ReturnsTrue_ForPalindrome()
        {
            bool result = stringUtils.IsPalindrome("madam");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result);
        }

        [TestMethod]
        public void ToUpperCase_ConvertsStringToUppercase()
        {
            string result = stringUtils.ToUpperCase("hello");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("HELLO", result);
        }
    }

    
    // NUNIT TEST CLASS
   
    [TestFixture]
    public class StringUtilsNUnitTest
    {
        private StringUtils stringUtils;

        [SetUp]
        public void Setup()
        {
            stringUtils = new StringUtils();
        }

        [Test]
        public void Reverse_ReturnsReversedString()
        {
            string result = stringUtils.Reverse("world");
            NUnit.Framework.Assert.AreEqual("dlrow", result);
        }

        [Test]
        public void IsPalindrome_ReturnsFalse_ForNonPalindrome()
        {
            bool result = stringUtils.IsPalindrome("hello");
            NUnit.Framework.Assert.IsFalse(result);
        }

        [Test]
        public void ToUpperCase_ConvertsStringToUppercase()
        {
            string result = stringUtils.ToUpperCase("dotnet");
            NUnit.Framework.Assert.AreEqual("DOTNET", result);
        }
    }
}
