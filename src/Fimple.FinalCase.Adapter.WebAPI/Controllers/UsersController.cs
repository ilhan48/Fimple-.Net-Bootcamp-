using Fimple.FinalCase.Core.Features.Users.Commands.Create;
using Fimple.FinalCase.Core.Features.Users.Commands.Delete;
using Fimple.FinalCase.Core.Features.Users.Commands.Update;
using Fimple.FinalCase.Core.Features.Users.Commands.UpdateFromAuth;
using Fimple.FinalCase.Core.Features.Users.Queries.GetById;
using Fimple.FinalCase.Core.Features.Users.Queries.GetList;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.AspNetCore.Mvc;

namespace Fimple.FinalCase.Adapter.WebAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UsersController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdUserQuery getByIdUserQuery)
    {
        GetByIdUserResponse result = await Mediator.Send(getByIdUserQuery);
        return Ok(result);
    }

    [HttpGet("GetFromAuth")]
    public async Task<IActionResult> GetFromAuth()
    {
        GetByIdUserQuery getByIdUserQuery = new() { Id = getUserIdFromRequest() };
        GetByIdUserResponse result = await Mediator.Send(getByIdUserQuery);
        return Ok(result);
    }

    [HttpGet("api/users")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserQuery getListUserQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserListItemDto> result = await Mediator.Send(getListUserQuery);
        return Ok(result);
    }

    [HttpPost("api/users")]
    public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommand)
    {
        CreatedUserResponse result = await Mediator.Send(createUserCommand);
        return Created(uri: "", result);
    }

    [HttpPut("api/users")]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
    {
        UpdatedUserResponse result = await Mediator.Send(updateUserCommand);
        return Ok(result);
    }

    [HttpPut("FromAuth")]
    public async Task<IActionResult> UpdateFromAuth([FromBody] UpdateUserFromAuthCommand updateUserFromAuthCommand)
    {
        updateUserFromAuthCommand.Id = getUserIdFromRequest();
        UpdatedUserFromAuthResponse result = await Mediator.Send(updateUserFromAuthCommand);
        return Ok(result);
    }

    [HttpDelete("api/users")]
    public async Task<IActionResult> Delete([FromBody] DeleteUserCommand deleteUserCommand)
    {
        DeletedUserResponse result = await Mediator.Send(deleteUserCommand);
        return Ok(result);
    }
}