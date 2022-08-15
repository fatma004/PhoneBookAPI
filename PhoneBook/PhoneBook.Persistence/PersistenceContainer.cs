using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Application.Configuration;
using PhoneBook.Application.Contracts;
using PhoneBook.Domain;
using PhoneBook.Persistence.Repositories;

namespace PhoneBook.Persistence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PhoneBookDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("PhoneBookConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IContactRepository), typeof(ContactRepository));
            services.AddScoped(typeof(IUserAccountRepository), typeof(UserAccountRepository));
            services.AddIdentity<SeUser, IdentityRole>().AddEntityFrameworkStores<PhoneBookDbContext>().AddDefaultTokenProviders();


            return services;
        }
    }
}
