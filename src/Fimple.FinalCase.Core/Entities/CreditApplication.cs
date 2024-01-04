using System.ComponentModel.DataAnnotations.Schema;
using Fimple.FinalCase.Core.Entities.Common;
using Fimple.FinalCase.Core.Enums;

namespace Fimple.FinalCase.Core.Entities.Identity;

public class CreditApplication : BaseAuditableEntity<int>
{
    [ForeignKey(nameof(User))]
    public int ApplicantId { get; set; }
    public decimal RequestedAmount { get; set; }
    public CreditApplicationStatus Status { get; set; }
    
    public virtual User User { get; set; }
    public virtual ICollection<PaymentPlan> PaymentPlans { get; set; }
}