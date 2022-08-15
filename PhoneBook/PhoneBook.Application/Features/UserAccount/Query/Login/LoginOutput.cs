

namespace PhoneBook.Application.Features.UserAccount.Query.Login
{
    public class LoginOutput
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string? Message { get;set; }

    }
}
