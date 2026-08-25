using System.Security.Claims;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTOs;

namespace Fundoo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        // Helper: Extract current logged-in UserId from JWT claims
        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                              ?? User.FindFirst("sub")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                throw new UnauthorizedAccessException("Invalid or missing user identity in token.");
            }

            return userId;
        }

        // POST: api/Notes
        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteRequest request)
        {
            int userId = GetCurrentUserId();
            var createdNote = await _noteService.CreateNoteAsync(userId, request);
            return CreatedAtAction(nameof(GetNoteById), new { noteId = createdNote.NoteId }, createdNote);
        }

        // GET: api/Notes (Fetches active notes only)
        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            int userId = GetCurrentUserId();
            var notes = await _noteService.GetAllNotesAsync(userId);
            return Ok(notes);
        }

        // GET: api/Notes/{noteId}
        [HttpGet("{noteId:int}")]
        public async Task<IActionResult> GetNoteById(int noteId)
        {
            int userId = GetCurrentUserId();
            var note = await _noteService.GetNoteByIdAsync(noteId, userId);
            if (note == null)
            {
                return NotFound(new { message = "Note not found or unauthorized access." });
            }
            return Ok(note);
        }

        // PUT: api/Notes/{noteId}
        [HttpPut("{noteId:int}")]
        public async Task<IActionResult> UpdateNote(int noteId, [FromBody] UpdateNoteRequest request)
        {
            int userId = GetCurrentUserId();
            var updatedNote = await _noteService.UpdateNoteAsync(noteId, userId, request);
            if (updatedNote == null)
            {
                return NotFound(new { message = "Note not found or unauthorized access." });
            }
            return Ok(updatedNote);
        }

        // PUT: api/Notes/{noteId}/image
        [HttpPut("{noteId:int}/image")]
        public async Task<IActionResult> UploadImage(int noteId, IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest(new { message = "Please select a valid image file." });
            }

            int userId = GetCurrentUserId();
            var imageUrl = await _noteService.UploadImageAsync(noteId, userId, image);
            if (imageUrl == null)
            {
                return NotFound(new { message = "Note not found or unauthorized access." });
            }

            return Ok(new { message = "Image uploaded successfully.", imageUrl });
        }

        // PUT: api/Notes/{noteId}/pin
        [HttpPut("{noteId:int}/pin")]
        public async Task<IActionResult> TogglePin(int noteId)
        {
            int userId = GetCurrentUserId();
            bool result = await _noteService.TogglePinAsync(noteId, userId);
            if (!result) return NotFound(new { message = "Note not found or unauthorized access." });
            return Ok(new { message = "Note pin status toggled successfully." });
        }

        // PUT: api/Notes/{noteId}/archive
        [HttpPut("{noteId:int}/archive")]
        public async Task<IActionResult> ToggleArchive(int noteId)
        {
            int userId = GetCurrentUserId();
            bool result = await _noteService.ToggleArchiveAsync(noteId, userId);
            if (!result) return NotFound(new { message = "Note not found or unauthorized access." });
            return Ok(new { message = "Note archive status toggled successfully." });
        }

        // GET: api/Notes/archive
        [HttpGet("archive")]
        public async Task<IActionResult> GetArchiveNotes()
        {
            int userId = GetCurrentUserId();
            var notes = await _noteService.GetArchiveNotesAsync(userId);
            return Ok(notes);
        }

        // GET: api/Notes/search?keyword=abc
        [HttpGet("search")]
        public async Task<IActionResult> SearchNotes([FromQuery] string keyword)
        {
            int userId = GetCurrentUserId();
            var notes = await _noteService.SearchNotesAsync(userId, keyword);
            return Ok(notes);
        }

        // --- Google Keep Trash Flow Endpoints ---

        // PUT: api/Notes/{noteId}/trash (Soft Delete: Move to Trash)
        [HttpPut("{noteId:int}/trash")]
        public async Task<IActionResult> MoveToTrash(int noteId)
        {
            int userId = GetCurrentUserId();
            bool result = await _noteService.MoveToTrashAsync(noteId, userId);
            if (!result) return NotFound(new { message = "Note not found or unauthorized access." });
            return Ok(new { message = "Note moved to trash successfully." });
        }

        // PUT: api/Notes/{noteId}/restore (Restore back to Home)
        [HttpPut("{noteId:int}/restore")]
        public async Task<IActionResult> RestoreNote(int noteId)
        {
            int userId = GetCurrentUserId();
            bool result = await _noteService.RestoreNoteAsync(noteId, userId);
            if (!result) return NotFound(new { message = "Note not found or unauthorized access." });
            return Ok(new { message = "Note restored successfully." });
        }

        // GET: api/Notes/trash (View Trashed Notes)
        [HttpGet("trash")]
        public async Task<IActionResult> GetTrashNotes()
        {
            int userId = GetCurrentUserId();
            var notes = await _noteService.GetTrashNotesAsync(userId);
            return Ok(notes);
        }

        // DELETE: api/Notes/{noteId}/forever (Permanent Single Hard Delete)
        [HttpDelete("{noteId:int}/forever")]
        public async Task<IActionResult> DeleteForever(int noteId)
        {
            int userId = GetCurrentUserId();
            bool result = await _noteService.DeleteForeverAsync(noteId, userId);
            if (!result) return NotFound(new { message = "Note not found or unauthorized access." });
            return Ok(new { message = "Note permanently deleted from database." });
        }

        // DELETE: api/Notes/trash/empty (Bulk Hard Delete for Logged-In User)
        [HttpDelete("trash/empty")]
        public async Task<IActionResult> EmptyTrash()
        {
            int userId = GetCurrentUserId();
            bool result = await _noteService.EmptyTrashAsync(userId);
            if (!result) return NotFound(new { message = "Trash is already empty." });
            return Ok(new { message = "All trash notes permanently removed." });
        }

        // PUT: api/Notes/{noteId}/reminder
        [HttpPut("{noteId:int}/reminder")]
        public async Task<IActionResult> SetReminder(int noteId, [FromBody] SetReminderRequest request)
        {
            int userId = GetCurrentUserId();
            string userEmail = User.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;

            bool result = await _noteService.SetReminderAsync(noteId, userId, userEmail, request);
            if (!result) return NotFound(new { message = "Note not found or inactive." });

            return Ok(new { message = "Reminder set successfully and queued for notification." });
        }

        // DELETE: api/Notes/{noteId}/reminder
        [HttpDelete("{noteId:int}/reminder")]
        public async Task<IActionResult> RemoveReminder(int noteId)
        {
            int userId = GetCurrentUserId();
            bool result = await _noteService.RemoveReminderAsync(noteId, userId);
            if (!result) return NotFound(new { message = "Note not found." });

            return Ok(new { message = "Reminder removed successfully." });
        }

        // GET: api/Notes/reminders
        [HttpGet("reminders")]
        public async Task<IActionResult> GetReminders()
        {
            int userId = GetCurrentUserId();
            var notes = await _noteService.GetNotesWithRemindersAsync(userId);
            return Ok(notes);
        }
    }
}