using FluentValidation;

namespace PhoneBook.Application.Features.UserAccount.Command.CreateUserAccount
{
    public class CreateUserAccountCommandValidator : AbstractValidator<CreateUserAccountInput>
    {
        public CreateUserAccountCommandValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .NotNull()
                .MaximumLength(25);
        }
    }
}
