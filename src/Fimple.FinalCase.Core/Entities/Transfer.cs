using System.ComponentModel.DataAnnotations.Schema;
using Fimple.FinalCase.Core.Entities.Common;
using Fimple.FinalCase.Core.Enums;

namespace Fimple.FinalCase.Core.Entities;

public class Transfer : BaseAuditableEntity<int>
{

    [ForeignKey(nameof(SenderAccount))]
    public int SenderAccountId { get; set; }
    [ForeignKey(nameof(ReceiverAccount))]
    public int ReceiverAccountId { get; set; }

    public decimal Amount { get; set; }
    public TransferStatus Status { get; set; }
    public short Max { get; set; }

    public virtual Account SenderAccount { get; set; }
    public virtual Account ReceiverAccount { get; set; }
}