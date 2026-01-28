using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTestingAssignment
{
    // BUSINESS LOGIC CLASS (Class Under Test)
    public class UserRegistration
    {
        // Registers a user after validating inputs
        public void RegisterUser(string username, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is required.");

            if (!IsValidEmail(email))
                throw new ArgumentException("Invalid email address.");

            if (!IsValidPassword(password))
                throw new ArgumentException("Invalid password.");

            // Registration successful (no return needed for this assignment)
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
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

    // MSTEST TEST CLASS (User Registration)
    [TestClass]
    public class UserRegistrationMSTest
    {
        private UserRegistration registration;

        [TestInitialize]
        public void Setup()
        {
            registration = new UserRegistration();
        }

        [TestMethod]
        public void RegisterUser_ValidInputs_DoesNotThrowException()
        {
            registration.RegisterUser(
                "john_doe",
                "john@example.com",
                "Password1"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterUser_InvalidEmail_ThrowsException()
        {
            registration.RegisterUser(
                "john_doe",
                "invalid_email",
                "Password1"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterUser_WeakPassword_ThrowsException()
        {
            registration.RegisterUser(
                "john_doe",
                "john@example.com",
                "pass"
            );
        }
    }

    // NUNIT TEST CLASS (User Registration)
    [TestFixture]
    public class UserRegistrationNUnitTest
    {
        private UserRegistration registration;

        [SetUp]
        public void Setup()
        {
            registration = new UserRegistration();
        }

        [Test]
        public void RegisterUser_ValidInputs_DoesNotThrowException()
        {
            NUnit.Framework.Assert.DoesNotThrow(
                () => registration.RegisterUser(
                    "alice",
                    "alice@example.com",
                    "Secure123"
                )
            );
        }

        [Test]
        public void RegisterUser_InvalidEmail_ThrowsException()
        {
            NUnit.Framework.Assert.Throws<ArgumentException>(
                () => registration.RegisterUser(
                    "alice",
                    "aliceexample.com",
                    "Secure123"
                )
            );
        }

        [Test]
        public void RegisterUser_InvalidPassword_ThrowsException()
        {
            NUnit.Framework.Assert.Throws<ArgumentException>(
                () => registration.RegisterUser(
                    "alice",
                    "alice@example.com",
                    "password"
                )
            );
        }
    }
}
