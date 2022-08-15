using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Features.Contact.Command.DeleteContact;

namespace PhoneBook.API.EndPoints.ContactEndPoints
{
    public class DeleteContact : EndpointBaseAsync.WithRequest<DeleteContactRequest>.WithActionResult
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public DeleteContact(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [Authorize]
        [HttpDelete("DeleteContact")]
        public override async Task<ActionResult> HandleAsync(DeleteContactRequest request, CancellationToken cancellationToken = default)
        {
            var input = _mapper.Map<DeleteContactInput>(request);
            await _mediator.Send(input);
            return NoContent();
        }
    }
}

