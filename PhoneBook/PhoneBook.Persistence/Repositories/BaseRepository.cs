using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Contracts;

namespace PhoneBook.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly PhoneBookDbContext _dbContext;
        public BaseRepository(PhoneBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T Entity)
        {
            await _dbContext.Set<T>().AddAsync(Entity);
            await _dbContext.SaveChangesAsync();
            return Entity;
        }
        public  async Task DeleteAsync(T Entity)
        {
             _dbContext.Set<T>().Remove(Entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetByAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State= EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
