using Fimple.FinalCase.Core.Features.Accounts.Commands.Create;
using Fimple.FinalCase.Core.Features.Accounts.Commands.UpdateBalance;
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
    
    [HttpPut("/update-balance")]
    public async Task<IActionResult> UpdateBalance([FromBody] UpdateBalanceCommand updateBalanceCommand)
    {
        UpdatedBalanceResponse response = await Mediator.Send(updateBalanceCommand);
    
        return Ok(response);
    }
    
}