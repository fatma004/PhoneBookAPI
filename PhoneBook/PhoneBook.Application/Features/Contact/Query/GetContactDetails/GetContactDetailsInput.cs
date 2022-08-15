using MediatR;

namespace PhoneBook.Application.Features.Contact.Query.GetContactDetails
{
    public class GetContactDetailsInput : IRequest<GetContactDetailsOutput>
    {
        public Guid ContactId { get; set; }
    }
}
