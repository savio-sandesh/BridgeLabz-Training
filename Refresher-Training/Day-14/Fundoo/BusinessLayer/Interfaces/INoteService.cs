using ModelLayer.DTOs;
using ModelLayer.Entities;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Interfaces
{
    public interface INoteService
    {
        Task<Note> CreateNoteAsync(CreateNoteDto dto, int userId);
        Task<IEnumerable<Note>> GetAllNotesAsync(int userId);
        Task<Note?> GetNoteByIdAsync(int noteId, int userId);
        Task<bool> DeleteNoteAsync(int noteId, int userId);

        Task<string?> UploadImageAsync(int noteId, int userId, IFormFile imageFile);
    }
}