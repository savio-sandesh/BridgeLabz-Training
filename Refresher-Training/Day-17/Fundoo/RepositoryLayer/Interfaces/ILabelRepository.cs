using ModelLayer.Entities;

namespace RepositoryLayer.Interfaces
{
    public interface ILabelRepository
    {
        // Master Label CRUD
        Task<Label> CreateLabelAsync(Label label);
        Task<IEnumerable<Label>> GetAllLabelsAsync(int userId);
        Task<Label?> GetLabelByIdAsync(int labelId, int userId);
        Task<bool> UpdateLabelAsync(int labelId, int userId, string newLabelName);
        Task<bool> DeleteLabelAsync(int labelId, int userId);

        // Junction Mapping Operations
        Task<bool> AddLabelToNoteAsync(int noteId, int labelId, int userId);
        Task<bool> RemoveLabelFromNoteAsync(int noteId, int labelId, int userId);
        Task<IEnumerable<Label>> GetLabelsByNoteIdAsync(int noteId, int userId);
        Task<IEnumerable<Note>> GetNotesByLabelIdAsync(int labelId, int userId);
    }
}