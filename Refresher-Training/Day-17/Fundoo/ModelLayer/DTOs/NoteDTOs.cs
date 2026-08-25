namespace ModelLayer.DTOs
{
    public class CreateNoteRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Backgroundcolor { get; set; }
    }

    public class UpdateNoteRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Backgroundcolor { get; set; } = string.Empty;
        public DateTime? Reminder { get; set; }
        public bool Pin { get; set; }
        public bool Archive { get; set; }
        public bool Trash { get; set; }
    }
}