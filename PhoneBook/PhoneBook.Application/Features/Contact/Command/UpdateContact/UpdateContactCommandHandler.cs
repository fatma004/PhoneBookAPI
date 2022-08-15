using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts;
using Contactt = PhoneBook.Domain.Contact;

namespace PhoneBook.Application.Features.Contact.Command.UpdateContact
{
    public class UpdateContactCommandHandler :IRequestHandler<UpdateContactInput>
    {
        private readonly IAsyncRepository<Contactt> _contactRepository;
        private readonly IMapper _mapper;
        public UpdateContactCommandHandler(IAsyncRepository<Contactt> contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateContactInput request, CancellationToken cancellationToken)
        {
            Contactt contact = _mapper.Map<Contactt>(request);
            await _contactRepository.UpdateAsync(contact);
            return Unit.Value;
        }
    }
}
