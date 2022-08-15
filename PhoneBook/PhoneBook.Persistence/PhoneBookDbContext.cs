using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain;
namespace PhoneBook.Persistence
{
    public class PhoneBookDbContext : IdentityDbContext<SeUser>
    {
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options)
            :base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
