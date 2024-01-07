using Fimple.FinalCase.Core.Features.Transfers.Commands.Create;
using Fimple.FinalCase.Core.Features.Transfers.Commands.Delete;
using Fimple.FinalCase.Core.Features.Transfers.Commands.Update;
using Fimple.FinalCase.Core.Features.Transfers.Queries.GetById;
using Fimple.FinalCase.Core.Features.Transfers.Queries.GetList;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.AspNetCore.Mvc;

namespace Fimple.FinalCase.Adapter.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransfersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTransferCommand createTransferCommand)
    {
        CreatedTransferResponse response = await Mediator.Send(createTransferCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTransferCommand updateTransferCommand)
    {
        UpdatedTransferResponse response = await Mediator.Send(updateTransferCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedTransferResponse response = await Mediator.Send(new DeleteTransferCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdTransferResponse response = await Mediator.Send(new GetByIdTransferQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTransferQuery getListTransferQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTransferListItemDto> response = await Mediator.Send(getListTransferQuery);
        return Ok(response);
    }
}