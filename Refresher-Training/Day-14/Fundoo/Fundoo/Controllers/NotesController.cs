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

        // Helper method to get logged-in UserId from JWT Claims
        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                              ?? User.FindFirst("UserId")?.Value;

            if (int.TryParse(userIdClaim, out int userId))
            {
                return userId;
            }

            throw new UnauthorizedAccessException("Invalid User Token.");
        }

        // 1. POST: api/Notes
        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteDto dto)
        {
            int userId = GetCurrentUserId();
            var createdNote = await _noteService.CreateNoteAsync(dto, userId);
            return StatusCode(StatusCodes.Status201Created, createdNote);
        }

        // 2. GET: api/Notes
        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            int userId = GetCurrentUserId();
            var notes = await _noteService.GetAllNotesAsync(userId);
            return Ok(notes);
        }

        // 3. GET: api/Notes/{noteId}
        [HttpGet("{noteId:int}")]
        public async Task<IActionResult> GetNoteById(int noteId)
        {
            int userId = GetCurrentUserId();
            var note = await _noteService.GetNoteByIdAsync(noteId, userId);
            if (note == null)
            {
                return NotFound(new { message = "Note not found." });
            }
            return Ok(note);
        }

        // 4. DELETE: api/Notes/{noteId}
        [HttpDelete("{noteId:int}")]
        public async Task<IActionResult> DeleteNote(int noteId)
        {
            int userId = GetCurrentUserId();
            bool isDeleted = await _noteService.DeleteNoteAsync(noteId, userId);
            if (!isDeleted)
            {
                return NotFound(new { message = "Note not found or you are not authorized to delete it." });
            }
            return Ok(new { message = "Note deleted successfully." });
        }

        // 5. POST / PUT: api/Notes/{noteId}/image
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

            return Ok(new { message = "Image uploaded successfully.", imageUrl = imageUrl });
        }
    }
}