using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTestingAssignment
{
    
    // BUSINESS LOGIC CLASS (Class Under Test)
   
    public class ListManager
    {
        // Adds an element to the list
        public void AddElement(List<int> list, int element)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            list.Add(element);
        }

        // Removes an element from the list
        public void RemoveElement(List<int> list, int element)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            list.Remove(element);
        }

        // Returns the size of the list
        public int GetSize(List<int> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            return list.Count;
        }
    }

   
    // MSTEST TEST CLASS
    
    [TestClass]
    public class ListManagerMSTest
    {
        private ListManager listManager;
        private List<int> numbers;

        [TestInitialize]
        public void Setup()
        {
            listManager = new ListManager();
            numbers = new List<int>();
        }

        [TestMethod]
        public void AddElement_AddsItemToList()
        {
            listManager.AddElement(numbers, 10);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, numbers.Count);
        }

        [TestMethod]
        public void RemoveElement_RemovesItemFromList()
        {
            numbers.Add(5);
            listManager.RemoveElement(numbers, 5);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, numbers.Count);
        }

        [TestMethod]
        public void GetSize_ReturnsCorrectCount()
        {
            numbers.Add(1);
            numbers.Add(2);
            int size = listManager.GetSize(numbers);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, size);
        }
    }

    
    // NUNIT TEST CLASS
    
    [TestFixture]
    public class ListManagerNUnitTest
    {
        private ListManager listManager;
        private List<int> numbers;

        [SetUp]
        public void Setup()
        {
            listManager = new ListManager();
            numbers = new List<int>();
        }

        [Test]
        public void AddElement_AddsItemToList()
        {
            listManager.AddElement(numbers, 20);
            NUnit.Framework.Assert.AreEqual(1, numbers.Count);
        }

        [Test]
        public void RemoveElement_RemovesItemFromList()
        {
            numbers.Add(30);
            listManager.RemoveElement(numbers, 30);
            NUnit.Framework.Assert.AreEqual(0, numbers.Count);
        }

        [Test]
        public void GetSize_ReturnsCorrectCount()
        {
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            int size = listManager.GetSize(numbers);
            NUnit.Framework.Assert.AreEqual(3, size);
        }
    }
}
