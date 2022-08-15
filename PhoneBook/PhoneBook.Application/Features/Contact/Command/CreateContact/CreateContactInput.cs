

using MediatR;

namespace PhoneBook.Application.Features.Contact.Command.CreateContact
{
    public class CreateContactInput :IRequest<Guid>
    {
        public string? Name { get; set; }
        public string? PicturePath { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string UserId { get; set; }
    }
}
