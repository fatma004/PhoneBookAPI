using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Application.Features.UserAccount.Command.CreateUserAccount
{
    public class CreateUserAccountInput : IRequest<CreateUserAccountOutput> 
    {
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }

    }
}
