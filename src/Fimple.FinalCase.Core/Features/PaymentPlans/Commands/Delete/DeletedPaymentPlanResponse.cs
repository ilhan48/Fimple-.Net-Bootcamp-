using Fimple.FinalCase.Core.Utilities.Responses;
namespace Fimple.FinalCase.Core.Features.PaymentPlans.Commands.Delete;

public class DeletedPaymentPlanResponse : IResponse
{
    public int Id { get; set; }
}