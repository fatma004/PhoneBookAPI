using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Features.UserAccount.Command.CreateUserAccount;

namespace PhoneBook.API.EndPoints.UserEndPoints
{
    public class CreateUserAccount : EndpointBaseAsync.WithRequest<CreateUserAccountRequest>.WithActionResult<CreateUserAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateUserAccount(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public override async Task<ActionResult<CreateUserAccountResponse>> HandleAsync([FromBody] CreateUserAccountRequest request, CancellationToken cancellationToken = default)
        {
            var input = _mapper.Map<CreateUserAccountInput>(request);
            var output = await _mediator.Send(input);
            return Ok(_mapper.Map<CreateUserAccountResponse>(output));
        }
    }
}
