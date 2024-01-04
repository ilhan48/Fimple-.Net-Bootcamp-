using System.ComponentModel.DataAnnotations.Schema;
using Fimple.FinalCase.Core.Entities.Common;
using Fimple.FinalCase.Core.Enums;

namespace Fimple.FinalCase.Core.Entities.Identity;

public class PaymentPlan : BaseAuditableEntity<int>
{
    [ForeignKey(nameof(CreditApplication))]
    public int CreditApplicationId { get; set; }
    public decimal InstallmentAmount { get; set; }
    public short NumberOfInstallment { get; set; }
    public short RemainingInstallment { get; set; }
    public DateTime DueDate { get; set; }
    public PaymentStatus Status { get; set; }
    public virtual CreditApplication CreditApplication { get; set; }
}