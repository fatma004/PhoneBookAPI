using MediatR;

namespace PhoneBook.Application.Features.Contact.Command.DeleteContact
{
    public class DeleteContactInput : IRequest
    {
        public Guid ContactId { get; set; }
    }
}
