using ContactsApp.Model;

namespace ContactsApp.Interface;

/// <summary>
/// Defines data access operations for contacts.
/// </summary>
public interface IContactRepository
{
    /// <summary>
    /// Retrieves all contacts.
    /// </summary>
    Task<List<Contact>> GetAllContactsAsync();

    /// <summary>
    /// Retrieves a contact by its identifier.
    /// </summary>
    Task<Contact?> GetContactByIdAsync(int contactId);

    /// <summary>
    /// Adds a new contact.
    /// </summary>
    Task<int> AddContactAsync(Contact contact);

    /// <summary>
    /// Updates an existing contact.
    /// </summary>
    Task<bool> UpdateContactAsync(Contact contact);

    /// <summary>
    /// Deletes a contact by its identifier.
    /// </summary>
    Task<bool> DeleteContactAsync(int contactId);
}