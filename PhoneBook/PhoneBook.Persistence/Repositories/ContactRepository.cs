using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Contracts;
using PhoneBook.Domain;

namespace PhoneBook.Persistence.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(PhoneBookDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Contact>> GetAllContactsAsync()
        {
            List<Contact> allContacts = await _dbContext.Contacts.ToListAsync();
            return allContacts;
        }

        public async Task<Contact> GetContactByIdAsync(Guid id)
        {
            Contact contact = await GetByAsync(id);
            return contact;
        }

        public async Task<IReadOnlyList<Contact>> GtAllContactsOfUser(string UserId)
        {
            List<Contact> allContactsOfUser = await _dbContext.Contacts.Where(c => c.UserId == UserId).ToListAsync();
            return allContactsOfUser;
        }
    }
}
