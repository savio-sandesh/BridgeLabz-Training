using ModelLayer.DTOs;
using ModelLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface ILabelService
    {
        Task<LabelResponse> CreateLabelAsync(int userId, LabelRequest request);
        Task<IEnumerable<LabelResponse>> GetAllLabelsAsync(int userId);
        Task<bool> UpdateLabelAsync(int labelId, int userId, LabelRequest request);
        Task<bool> DeleteLabelAsync(int labelId, int userId);
        Task<bool> AddLabelToNoteAsync(int noteId, int labelId, int userId);
        Task<bool> RemoveLabelFromNoteAsync(int noteId, int labelId, int userId);
        Task<IEnumerable<LabelResponse>> GetLabelsByNoteIdAsync(int noteId, int userId);
        Task<IEnumerable<Note>> GetNotesByLabelIdAsync(int labelId, int userId);
    }
}