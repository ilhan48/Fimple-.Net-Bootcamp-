using Fimple.FinalCase.Core.Features.Accounts.Commands.Create;
using Fimple.FinalCase.Core.Features.Accounts.Commands.Delete;
using Fimple.FinalCase.Core.Features.Accounts.Commands.Update;
using Fimple.FinalCase.Core.Features.Accounts.Commands.UpdateBalance;
using Fimple.FinalCase.Core.Features.Accounts.Queries.GetBalanceInformation;
using Fimple.FinalCase.Core.Features.Accounts.Queries.GetById;
using Fimple.FinalCase.Core.Features.Accounts.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace Fimple.FinalCase.Adapter.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountCommand createAccountCommand)
    {
        CreatedAccountResponse response = await Mediator.Send(createAccountCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountCommand updateAccountCommand)
    {
        UpdatedAccountResponse response = await Mediator.Send(updateAccountCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountResponse response = await Mediator.Send(new DeleteAccountCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountResponse response = await Mediator.Send(new GetByIdAccountQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetListAsync([FromQuery] GetListAccountQuery getListAccountQuery)
    {

        var response = await Mediator.Send(getListAccountQuery);
        return Ok(response);
    }
    
    [HttpGet("GetBalanceInformation")]
    public async Task<IActionResult> GetBalanceInformation([FromQuery] GetBalanceInformationQuery getBalanceInformationQuery)
    {
        GetBalanceInformationResponse response = await Mediator.Send(getBalanceInformationQuery);
        return Ok(response);
    }

    [HttpPut("UpdateBalance")]
    public async Task<IActionResult> UpdateBalance([FromBody] UpdateBalanceCommand updateAccountCommand)
    {

        UpdateBalanceResponse response = await Mediator.Send(updateAccountCommand);

        return Ok(response);
    }
}
