using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTestingAssignment
{
    // BUSINESS LOGIC CLASS (Class Under Test)
    public class FileProcessor
    {
        // Writes content to a file
        public void WriteToFile(string filename, string content)
        {
            File.WriteAllText(filename, content);
        }

        // Reads content from a file
        public string ReadFromFile(string filename)
        {
            if (!File.Exists(filename))
                throw new IOException("File does not exist.");

            return File.ReadAllText(filename);
        }
    }

    // MSTEST TEST CLASS (File Handling)
    [TestClass]
    public class FileProcessorMSTest
    {
        private FileProcessor fileProcessor;
        private string testFile;

        [TestInitialize]
        public void Setup()
        {
            fileProcessor = new FileProcessor();
            testFile = "test_mstest.txt";
        }

        [TestMethod]
        public void WriteAndRead_File_ContentMatches()
        {
            fileProcessor.WriteToFile(testFile, "Hello MSTest");
            string content = fileProcessor.ReadFromFile(testFile);
            Assert.AreEqual("Hello MSTest", content);
        }

        [TestMethod]
        public void File_Exists_After_Writing()
        {
            fileProcessor.WriteToFile(testFile, "Test File");
            Assert.IsTrue(File.Exists(testFile));
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void Read_NonExisting_File_ThrowsException()
        {
            fileProcessor.ReadFromFile("non_existing_file.txt");
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(testFile))
                File.Delete(testFile);
        }
    }

    // NUNIT TEST CLASS (File Handling)
    [TestFixture]
    public class FileProcessorNUnitTest
    {
        private FileProcessor fileProcessor;
        private string testFile;

        [SetUp]
        public void Setup()
        {
            fileProcessor = new FileProcessor();
            testFile = "test_nunit.txt";
        }

        [Test]
        public void WriteAndRead_File_ContentMatches()
        {
            fileProcessor.WriteToFile(testFile, "Hello NUnit");
            string content = fileProcessor.ReadFromFile(testFile);
            NUnit.Framework.Assert.AreEqual("Hello NUnit", content);
        }

        [Test]
        public void File_Exists_After_Writing()
        {
            fileProcessor.WriteToFile(testFile, "Test File");
            NUnit.Framework.Assert.IsTrue(File.Exists(testFile));
        }

        [Test]
        public void Read_NonExisting_File_ThrowsException()
        {
            NUnit.Framework.Assert.Throws<IOException>(
                () => fileProcessor.ReadFromFile("non_existing_file.txt")
            );
        }

        [TearDown]
        public void Cleanup()
        {
            if (File.Exists(testFile))
                File.Delete(testFile);
        }
    }
}
