using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ModelLayer.DTOs;
using ModelLayer.Entities;
using RepositoryLayer.Interfaces;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly Cloudinary _cloudinary;
        private readonly IRabbitMqProducer _rabbitMqProducer;

        public NoteService(
            INoteRepository noteRepository,
            IConfiguration configuration,
            IRabbitMqProducer rabbitMqProducer)
        {
            _noteRepository = noteRepository;
            _rabbitMqProducer = rabbitMqProducer;

            // Initialize Cloudinary
            var account = new Account(
                configuration["CloudinarySettings:CloudName"],
                configuration["CloudinarySettings:ApiKey"],
                configuration["CloudinarySettings:ApiSecret"]
            );
            _cloudinary = new Cloudinary(account);
        }

        public async Task<Note> CreateNoteAsync(int userId, CreateNoteRequest request)
        {
            var note = new Note
            {
                UserId = userId,
                Title = request.Title,
                Description = request.Description,
                Backgroundcolor = string.IsNullOrWhiteSpace(request.Backgroundcolor) ? "#FFFFFF" : request.Backgroundcolor,
                Created = DateTime.UtcNow,
                Edited = DateTime.UtcNow
            };

            return await _noteRepository.CreateNoteAsync(note);
        }

        public async Task<IEnumerable<Note>> GetAllNotesAsync(int userId)
        {
            return await _noteRepository.GetAllNotesAsync(userId);
        }

        public async Task<Note?> GetNoteByIdAsync(int noteId, int userId)
        {
            return await _noteRepository.GetNoteByIdAsync(noteId, userId);
        }

        public async Task<Note?> UpdateNoteAsync(int noteId, int userId, UpdateNoteRequest request)
        {
            var existingNote = await _noteRepository.GetNoteByIdAsync(noteId, userId);
            if (existingNote == null) return null;

            existingNote.Title = request.Title;
            existingNote.Description = request.Description;
            existingNote.Backgroundcolor = request.Backgroundcolor;
            existingNote.Reminder = request.Reminder;
            existingNote.Pin = request.Pin;
            existingNote.Archive = request.Archive;
            existingNote.Trash = request.Trash;

            return await _noteRepository.UpdateNoteAsync(existingNote);
        }

        public async Task<string?> UploadImageAsync(int noteId, int userId, IFormFile imageFile)
        {
            var note = await _noteRepository.GetNoteByIdAsync(noteId, userId);
            if (note == null || imageFile == null || imageFile.Length == 0)
            {
                return null;
            }

            await using var stream = imageFile.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(imageFile.FileName, stream),
                Folder = "fundoo_notes"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            if (uploadResult.Error != null)
            {
                throw new Exception($"Cloudinary Error: {uploadResult.Error.Message}");
            }

            string imageUrl = uploadResult.SecureUrl.ToString();
            await _noteRepository.UpdateNoteImageAsync(noteId, userId, imageUrl);

            return imageUrl;
        }

        public async Task<bool> TogglePinAsync(int noteId, int userId)
        {
            return await _noteRepository.TogglePinAsync(noteId, userId);
        }

        public async Task<bool> ToggleArchiveAsync(int noteId, int userId)
        {
            return await _noteRepository.ToggleArchiveAsync(noteId, userId);
        }

        public async Task<IEnumerable<Note>> GetArchiveNotesAsync(int userId)
        {
            return await _noteRepository.GetArchiveNotesAsync(userId);
        }

        public async Task<IEnumerable<Note>> SearchNotesAsync(int userId, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _noteRepository.GetAllNotesAsync(userId);
            }
            return await _noteRepository.SearchNotesAsync(userId, keyword.Trim());
        }

        // --- Google Keep Trash Operations ---

        public async Task<bool> MoveToTrashAsync(int noteId, int userId)
        {
            return await _noteRepository.MoveToTrashAsync(noteId, userId);
        }

        public async Task<bool> RestoreNoteAsync(int noteId, int userId)
        {
            return await _noteRepository.RestoreNoteAsync(noteId, userId);
        }

        public async Task<IEnumerable<Note>> GetTrashNotesAsync(int userId)
        {
            return await _noteRepository.GetTrashNotesAsync(userId);
        }

        public async Task<bool> DeleteForeverAsync(int noteId, int userId)
        {
            return await _noteRepository.DeleteForeverAsync(noteId, userId);
        }

        public async Task<bool> EmptyTrashAsync(int userId)
        {
            return await _noteRepository.EmptyTrashAsync(userId);
        }
        public async Task<bool> SetReminderAsync(int noteId, int userId, string userEmail, SetReminderRequest request)
        {
            var note = await _noteRepository.GetNoteByIdAsync(noteId, userId);
            if (note == null) return false;

            var updated = await _noteRepository.SetReminderAsync(noteId, userId, request.Reminder);
            if (updated)
            {
                // Non-blocking asynchronous message publishing to RabbitMQ
                var notificationMessage = new ReminderNotificationMessage
                {
                    NoteId = noteId,
                    UserId = userId,
                    Email = userEmail,
                    NoteTitle = note.Title,
                    ReminderTime = request.Reminder
                };

                await _rabbitMqProducer.SendMessageAsync(notificationMessage, "reminder_notifications_queue");
            }

            return updated;
        }

        public async Task<bool> RemoveReminderAsync(int noteId, int userId)
        {
            return await _noteRepository.RemoveReminderAsync(noteId, userId);
        }

        public async Task<IEnumerable<Note>> GetNotesWithRemindersAsync(int userId)
        {
            return await _noteRepository.GetNotesWithRemindersAsync(userId);
        }
    }
}