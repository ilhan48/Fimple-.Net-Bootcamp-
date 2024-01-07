using Fimple.FinalCase.Core.Features.AutomaticPayments.Commands.Create;
using Fimple.FinalCase.Core.Features.AutomaticPayments.Commands.Delete;
using Fimple.FinalCase.Core.Features.AutomaticPayments.Commands.Update;
using Fimple.FinalCase.Core.Features.AutomaticPayments.Queries.GetById;
using Fimple.FinalCase.Core.Features.AutomaticPayments.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace Fimple.FinalCase.Adapter.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutomaticPaymentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAutomaticPaymentCommand createAutomaticPaymentCommand)
    {
        CreatedAutomaticPaymentResponse response = await Mediator.Send(createAutomaticPaymentCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAutomaticPaymentCommand updateAutomaticPaymentCommand)
    {
        UpdatedAutomaticPaymentResponse response = await Mediator.Send(updateAutomaticPaymentCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAutomaticPaymentResponse response = await Mediator.Send(new DeleteAutomaticPaymentCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAutomaticPaymentResponse response = await Mediator.Send(new GetByIdAutomaticPaymentQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListAutomaticPaymentQuery getListAutomaticPaymentQuery)
    {
        var response = await Mediator.Send(getListAutomaticPaymentQuery);
        return Ok(response);
    }
}