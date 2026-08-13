using Models.Entity;

namespace Business.Interface;

public interface IContactBusiness
{
    Task<IEnumerable<Contact>> GetAllContactsAsync();

    Task<Contact?> GetContactByIdAsync(int id);

    Task<Contact> AddContactAsync(Contact contact);

    Task<Contact> UpdateContactAsync(Contact contact);

    Task<bool> DeleteContactAsync(int id);
}