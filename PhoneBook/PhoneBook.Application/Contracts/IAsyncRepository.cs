
namespace PhoneBook.Application.Contracts
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T>GetByAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);

    }
}
