using Business.Interface;
using Models.Entity;
using Repository.Interface;

namespace Business.Service;

public class ContactBusiness : IContactBusiness
{
    private readonly IContactRepository _contactRepository;

    public ContactBusiness(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<IEnumerable<Contact>> GetAllContactsAsync()
    {
        return await _contactRepository.GetAllContactsAsync();
    }

    public async Task<Contact?> GetContactByIdAsync(int id)
    {
        return await _contactRepository.GetContactByIdAsync(id);
    }

    public async Task<Contact> AddContactAsync(Contact contact)
    {
        return await _contactRepository.AddContactAsync(contact);
    }

    public async Task<Contact> UpdateContactAsync(Contact contact)
    {
        return await _contactRepository.UpdateContactAsync(contact);
    }

    public async Task<bool> DeleteContactAsync(int id)
    {
        return await _contactRepository.DeleteContactAsync(id);
    }
}