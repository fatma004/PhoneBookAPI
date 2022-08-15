using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts;

namespace PhoneBook.Application.Features.Contact.Query.GetContactsList
{
    public class GetUserContactsQueryHandler : IRequestHandler<GetUserContactsInput, List<GetUserContactsOutput>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public GetUserContactsQueryHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<List<GetUserContactsOutput>> Handle(GetUserContactsInput request, CancellationToken cancellationToken)
        {
            var allContacts = await _contactRepository.GtAllContactsOfUser(request.UserId);
            return _mapper.Map<List<GetUserContactsOutput>>(allContacts);
        }
    }
}
