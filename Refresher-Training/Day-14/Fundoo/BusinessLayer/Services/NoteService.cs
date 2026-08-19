using BusinessLayer.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ModelLayer.DTOs;
using ModelLayer.Entities;
using RepositoryLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly Cloudinary _cloudinary;

        public NoteService(INoteRepository noteRepository, IConfiguration configuration)
        {
            _noteRepository = noteRepository;

            // Initialize Cloudinary instance
            var account = new Account(
                configuration["CloudinarySettings:CloudName"],
                configuration["CloudinarySettings:ApiKey"],
                configuration["CloudinarySettings:ApiSecret"]
            );
            _cloudinary = new Cloudinary(account);
        }

        // Image Upload Logic
        public async Task<string?> UploadImageAsync(int noteId, int userId, IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return null;
            }

            // 1. Verify Note exists and belongs to logged-in user
            var note = await _noteRepository.GetNoteByIdAsync(noteId, userId);
            if (note == null)
            {
                return null;
            }

            // 2. Upload file to Cloudinary via stream
            using var stream = imageFile.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(imageFile.FileName, stream),
                Folder = "fundoo_notes"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                throw new Exception(uploadResult.Error.Message);
            }

            string imageUrl = uploadResult.SecureUrl.ToString();

            // 3. Save Image URL in Database
            await _noteRepository.UpdateNoteImageAsync(noteId, userId, imageUrl);

            return imageUrl;
        }

        public async Task<Note> CreateNoteAsync(CreateNoteDto dto, int userId)
        {
            var note = new Note
            {
                UserId = userId,
                Title = dto.Title,
                Description = dto.Description,
                Backgroundcolor = string.IsNullOrWhiteSpace(dto.Backgroundcolor) ? "#FFFFFF" : dto.Backgroundcolor,
                Reminder = DateTime.UtcNow,
                Created = DateTime.UtcNow,
                Edited = DateTime.UtcNow,
                Image = string.Empty,
                Pin = false,
                Trash = false,
                Archive = false
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

        public async Task<bool> DeleteNoteAsync(int noteId, int userId)
        {
            return await _noteRepository.DeleteNoteAsync(noteId, userId);
        }
    }
}