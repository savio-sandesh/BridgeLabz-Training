using System.ComponentModel.DataAnnotations;

namespace ModelLayer.DTOs
{
    public class LabelRequest
    {
        [Required]
        [MaxLength(50)]
        public string LabelName { get; set; } = string.Empty;
    }

    public class LabelResponse
    {
        public int LabelId { get; set; }
        public int UserId { get; set; }
        public string LabelName { get; set; } = string.Empty;
    }
}