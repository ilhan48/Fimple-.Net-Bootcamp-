using Fimple.FinalCase.Core.Enums;

namespace Fimple.FinalCase.Core.Features.CreditApplications.Queries.GetList;

public class GetListCreditApplicationListItemDto
{ 
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public decimal RequestedAmount { get; set; }
    public CreditApplicationStatus Status { get; set; }
}