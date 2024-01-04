using Fimple.FinalCase.Core.Features.OperationClaims.Commands.Create;
using Fimple.FinalCase.Core.Features.OperationClaims.Commands.Delete;
using Fimple.FinalCase.Core.Features.OperationClaims.Commands.Update;
using Fimple.FinalCase.Core.Features.OperationClaims.Queries.GetById;
using Fimple.FinalCase.Core.Features.OperationClaims.Queries.GetList;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.AspNetCore.Mvc;

namespace Fimple.FinalCase.Adapter.WebAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class OperationClaimsController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdOperationClaimQuery getByIdOperationClaimQuery)
    {
        GetByIdOperationClaimResponse result = await Mediator.Send(getByIdOperationClaimQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListOperationClaimListItemDto> result = await Mediator.Send(getListOperationClaimQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
    {
        CreatedOperationClaimResponse result = await Mediator.Send(createOperationClaimCommand);
        return Created(uri: "", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
    {
        UpdatedOperationClaimResponse result = await Mediator.Send(updateOperationClaimCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
    {
        DeletedOperationClaimResponse result = await Mediator.Send(deleteOperationClaimCommand);
        return Ok(result);
    }
}
