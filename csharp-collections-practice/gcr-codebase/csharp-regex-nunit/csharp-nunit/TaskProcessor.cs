using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTestingAssignment
{
    // BUSINESS LOGIC CLASS (Class Under Test)
    public class TaskProcessor
    {
        // Simulates a long-running task
        public string LongRunningTask()
        {
            Thread.Sleep(3000); // Delays execution for 3 seconds
            return "Completed";
        }
    }

    // MSTEST TEST CLASS (Timeout Testing)
    [TestClass]
    public class TaskProcessorMSTest
    {
        private TaskProcessor processor;

        [TestInitialize]
        public void Setup()
        {
            processor = new TaskProcessor();
        }

        [TestMethod]
        [Timeout(2000)] // Test fails if execution exceeds 2 seconds
        public void LongRunningTask_ShouldCompleteWithinTimeLimit()
        {
            processor.LongRunningTask();
        }
    }

    // NUNIT TEST CLASS (Timeout Testing)
    [TestFixture]
    public class TaskProcessorNUnitTest
    {
        private TaskProcessor processor;

        [SetUp]
        public void Setup()
        {
            processor = new TaskProcessor();
        }

        [Test]
        [Timeout(2000)] // Test fails if execution exceeds 2 seconds
        public void LongRunningTask_ShouldCompleteWithinTimeLimit()
        {
            processor.LongRunningTask();
        }
    }
}
