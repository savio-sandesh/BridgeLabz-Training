using ModelLayer.Entities;

namespace RepositoryLayer.Interfaces
{
    public interface INoteRepository
    {
        // --- Core CRUD Operations ---
        Task<Note> CreateNoteAsync(Note note);
        Task<IEnumerable<Note>> GetAllNotesAsync(int userId);
        Task<Note?> GetNoteByIdAsync(int noteId, int userId);
        Task<Note?> UpdateNoteAsync(Note note);
        Task<bool> UpdateNoteImageAsync(int noteId, int userId, string imageUrl);

        // --- Pin & Archive Operations ---
        Task<bool> TogglePinAsync(int noteId, int userId);
        Task<bool> ToggleArchiveAsync(int noteId, int userId);
        Task<IEnumerable<Note>> GetArchiveNotesAsync(int userId);

        // --- Search & Filter ---
        Task<IEnumerable<Note>> SearchNotesAsync(int userId, string keyword);

        // --- Google Keep Trash Flow Operations ---
        Task<bool> MoveToTrashAsync(int noteId, int userId);
        Task<bool> RestoreNoteAsync(int noteId, int userId);
        Task<IEnumerable<Note>> GetTrashNotesAsync(int userId);
        Task<bool> DeleteForeverAsync(int noteId, int userId);
        Task<bool> EmptyTrashAsync(int userId);
    }
}