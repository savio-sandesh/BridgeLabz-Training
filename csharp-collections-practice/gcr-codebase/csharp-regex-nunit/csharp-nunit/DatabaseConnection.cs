using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTestingAssignment
{
    
    // BUSINESS LOGIC CLASS (Class Under Test)
    
    public class DatabaseConnection
    {
        public bool IsConnected { get; private set; }

        // Simulates opening a database connection
        public void Connect()
        {
            IsConnected = true;
        }

        // Simulates closing a database connection
        public void Disconnect()
        {
            IsConnected = false;
        }
    }

    
    // MSTEST TEST CLASS
   
    [TestClass]
    public class DatabaseConnectionMSTest
    {
        private DatabaseConnection database;

        [TestInitialize]
        public void Setup()
        {
            database = new DatabaseConnection();
            database.Connect();
        }

        [TestMethod]
        public void Connect_SetsConnectionStateToTrue()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(database.IsConnected);
        }

        [TestCleanup]
        public void Cleanup()
        {
            database.Disconnect();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(database.IsConnected);
        }
    }


    // NUNIT TEST CLASS
    
    [TestFixture]
    public class DatabaseConnectionNUnitTest
    {
        private DatabaseConnection database;

        [SetUp]
        public void Setup()
        {
            database = new DatabaseConnection();
            database.Connect();
        }

        [Test]
        public void Connect_SetsConnectionStateToTrue()
        {
            NUnit.Framework.Assert.IsTrue(database.IsConnected);
        }

        [TearDown]
        public void Cleanup()
        {
            database.Disconnect();
            NUnit.Framework.Assert.IsFalse(database.IsConnected);
        }
    }
}
