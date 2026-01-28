using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTestingAssignment
{
    // BUSINESS LOGIC CLASS (Class Under Test)
    public class PasswordValidator
    {
        // Password must be at least 8 characters long,
        // contain at least one uppercase letter and one digit
        public bool IsValid(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            bool hasUpperCase = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUpperCase = true;

                if (char.IsDigit(c))
                    hasDigit = true;
            }

            return password.Length >= 8 && hasUpperCase && hasDigit;
        }
    }

    // MSTEST TEST CLASS (Password Validation)
    [TestClass]
    public class PasswordValidatorMSTest
    {
        private PasswordValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new PasswordValidator();
        }

        [TestMethod]
        public void ValidPassword_ReturnsTrue()
        {
            bool result = validator.IsValid("StrongPass1");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PasswordWithoutUppercase_ReturnsFalse()
        {
            bool result = validator.IsValid("weakpass1");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PasswordWithoutDigit_ReturnsFalse()
        {
            bool result = validator.IsValid("WeakPass");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShortPassword_ReturnsFalse()
        {
            bool result = validator.IsValid("Wp1");
            Assert.IsFalse(result);
        }
    }

    // NUNIT TEST CLASS (Password Validation)
    [TestFixture]
    public class PasswordValidatorNUnitTest
    {
        private PasswordValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new PasswordValidator();
        }

        [Test]
        public void ValidPassword_ReturnsTrue()
        {
            bool result = validator.IsValid("Secure123");
            NUnit.Framework.Assert.IsTrue(result);
        }

        [Test]
        public void PasswordWithoutUppercase_ReturnsFalse()
        {
            bool result = validator.IsValid("secure123");
            NUnit.Framework.Assert.IsFalse(result);
        }

        [Test]
        public void PasswordWithoutDigit_ReturnsFalse()
        {
            bool result = validator.IsValid("SecurePass");
            NUnit.Framework.Assert.IsFalse(result);
        }

        [Test]
        public void EmptyPassword_ReturnsFalse()
        {
            bool result = validator.IsValid("");
            NUnit.Framework.Assert.IsFalse(result);
        }
    }
}
