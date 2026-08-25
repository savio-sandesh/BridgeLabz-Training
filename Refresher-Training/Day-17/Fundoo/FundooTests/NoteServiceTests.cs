using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.DTOs;
using ModelLayer.Entities;
using Moq;
using RepositoryLayer.Interfaces;

namespace FundooTests
{
    [TestClass]
    public class NoteServiceTests
    {
        private Mock<INoteRepository> _noteRepoMock = null!;
        private Mock<IConfiguration> _configMock = null!;
        private Mock<IRabbitMqProducer> _rabbitMqProducerMock = null!;
        private NoteService _noteService = null!;

        [TestInitialize]
        public void Setup()
        {
            _noteRepoMock = new Mock<INoteRepository>();
            _configMock = new Mock<IConfiguration>();
            _rabbitMqProducerMock = new Mock<IRabbitMqProducer>();
            
            // Setup configuration mocks for Cloudinary
            _configMock.Setup(c => c["CloudinarySettings:CloudName"]).Returns("test");
            _configMock.Setup(c => c["CloudinarySettings:ApiKey"]).Returns("test");
            _configMock.Setup(c => c["CloudinarySettings:ApiSecret"]).Returns("test");
            
            _noteService = new NoteService(
                _noteRepoMock.Object,
                _configMock.Object,
                _rabbitMqProducerMock.Object);
        }

        [TestMethod]
        public async Task CreateNoteAsync_ValidInput_ReturnsCreatedNote()
        {
            // Arrange
            int userId = 1;
            var request = new CreateNoteRequest
            {
                Title = "Unit Test Title",
                Description = "Unit Test Description",
                Backgroundcolor = "#FFFFFF"
            };

            var expectedNote = new Note
            {
                NoteId = 101,
                UserId = userId,
                Title = request.Title,
                Description = request.Description,
                Backgroundcolor = request.Backgroundcolor,
                Created = DateTime.UtcNow
            };

            _noteRepoMock
                .Setup(repo => repo.CreateNoteAsync(It.IsAny<Note>()))
                .ReturnsAsync(expectedNote);

            // Act
            var result = await _noteService.CreateNoteAsync(userId, request);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Unit Test Title", result.Title);
            Assert.AreEqual(101, result.NoteId);
            _noteRepoMock.Verify(repo => repo.CreateNoteAsync(It.IsAny<Note>()), Times.Once);
        }

        [TestMethod]
        public async Task GetNoteByIdAsync_NoteExists_ReturnsNote()
        {
            // Arrange
            int noteId = 5;
            int userId = 1;
            var existingNote = new Note
            {
                NoteId = noteId,
                UserId = userId,
                Title = "Existing Note",
                Description = "Some Content"
            };

            _noteRepoMock
                .Setup(repo => repo.GetNoteByIdAsync(noteId, userId))
                .ReturnsAsync(existingNote);

            // Act
            var result = await _noteService.GetNoteByIdAsync(noteId, userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(noteId, result.NoteId);
            Assert.AreEqual("Existing Note", result.Title);
        }

        [TestMethod]
        public async Task GetNoteByIdAsync_NoteNotFound_ReturnsNull()
        {
            // Arrange
            int noteId = 999;
            int userId = 1;

            _noteRepoMock
                .Setup(repo => repo.GetNoteByIdAsync(noteId, userId))
                .ReturnsAsync((Note?)null);

            // Act
            var result = await _noteService.GetNoteByIdAsync(noteId, userId);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task MoveToTrashAsync_ValidNote_ReturnsTrue()
        {
            // Arrange
            int noteId = 10;
            int userId = 1;

            _noteRepoMock
                .Setup(repo => repo.MoveToTrashAsync(noteId, userId))
                .ReturnsAsync(true);

            // Act
            var result = await _noteService.MoveToTrashAsync(noteId, userId);

            // Assert
            Assert.IsTrue(result);
            _noteRepoMock.Verify(repo => repo.MoveToTrashAsync(noteId, userId), Times.Once);
        }
    }
}