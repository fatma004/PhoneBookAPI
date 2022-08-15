using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts;

namespace PhoneBook.Application.Features.Contact.Query.GetContactDetails
{
    public class GetContactDetailsQueryHandler : IRequestHandler<GetContactDetailsInput, GetContactDetailsOutput>
    {
        private readonly IContactRepository _contactReposirory;
        private readonly IMapper _mapper;
        public GetContactDetailsQueryHandler(IContactRepository contactReposirory, IMapper mapper)
        {
            _contactReposirory = contactReposirory;
            _mapper = mapper;
        }

        public async Task<GetContactDetailsOutput> Handle(GetContactDetailsInput request, CancellationToken cancellationToken)
        {
            var Contact = await _contactReposirory.GetContactByIdAsync(request.ContactId);
            return _mapper.Map<GetContactDetailsOutput>(Contact);
        }
    }
}
