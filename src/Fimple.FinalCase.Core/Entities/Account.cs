using System.ComponentModel.DataAnnotations.Schema;
using Fimple.FinalCase.Core.Entities.Common;
using Fimple.FinalCase.Core.Entities.Identity;

namespace Fimple.FinalCase.Core.Entities;

public class Account : BaseAuditableEntity<int>
{
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public decimal Balance { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<Process> Processes { get; set; }
    public virtual ICollection<Transfer> Transfers { get; set; }
}