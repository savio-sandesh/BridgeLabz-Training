using Microsoft.EntityFrameworkCore;
using ModelLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _context;

        public NoteRepository(AppDbContext context)
        {
            _context = context;
        }

        // 1. Create Note
        public async Task<Note> CreateNoteAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        // 2. Get All Notes for logged-in user
        public async Task<IEnumerable<Note>> GetAllNotesAsync(int userId)
        {
            return await _context.Notes
                .Where(n => n.UserId == userId)
                .ToListAsync();
        }

        // 3. Get Specific Note by Id and UserId
        public async Task<Note?> GetNoteByIdAsync(int noteId, int userId)
        {
            return await _context.Notes
                .FirstOrDefaultAsync(n => n.NoteId == noteId && n.UserId == userId);
        }

        // 4. Delete Note
        public async Task<bool> DeleteNoteAsync(int noteId, int userId)
        {
            var note = await GetNoteByIdAsync(noteId, userId);
            if (note == null)
            {
                return false;
            }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateNoteImageAsync(int noteId, int userId, string imageUrl)
        {
            var note = await GetNoteByIdAsync(noteId, userId);
            if (note == null)
            {
                return false;
            }

            note.Image = imageUrl;
            note.Edited = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}