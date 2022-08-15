

using MediatR;

namespace PhoneBook.Application.Features.UserAccount.Query.Login
{
    public class LoginInput : IRequest<LoginOutput>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
