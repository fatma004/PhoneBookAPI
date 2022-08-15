using PhoneBook.Domain;


namespace PhoneBook.Application.Contracts
{
    public interface IContactRepository : IAsyncRepository<Contact>
    {
        Task<IReadOnlyList<Contact>> GetAllContactsAsync();
        Task<Contact>GetContactByIdAsync(Guid id);
        Task<IReadOnlyList<Contact>> GtAllContactsOfUser(string UserId);
    }
}
