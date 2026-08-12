using ContactApp.Data;
using ContactApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Controllers;

/// <summary>
/// Provides API endpoints for managing contact records.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactsController"/> class.
    /// </summary>
    /// <param name="context">
    /// The database context used to access contact records.
    /// </param>
    public ContactsController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves all active contact records from the database.
    /// </summary>
    /// <returns>
    /// A collection of active contacts with an HTTP 200 OK response.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetContacts()
    {
        var contacts = await _context.Contacts
            .Where(c => c.IsActive)
            .ToListAsync();

        return Ok(contacts);
    }

    /// <summary>
    /// Retrieves an active contact by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the contact.</param>
    /// <returns>
    /// The requested contact if found; otherwise, an HTTP 404 Not Found response.
    /// </returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetContactById(int id)
    {
        var contact = await _context.Contacts
            .FirstOrDefaultAsync(c => c.ContactId == id && c.IsActive);

        if (contact == null)
        {
            return NotFound($"Contact with ID {id} was not found.");
        }

        return Ok(contact);
    }

    /// <summary>
    /// Creates a new contact record in the database.
    /// </summary>
    /// <param name="contact">The contact information to create.</param>
    /// <returns>
    /// The newly created contact with an HTTP 201 Created response.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> CreateContact(Contact contact)
    {
        contact.CreatedAt = DateTime.UtcNow;
        contact.IsActive = true;

        _context.Contacts.Add(contact);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetContactById),
            new { id = contact.ContactId },
            contact);
    }

    /// <summary>
    /// Updates an existing active contact record.
    /// </summary>
    /// <param name="id">The unique identifier of the contact to update.</param>
    /// <param name="updatedContact">The updated contact information.</param>
    /// <returns>
    /// The updated contact if found; otherwise, an HTTP 404 Not Found response.
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContact(
        int id,
        Contact updatedContact)
    {
        var contact = await _context.Contacts
            .FirstOrDefaultAsync(c => c.ContactId == id && c.IsActive);

        if (contact == null)
        {
            return NotFound($"Contact with ID {id} was not found.");
        }

        contact.FirstName = updatedContact.FirstName;
        contact.LastName = updatedContact.LastName;
        contact.Email = updatedContact.Email;
        contact.PhoneNumber = updatedContact.PhoneNumber;

        await _context.SaveChangesAsync();

        return Ok(contact);
    }

    /// <summary>
    /// Soft deletes an active contact by setting its IsActive value to false.
    /// The contact record remains in the database.
    /// </summary>
    /// <param name="id">The unique identifier of the contact to deactivate.</param>
    /// <returns>
    /// An HTTP 204 No Content response if the contact is deactivated;
    /// otherwise, an HTTP 404 Not Found response.
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        var contact = await _context.Contacts
            .FirstOrDefaultAsync(c => c.ContactId == id && c.IsActive);

        if (contact == null)
        {
            return NotFound($"Contact with ID {id} was not found.");
        }

        contact.IsActive = false;

        await _context.SaveChangesAsync();

        return NoContent();
    }
}