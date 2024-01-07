using Fimple.FinalCase.Core.Features.PaymentPlans.Commands.Create;
using Fimple.FinalCase.Core.Features.PaymentPlans.Commands.Delete;
using Fimple.FinalCase.Core.Features.PaymentPlans.Commands.Update;
using Fimple.FinalCase.Core.Features.PaymentPlans.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Fimple.FinalCase.Adapter.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PaymentPlansController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePaymentPlanCommand createPaymentPlanCommand)
    {
        CreatedPaymentPlanResponse response = await Mediator.Send(createPaymentPlanCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePaymentPlanCommand updatePaymentPlanCommand)
    {
        UpdatedPaymentPlanResponse response = await Mediator.Send(updatePaymentPlanCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedPaymentPlanResponse response = await Mediator.Send(new DeletePaymentPlanCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdPaymentPlanResponse response = await Mediator.Send(new GetByIdPaymentPlanQuery { Id = id });
        return Ok(response);
    }
}