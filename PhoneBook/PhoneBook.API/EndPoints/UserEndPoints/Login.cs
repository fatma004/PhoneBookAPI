using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Features.UserAccount.Query.Login;

namespace PhoneBook.API.EndPoints.UserEndPoints
{
    public class Login : EndpointBaseAsync.WithRequest<LoginRequest>.WithActionResult<LoginResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public Login(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost("Login")]
        public override async Task<ActionResult<LoginResponse>> HandleAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            var input = _mapper.Map<LoginInput>(request);
            var output = await _mediator.Send(input);
            var response = _mapper.Map<LoginResponse>(output);
            return Ok(response);
        }
    }
}
