using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Features.Contact.Command.CreateContact;

namespace PhoneBook.API.EndPoints.ContactEndPoints
{
    public class CreateContact : EndpointBaseAsync.WithRequest<CreateContactRequest>.WithActionResult<System.Guid>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CreateContact(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [Authorize]
        [HttpPost("AddContact")]
        public override async Task<ActionResult<System.Guid>> HandleAsync(CreateContactRequest request, CancellationToken cancellationToken = default)
        {
            var input = _mapper.Map<CreateContactInput>(request);
            System.Guid id = await _mediator.Send(input);
            return Ok(id);
        }
    }
}