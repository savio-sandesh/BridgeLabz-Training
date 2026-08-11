using ContactsApp.Interface;
using ContactsApp.Model;

namespace ContactsApp.Service;

/// <summary>
/// Provides application-level contact operations.
/// </summary>
public class ContactService : IContactService
{
    private readonly IContactRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactService"/> class.
    /// </summary>
    public ContactService(IContactRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Retrieves all contacts.
    /// </summary>
    public async Task<List<Contact>> GetAllContactsAsync()
    {
        return await _repository.GetAllContactsAsync();
    }

    /// <summary>
    /// Retrieves a contact by identifier.
    /// </summary>
    public async Task<Contact?> GetContactByIdAsync(int contactId)
    {
        if (contactId <= 0)
        {
            throw new ArgumentException(
                "Contact ID must be greater than zero."
            );
        }

        return await _repository.GetContactByIdAsync(contactId);
    }

    /// <summary>
    /// Adds a new contact after validating required fields.
    /// </summary>
    public async Task<int> AddContactAsync(Contact contact)
    {
        if (string.IsNullOrWhiteSpace(contact.FirstName))
        {
            throw new ArgumentException("First name is required.");
        }

        if (string.IsNullOrWhiteSpace(contact.LastName))
        {
            throw new ArgumentException("Last name is required.");
        }

        if (string.IsNullOrWhiteSpace(contact.Email))
        {
            throw new ArgumentException("Email is required.");
        }

        if (string.IsNullOrWhiteSpace(contact.PhoneNumber))
        {
            throw new ArgumentException("Phone number is required.");
        }

        return await _repository.AddContactAsync(contact);
    }

    /// <summary>
    /// Updates an existing contact after validating required fields.
    /// </summary>
    public async Task<bool> UpdateContactAsync(Contact contact)
    {
        if (contact.ContactId <= 0)
        {
            throw new ArgumentException(
                "Contact ID must be greater than zero."
            );
        }


        if (string.IsNullOrWhiteSpace(contact.FirstName))
        {
            throw new ArgumentException(
                "First name is required."
            );
        }


        if (string.IsNullOrWhiteSpace(contact.LastName))
        {
            throw new ArgumentException(
                "Last name is required."
            );
        }


        if (string.IsNullOrWhiteSpace(contact.Email))
        {
            throw new ArgumentException(
                "Email is required."
            );
        }


        if (string.IsNullOrWhiteSpace(contact.PhoneNumber))
        {
            throw new ArgumentException(
                "Phone number is required."
            );
        }


        return await _repository.UpdateContactAsync(contact);
    }

    /// <summary>
    /// Deletes a contact by identifier.
    /// </summary>
    public async Task<bool> DeleteContactAsync(int contactId)
    {
        if (contactId <= 0)
        {
            throw new ArgumentException(
                "Contact ID must be greater than zero."
            );
        }


        return await _repository.DeleteContactAsync(contactId);
    }
}