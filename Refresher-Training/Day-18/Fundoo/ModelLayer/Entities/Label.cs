using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Entities
{
    public class Label
    {
        [Key]
        public int LabelId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string LabelName { get; set; } = string.Empty;

        // Navigation Properties
        public virtual User? User { get; set; }
        public virtual ICollection<NoteLabel> NoteLabels { get; set; } = new List<NoteLabel>();
    }
}