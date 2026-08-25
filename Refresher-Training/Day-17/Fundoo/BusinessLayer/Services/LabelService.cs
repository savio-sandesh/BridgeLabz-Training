using BusinessLayer.Interfaces;
using ModelLayer.DTOs;
using ModelLayer.Entities;
using RepositoryLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class LabelService : ILabelService
    {
        private readonly ILabelRepository _labelRepository;

        public LabelService(ILabelRepository labelRepository)
        {
            _labelRepository = labelRepository;
        }

        public async Task<LabelResponse> CreateLabelAsync(int userId, LabelRequest request)
        {
            var label = new Label
            {
                UserId = userId,
                LabelName = request.LabelName.Trim()
            };

            var created = await _labelRepository.CreateLabelAsync(label);
            return new LabelResponse
            {
                LabelId = created.LabelId,
                UserId = created.UserId,
                LabelName = created.LabelName
            };
        }

        public async Task<IEnumerable<LabelResponse>> GetAllLabelsAsync(int userId)
        {
            var labels = await _labelRepository.GetAllLabelsAsync(userId);
            return labels.Select(l => new LabelResponse
            {
                LabelId = l.LabelId,
                UserId = l.UserId,
                LabelName = l.LabelName
            });
        }

        public async Task<bool> UpdateLabelAsync(int labelId, int userId, LabelRequest request)
        {
            return await _labelRepository.UpdateLabelAsync(labelId, userId, request.LabelName.Trim());
        }

        public async Task<bool> DeleteLabelAsync(int labelId, int userId)
        {
            return await _labelRepository.DeleteLabelAsync(labelId, userId);
        }

        public async Task<bool> AddLabelToNoteAsync(int noteId, int labelId, int userId)
        {
            return await _labelRepository.AddLabelToNoteAsync(noteId, labelId, userId);
        }

        public async Task<bool> RemoveLabelFromNoteAsync(int noteId, int labelId, int userId)
        {
            return await _labelRepository.RemoveLabelFromNoteAsync(noteId, labelId, userId);
        }

        public async Task<IEnumerable<LabelResponse>> GetLabelsByNoteIdAsync(int noteId, int userId)
        {
            var labels = await _labelRepository.GetLabelsByNoteIdAsync(noteId, userId);
            return labels.Select(l => new LabelResponse
            {
                LabelId = l.LabelId,
                UserId = l.UserId,
                LabelName = l.LabelName
            });
        }

        public async Task<IEnumerable<Note>> GetNotesByLabelIdAsync(int labelId, int userId)
        {
            return await _labelRepository.GetNotesByLabelIdAsync(labelId, userId);
        }
    }
}