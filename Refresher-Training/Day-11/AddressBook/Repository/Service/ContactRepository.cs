using Microsoft.EntityFrameworkCore;
using Models.Entity;
using Repository.Context;
using Repository.Interface;

namespace Repository.Service;

public class ContactRepository : IContactRepository
{
    private readonly AddressBookContext _context;

    public ContactRepository(AddressBookContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contact>> GetAllContactsAsync()
    {
        return await _context.Contacts.ToListAsync();
    }

    public async Task<Contact?> GetContactByIdAsync(int id)
    {
        return await _context.Contacts
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Contact> AddContactAsync(Contact contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();

        return contact;
    }

    public async Task<Contact> UpdateContactAsync(Contact contact)
    {
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();

        return contact;
    }

    public async Task<bool> DeleteContactAsync(int id)
    {
        var contact = await _context.Contacts
            .FirstOrDefaultAsync(c => c.Id == id);

        if (contact == null)
        {
            return false;
        }

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();

        return true;
    }
}