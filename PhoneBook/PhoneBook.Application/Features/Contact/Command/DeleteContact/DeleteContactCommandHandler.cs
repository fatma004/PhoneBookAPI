using Contactt = PhoneBook.Domain.Contact;
using MediatR;
using PhoneBook.Application.Contracts;
using AutoMapper;

namespace PhoneBook.Application.Features.Contact.Command.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactInput>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public DeleteContactCommandHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteContactInput request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetContactByIdAsync(request.ContactId);
            await _contactRepository.DeleteAsync(contact); 
            return Unit.Value;
        }
    }
}
