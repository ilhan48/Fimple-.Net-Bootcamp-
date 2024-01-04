using Fimple.FinalCase.Core.Features.UserOperationClaims.Commands.Create;
using Fimple.FinalCase.Core.Features.UserOperationClaims.Commands.Delete;
using Fimple.FinalCase.Core.Features.UserOperationClaims.Commands.Update;
using Fimple.FinalCase.Core.Features.UserOperationClaims.Queries.GetById;
using Fimple.FinalCase.Core.Features.UserOperationClaims.Queries.GetList;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.AspNetCore.Mvc;

namespace Fimple.FinalCase.Adapter.WebAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UserOperationClaimsController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdUserOperationClaimQuery getByIdUserOperationClaimQuery)
    {
        GetByIdUserOperationClaimResponse result = await Mediator.Send(getByIdUserOperationClaimQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserOperationClaimQuery getListUserOperationClaimQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserOperationClaimListItemDto> result = await Mediator.Send(getListUserOperationClaimQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
    {
        CreatedUserOperationClaimResponse result = await Mediator.Send(createUserOperationClaimCommand);
        return Created(uri: "", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
    {
        UpdatedUserOperationClaimResponse result = await Mediator.Send(updateUserOperationClaimCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
    {
        DeletedUserOperationClaimResponse result = await Mediator.Send(deleteUserOperationClaimCommand);
        return Ok(result);
    }
}
