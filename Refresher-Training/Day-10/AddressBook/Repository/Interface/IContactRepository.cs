using Models.Entity;

namespace Repository.Interface;

/// <summary>
/// Defines the operations available for managing contacts.
/// </summary>
public interface IContactRepository
{
    /// <summary>
    /// Retrieves all contacts.
    /// </summary>
    /// <returns>A collection of contacts.</returns>
    Task<IEnumerable<Contact>> GetAllContactsAsync();

    /// <summary>
    /// Retrieves a contact by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the contact.</param>
    /// <returns>The contact if found; otherwise, null.</returns>
    Task<Contact?> GetContactByIdAsync(int id);

    /// <summary>
    /// Adds a new contact.
    /// </summary>
    /// <param name="contact">The contact to add.</param>
    /// <returns>The newly added contact.</returns>
    Task<Contact> AddContactAsync(Contact contact);

    /// <summary>
    /// Updates an existing contact.
    /// </summary>
    /// <param name="contact">The contact to update.</param>
    /// <returns>The updated contact.</returns>
    Task<Contact> UpdateContactAsync(Contact contact);

    /// <summary>
    /// Deletes a contact by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the contact.</param>
    /// <returns>True if the contact was deleted; otherwise, false.</returns>
    Task<bool> DeleteContactAsync(int id);
}