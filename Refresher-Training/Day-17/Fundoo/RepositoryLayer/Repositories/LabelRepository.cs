using Microsoft.EntityFrameworkCore;
using ModelLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Repositories
{
    public class LabelRepository : ILabelRepository
    {
        private readonly AppDbContext _context;

        public LabelRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Label> CreateLabelAsync(Label label)
        {
            _context.Labels.Add(label);
            await _context.SaveChangesAsync();
            return label;
        }

        public async Task<IEnumerable<Label>> GetAllLabelsAsync(int userId)
        {
            return await _context.Labels
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }

        public async Task<Label?> GetLabelByIdAsync(int labelId, int userId)
        {
            return await _context.Labels
                .FirstOrDefaultAsync(l => l.LabelId == labelId && l.UserId == userId);
        }

        public async Task<bool> UpdateLabelAsync(int labelId, int userId, string newLabelName)
        {
            var label = await GetLabelByIdAsync(labelId, userId);
            if (label == null) return false;

            label.LabelName = newLabelName;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLabelAsync(int labelId, int userId)
        {
            var label = await GetLabelByIdAsync(labelId, userId);
            if (label == null) return false;

            // Remove associated NoteLabels mappings
            var mappings = _context.NoteLabels.Where(nl => nl.LabelId == labelId);
            _context.NoteLabels.RemoveRange(mappings);

            _context.Labels.Remove(label);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddLabelToNoteAsync(int noteId, int labelId, int userId)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.NoteId == noteId && n.UserId == userId);
            var label = await GetLabelByIdAsync(labelId, userId);

            if (note == null || label == null) return false;

            var exists = await _context.NoteLabels.AnyAsync(nl => nl.NoteId == noteId && nl.LabelId == labelId);
            if (exists) return true;

            var mapping = new NoteLabel { NoteId = noteId, LabelId = labelId };
            _context.NoteLabels.Add(mapping);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveLabelFromNoteAsync(int noteId, int labelId, int userId)
        {
            var mapping = await _context.NoteLabels
                .FirstOrDefaultAsync(nl => nl.NoteId == noteId && nl.LabelId == labelId && nl.Label!.UserId == userId);

            if (mapping == null) return false;

            _context.NoteLabels.Remove(mapping);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Label>> GetLabelsByNoteIdAsync(int noteId, int userId)
        {
            return await _context.NoteLabels
                .Where(nl => nl.NoteId == noteId && nl.Note!.UserId == userId)
                .Select(nl => nl.Label!)
                .ToListAsync();
        }

        public async Task<IEnumerable<Note>> GetNotesByLabelIdAsync(int labelId, int userId)
        {
            return await _context.NoteLabels
                .Where(nl => nl.LabelId == labelId && nl.Label!.UserId == userId && !nl.Note!.Trash)
                .Select(nl => nl.Note!)
                .ToListAsync();
        }
    }
}