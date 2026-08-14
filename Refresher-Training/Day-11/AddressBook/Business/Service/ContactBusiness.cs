using Business.Interface;
using Models.DTO;
using Models.Entity;
using Models.Exception;
using Repository.Interface;

namespace Business.Service;

/// <summary>
/// Provides business operations for managing contacts.
/// </summary>
public class ContactBusiness : IContactBusiness
{
    private readonly IContactRepository _contactRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactBusiness"/> class.
    /// </summary>
    /// <param name="contactRepository">
    /// The contact repository used to perform data access operations.
    /// </param>
    public ContactBusiness(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    /// <summary>
    /// Retrieves all contacts and converts them to response DTOs.
    /// </summary>
    public async Task<IEnumerable<ContactResponseDto>> GetAllContactsAsync()
    {
        var contacts = await _contactRepository.GetAllContactsAsync();

        return contacts.Select(contact => new ContactResponseDto
        {
            Id = contact.Id,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            PhoneNumber = contact.PhoneNumber,
            Email = contact.Email,
            Address = contact.Address
        });
    }

    /// <summary>
    /// Retrieves a contact by ID and converts it to a response DTO.
    /// </summary>
    public async Task<ContactResponseDto> GetContactByIdAsync(int id)
    {
        var contact = await _contactRepository.GetContactByIdAsync(id);

        if (contact == null)
        {
            throw new ContactNotFoundException(id);
        }

        return new ContactResponseDto
        {
            Id = contact.Id,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            PhoneNumber = contact.PhoneNumber,
            Email = contact.Email,
            Address = contact.Address
        };
    }

    /// <summary>
    /// Creates a new contact from the provided DTO.
    /// </summary>
    public async Task<ContactResponseDto> AddContactAsync(
        CreateContactDto contactDto)
    {
        var contact = new Contact
        {
            FirstName = contactDto.FirstName,
            LastName = contactDto.LastName,
            PhoneNumber = contactDto.PhoneNumber,
            Email = contactDto.Email,
            Address = contactDto.Address
        };

        var createdContact =
            await _contactRepository.AddContactAsync(contact);

        return new ContactResponseDto
        {
            Id = createdContact.Id,
            FirstName = createdContact.FirstName,
            LastName = createdContact.LastName,
            PhoneNumber = createdContact.PhoneNumber,
            Email = createdContact.Email,
            Address = createdContact.Address
        };
    }

    /// <summary>
    /// Updates an existing contact using the provided DTO.
    /// </summary>
    public async Task<ContactResponseDto> UpdateContactAsync(
        int id,
        UpdateContactDto contactDto)
    {
        var existingContact =
            await _contactRepository.GetContactByIdAsync(id);

        if (existingContact == null)
        {
            throw new ContactNotFoundException(id);
        }

        existingContact.FirstName = contactDto.FirstName;
        existingContact.LastName = contactDto.LastName;
        existingContact.PhoneNumber = contactDto.PhoneNumber;
        existingContact.Email = contactDto.Email;
        existingContact.Address = contactDto.Address;

        var updatedContact =
            await _contactRepository.UpdateContactAsync(existingContact);

        return new ContactResponseDto
        {
            Id = updatedContact.Id,
            FirstName = updatedContact.FirstName,
            LastName = updatedContact.LastName,
            PhoneNumber = updatedContact.PhoneNumber,
            Email = updatedContact.Email,
            Address = updatedContact.Address
        };
    }

    /// <summary>
    /// Deletes a contact by ID.
    /// </summary>
    public async Task<bool> DeleteContactAsync(int id)
    {
        var existingContact =
            await _contactRepository.GetContactByIdAsync(id);

        if (existingContact == null)
        {
            throw new ContactNotFoundException(id);
        }

        return await _contactRepository.DeleteContactAsync(id);
    }
}