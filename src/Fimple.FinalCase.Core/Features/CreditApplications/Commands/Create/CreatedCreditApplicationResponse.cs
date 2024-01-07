using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Utilities.Responses;

namespace Fimple.FinalCase.Core.Features.CreditApplications.Commands.Create;

public class CreatedCreditApplicationResponse : IResponse
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public decimal RequestedAmount { get; set; }
    public CreditApplicationStatus Status { get; set; }
}