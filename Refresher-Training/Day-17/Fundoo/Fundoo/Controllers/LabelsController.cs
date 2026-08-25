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
    public class LabelsController : ControllerBase
    {
        private readonly ILabelService _labelService;

        public LabelsController(ILabelService labelService)
        {
            _labelService = labelService;
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value 
                              ?? User.FindFirst("sub")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                throw new UnauthorizedAccessException("User identification failed.");
            }
            return userId;
        }

        // POST: api/Labels
        [HttpPost]
        public async Task<IActionResult> CreateLabel([FromBody] LabelRequest request)
        {
            int userId = GetCurrentUserId();
            var result = await _labelService.CreateLabelAsync(userId, request);
            return Ok(result);
        }

        // GET: api/Labels
        [HttpGet]
        public async Task<IActionResult> GetAllLabels()
        {
            int userId = GetCurrentUserId();
            var labels = await _labelService.GetAllLabelsAsync(userId);
            return Ok(labels);
        }

        // PUT: api/Labels/{labelId}
        [HttpPut("{labelId:int}")]
        public async Task<IActionResult> UpdateLabel(int labelId, [FromBody] LabelRequest request)
        {
            int userId = GetCurrentUserId();
            bool result = await _labelService.UpdateLabelAsync(labelId, userId, request);
            if (!result) return NotFound(new { message = "Label not found." });
            return Ok(new { message = "Label updated successfully." });
        }

        // DELETE: api/Labels/{labelId}
        [HttpDelete("{labelId:int}")]
        public async Task<IActionResult> DeleteLabel(int labelId)
        {
            int userId = GetCurrentUserId();
            bool result = await _labelService.DeleteLabelAsync(labelId, userId);
            if (!result) return NotFound(new { message = "Label not found." });
            return Ok(new { message = "Label deleted successfully." });
        }

        // POST: api/Labels/note/{noteId}/attach/{labelId}
        [HttpPost("note/{noteId:int}/attach/{labelId:int}")]
        public async Task<IActionResult> AddLabelToNote(int noteId, int labelId)
        {
            int userId = GetCurrentUserId();
            bool result = await _labelService.AddLabelToNoteAsync(noteId, labelId, userId);
            if (!result) return BadRequest(new { message = "Note or Label not found, or access denied." });
            return Ok(new { message = "Label attached to note successfully." });
        }

        // DELETE: api/Labels/note/{noteId}/detach/{labelId}
        [HttpDelete("note/{noteId:int}/detach/{labelId:int}")]
        public async Task<IActionResult> RemoveLabelFromNote(int noteId, int labelId)
        {
            int userId = GetCurrentUserId();
            bool result = await _labelService.RemoveLabelFromNoteAsync(noteId, labelId, userId);
            if (!result) return NotFound(new { message = "Mapping not found." });
            return Ok(new { message = "Label removed from note successfully." });
        }

        // GET: api/Labels/note/{noteId}
        [HttpGet("note/{noteId:int}")]
        public async Task<IActionResult> GetLabelsByNote(int noteId)
        {
            int userId = GetCurrentUserId();
            var labels = await _labelService.GetLabelsByNoteIdAsync(noteId, userId);
            return Ok(labels);
        }

        // GET: api/Labels/{labelId}/notes
        [HttpGet("{labelId:int}/notes")]
        public async Task<IActionResult> GetNotesByLabel(int labelId)
        {
            int userId = GetCurrentUserId();
            var notes = await _labelService.GetNotesByLabelIdAsync(labelId, userId);
            return Ok(notes);
        }
    }
}