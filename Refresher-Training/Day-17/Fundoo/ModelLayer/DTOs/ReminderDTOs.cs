using System.ComponentModel.DataAnnotations;

namespace ModelLayer.DTOs
{
    public class SetReminderRequest
    {
        [Required]
        public DateTime Reminder { get; set; }
    }

    public class ReminderNotificationMessage
    {
        public int NoteId { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string NoteTitle { get; set; } = string.Empty;
        public DateTime ReminderTime { get; set; }
        public DateTime TriggeredAt { get; set; } = DateTime.UtcNow;
    }
}