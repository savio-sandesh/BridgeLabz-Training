using ContactApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Data;

/// <summary>
/// Represents the Entity Framework Core database context for the Contacts application.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppDbContext"/> class.
    /// </summary>
    /// <param name="options">
    /// The configuration options for the database context.
    /// </param>
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the collection of contact entities.
    /// </summary>
    public DbSet<Contact> Contacts { get; set; }

    /// <summary>
    /// Configures the entity mappings and database table settings.
    /// </summary>
    /// <param name="modelBuilder">
    /// The builder used to configure the entity model.
    /// </param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>()
            .ToTable("Contacts", table =>
                table.UseSqlOutputClause(false));
    }
}