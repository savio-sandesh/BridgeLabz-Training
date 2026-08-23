using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Entities
{
    public class NoteLabel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Note")]
        public int NoteId { get; set; }

        [Required]
        [ForeignKey("Label")]
        public int LabelId { get; set; }

        // Navigation Properties
        public virtual Note? Note { get; set; }
        public virtual Label? Label { get; set; }
    }
}