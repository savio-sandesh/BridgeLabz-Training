using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Entity;

namespace AddressBook.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactBusiness _contactBusiness;

    public ContactsController(IContactBusiness contactBusiness)
    {
        _contactBusiness = contactBusiness;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllContacts()
    {
        var contacts = await _contactBusiness.GetAllContactsAsync();

        return Ok(contacts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContactById(int id)
    {
        var contact = await _contactBusiness.GetContactByIdAsync(id);

        if (contact == null)
        {
            return NotFound();
        }

        return Ok(contact);
    }

    [HttpPost]
    public async Task<IActionResult> AddContact(Contact contact)
    {
        var createdContact = await _contactBusiness.AddContactAsync(contact);

        return Ok(createdContact);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContact(
        int id,
        Contact contact)
    {
        if (id != contact.Id)
        {
            return BadRequest("ID mismatch.");
        }

        var updatedContact = await _contactBusiness.UpdateContactAsync(contact);

        return Ok(updatedContact);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        var deleted = await _contactBusiness.DeleteContactAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return Ok("Contact deleted successfully.");
    }
}