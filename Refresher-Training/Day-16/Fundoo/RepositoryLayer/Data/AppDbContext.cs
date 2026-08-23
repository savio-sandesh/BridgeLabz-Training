using Microsoft.EntityFrameworkCore;
using ModelLayer.Entities;

namespace RepositoryLayer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Note> Notes { get; set; } = null!;
        public DbSet<Label> Labels { get; set; } = null!;
        public DbSet<NoteLabel> NoteLabels { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User Email Uniqueness
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Note -> User
            modelBuilder.Entity<Note>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Label -> User
            modelBuilder.Entity<Label>()
                .HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // NoteLabel -> Note (Restrict SQL Server multiple cascade path)
            modelBuilder.Entity<NoteLabel>()
                .HasOne(nl => nl.Note)
                .WithMany()
                .HasForeignKey(nl => nl.NoteId)
                .OnDelete(DeleteBehavior.Restrict);

            // NoteLabel -> Label (Restrict)
            modelBuilder.Entity<NoteLabel>()
                .HasOne(nl => nl.Label)
                .WithMany(l => l.NoteLabels)
                .HasForeignKey(nl => nl.LabelId)
                .OnDelete(DeleteBehavior.Restrict);

            // Prevent duplicate mapping
            modelBuilder.Entity<NoteLabel>()
                .HasIndex(nl => new { nl.NoteId, nl.LabelId })
                .IsUnique();
        }
    }
}