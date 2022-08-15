using AutoMapper;
using MediatR;
using PhoneBook.Application.Contracts;

namespace PhoneBook.Application.Features.UserAccount.Query.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginInput, LoginOutput>
    {
        private readonly IUserAccountRepository _userAccountReposirory;
        private readonly IMapper _mapper;
        public LoginQueryHandler(IUserAccountRepository userAccountReposirory, IMapper mapper)
        {
            _userAccountReposirory = userAccountReposirory;
            _mapper = mapper;
        }
        public async Task<LoginOutput> Handle(LoginInput request, CancellationToken cancellationToken)
        {
            var loginInput = _mapper.Map<LoginInput>(request);
            var loginOutput = await _userAccountReposirory.LoginAsync(loginInput);
            return loginOutput;
        }
    }
}
