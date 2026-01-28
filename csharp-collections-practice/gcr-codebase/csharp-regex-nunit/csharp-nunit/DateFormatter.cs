using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTestingAssignment
{
    // BUSINESS LOGIC CLASS (Class Under Test)
    public class DateFormatter
    {
        // Converts date from yyyy-MM-dd to dd-MM-yyyy
        public string FormatDate(string inputDate)
        {
            if (string.IsNullOrWhiteSpace(inputDate))
                throw new ArgumentException("Date cannot be empty.");

            DateTime date;
            bool isValid = DateTime.TryParseExact(
                inputDate,
                "yyyy-MM-dd",
                null,
                System.Globalization.DateTimeStyles.None,
                out date
            );

            if (!isValid)
                throw new FormatException("Invalid date format.");

            return date.ToString("dd-MM-yyyy");
        }
    }

    // MSTEST TEST CLASS (Date Formatting)
    [TestClass]
    public class DateFormatterMSTest
    {
        private DateFormatter formatter;

        [TestInitialize]
        public void Setup()
        {
            formatter = new DateFormatter();
        }

        [TestMethod]
        public void FormatDate_ValidInput_ReturnsFormattedDate()
        {
            string result = formatter.FormatDate("2024-08-15");
            Assert.AreEqual("15-08-2024", result);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FormatDate_InvalidInput_ThrowsException()
        {
            formatter.FormatDate("15/08/2024");
        }
    }

    // NUNIT TEST CLASS (Date Formatting)
    [TestFixture]
    public class DateFormatterNUnitTest
    {
        private DateFormatter formatter;

        [SetUp]
        public void Setup()
        {
            formatter = new DateFormatter();
        }

        [Test]
        public void FormatDate_ValidInput_ReturnsFormattedDate()
        {
            string result = formatter.FormatDate("2023-01-01");
            NUnit.Framework.Assert.AreEqual("01-01-2023", result);
        }

        [Test]
        public void FormatDate_InvalidInput_ThrowsException()
        {
            NUnit.Framework.Assert.Throws<FormatException>(
                () => formatter.FormatDate("01-01-2023")
            );
        }
    }
}
