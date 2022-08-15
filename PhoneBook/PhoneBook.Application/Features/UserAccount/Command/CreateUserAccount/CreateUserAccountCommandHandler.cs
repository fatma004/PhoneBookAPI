using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts;
using PhoneBook.Domain;

namespace PhoneBook.Application.Features.UserAccount.Command.CreateUserAccount
{
    public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountInput, CreateUserAccountOutput>
    {
        private readonly IUserAccountRepository _userAccountReposirory;
        private readonly IMapper _mapper;
        public CreateUserAccountCommandHandler(IUserAccountRepository userAccountReposirory, IMapper mapper)
        {
            _userAccountReposirory = userAccountReposirory;
            _mapper = mapper;
        }
        public async Task<CreateUserAccountOutput> Handle(CreateUserAccountInput request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<SeUser>(request);
            CreateUserAccountCommandValidator validator = new CreateUserAccountCommandValidator();
            var res = await validator.ValidateAsync(request);
            if (res.Errors.Any())
            {
                throw new Exception("Failed to create user account.");
            }
            user = await _userAccountReposirory.AddAsync(user);
            var token = await _userAccountReposirory.CreateJwtToken(user);
            return new CreateUserAccountOutput() { Token = token };
        }


    }
}
