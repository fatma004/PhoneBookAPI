using MediatR;

namespace PhoneBook.Application.Features.Contact.Command.UpdateContact
{
    public class UpdateContactInput :IRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? PicturePath { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string UserId { get; set; }
    }
}
