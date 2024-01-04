using System.ComponentModel.DataAnnotations.Schema;
using Fimple.FinalCase.Core.Entities.Common;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Enums;

namespace Fimple.FinalCase.Core.Entities;

public class AutomaticPayment : BaseAuditableEntity<int>
{
    [ForeignKey(nameof(Identity.User))]
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public AutomaticPaymentStatus Status { get; set; }
    
    public virtual User User { get; set; }
}