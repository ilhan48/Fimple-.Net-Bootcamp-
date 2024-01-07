using Fimple.FinalCase.Core.Enums;

namespace Fimple.FinalCase.Core.Features.PaymentPlans.Queries.GetList;

public class GetListPaymentPlanListItemDto
{
    public int Id { get; set; }
    public int CreditApplicationId { get; set; }
    public decimal InstallmentAmount { get; set; }
    public short NumberOfInstallment { get; set; }
    public short RemainingInstallment { get; set; }
    public DateTime DueDate { get; set; }
    public PaymentStatus Status { get; set; }
}