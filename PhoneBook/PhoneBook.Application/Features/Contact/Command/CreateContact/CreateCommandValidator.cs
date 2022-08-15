using FluentValidation;

namespace PhoneBook.Application.Features.Contact.Command.CreateContact
{
    public class CreateCommandValidator : AbstractValidator<CreateContactInput>
    {
        public CreateCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(25);
            RuleFor(c => c.PhoneNumber)
                 .NotEmpty()
                 .NotNull();
        }
    }
}
