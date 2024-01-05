using System.ComponentModel.DataAnnotations.Schema;
using Fimple.FinalCase.Core.Entities.Common;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Enums;

namespace Fimple.FinalCase.Core.Entities;

public class SupportTicket : BaseAuditableEntity<int>
{
    [ForeignKey(nameof(AskingUser))]
    public int AskingId { get; set; }
    [ForeignKey(nameof(AnsweringUser))]
    public int AnsweringId { get; set; }
    public string Issue { get; set; }
    public string Answer { get; set; }
    public SupportTicketStatus Status { get; set; }
    
    public virtual User AskingUser { get; set; }
    public virtual User AnsweringUser { get; set; }
}