using BusinessLayer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.DTOs;
using ModelLayer.Entities;
using Moq;
using RepositoryLayer.Interfaces;

namespace FundooTests
{
    [TestClass]
    public class LabelServiceTests
    {
        private Mock<ILabelRepository> _labelRepoMock = null!;
        private LabelService _labelService = null!;

        [TestInitialize]
        public void Setup()
        {
            _labelRepoMock = new Mock<ILabelRepository>();
            _labelService = new LabelService(_labelRepoMock.Object);
        }

        [TestMethod]
        public async Task CreateLabelAsync_ValidName_ReturnsLabelResponse()
        {
            // Arrange
            int userId = 1;
            var request = new LabelRequest { LabelName = "Work" };
            var createdEntity = new Label
            {
                LabelId = 1,
                UserId = userId,
                LabelName = "Work"
            };

            _labelRepoMock
                .Setup(repo => repo.CreateLabelAsync(It.IsAny<Label>()))
                .ReturnsAsync(createdEntity);

            // Act
            var result = await _labelService.CreateLabelAsync(userId, request);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Work", result.LabelName);
            Assert.AreEqual(1, result.LabelId);
        }

        [TestMethod]
        public async Task AddLabelToNoteAsync_Success_ReturnsTrue()
        {
            // Arrange
            int noteId = 10;
            int labelId = 2;
            int userId = 1;

            _labelRepoMock
                .Setup(repo => repo.AddLabelToNoteAsync(noteId, labelId, userId))
                .ReturnsAsync(true);

            // Act
            var result = await _labelService.AddLabelToNoteAsync(noteId, labelId, userId);

            // Assert
            Assert.IsTrue(result);
        }
    }
}