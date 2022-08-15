using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Features.Contact.Query.GetContactsList;

namespace PhoneBook.API.EndPoints.ContactEndPoints
{
    public class GetUserContacts : EndpointBaseAsync.WithRequest<string>.WithActionResult<List<GetUserContactsResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetUserContacts(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpGet("GetContactsOfUser/{UserId}")]
        public override async Task<ActionResult<List<GetUserContactsResponse>>> HandleAsync([FromRoute] string UserId, CancellationToken cancellationToken = default)
        {

            var input = new GetUserContactsInput() { UserId = UserId };
            var output =await _mediator.Send(input);
            var res = new List<GetUserContactsResponse>();
            foreach(var c in output)
            {
                res.Add(_mapper.Map<GetUserContactsResponse>(c));
            }
            return Ok( res);
        }
    }
}