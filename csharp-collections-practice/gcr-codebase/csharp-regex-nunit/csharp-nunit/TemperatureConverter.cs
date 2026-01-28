using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTestingAssignment
{
    // BUSINESS LOGIC CLASS (Class Under Test)
    public class TemperatureConverter
    {
        // Converts Celsius to Fahrenheit
        public double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        // Converts Fahrenheit to Celsius
        public double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }

    // MSTEST TEST CLASS (Temperature Conversion)
    [TestClass]
    public class TemperatureConverterMSTest
    {
        private TemperatureConverter converter;

        [TestInitialize]
        public void Setup()
        {
            converter = new TemperatureConverter();
        }

        [TestMethod]
        public void CelsiusToFahrenheit_ReturnsCorrectValue()
        {
            double result = converter.CelsiusToFahrenheit(0);
            Assert.AreEqual(32, result);
        }

        [TestMethod]
        public void FahrenheitToCelsius_ReturnsCorrectValue()
        {
            double result = converter.FahrenheitToCelsius(212);
            Assert.AreEqual(100, result);
        }
    }

    // NUNIT TEST CLASS (Temperature Conversion)
    [TestFixture]
    public class TemperatureConverterNUnitTest
    {
        private TemperatureConverter converter;

        [SetUp]
        public void Setup()
        {
            converter = new TemperatureConverter();
        }

        [Test]
        public void CelsiusToFahrenheit_ReturnsCorrectValue()
        {
            double result = converter.CelsiusToFahrenheit(100);
            NUnit.Framework.Assert.AreEqual(212, result);
        }

        [Test]
        public void FahrenheitToCelsius_ReturnsCorrectValue()
        {
            double result = converter.FahrenheitToCelsius(32);
            NUnit.Framework.Assert.AreEqual(0, result);
        }
    }
}
