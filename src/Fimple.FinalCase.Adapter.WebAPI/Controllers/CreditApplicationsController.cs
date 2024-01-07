using Fimple.FinalCase.Core.Features.CreditApplications.Commands.Create;
using Fimple.FinalCase.Core.Features.CreditApplications.Commands.Delete;
using Fimple.FinalCase.Core.Features.CreditApplications.Commands.Update;
using Fimple.FinalCase.Core.Features.CreditApplications.Queries.GetById;
using Fimple.FinalCase.Core.Features.CreditApplications.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace Fimple.FinalCase.Adapter.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreditApplicationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCreditApplicationCommand createCreditApplicationCommand)
    {
        CreatedCreditApplicationResponse response = await Mediator.Send(createCreditApplicationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCreditApplicationCommand updateCreditApplicationCommand)
    {
        UpdatedCreditApplicationResponse response = await Mediator.Send(updateCreditApplicationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCreditApplicationResponse response = await Mediator.Send(new DeleteCreditApplicationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCreditApplicationResponse response = await Mediator.Send(new GetByIdCreditApplicationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetListAsync([FromQuery] GetListCreditApplicationQuery request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
}