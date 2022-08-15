using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Features.Contact.Query.GetContactDetails;

namespace PhoneBook.API.EndPoints.ContactEndPoints
{
    public class GetContactDetails : EndpointBaseAsync.WithRequest<Guid>.WithActionResult<GetContactDetailsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetContactDetails(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpGet("GetContactDetails/{ContactId:Guid}")]
        public override async Task<ActionResult<GetContactDetailsResponse>> HandleAsync([FromRoute] Guid ContactId, CancellationToken cancellationToken = default)
        {
            var x = ContactId;
            var input = new GetContactDetailsInput() { ContactId = ContactId };
            var output = (await _mediator.Send(input));
            return Ok(_mapper.Map<GetContactDetailsResponse>(output));
        }
    }
}

