using Microsoft.AspNetCore.Http;
using ModelLayer.DTOs;
using ModelLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface INoteService
    {
        // Core CRUD
        Task<Note> CreateNoteAsync(int userId, CreateNoteRequest request);
        Task<IEnumerable<Note>> GetAllNotesAsync(int userId);
        Task<Note?> GetNoteByIdAsync(int noteId, int userId);
        Task<Note?> UpdateNoteAsync(int noteId, int userId, UpdateNoteRequest request);
        Task<string?> UploadImageAsync(int noteId, int userId, IFormFile imageFile);

        // Pin & Archive
        Task<bool> TogglePinAsync(int noteId, int userId);
        Task<bool> ToggleArchiveAsync(int noteId, int userId);
        Task<IEnumerable<Note>> GetArchiveNotesAsync(int userId);

        // Search
        Task<IEnumerable<Note>> SearchNotesAsync(int userId, string keyword);

        // Google Keep Trash Flow
        Task<bool> MoveToTrashAsync(int noteId, int userId);
        Task<bool> RestoreNoteAsync(int noteId, int userId);
        Task<IEnumerable<Note>> GetTrashNotesAsync(int userId);
        Task<bool> DeleteForeverAsync(int noteId, int userId);
        Task<bool> EmptyTrashAsync(int userId);
    }
}