using Fimple.FinalCase.Core.Features.SupportTickets.Commands.Create;
using Fimple.FinalCase.Core.Features.SupportTickets.Commands.Respond;
using Fimple.FinalCase.Core.Features.SupportTickets.Queries.GetOpenSupportTickets;
using Fimple.FinalCase.Core.Features.SupportTickets.Queries.GetSupportTicketsForAnswering;
using Fimple.FinalCase.Core.Features.SupportTickets.Queries.GetSupportTicketsForAsking;
using Microsoft.AspNetCore.Mvc;

namespace Fimple.FinalCase.Adapter.WebAPI.Controllers;


[ApiController]
[Route("api/support-tickets")]
public class SupportTicketController : BaseController
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateSupportTicket([FromBody] CreateSupportTicketCommand command)
    {
        int ticketId = await Mediator.Send(command);
        return Ok(ticketId);
    }

    [HttpPost("respond")]
    public async Task<IActionResult> RespondToSupportTicket([FromBody] RespondToSupportTicketCommand command)
    {
        bool response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpGet("get-for-asking/{askingId}")]
    public async Task<IActionResult> GetSupportTicketsForAsking(int askingId)
    {
        var query = new GetSupportTicketsForAskingQuery { AskingId = askingId };
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("get-for-answering/{answeringId}")]
    public async Task<IActionResult> GetSupportTicketsForAnswering(int answeringId)
    {
        var query = new GetSupportTicketsForAnsweringQuery { AnsweringId = answeringId };
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("get-open-tickets")]
    public async Task<IActionResult> GetOpenSupportTickets()
    {
        var query = new GetOpenSupportTicketsQuery();
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}
