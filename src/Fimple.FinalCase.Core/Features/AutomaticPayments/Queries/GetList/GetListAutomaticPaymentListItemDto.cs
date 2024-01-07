using Fimple.FinalCase.Core.Enums;

namespace Fimple.FinalCase.Core.Features.AutomaticPayments.Queries.GetList;

public class GetListAutomaticPaymentListItemDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public AutomaticPaymentStatus Status { get; set; }
}