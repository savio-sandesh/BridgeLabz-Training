using Microsoft.EntityFrameworkCore;
using Models.Entity;

namespace Repository.Context;

/// <summary>
/// Represents the database context for the Address Book application.
/// </summary>
public class AddressBookContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddressBookContext"/> class.
    /// </summary>
    /// <param name="options">The options used to configure the database context.</param>
    public AddressBookContext(DbContextOptions<AddressBookContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the Contacts table.
    /// </summary>
    public DbSet<Contact> Contacts { get; set; }
}