using System.ComponentModel.DataAnnotations.Schema;
using Fimple.FinalCase.Core.Entities.Common;
using Fimple.FinalCase.Core.Enums;

namespace Fimple.FinalCase.Core.Entities;

public class Process : BaseAuditableEntity<int>
{
    [ForeignKey(nameof(Entities.Account))]
    public int AccountId { get; set; }
    public ProcessType Type { get; set; }
    

    public decimal Amount { get; set; }

    public virtual Account Account { get; set; }
}