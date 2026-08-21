using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Entities
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        // Foreign Key for User
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Reminder { get; set; }
        public string Backgroundcolor { get; set; }
        public string Image { get; set; }
        public bool Pin { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public bool Trash { get; set; }
        public bool Archive { get; set; }

      
    }
}