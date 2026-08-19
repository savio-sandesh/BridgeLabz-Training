using ModelLayer.Entities;

namespace RepositoryLayer.Interfaces
{
    public interface INoteRepository
    {
        Task<Note> CreateNoteAsync(Note note);
        Task<IEnumerable<Note>> GetAllNotesAsync(int userId);
        Task<Note?> GetNoteByIdAsync(int noteId, int userId);
        Task<bool> DeleteNoteAsync(int noteId, int userId);
        Task<bool> UpdateNoteImageAsync(int noteId, int userId, string imageUrl);
    }
}