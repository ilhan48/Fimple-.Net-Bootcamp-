using Fimple.FinalCase.Core.Features.Processes.Commands.Create;
using Fimple.FinalCase.Core.Features.Processes.Commands.Delete;
using Fimple.FinalCase.Core.Features.Processes.Commands.Update;
using Fimple.FinalCase.Core.Features.Processes.Queries.GetById;
using Fimple.FinalCase.Core.Features.Processes.Queries.GetList;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.AspNetCore.Mvc;

namespace Fimple.FinalCase.Adapter.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProcessesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProcessCommand createProcessCommand)
    {
        CreatedProcessResponse response = await Mediator.Send(createProcessCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProcessCommand updateProcessCommand)
    {
        UpdatedProcessResponse response = await Mediator.Send(updateProcessCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProcessResponse response = await Mediator.Send(new DeleteProcessCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProcessResponse response = await Mediator.Send(new GetByIdProcessQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProcessQuery getListProcessQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProcessListItemDto> response = await Mediator.Send(getListProcessQuery);
        return Ok(response);
    }
}