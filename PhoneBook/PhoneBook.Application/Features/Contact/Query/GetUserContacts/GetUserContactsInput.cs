using MediatR;


namespace PhoneBook.Application.Features.Contact.Query.GetContactsList
{
    public class GetUserContactsInput : IRequest<List<GetUserContactsOutput>>
    {
         public string UserId { get; set; }
    }
}
