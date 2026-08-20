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

        // 2. Get All Active Notes (Jo Trash aur Archive me na hon, pinned notes top par)
        public async Task<IEnumerable<Note>> GetAllNotesAsync(int userId)
        {
            return await _context.Notes
                .Where(n => n.UserId == userId && !n.Trash && !n.Archive)
                .OrderByDescending(n => n.Pin)
                .ThenByDescending(n => n.Created)
                .ToListAsync();
        }

        // 3. Get Note By ID
        public async Task<Note?> GetNoteByIdAsync(int noteId, int userId)
        {
            return await _context.Notes.FirstOrDefaultAsync(n => n.NoteId == noteId && n.UserId == userId);
        }

        // 4. Update Note
        public async Task<Note?> UpdateNoteAsync(Note note)
        {
            note.Edited = DateTime.UtcNow;
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
            return note;
        }

        // 5. Update Note Image URL
        public async Task<bool> UpdateNoteImageAsync(int noteId, int userId, string imageUrl)
        {
            var note = await GetNoteByIdAsync(noteId, userId);
            if (note == null) return false;

            note.Image = imageUrl;
            note.Edited = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        // 6. Toggle Pin
        public async Task<bool> TogglePinAsync(int noteId, int userId)
        {
            var note = await GetNoteByIdAsync(noteId, userId);
            if (note == null) return false;

            note.Pin = !note.Pin;
            note.Edited = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        // 7. Toggle Archive (Archive karne par pin automatically false ho jata hai)
        public async Task<bool> ToggleArchiveAsync(int noteId, int userId)
        {
            var note = await GetNoteByIdAsync(noteId, userId);
            if (note == null) return false;

            note.Archive = !note.Archive;
            if (note.Archive)
            {
                note.Pin = false;
            }
            note.Edited = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        // 8. Get Archive Notes
        public async Task<IEnumerable<Note>> GetArchiveNotesAsync(int userId)
        {
            return await _context.Notes
                .Where(n => n.UserId == userId && n.Archive && !n.Trash)
                .OrderByDescending(n => n.Edited)
                .ToListAsync();
        }

        // 9. Search Notes (Active notes me search karta hai)
        public async Task<IEnumerable<Note>> SearchNotesAsync(int userId, string keyword)
        {
            return await _context.Notes
                .Where(n => n.UserId == userId && !n.Trash &&
                           (n.Title.Contains(keyword) || n.Description.Contains(keyword)))
                .OrderByDescending(n => n.Created)
                .ToListAsync();
        }

        // --- Google Keep Trash Flow Implementation ---

        // 10. Move to Trash (Soft Delete)
        public async Task<bool> MoveToTrashAsync(int noteId, int userId)
        {
            var note = await GetNoteByIdAsync(noteId, userId);
            if (note == null) return false;

            note.Trash = true;
            note.Pin = false; // Trashed note pinned nahi reh sakta
            note.Edited = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        // 11. Restore Note from Trash
        public async Task<bool> RestoreNoteAsync(int noteId, int userId)
        {
            var note = await GetNoteByIdAsync(noteId, userId);
            if (note == null) return false;

            note.Trash = false;
            note.Edited = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        // 12. Get All Trashed Notes
        public async Task<IEnumerable<Note>> GetTrashNotesAsync(int userId)
        {
            return await _context.Notes
                .Where(n => n.UserId == userId && n.Trash)
                .OrderByDescending(n => n.Edited)
                .ToListAsync();
        }

        // 13. Delete Single Note Forever (Permanent Hard Delete)
        public async Task<bool> DeleteForeverAsync(int noteId, int userId)
        {
            var note = await GetNoteByIdAsync(noteId, userId);
            if (note == null) return false;

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return true;
        }

        // 14. Empty Entire Trash for Logged-In User (Bulk Hard Delete)
        public async Task<bool> EmptyTrashAsync(int userId)
        {
            var trashedNotes = await _context.Notes
                .Where(n => n.UserId == userId && n.Trash)
                .ToListAsync();

            if (!trashedNotes.Any()) return false;

            _context.Notes.RemoveRange(trashedNotes);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}