using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts;
using Contactt = PhoneBook.Domain.Contact;

namespace PhoneBook.Application.Features.Contact.Command.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactInput, Guid>
    {
        private readonly IContactRepository _contactReposirory;
        private readonly IMapper _mapper;
        public CreateContactCommandHandler(IContactRepository contactReposirory, IMapper mapper)
        {
            _contactReposirory = contactReposirory;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateContactInput request, CancellationToken cancellationToken)
        {
            var contact = _mapper.Map<Contactt>(request);
            CreateCommandValidator validator = new CreateCommandValidator();
            var res = await validator.ValidateAsync(request);
            if(res.Errors.Any())
            {
                throw new Exception("Contact is not valid!");
            }
            contact = await _contactReposirory.AddAsync(contact);
            return contact.Id;
        }
    }
}
