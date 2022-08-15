using PhoneBook.Application.Features.UserAccount.Query.Login;
using PhoneBook.Domain;

namespace PhoneBook.Application.Contracts
{
    public interface IUserAccountRepository : IAsyncRepository<SeUser>
    {
        public  Task<string> CreateJwtToken(SeUser user);
        public Task<LoginOutput> LoginAsync(LoginInput loginInput);
    }
}
