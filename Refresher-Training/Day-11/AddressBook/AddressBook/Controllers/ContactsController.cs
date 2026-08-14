using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;

namespace AddressBook.Controllers;

/// <summary>
/// Provides API endpoints for managing contacts.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactBusiness _contactBusiness;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactsController"/> class.
    /// </summary>
    /// <param name="contactBusiness">
    /// The business service used to manage contacts.
    /// </param>
    public ContactsController(IContactBusiness contactBusiness)
    {
        _contactBusiness = contactBusiness;
    }

    /// <summary>
    /// Retrieves all contacts.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllContacts()
    {
        var contacts = await _contactBusiness.GetAllContactsAsync();

        return Ok(contacts);
    }

    /// <summary>
    /// Retrieves a contact by its ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetContactById(int id)
    {
        var contact = await _contactBusiness.GetContactByIdAsync(id);

        return Ok(contact);
    }

    /// <summary>
    /// Creates a new contact.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> AddContact(
        CreateContactDto contactDto)
    {
        var createdContact =
            await _contactBusiness.AddContactAsync(contactDto);

        return Ok(createdContact);
    }

    /// <summary>
    /// Updates an existing contact.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContact(
        int id,
        UpdateContactDto contactDto)
    {
        var updatedContact =
            await _contactBusiness.UpdateContactAsync(id, contactDto);

        return Ok(updatedContact);
    }

    /// <summary>
    /// Deletes a contact by its ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        var deleted = await _contactBusiness.DeleteContactAsync(id);

        return Ok("Contact deleted successfully.");
    }
}