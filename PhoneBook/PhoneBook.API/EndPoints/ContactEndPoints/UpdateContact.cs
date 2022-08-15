using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Features.Contact.Command.UpdateContact;

namespace PhoneBook.API.EndPoints.ContactEndPoints
{
    public class UpdateContact : EndpointBaseAsync.WithRequest<UpdateContactRequest>.WithActionResult
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public UpdateContact(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [Authorize]
        [HttpPut("UpdateContact")]
        public override async Task<ActionResult> HandleAsync(UpdateContactRequest request, CancellationToken cancellationToken = default)
        {
            var input = _mapper.Map<UpdateContactInput>(request);
            await _mediator.Send(input);
            return NoContent();
        }
    }
}