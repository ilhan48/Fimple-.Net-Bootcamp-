using Fimple.FinalCase.Core.Utilities.Responses;
namespace Fimple.FinalCase.Core.Features.PaymentPlans.Commands.Create;

public class CreatedPaymentPlanResponse : IResponse
{
    public int Id { get; set; }
    public int CreditApplicationId { get; set; }
    public decimal InstallmentAmount { get; set; }
    public short NumberOfInstallment { get; set; }
    public short RemainingInstallment { get; set; }
    public DateTime DueDate { get; set; }
}