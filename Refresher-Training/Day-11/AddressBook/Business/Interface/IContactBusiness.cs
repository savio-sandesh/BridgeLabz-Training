using Models.DTO;

namespace Business.Interface;

/// <summary>
/// Defines business operations for managing contacts.
/// </summary>
public interface IContactBusiness
{
    /// <summary>
    /// Retrieves all contacts.
    /// </summary>
    Task<IEnumerable<ContactResponseDto>> GetAllContactsAsync();

    /// <summary>
    /// Retrieves a contact by its ID.
    /// </summary>
    Task<ContactResponseDto> GetContactByIdAsync(int id);

    /// <summary>
    /// Creates a new contact.
    /// </summary>
    Task<ContactResponseDto> AddContactAsync(CreateContactDto contactDto);

    /// <summary>
    /// Updates an existing contact.
    /// </summary>
    Task<ContactResponseDto> UpdateContactAsync(
        int id,
        UpdateContactDto contactDto);

    /// <summary>
    /// Deletes a contact by its ID.
    /// </summary>
    Task<bool> DeleteContactAsync(int id);
}